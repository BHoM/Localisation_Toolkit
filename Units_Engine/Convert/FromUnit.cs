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

namespace BH.Engine.Units
{
    public static partial class Convert
    {
        [Description("Converts a value from the given unit symbol to SI, e.g. 12 \"mm\" → 0.012 m.")]
        [Input("value", "The value in the specified unit.")]
        [Input("unitSymbol", "Unit symbol (e.g. \"mm\", \"kN\", \"MPa\"). Case-sensitive.")]
        [Output("siValue", "The value in SI units, or NaN if the unit is unrecognised.")]
        public static double FromUnit(this double value, string unitSymbol)
        {
            UnitSpec spec = Query.ResolveUnit(unitSymbol);
            if (spec == null)
                return double.NaN;

            return FromUnit(value, spec);
        }

        private static double FromUnit(double value, UnitSpec spec)
        {
            switch (spec.Family)
            {
                case QuantityFamily.Length:                 return value.FromLength(spec.Unit);
                case QuantityFamily.Area:                   return value.FromArea(spec.Unit);
                case QuantityFamily.Volume:                 return value.FromVolume(spec.Unit);
                case QuantityFamily.AreaMomentOfInertia:    return value.FromAreaMomentOfInertia(spec.Unit);
                case QuantityFamily.Pressure:               return value.FromPressure(spec.Unit);
                case QuantityFamily.Force:                  return value.FromForce(spec.Unit);
                case QuantityFamily.Torque:                 return value.FromTorque(spec.Unit);
                case QuantityFamily.ForcePerLength:         return value.FromForcePerLength(spec.Unit);
                case QuantityFamily.Angle:                  return value.FromAngle(spec.Unit);
                case QuantityFamily.Mass:                   return value.FromMass(spec.Unit);
                case QuantityFamily.Acceleration:           return value.FromAcceleration(spec.Unit);
                case QuantityFamily.Density:                return value.FromDensity(spec.Unit);
                case QuantityFamily.Energy:                 return value.FromEnergy(spec.Unit);
                case QuantityFamily.Speed:                  return value.FromSpeed(spec.Unit);
                case QuantityFamily.Temperature:            return value.FromTemperature(spec.Unit);
                case QuantityFamily.Time:                   return value.FromDuration(spec.Unit);
                case QuantityFamily.None:                   return value;
                default: return double.NaN;
            }
        }
    }
}
