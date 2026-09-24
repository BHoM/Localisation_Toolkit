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
            // No unit is how a dimensionless quantity arrives - a Ratio or a Strain. Nothing to convert,
            // so the value passes straight through.
            if (unit == null)
            {
                Compute.RecordError($"BH.Engine.Units has no conversion for a null unit.");
                return siValue;
            }

            switch (unit.GetType().Name)
            {
                case nameof(LengthUnit):                        return siValue.ToLength(unit);
                case nameof(AreaUnit):                          return siValue.ToArea(unit);
                case nameof(VolumeUnit):                        return siValue.ToVolume(unit);
                case nameof(AreaMomentOfInertiaUnit):           return siValue.ToAreaMomentOfInertia(unit);
                case nameof(PressureUnit):                      return siValue.ToPressure(unit);
                case nameof(ForceUnit):                         return siValue.ToForce(unit);
                case nameof(TorqueUnit):                        return siValue.ToTorque(unit);
                case nameof(ForcePerLengthUnit):                return siValue.ToForcePerLength(unit);
                case nameof(TorquePerLengthUnit):               return siValue.ToMomentPerLength(unit);
                case nameof(MassUnit):                          return siValue.ToMass(unit);
                case nameof(AngleUnit):                         return siValue.ToAngle(unit);
                case nameof(AccelerationUnit):                  return siValue.ToAcceleration(unit);
                case nameof(DensityUnit):                       return siValue.ToDensity(unit);
                case nameof(EnergyUnit):                        return siValue.ToEnergy(unit);
                case nameof(SpeedUnit):                         return siValue.ToSpeed(unit);
                case nameof(DurationUnit):                      return siValue.ToDuration(unit);
                case nameof(TemperatureUnit):                   return siValue.ToTemperature(unit);
                case nameof(TemperatureDeltaUnit):              return siValue.ToTemperatureDelta(unit);
                case nameof(CoefficientOfThermalExpansionUnit): return siValue.ToCoefficientOfThermalExpansion(unit);
                case nameof(ElectricConductivityUnit):          return siValue.ToElectricConductivity(unit);
                case nameof(MassFractionUnit):                  return siValue.ToMassFraction(unit);
                case nameof(MolalityUnit):                      return siValue.ToMolality(unit);
                case nameof(WarpingMomentOfInertiaUnit):        return siValue.ToWarpingMomentOfInertia(unit);

                default:
                    Compute.RecordError($"BH.Engine.Units has no conversion for a {unit.GetType().Name}.");
                    return double.NaN;
            }
        }

        /***************************************************/
    }
}
