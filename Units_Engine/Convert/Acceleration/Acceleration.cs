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

        [Description("Convert an acceleration into SI units (metresPerSecondSquared).")]
        [Input("acceleration", "The quantity to convert.")]
        [Input("unit", "The unit in which the quantity is defined. This can be a string, or you can use the BHoM Enum AccelerationUnit.")]
        [Output("metresPerSecondSquared", "The equivalent number of metresPerSecondSquared.")]
        public static double FromAcceleration(this double acceleration, object unit)
        {
            UN.QuantityValue qv = acceleration;
            UNU.AccelerationUnit unUnit = ToAccelerationUnit(unit);
            if (unUnit != UNU.AccelerationUnit.Undefined)

                return UN.UnitConverter.Convert(qv, unUnit, UNU.AccelerationUnit.MeterPerSecondSquared);

            Compute.RecordError("Unit was undefined. Please use the appropriate BHoM Units Enum.");
            return double.NaN;
        }

        /***************************************************/

        [Description("Convert SI units (metresPerSecondSquared) into another acceleration unit.")]
        [Input("metresPerSecondSquared", "The number of metresPerSecondSquared to convert.")]
        [Input("unit", "The unit to convert to. This can be a string, or you can use the BHoM Enum AccelerationUnit.")]
        [Output("acceleration", "The equivalent quantity defined in the specified unit.")]
        public static double ToAcceleration(this double metresPerSecondSquared, object unit)
        {
            UN.QuantityValue qv = metresPerSecondSquared;
            UNU.AccelerationUnit unUnit = ToAccelerationUnit(unit);
            if (unUnit != UNU.AccelerationUnit.Undefined)
                return UN.UnitConverter.Convert(qv, UNU.AccelerationUnit.MeterPerSecondSquared, unUnit);

            Compute.RecordError("Unit was undefined. Please use the appropriate BHoM Units Enum.");
            return double.NaN;
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        private static UNU.AccelerationUnit ToAccelerationUnit(object unit)
        {
            if (unit == null || unit.ToString() == null)
                return UNU.AccelerationUnit.Undefined;

            if (unit.GetType() == typeof(string))
            {
                AccelerationUnit unitEnum;
                if (Enum.TryParse<AccelerationUnit>(unit.ToString(), out unitEnum))
                    unit = unitEnum;
                else
                    unit = unit.ToString().ToLower();
            }

            switch (unit)
            {
                case AccelerationUnit.CentimeterPerSecondSquared:
                    return UNU.AccelerationUnit.CentimeterPerSecondSquared;
                case AccelerationUnit.DecimeterPerSecondSquared:
                    return UNU.AccelerationUnit.DecimeterPerSecondSquared;
                case AccelerationUnit.FootPerSecondSquared:
                    return UNU.AccelerationUnit.FootPerSecondSquared;
                case AccelerationUnit.InchPerSecondSquared:
                    return UNU.AccelerationUnit.InchPerSecondSquared;
                case AccelerationUnit.KilometerPerSecondSquared:
                    return UNU.AccelerationUnit.KilometerPerSecondSquared;
                case AccelerationUnit.KnotPerHour:
                    return UNU.AccelerationUnit.KnotPerHour;
                case AccelerationUnit.KnotPerMinute:
                    return UNU.AccelerationUnit.KnotPerMinute;
                case AccelerationUnit.KnotPerSecond:
                    return UNU.AccelerationUnit.KnotPerSecond;
                case AccelerationUnit.MeterPerSecondSquared:
                    return UNU.AccelerationUnit.MeterPerSecondSquared;
                case AccelerationUnit.MicrometerPerSecondSquared:
                    return UNU.AccelerationUnit.MicrometerPerSecondSquared;
                case AccelerationUnit.MillimeterPerSecondSquared:
                    return UNU.AccelerationUnit.MillimeterPerSecondSquared;
                case AccelerationUnit.NanometerPerSecondSquared:
                    return UNU.AccelerationUnit.NanometerPerSecondSquared;
                case AccelerationUnit.StandardGravity:
                    return UNU.AccelerationUnit.StandardGravity;
                case AccelerationUnit.Undefined:
                default:
                    return UNU.AccelerationUnit.Undefined;
            }
        }
    }
}


