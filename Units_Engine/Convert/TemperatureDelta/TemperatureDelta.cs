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

        [Description("Convert a temperatureDelta into SI units (kelvin).")]
        [Input("temperatureDelta", "The quantity to convert.")]
        [Input("unit", "The unit in which the quantity is defined. This can be a string, or you can use the BHoM Enum TemperatureDeltaUnit.")]
        [Output("kelvin", "The equivalent number of kelvin.")]
        public static double FromTemperatureDelta(this double temperatureDelta, object unit)
        {
            if (Double.IsNaN(temperatureDelta) || Double.IsInfinity(temperatureDelta))
            {
                Compute.RecordError("Quantity is not a real number.");
                return double.NaN;
            }

            UN.QuantityValue qv = temperatureDelta;
            UNU.TemperatureDeltaUnit unitSI = UNU.TemperatureDeltaUnit.Kelvin;
            UNU.TemperatureDeltaUnit? unUnit = ToTemperatureDeltaUnit(unit);

            if (unUnit != null)
                return UN.UnitConverter.Convert(qv, unUnit, unitSI);

            Compute.RecordError("Unit was undefined. Please use the appropriate BHoM Units Enum.");
            return double.NaN;
        }

        /***************************************************/

        [Description("Convert SI units (kelvin) into another temperatureDelta unit.")]
        [Input("kelvin", "The number of kelvin to convert.")]
        [Input("unit", "The unit to convert to. This can be a string, or you can use the BHoM Enum TemperatureDeltaUnit.")]
        [Output("temperatureDelta", "The equivalent quantity defined in the specified unit.")]
        public static double ToTemperatureDelta(this double kelvin, object unit)
        {
            if (Double.IsNaN(kelvin) || Double.IsInfinity(kelvin))
            {
                Compute.RecordError("Quantity is not a real number.");
                return double.NaN;
            }

            UN.QuantityValue qv = kelvin;
            UNU.TemperatureDeltaUnit unitSI = UNU.TemperatureDeltaUnit.Kelvin;
            UNU.TemperatureDeltaUnit? unUnit = ToTemperatureDeltaUnit(unit);

            if (unUnit != null)
                return UN.UnitConverter.Convert(qv, unitSI, unUnit);

            Compute.RecordError("Unit was undefined. Please use the appropriate BHoM Units Enum.");
            return double.NaN;
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        private static UNU.TemperatureDeltaUnit? ToTemperatureDeltaUnit(object unit)
        {
            if (unit == null || unit.ToString() == null)
                return null;

            if (unit.GetType() == typeof(string))
            {
                TemperatureDeltaUnit unitEnum;
                if (Enum.TryParse<TemperatureDeltaUnit>(unit.ToString(), out unitEnum))
                    unit = unitEnum;
                else
                    unit = unit.ToString().ToLower();
            }

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
                default:
                    return null;
            }
        }
    }
}






