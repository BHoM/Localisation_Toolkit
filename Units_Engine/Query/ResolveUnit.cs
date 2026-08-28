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

        [Description("Resolves a unit symbol string to its corresponding UnitSpec, identifying the quantity family and unit.")]
        [Input("unitSymbol", "Unit symbol to resolve (e.g. \"mm\", \"kN\", \"MPa\"). Case-sensitive.")]
        [Output("unitSpec", "The resolved UnitSpec, or null if the unit is unrecognised.")]
        public static UnitSpec ResolveUnit(string unitSymbol)
        {
            string key = unitSymbol?.Trim() ?? "";
            if (key == "" || key == "-")
                return new UnitSpec { Family = QuantityFamily.None, Unit = null };

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

            foreach (var family in m_Families)
            {
                foreach (object unit in Enum.GetValues(family.Key))
                {
                    foreach (string symbol in GetAbbreviations(family.Key, (int)(object)unit))
                    {
                        TryAdd(table, symbol, family.Value, unit);
                        TryAdd(table, Ascii(symbol), family.Value, unit);
                    }
                }
            }

            // Torque aliases UnitsNet doesn't publish
            TryAdd(table, "Nm", QuantityFamily.Torque, UNU.TorqueUnit.NewtonMeter);
            TryAdd(table, "N.m", QuantityFamily.Torque, UNU.TorqueUnit.NewtonMeter);
            TryAdd(table, "kNm", QuantityFamily.Torque, UNU.TorqueUnit.KilonewtonMeter);
            TryAdd(table, "kN.m", QuantityFamily.Torque, UNU.TorqueUnit.KilonewtonMeter);

            return table;
        }

        /***************************************************/

        private static IEnumerable<string> GetAbbreviations(Type unitType, int unitValue)
        {
            try
            {
                return UN.UnitsNetSetup.Default.UnitAbbreviations
                    .GetUnitAbbreviations(unitType, unitValue, CultureInfo.InvariantCulture);
            }
            catch
            {
                return Array.Empty<string>();
            }
        }

        /***************************************************/

        private static void TryAdd(Dictionary<string, UnitSpec> table, string symbol,
                                   QuantityFamily family, object unit)
        {
            if (!string.IsNullOrWhiteSpace(symbol) && !table.ContainsKey(symbol))
                table[symbol] = new UnitSpec { Family = family, Unit = unit };
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

        private static readonly Dictionary<Type, QuantityFamily> m_Families = new Dictionary<Type, QuantityFamily>
        {
            { typeof(UNU.LengthUnit),              QuantityFamily.Length },
            { typeof(UNU.AreaUnit),                QuantityFamily.Area },
            { typeof(UNU.VolumeUnit),              QuantityFamily.Volume },
            { typeof(UNU.AreaMomentOfInertiaUnit), QuantityFamily.AreaMomentOfInertia },
            { typeof(UNU.PressureUnit),            QuantityFamily.Pressure },
            { typeof(UNU.ForceUnit),               QuantityFamily.Force },
            { typeof(UNU.TorqueUnit),              QuantityFamily.Torque },
            { typeof(UNU.ForcePerLengthUnit),      QuantityFamily.ForcePerLength },
            { typeof(UNU.AngleUnit),               QuantityFamily.Angle },
            { typeof(UNU.MassUnit),                QuantityFamily.Mass },
        };

        private static readonly Dictionary<string, UnitSpec> m_UnitTable = BuildUnitTable();

        /***************************************************/
    }
}