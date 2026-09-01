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

using BH.oM.Base.Attributes;
using BH.oM.Units;
using BH.Engine.Base;

namespace BH.Engine.Units
{
    public static partial class Convert
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        [Description("Converts an SI value to the given unit, e.g. 0.012 m → 12 LengthUnit.Millimeter. " +
            "The inverse of FromUnit.")]
        [Input("siValue", "The value in SI units.")]
        [Input("unit", "The unit to convert to, as a member of one of the BH.oM.Units unit enums, e.g. " +
            "LengthUnit.Millimeter. A UnitsNet unit is read as well, but records a warning.")]
        [Output("value", "The value in the given unit, or NaN when the unit has no conversion.")]
        public static double ToUnit(this double siValue, Enum unit)
        {
            Enum bhomUnit = BHoMUnit(unit);
            if (bhomUnit == null)
                return double.NaN;

            // See FromUnit: the unit's type names its quantity, so the type is the whole of the dispatch.
            switch (bhomUnit.GetType().Name)
            {
                case nameof(LengthUnit):                        return siValue.ToLength(bhomUnit);
                case nameof(AreaUnit):                          return siValue.ToArea(bhomUnit);
                case nameof(VolumeUnit):                        return siValue.ToVolume(bhomUnit);
                case nameof(AreaMomentOfInertiaUnit):           return siValue.ToAreaMomentOfInertia(bhomUnit);
                case nameof(PressureUnit):                      return siValue.ToPressure(bhomUnit);
                case nameof(ForceUnit):                         return siValue.ToForce(bhomUnit);
                case nameof(TorqueUnit):                        return siValue.ToTorque(bhomUnit);
                case nameof(ForcePerLengthUnit):                return siValue.ToForcePerLength(bhomUnit);
                case nameof(TorquePerLengthUnit):               return siValue.ToMomentPerLength(bhomUnit);
                case nameof(MassUnit):                          return siValue.ToMass(bhomUnit);
                case nameof(AngleUnit):                         return siValue.ToAngle(bhomUnit);
                case nameof(AccelerationUnit):                  return siValue.ToAcceleration(bhomUnit);
                case nameof(DensityUnit):                       return siValue.ToDensity(bhomUnit);
                case nameof(EnergyUnit):                        return siValue.ToEnergy(bhomUnit);
                case nameof(SpeedUnit):                         return siValue.ToSpeed(bhomUnit);
                case nameof(DurationUnit):                      return siValue.ToDuration(bhomUnit);
                case nameof(TemperatureUnit):                   return siValue.ToTemperature(bhomUnit);
                case nameof(TemperatureDeltaUnit):              return siValue.ToTemperatureDelta(bhomUnit);
                case nameof(CoefficientOfThermalExpansionUnit): return siValue.ToCoefficientOfThermalExpansion(bhomUnit);
                case nameof(ElectricConductivityUnit):          return siValue.ToElectricConductivity(bhomUnit);
                case nameof(MassFractionUnit):                  return siValue.ToMassFraction(bhomUnit);
                case nameof(MolalityUnit):                      return siValue.ToMolality(bhomUnit);

                default:
                    Compute.RecordError($"BH.Engine.Units has no conversion for a {bhomUnit.GetType().Name}.");
                    return double.NaN;
            }
        }

        /***************************************************/

        [Description("Converts an SI value to the given unit symbol, e.g. 0.012 m → 12 \"mm\".")]
        [Input("siValue", "The value in SI units.")]
        [Input("unitSymbol", "Unit symbol to convert to (e.g. \"mm\", \"kN\", \"MPa\"). Case-sensitive. An empty symbol or \"-\" leaves the value unchanged.")]
        [Output("value", "The value in the specified unit, or NaN if the unit is unrecognised.")]
        public static double ToUnit(this double siValue, string unitSymbol)
        {
            UnitSpec spec = Query.ResolveUnit(unitSymbol);
            if (spec == null)
                return double.NaN;

            // FromUnit multiplies by the factor to reach SI, so coming back the other way divides by it.
            if (spec.Unit == null)
                return siValue / spec.Factor;

            return ConvertUnit(siValue, spec.SIUnit, spec.Unit, unitSymbol);
        }

        /***************************************************/
    }
}
