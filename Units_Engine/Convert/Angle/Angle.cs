/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2024, the respective contributors. All rights reserved.
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

        [Description("Convert a angle into SI units (radian).")]
        [Input("angle", "The quantity to convert.")]
        [Input("unit", "The unit in which the quantity is defined. This can be a string, or you can use the BHoM Enum AngleUnit.")]
        [Output("radian", "The equivalent number of radian.")]
        public static double FromAngle(this double angle, object unit)
        {
            if (Double.IsNaN(angle) || Double.IsInfinity(angle))
            {
                Compute.RecordError("Quantity is not a real number.");
                return double.NaN;
            }

            UN.QuantityValue qv = angle;
            UNU.AngleUnit unitSI = UNU.AngleUnit.Radian;
            UNU.AngleUnit unUnit = ToAngleUnit(unit);

            if (unUnit != UNU.AngleUnit.Undefined)
                return UN.UnitConverter.Convert(qv, unUnit, unitSI);

            Compute.RecordError("Unit was undefined. Please use the appropriate BHoM Units Enum.");
            return double.NaN;
        }

        /***************************************************/

        [Description("Convert SI units (radian) into another angle unit.")]
        [Input("radian", "The number of radian to convert.")]
        [Input("unit", "The unit to convert to. This can be a string, or you can use the BHoM Enum AngleUnit.")]
        [Output("angle", "The equivalent quantity defined in the specified unit.")]
        public static double ToAngle(this double radian, object unit)
        {
            if (Double.IsNaN(radian) || Double.IsInfinity(radian))
            {
                Compute.RecordError("Quantity is not a real number.");
                return double.NaN;
            }

            UN.QuantityValue qv = radian;
            UNU.AngleUnit unitSI = UNU.AngleUnit.Radian;
            UNU.AngleUnit unUnit = ToAngleUnit(unit);

            if (unUnit != UNU.AngleUnit.Undefined)
                return UN.UnitConverter.Convert(qv, unitSI, unUnit);

            Compute.RecordError("Unit was undefined. Please use the appropriate BHoM Units Enum.");
            return double.NaN;
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        private static UNU.AngleUnit ToAngleUnit(object unit)
        {
            if (unit == null || unit.ToString() == null)
                return UNU.AngleUnit.Undefined;

            if (unit.GetType() == typeof(string))
            {
                AngleUnit unitEnum;
                if (Enum.TryParse<AngleUnit>(unit.ToString(), out unitEnum))
                    unit = unitEnum;
                else
                    unit = unit.ToString().ToLower();
            }

            switch (unit)
            {
                case AngleUnit.Arcminute:
                    return UNU.AngleUnit.Arcminute;
                case AngleUnit.Arcsecond:
                    return UNU.AngleUnit.Arcsecond;
                case AngleUnit.Centiradian:
                    return UNU.AngleUnit.Centiradian;
                case AngleUnit.Deciradian:
                    return UNU.AngleUnit.Deciradian;
                case "degree":
                case "degrees":
                case "deg":
                case AngleUnit.Degree:
                    return UNU.AngleUnit.Degree;
                case AngleUnit.Gradian:
                    return UNU.AngleUnit.Gradian;
                case AngleUnit.Microdegree:
                    return UNU.AngleUnit.Microdegree;
                case AngleUnit.Microradian:
                    return UNU.AngleUnit.Microradian;
                case AngleUnit.Millidegree:
                    return UNU.AngleUnit.Millidegree;
                case AngleUnit.Milliradian:
                    return UNU.AngleUnit.Milliradian;
                case AngleUnit.Nanodegree:
                    return UNU.AngleUnit.Nanodegree;
                case AngleUnit.Nanoradian:
                    return UNU.AngleUnit.Nanoradian;
                case "radian":
                case "radians":
                case "rad":
                case AngleUnit.Radian:
                    return UNU.AngleUnit.Radian;
                case "revolutions":
                case "revs":
                case "rev":
                case AngleUnit.Revolution:
                    return UNU.AngleUnit.Revolution;
                case AngleUnit.Undefined:
                default:
                    return UNU.AngleUnit.Undefined;
            }
        }
    }
}




