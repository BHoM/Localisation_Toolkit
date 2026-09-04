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
using System.ComponentModel;
using System.Globalization;

using UN = UnitsNet; //This is to avoid clashes between UnitsNet quantity attributes and BHoM quantity attributes

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

        [Description("The engineer-facing symbol for a unit, e.g. LengthUnit.Millimeter -> \"mm\" and " +
            "AreaMomentOfInertiaUnit.CentimeterToTheFourth -> \"cm⁴\.")]
        [Input("unit", "A member of one of the unit enums, e.g. LengthUnit.Millimeter.")]
        [Output("symbol", "The unit's display symbol, or an empty string for a unit with no symbol.")]
        public static string UnitSymbol(this Enum unit)
        {
            if (unit == null)
            {
                Compute.RecordError("A unit symbol can only be taken from a unit enum member.");
                return "";
            }

            switch (unit.GetType().Name)
            {
                case nameof(LengthUnit):                        return Symbol(unit, Convert.ToLengthUnit(unit));
                case nameof(AreaUnit):                          return Symbol(unit, Convert.ToAreaUnit(unit));
                case nameof(VolumeUnit):                        return Symbol(unit, Convert.ToVolumeUnit(unit));
                case nameof(AreaMomentOfInertiaUnit):           return Symbol(unit, Convert.ToAreaMomentOfInertiaUnit(unit));
                case nameof(WarpingMomentOfInertiaUnit):        return Symbol(unit, Convert.ToWarpingMomentOfInertiaUnit(unit));
                case nameof(PressureUnit):                      return Symbol(unit, Convert.ToPressureUnit(unit));
                case nameof(ForceUnit):                         return Symbol(unit, Convert.ToForceUnit(unit));
                case nameof(TorqueUnit):                        return Symbol(unit, Convert.ToTorqueUnit(unit));
                case nameof(ForcePerLengthUnit):                return Symbol(unit, Convert.ToForcePerLengthUnit(unit));
                case nameof(TorquePerLengthUnit):               return Symbol(unit, Convert.ToTorquePerLengthUnit(unit));
                case nameof(MassUnit):                          return Symbol(unit, Convert.ToMassUnit(unit));
                case nameof(AngleUnit):                         return Symbol(unit, Convert.ToAngleUnit(unit));
                case nameof(AccelerationUnit):                  return Symbol(unit, Convert.ToAccelerationUnit(unit));
                case nameof(DensityUnit):                       return Symbol(unit, Convert.ToDensityUnit(unit));
                case nameof(EnergyUnit):                        return Symbol(unit, Convert.ToEnergyUnit(unit));
                case nameof(SpeedUnit):                         return Symbol(unit, Convert.ToSpeedUnit(unit));
                case nameof(DurationUnit):                      return Symbol(unit, Convert.ToDurationUnit(unit));
                case nameof(TemperatureUnit):                   return Symbol(unit, Convert.ToTemperatureUnit(unit));
                case nameof(TemperatureDeltaUnit):              return Symbol(unit, Convert.ToTemperatureDeltaUnit(unit));
                case nameof(CoefficientOfThermalExpansionUnit): return Symbol(unit, Convert.ToCoefficientOfThermalExpansionUnit(unit));
                case nameof(ElectricConductivityUnit):          return Symbol(unit, Convert.ToElectricConductivityUnit(unit));
                case nameof(MassFractionUnit):                  return Symbol(unit, Convert.ToMassFractionUnit(unit));
                case nameof(MolalityUnit):                      return Symbol(unit, Convert.ToMolalityUnit(unit));

                default:
                    Compute.RecordError($"BH.Engine.Units has no symbol for a {unit.GetType().Name}.");
                    return "";
            }
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        // The bridge to UnitsNet is Convert's per-quantity mapper, the same one the conversions go through,
        // so a symbol and a conversion can never disagree about which UnitsNet unit a BHoM unit is. It cannot
        // be a cast - the integer values disagree for LengthUnit, AngleUnit, PressureUnit and others, so a
        // cast would hand back a different unit (Radian -> Revolution) - and it cannot be by name either:
        // BH.oM.Units spells SiemensPerMetre where UnitsNet spells SiemensPerMeter.
        private static string Symbol<T>(Enum unit, T? netUnit) where T : struct, Enum
        {
            if (netUnit == null)
            {
                // BH.oM.Units's own Undefined, and anything BHoM has added that UnitsNet has no unit for.
                Compute.RecordError($"BH.Engine.Units cannot map {unit.GetType().Name}.{unit} to a " +
                    "UnitsNet unit, so it has no symbol.");
                return "";
            }

            string symbol = UN.UnitsNetSetup.Default.UnitAbbreviations
                .GetDefaultAbbreviation<T>(netUnit.Value, CultureInfo.CurrentCulture);

            if (string.IsNullOrEmpty(symbol))
            {
                // UnitsNet knows the unit but has registered no abbreviation for it. At 5.55.0 that is
                // VolumeUnit.MetricCup and the six other spoon-and-cup units, and nothing else.
                Compute.RecordError($"UnitsNet publishes no symbol for {unit.GetType().Name}.{unit}.");
                return "";
            }

            return symbol;
        }

        /***************************************************/
    }
}
