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

namespace BH.Engine.Units
{
    public static partial class Convert
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        [Description("Convert a temperatureDelta into SI units (kelvin).")]
        [Input("temperatureDelta", "The quantity to convert.")]
        [Input("unit", "The unit in which the quantity is defined.")]
        [Output("kelvin", "The equivalent number of kelvin.")]
        public static double FromTemperatureDelta(this double temperatureDelta, object unit)
        {
            UN.QuantityValue qv = temperatureDelta;
            return UN.UnitConverter.Convert(qv, ToTemperatureDeltaUnit(unit), TemperatureDeltaUnit.Kelvin);
        }

        /***************************************************/

        [Description("Convert SI units (kelvin) into another temperatureDelta unit.")]
        [Input("kelvin", "The number of kelvin to convert.")]
        [Input("unit", "The unit to convert to.")]
        [Output("temperatureDelta", "The equivalent quantity defined in the specified unit.")]
        public static double ToTemperatureDelta(this double kelvin, object unit)
        {
            UN.QuantityValue qv = kelvin;
            return UN.UnitConverter.Convert(qv, TemperatureDeltaUnit.Kelvin, ToTemperatureDeltaUnit(unit));
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        private static UNU.TemperatureDeltaUnit ToTemperatureDeltaUnit(object unit)
        {
            if (unit.GetType() == typeof(string))
                unit = unit.ToString().ToLower();

            switch (unit)
            {
                case "c":
                case TemperatureDeltaUnit.DegreeCelsius:
                    return UNU.TemperatureDeltaUnit.DegreeCelsius;
                case TemperatureDeltaUnit.DegreeDelisle:
                    return UNU.TemperatureDeltaUnit.DegreeDelisle;
                case "f":
                case TemperatureDeltaUnit.DegreeFahrenheit:
                    return UNU.TemperatureDeltaUnit.DegreeFahrenheit;
                case TemperatureDeltaUnit.DegreeNewton:
                    return UNU.TemperatureDeltaUnit.DegreeNewton;
                case "r":
                case TemperatureDeltaUnit.DegreeRankine:
                    return UNU.TemperatureDeltaUnit.DegreeRankine;
                case TemperatureDeltaUnit.DegreeReaumur:
                    return UNU.TemperatureDeltaUnit.DegreeReaumur;
                case TemperatureDeltaUnit.DegreeRoemer:
                    return UNU.TemperatureDeltaUnit.DegreeRoemer;
                case "k":
                case TemperatureDeltaUnit.Kelvin:
                    return UNU.TemperatureDeltaUnit.Kelvin;
                case TemperatureDeltaUnit.MillidegreeCelsius:
                    return UNU.TemperatureDeltaUnit.MillidegreeCelsius;
                case TemperatureDeltaUnit.Undefined:
                default:
                    return UNU.TemperatureDeltaUnit.Undefined;
            }
        }
    }
}


