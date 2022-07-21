/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2022, the respective contributors. All rights reserved.
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UN = UnitsNet; //This is to avoid clashes between UnitsNet quantity attributes and BHoM quantity attributes
using UNU = UnitsNet.Units;

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

        [Description("Convert a temperature into SI units (celsius).")]
        [Input("temperature", "The quantity to convert.")]
        [Input("unit", "The unit in which the quantity is defined. This can be a string, or you can use the BHoM Enum TemperatureUnit.")]
        [Output("celsius", "The equivalent number of celsius.")]
        public static double FromTemperature(this double temperature, object unit)
        {
            if (Double.IsNaN(temperature) || Double.IsInfinity(temperature))
            {
                Compute.RecordError("Quantity is not a real number.");
                return double.NaN;
            }

            UN.QuantityValue qv = temperature;
            UNU.TemperatureUnit unitSI = UNU.TemperatureUnit.DegreeCelsius;
            UNU.TemperatureUnit unUnit = ToTemperatureUnit(unit);

            if (unUnit != UNU.TemperatureUnit.Undefined)
                return UN.UnitConverter.Convert(qv, unUnit, unitSI);

            Compute.RecordError("Unit was undefined. Please use the appropriate BHoM Units Enum.");
            return double.NaN;
            return UN.UnitConverter.Convert(qv, ToTemperatureUnit(unit), UNU.TemperatureUnit.DegreeCelsius);
        }

        /***************************************************/

        [Description("Convert SI units (celsius) into another temperature unit.")]
        [Input("celsius", "The number of celsius to convert.")]
        [Input("unit", "The unit to convert to. This can be a string, or you can use the BHoM Enum TemperatureUnit.")]
        [Output("temperature", "The equivalent quantity defined in the specified unit.")]
        public static double ToTemperature(this double celsius, object unit)
        {
            if (Double.IsNaN(celsius) || Double.IsInfinity(celsius))
            {
                Compute.RecordError("Quantity is not a real number.");
                return double.NaN;
            }

            UN.QuantityValue qv = celsius;
            UNU.TemperatureUnit unitSI = UNU.TemperatureUnit.DegreeCelsius;
            UNU.TemperatureUnit unUnit = ToTemperatureUnit(unit);

            if (unUnit != UNU.TemperatureUnit.Undefined)
                return UN.UnitConverter.Convert(qv, unitSI, unUnit);

            Compute.RecordError("Unit was undefined. Please use the appropriate BHoM Units Enum.");
            return double.NaN;
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        private static UNU.TemperatureUnit ToTemperatureUnit(object unit)
        {
            if (unit == null || unit.ToString() == null)
                return UNU.TemperatureUnit.Undefined;

            if (unit.GetType() == typeof(string))
            {
                TemperatureUnit unitEnum;
                if (Enum.TryParse<TemperatureUnit>(unit.ToString(), out unitEnum))
                    unit = unitEnum;
                else
                    unit = unit.ToString().ToLower();
            }

            switch (unit)
            {
                case "celsius":
                case "c":
                case TemperatureUnit.DegreeCelsius:
                    return UNU.TemperatureUnit.DegreeCelsius;
                case TemperatureUnit.DegreeDelisle:
                    return UNU.TemperatureUnit.DegreeDelisle;
                case "fahrenheit":
                case "f":
                case TemperatureUnit.DegreeFahrenheit:
                    return UNU.TemperatureUnit.DegreeFahrenheit;
                case TemperatureUnit.DegreeNewton:
                    return UNU.TemperatureUnit.DegreeNewton;
                case "rankine":
                case "r":
                case TemperatureUnit.DegreeRankine:
                    return UNU.TemperatureUnit.DegreeRankine;
                case TemperatureUnit.DegreeReaumur:
                    return UNU.TemperatureUnit.DegreeReaumur;
                case TemperatureUnit.DegreeRoemer:
                    return UNU.TemperatureUnit.DegreeRoemer;
                case "kelvin":
                case "k":
                case TemperatureUnit.Kelvin:
                    return UNU.TemperatureUnit.Kelvin;
                case TemperatureUnit.MillidegreeCelsius:
                    return UNU.TemperatureUnit.MillidegreeCelsius;
                case TemperatureUnit.SolarTemperature:
                    return UNU.TemperatureUnit.SolarTemperature;
                case TemperatureUnit.Undefined:
                default:
                    return UNU.TemperatureUnit.Undefined;
            }
        }
    }
}


