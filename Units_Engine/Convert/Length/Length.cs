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

        [Description("Convert a length into SI units (metres).")]
        [Input("length", "The quantity to convert.")]
        [Input("unit", "The unit in which the quantity is defined. This can be a string, or you can use the BHoM Enum LengthUnit.")]
        [Output("metres", "The equivalent number of metres.")]
        public static double FromLength(this double length, object unit)
        {
            if (Double.IsNaN(length) || Double.IsInfinity(length))
            {
                Compute.RecordError("Quantity is not a real number.");
                return double.NaN;
            }

            UN.QuantityValue qv = length;
            UNU.LengthUnit unitSI = UNU.LengthUnit.Meter;
            UNU.LengthUnit? unUnit = ToLengthUnit(unit);

            if (unUnit != null)
                return UN.UnitConverter.Convert(qv, unUnit, unitSI);

            Compute.RecordError("Unit was undefined. Please use the appropriate BHoM Units Enum.");
            return double.NaN;
        }

        /***************************************************/

        [Description("Convert SI units (metres) into another length unit.")]
        [Input("metres", "The number of metres to convert.")]
        [Input("unit", "The unit to convert to. This can be a string, or you can use the BHoM Enum LengthUnit.")]
        [Output("length", "The equivalent quantity defined in the specified unit.")]
        public static double ToLength(this double metres, object unit)
        {
            if (Double.IsNaN(metres) || Double.IsInfinity(metres))
            {
                Compute.RecordError("Quantity is not a real number.");
                return double.NaN;
            }

            UN.QuantityValue qv = metres;
            UNU.LengthUnit unitSI = UNU.LengthUnit.Meter;
            UNU.LengthUnit? unUnit = ToLengthUnit(unit);

            if (unUnit != null)
                return UN.UnitConverter.Convert(qv, unitSI, unUnit);

            Compute.RecordError("Unit was undefined. Please use the appropriate BHoM Units Enum.");
            return double.NaN;
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        private static UNU.LengthUnit? ToLengthUnit(object unit)
        {
            if (unit == null || unit.ToString() == null)
                return null;

            if (unit.GetType() == typeof(string))
            {
                LengthUnit unitEnum;
                if (Enum.TryParse<LengthUnit>(unit.ToString(), out unitEnum))
                    unit = unitEnum;
                else
                    unit = unit.ToString().ToLower();
            }

            switch (unit)
            {
                case "cm":
                case LengthUnit.Centimeter:
                    return UNU.LengthUnit.Centimeter;
                case "chain":
                case LengthUnit.Chain:
                    return UNU.LengthUnit.Chain;
                case LengthUnit.Decimeter:
                    return UNU.LengthUnit.Decimeter;
                case LengthUnit.Fathom:
                    return UNU.LengthUnit.Fathom;
                case "foot":
                case "feet":
                case "ft":
                case LengthUnit.Foot:
                    return UNU.LengthUnit.Foot;
                case LengthUnit.Hectometer:
                    return UNU.LengthUnit.Hectometer;
                case "inch":
                case "in":
                case "inches":
                case LengthUnit.Inch:
                    return UNU.LengthUnit.Inch;
                case "km":
                case LengthUnit.Kilometer:
                    return UNU.LengthUnit.Kilometer;
                case "m":
                case LengthUnit.Meter:
                    return UNU.LengthUnit.Meter;
                case LengthUnit.Microinch:
                    return UNU.LengthUnit.Microinch;
                case LengthUnit.Micrometer:
                    return UNU.LengthUnit.Micrometer;
                case LengthUnit.Mil:
                    return UNU.LengthUnit.Mil;
                case "mi":
                case LengthUnit.Mile:
                    return UNU.LengthUnit.Mile;
                case "mm":
                case LengthUnit.Millimeter:
                    return UNU.LengthUnit.Millimeter;
                case LengthUnit.Nanometer:
                    return UNU.LengthUnit.Nanometer;
                case "yd":
                case LengthUnit.Yard:
                    return UNU.LengthUnit.Yard;
                default:
                    return null;
            }
        }
    }
}


