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

using System.ComponentModel;
using BH.oM.Base.Attributes;
using BH.oM.Units;

namespace BH.Engine.Units
{
    public static partial class Convert
    {
        [Description("Converts an SI value to the given unit symbol, e.g. 0.012 m → 12 \"mm\".")]
        [Input("siValue", "The value in SI units.")]
        [Input("unitSymbol", "Unit symbol to convert to (e.g. \"mm\", \"kN\", \"MPa\"). Case-sensitive.")]
        [Output("value", "The value in the specified unit, or NaN if the unit is unrecognised.")]
        public static double ToUnit(this double siValue, string unitSymbol)
        {
            UnitSpec spec = Query.ResolveUnit(unitSymbol);
            if (spec == null)
                return double.NaN;

            return ToUnit(siValue, spec);
        }

        private static double ToUnit(double siValue, UnitSpec spec)
        {
            switch (spec.Family)
            {
                case QuantityFamily.Length:                 return siValue.ToLength(spec.Unit);
                case QuantityFamily.Area:                   return siValue.ToArea(spec.Unit);
                case QuantityFamily.Volume:                 return siValue.ToVolume(spec.Unit);
                case QuantityFamily.AreaMomentOfInertia:    return siValue.ToAreaMomentOfInertia(spec.Unit);
                case QuantityFamily.Pressure:               return siValue.ToPressure(spec.Unit);
                case QuantityFamily.Force:                  return siValue.ToForce(spec.Unit);
                case QuantityFamily.Torque:                 return siValue.ToTorque(spec.Unit);
                case QuantityFamily.ForcePerLength:         return siValue.ToForcePerLength(spec.Unit);
                case QuantityFamily.Angle:                  return siValue.ToAngle(spec.Unit);
                case QuantityFamily.Mass:                   return siValue.ToMass(spec.Unit);
                case QuantityFamily.Acceleration:           return siValue.ToAcceleration(spec.Unit);
                case QuantityFamily.Density:                return siValue.ToDensity(spec.Unit);
                case QuantityFamily.Energy:                 return siValue.ToEnergy(spec.Unit);
                case QuantityFamily.Speed:                  return siValue.ToSpeed(spec.Unit);
                case QuantityFamily.Temperature:            return siValue.ToTemperature(spec.Unit);
                case QuantityFamily.Time:                   return siValue.ToDuration(spec.Unit);
                case QuantityFamily.None:                   return siValue;
                default: return double.NaN;
            }
        }
    }
}