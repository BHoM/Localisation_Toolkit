/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
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

        [Description("Convert a duration into SI units (seconds).")]
        [Input("duration", "The quantity to convert.")]
        [Input("unit", "The unit in which the quantity is defined. This can be a string, or you can use the BHoM Enum DurationUnit.")]
        [Output("second", "The equivalent number of seconds.")]
        public static double FromDuration(this double duration, object unit)
        {
            if (Double.IsNaN(duration) || Double.IsInfinity(duration))
            {
                Compute.RecordError("Quantity is not a real number.");
                return double.NaN;
            }

            UN.QuantityValue qv = duration;
            UNU.DurationUnit unitSI = UNU.DurationUnit.Second;
            UNU.DurationUnit unUnit = ToDurationUnit(unit);
            if (unUnit != UNU.DurationUnit.Undefined)
                return UN.UnitConverter.Convert(qv, unUnit, unitSI);
            Compute.RecordError("Unit was undefined. Please use the appropriate BHoM Units Enum.");
            return double.NaN;
        }

        /***************************************************/

        [Description("Convert SI units (seconds) into another duration unit.")]
        [Input("second", "The number of seconds to convert.")]
        [Input("unit", "The unit to convert to. This can be a string, or you can use the BHoM Enum DurationUnit.")]
        [Output("duration", "The equivalent quantity defined in the specified unit.")]
        public static double ToDuration(this double second, object unit)
        {
            if (Double.IsNaN(second) || Double.IsInfinity(second))
            {
                Compute.RecordError("Quantity is not a real number.");
                return double.NaN;
            }

            UN.QuantityValue qv = second;
            UNU.DurationUnit unitSI = UNU.DurationUnit.Second;
            UNU.DurationUnit unUnit = ToDurationUnit(unit);
            if (unUnit != UNU.DurationUnit.Undefined)
                return UN.UnitConverter.Convert(qv, unitSI, unUnit);
            Compute.RecordError("Unit was undefined. Please use the appropriate BHoM Units Enum.");
            return double.NaN;
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        private static UNU.DurationUnit ToDurationUnit(object unit)
        {
            if (unit == null || unit.ToString() == null)
                return UNU.DurationUnit.Undefined;
            if (unit.GetType() == typeof(string))
            {
                DurationUnit unitEnum;
                if (Enum.TryParse<DurationUnit>(unit.ToString(), out unitEnum))
                    unit = unitEnum;
                else
                    unit = unit.ToString().ToLower();
            }

            switch (unit)
            {
                case DurationUnit.Millisecond:
                    return UNU.DurationUnit.Millisecond;
                case DurationUnit.Second:
                    return UNU.DurationUnit.Second;
                case DurationUnit.Minute:
                    return UNU.DurationUnit.Minute;
                case DurationUnit.Hour:
                    return UNU.DurationUnit.Hour;
                case DurationUnit.Undefined:
                default:
                    return UNU.DurationUnit.Undefined;
            }
        }
    }
}