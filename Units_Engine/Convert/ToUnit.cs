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
                return siValue;

            Enum bhomUnit = BHoMUnit(unit);
            if (bhomUnit == null)
                return double.NaN;

            // The unit's type names its quantity, so the type is the whole of the dispatch. This is why the
            // unit travels as an enum and not as a symbol: a symbol two quantities both publish - "t" for
            // both a tonne and a teaspoon - would have to be guessed at, where a type cannot be mistaken.
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
                case nameof(WarpingMomentOfInertiaUnit):        return siValue.ToWarpingMomentOfInertia(bhomUnit);

                default:
                    Compute.RecordError($"BH.Engine.Units has no conversion for a {bhomUnit.GetType().Name}.");
                    return double.NaN;
            }
        }

        /***************************************************/
    }
}
