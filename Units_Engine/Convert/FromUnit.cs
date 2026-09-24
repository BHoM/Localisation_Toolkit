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

        [Description("Converts a value from the given unit to SI, e.g. 12 LengthUnit.Millimeter → 0.012 m. " +
            "The inverse of ToUnit.")]
        [Input("value", "The value in the given unit.")]
        [Input("unit", "The unit the value is in, as a member of one of the BH.oM.Units unit enums, e.g. " +
            "LengthUnit.Millimeter.")]
        [Output("siValue", "The value in SI units, or NaN when the unit has no conversion.")]
        public static double FromUnit(this double value, Enum unit)
        {
            // No unit is how a dimensionless quantity arrives - a Ratio or a Strain. Nothing to convert,
            // so the value passes straight through.
            if (unit == null)
            {
                Compute.RecordError($"BH.Engine.Units has no conversion for a null unit.");
                return value;
            }

            // The unit's type names its quantity, so the type is the whole of the dispatch. This is why the
            // unit travels as an enum and not as a symbol: a symbol two quantities both publish - "t" for
            // both a tonne and a teaspoon - would have to be guessed at, where a type cannot be mistaken.
            switch (unit.GetType().Name)
            {
                case nameof(LengthUnit):                        return value.FromLength(unit);
                case nameof(AreaUnit):                          return value.FromArea(unit);
                case nameof(VolumeUnit):                        return value.FromVolume(unit);
                case nameof(AreaMomentOfInertiaUnit):           return value.FromAreaMomentOfInertia(unit);
                case nameof(PressureUnit):                      return value.FromPressure(unit);
                case nameof(ForceUnit):                         return value.FromForce(unit);
                case nameof(TorqueUnit):                        return value.FromTorque(unit);
                case nameof(ForcePerLengthUnit):                return value.FromForcePerLength(unit);
                case nameof(TorquePerLengthUnit):               return value.FromMomentPerLength(unit);
                case nameof(MassUnit):                          return value.FromMass(unit);
                case nameof(AngleUnit):                         return value.FromAngle(unit);
                case nameof(AccelerationUnit):                  return value.FromAcceleration(unit);
                case nameof(DensityUnit):                       return value.FromDensity(unit);
                case nameof(EnergyUnit):                        return value.FromEnergy(unit);
                case nameof(SpeedUnit):                         return value.FromSpeed(unit);
                case nameof(DurationUnit):                      return value.FromDuration(unit);
                case nameof(TemperatureUnit):                   return value.FromTemperature(unit);
                case nameof(TemperatureDeltaUnit):              return value.FromTemperatureDelta(unit);
                case nameof(CoefficientOfThermalExpansionUnit): return value.FromCoefficientOfThermalExpansion(unit);
                case nameof(ElectricConductivityUnit):          return value.FromElectricConductivity(unit);
                case nameof(MassFractionUnit):                  return value.FromMassFraction(unit);
                case nameof(MolalityUnit):                      return value.FromMolality(unit);
                case nameof(WarpingMomentOfInertiaUnit):        return value.FromWarpingMomentOfInertia(unit);

                default:
                    Compute.RecordError($"BH.Engine.Units has no conversion for a {unit.GetType().Name}.");
                    return double.NaN;
            }
        }
    }
}
