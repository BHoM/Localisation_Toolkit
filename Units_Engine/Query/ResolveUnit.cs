/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2026, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * The BHoM is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Lesser General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * The BHoM is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Lesser General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Lesser General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using UN = UnitsNet; //This is to avoid clashes between UnitsNet quantity attributes and BHoM quantity attributes
using UNU = UnitsNet.Units;

using System.ComponentModel;
using BH.oM.Base.Attributes;
using BH.oM.Units;
using BH.Engine.Base;

namespace BH.Engine.Units
{
    public static partial class Query
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        [Description("Resolves a unit symbol string to its corresponding UnitSpec, identifying the unit and the SI unit its quantity converts to.")]
        [Input("unitSymbol", "Unit symbol to resolve (e.g. \"mm\", \"kN\", \"MPa\"). Case-sensitive.")]
        [Output("unitSpec", "The resolved UnitSpec, or null if the unit is unrecognised.")]
        public static UnitSpec ResolveUnit(string unitSymbol)
        {
            string key = unitSymbol?.Trim() ?? "";
            if (key == "" || key == "-")
                return new UnitSpec();

            if (m_UnitTable.TryGetValue(key, out UnitSpec spec))
                return spec;

            Compute.RecordError($"Unit '{unitSymbol}' is not recognised. Unit symbols are case-sensitive.");
            return null;
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        private static Dictionary<string, UnitSpec> BuildUnitTable()
        {
            var table = new Dictionary<string, UnitSpec>(StringComparer.Ordinal);

            foreach (Enum siUnit in m_SIUnits)
            {
                UN.QuantityInfo quantityInfo = UN.Quantity.Infos.FirstOrDefault(x => x.UnitType == siUnit.GetType());
                if (quantityInfo == null)
                    continue;

                foreach (UN.UnitInfo unitInfo in quantityInfo.UnitInfos)
                {
                    foreach (string symbol in GetAbbreviations(unitInfo))
                    {
                        TryAdd(table, symbol, unitInfo, siUnit);
                        TryAdd(table, Ascii(symbol), unitInfo, siUnit);
                    }
                }
            }

            // Torque aliases UnitsNet doesn't publish
            UN.UnitInfo newtonMetre = UN.Quantity.GetUnitInfo(UNU.TorqueUnit.NewtonMeter);
            UN.UnitInfo kilonewtonMetre = UN.Quantity.GetUnitInfo(UNU.TorqueUnit.KilonewtonMeter);

            TryAdd(table, "Nm", newtonMetre, UNU.TorqueUnit.NewtonMeter);
            TryAdd(table, "N.m", newtonMetre, UNU.TorqueUnit.NewtonMeter);
            TryAdd(table, "kNm", kilonewtonMetre, UNU.TorqueUnit.NewtonMeter);
            TryAdd(table, "kN.m", kilonewtonMetre, UNU.TorqueUnit.NewtonMeter);

            // Symbols that more than one quantity claims, forced to the reading expected in a building
            // engineering context. Left to the loop above, each of these lands on a unit that is never
            // the one intended here. The remaining overlaps the loop resolves acceptably on its own:
            // "g" to gram, "mg" to milligram, "MN" to meganewton, "kt" to kilotonne, "mil" to mil,
            // "m" to metre, "'" to foot and the double prime to inch.
            Set(table, "t", UNU.MassUnit.Tonne, UNU.MassUnit.Kilogram);             // not Volume.MetricTeaspoon
            Set(table, "h", UNU.DurationUnit.Hour, UNU.DurationUnit.Second);        // not Length.Hand
            Set(table, "min", UNU.DurationUnit.Minute, UNU.DurationUnit.Second);    // not Angle.Arcminute
            Set(table, "sec", UNU.DurationUnit.Second, UNU.DurationUnit.Second);    // not Angle.Arcsecond

            return table;
        }

        /***************************************************/

        private static IEnumerable<string> GetAbbreviations(UN.UnitInfo unitInfo)
        {
            try
            {
                return UN.UnitsNetSetup.Default.UnitAbbreviations.GetAbbreviations(unitInfo, CultureInfo.InvariantCulture);
            }
            catch
            {
                return Array.Empty<string>();
            }
        }

        /***************************************************/

        // Claims a symbol for a unit, leaving any earlier claim on that symbol in place.
        private static void TryAdd(Dictionary<string, UnitSpec> table, string symbol,
                                   UN.UnitInfo unitInfo, Enum siUnit)
        {
            if (!string.IsNullOrWhiteSpace(symbol) && !table.ContainsKey(symbol))
                table[symbol] = Spec(unitInfo, siUnit);
        }

        /***************************************************/

        // Claims a symbol for a unit, overriding any earlier claim on that symbol.
        private static void Set(Dictionary<string, UnitSpec> table, string symbol, Enum unit, Enum siUnit)
        {
            table[symbol] = Spec(UN.Quantity.GetUnitInfo(unit), siUnit);
        }

        /***************************************************/

        private static UnitSpec Spec(UN.UnitInfo unitInfo, Enum siUnit)
        {
            return new UnitSpec
            {
                Unit = unitInfo.Value,
                SIUnit = siUnit,
                QuantityName = unitInfo.QuantityName
            };
        }

        /***************************************************/

        private static string Ascii(string symbol)
        {
            return symbol?
                .Replace("²", "2")
                .Replace("³", "3")
                .Replace("⁴", "4")
                .Replace("⁶", "6");
        }

        /***************************************************/
        /**** Private Fields                            ****/
        /***************************************************/

        // The quantities recognised by ResolveUnit, each represented by the SI unit it converts to and from.
        // The unit type of the quantity is taken from the entry itself, so adding a quantity is a single line.
        // These are the SI units used by the corresponding BHoM Convert methods, which is not always the UnitsNet
        // base unit - notably Temperature, where the BHoM convention is degrees Celsius rather than Kelvin.
        // Order matters: where two quantities publish the same unit symbol, the first entry to claim it wins.
        // Mass precedes Angle and Acceleration so that "g" resolves to gram rather than gradian or standard gravity.
        private static readonly Enum[] m_SIUnits = new Enum[]
        {
            UNU.LengthUnit.Meter,
            UNU.AreaUnit.SquareMeter,
            UNU.VolumeUnit.CubicMeter,
            UNU.AreaMomentOfInertiaUnit.MeterToTheFourth,
            UNU.PressureUnit.Pascal,
            UNU.ForceUnit.Newton,
            UNU.TorqueUnit.NewtonMeter,
            UNU.ForcePerLengthUnit.NewtonPerMeter,
            UNU.TorquePerLengthUnit.NewtonMeterPerMeter,
            UNU.MassUnit.Kilogram,
            UNU.AngleUnit.Radian,
            UNU.AccelerationUnit.MeterPerSecondSquared,
            UNU.DensityUnit.KilogramPerCubicMeter,
            UNU.EnergyUnit.Joule,
            UNU.SpeedUnit.MeterPerSecond,
            UNU.DurationUnit.Second,
            UNU.TemperatureUnit.DegreeCelsius,
            UNU.TemperatureDeltaUnit.Kelvin,
            UNU.CoefficientOfThermalExpansionUnit.PerKelvin,
            UNU.ElectricConductivityUnit.SiemensPerMeter,
            UNU.MassFractionUnit.KilogramPerKilogram,
            UNU.MolalityUnit.MolePerKilogram,
        };

        private static readonly Dictionary<string, UnitSpec> m_UnitTable = BuildUnitTable();

        /***************************************************/
    }
}
