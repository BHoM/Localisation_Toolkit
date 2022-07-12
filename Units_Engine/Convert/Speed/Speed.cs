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

        [Description("Convert a speed into SI units (metresPerSecond).")]
        [Input("speed", "The quantity to convert.")]
        [Input("unit", "The unit in which the quantity is defined. This can be a string, or you can use the BHoM Enum SpeedUnit.")]
        [Output("metresPerSecond", "The equivalent number of metresPerSecond.")]
        public static double FromSpeed(this double acceleration, object unit)
        {
            UN.QuantityValue qv = acceleration;
            return UN.UnitConverter.Convert(qv, ToSpeedUnit(unit), UNU.SpeedUnit.MeterPerSecond);
        }

        /***************************************************/

        [Description("Convert SI units (metresPerSecond) into another speed unit.")]
        [Input("metresPerSecond", "The number of metresPerSecond to convert.")]
        [Input("unit", "The unit to convert to. This can be a string, or you can use the BHoM Enum SpeedUnit.")]
        [Output("speed", "The equivalent quantity defined in the specified unit.")]
        public static double ToSpeed(this double metresPerSecond, object unit)
        {
            UN.QuantityValue qv = metresPerSecond;
            return UN.UnitConverter.Convert(qv, UNU.SpeedUnit.MeterPerSecond, ToSpeedUnit(unit));
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        private static UNU.SpeedUnit ToSpeedUnit(object unit)
        {
            if (unit.GetType() == typeof(string))
                unit = unit.ToString().ToLower();

            switch (unit)
            {
                case SpeedUnit.CentimeterPerHour:
                    return UNU.SpeedUnit.CentimeterPerHour;
                case SpeedUnit.CentimeterPerMinute:
                    return UNU.SpeedUnit.CentimeterPerMinute;
                case SpeedUnit.CentimeterPerSecond:
                    return UNU.SpeedUnit.CentimeterPerSecond;
                case SpeedUnit.DecimeterPerMinute:
                    return UNU.SpeedUnit.DecimeterPerMinute;
                case SpeedUnit.DecimeterPerSecond:
                    return UNU.SpeedUnit.DecimeterPerSecond;
                case SpeedUnit.FootPerHour:
                    return UNU.SpeedUnit.FootPerHour;
                case SpeedUnit.FootPerMinute:
                    return UNU.SpeedUnit.FootPerMinute;
                case SpeedUnit.FootPerSecond:
                    return UNU.SpeedUnit.FootPerSecond;
                case SpeedUnit.InchPerHour:
                    return UNU.SpeedUnit.InchPerHour;
                case SpeedUnit.InchPerMinute:
                    return UNU.SpeedUnit.InchPerMinute;
                case SpeedUnit.InchPerSecond:
                    return UNU.SpeedUnit.InchPerSecond;
                case SpeedUnit.KilometerPerHour:
                    return UNU.SpeedUnit.KilometerPerHour;
                case SpeedUnit.KilometerPerMinute:
                    return UNU.SpeedUnit.KilometerPerMinute;
                case SpeedUnit.KilometerPerSecond:
                    return UNU.SpeedUnit.KilometerPerSecond;
                case SpeedUnit.Knot:
                    return UNU.SpeedUnit.Knot;
                case SpeedUnit.MeterPerHour:
                    return UNU.SpeedUnit.MeterPerHour;
                case SpeedUnit.MeterPerMinute:
                    return UNU.SpeedUnit.MeterPerMinute;
                case SpeedUnit.MeterPerSecond:
                    return UNU.SpeedUnit.MeterPerSecond;
                case SpeedUnit.MicrometerPerMinute:
                    return UNU.SpeedUnit.MicrometerPerMinute;
                case SpeedUnit.MicrometerPerSecond:
                    return UNU.SpeedUnit.MicrometerPerSecond;
                case SpeedUnit.MilePerHour:
                    return UNU.SpeedUnit.MilePerHour;
                case SpeedUnit.MillimeterPerHour:
                    return UNU.SpeedUnit.MillimeterPerHour;
                case SpeedUnit.MillimeterPerMinute:
                    return UNU.SpeedUnit.MillimeterPerMinute;
                case SpeedUnit.MillimeterPerSecond:
                    return UNU.SpeedUnit.MillimeterPerSecond;
                case SpeedUnit.NanometerPerMinute:
                    return UNU.SpeedUnit.NanometerPerMinute;
                case SpeedUnit.NanometerPerSecond:
                    return UNU.SpeedUnit.NanometerPerSecond;
                case SpeedUnit.UsSurveyFootPerHour:
                    return UNU.SpeedUnit.UsSurveyFootPerHour;
                case SpeedUnit.UsSurveyFootPerMinute:
                    return UNU.SpeedUnit.UsSurveyFootPerMinute;
                case SpeedUnit.UsSurveyFootPerSecond:
                    return UNU.SpeedUnit.UsSurveyFootPerSecond;
                case SpeedUnit.YardPerHour:
                    return UNU.SpeedUnit.YardPerHour;
                case SpeedUnit.YardPerMinute:
                    return UNU.SpeedUnit.YardPerMinute;
                case SpeedUnit.YardPerSecond:
                    return UNU.SpeedUnit.YardPerSecond;
                case SpeedUnit.Undefined:
                default:
                    return UNU.SpeedUnit.Undefined;
            }
        }
    }
}
