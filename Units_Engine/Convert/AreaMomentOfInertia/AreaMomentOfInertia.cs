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

        [Description("Convert a areaMomentOfInertia into SI units (metresToTheFourth).")]
        [Input("areaMomentOfInertia", "The quantity to convert.")]
        [Input("unit", "The unit in which the quantity is defined.")]
        [Output("metresToTheFourth", "The equivalent number of metresToTheFourth.")]
        public static double FromAreaMomentOfInertia(this double areaMomentOfInertia, object unit)
        {
            UN.QuantityValue qv = areaMomentOfInertia;
            return UN.UnitConverter.Convert(qv, ToAreaMomentOfInertiaUnit(unit), AreaMomentOfInertiaUnit.MeterToTheFourth);
        }

        /***************************************************/

        [Description("Convert SI units (metresToTheFourth) into another areaMomentOfInertia unit.")]
        [Input("metresToTheFourth", "The number of metresToTheFourth to convert.")]
        [Input("unit", "The unit to convert to.")]
        [Output("areaMomentOfInertia", "The equivalent quantity defined in the specified unit.")]
        public static double ToAreaMomentOfInertia(this double metresToTheFourth, object unit)
        {
            UN.QuantityValue qv = metresToTheFourth;
            return UN.UnitConverter.Convert(qv, AreaMomentOfInertiaUnit.MeterToTheFourth, ToAreaMomentOfInertiaUnit(unit));
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        private static UNU.AreaMomentOfInertiaUnit ToAreaMomentOfInertiaUnit(object unit)
        {
            if (unit.GetType() == typeof(string))
                unit = unit.ToString().ToLower();

            switch (unit)
            {
                case AreaMomentOfInertiaUnit.CentimeterToTheFourth:
                    return UNU.AreaMomentOfInertiaUnit.CentimeterToTheFourth;
                case AreaMomentOfInertiaUnit.DecimeterToTheFourth:
                    return UNU.AreaMomentOfInertiaUnit.DecimeterToTheFourth;
                case AreaMomentOfInertiaUnit.FootToTheFourth:
                    return UNU.AreaMomentOfInertiaUnit.FootToTheFourth;
                case AreaMomentOfInertiaUnit.InchToTheFourth:
                    return UNU.AreaMomentOfInertiaUnit.InchToTheFourth;
                case AreaMomentOfInertiaUnit.MeterToTheFourth:
                    return UNU.AreaMomentOfInertiaUnit.MeterToTheFourth;
                case AreaMomentOfInertiaUnit.MillimeterToTheFourth:
                    return UNU.AreaMomentOfInertiaUnit.MillimeterToTheFourth;
                case AreaMomentOfInertiaUnit.Undefined:
                default:
                    return UNU.AreaMomentOfInertiaUnit.Undefined;
            }
        }
    }
}


