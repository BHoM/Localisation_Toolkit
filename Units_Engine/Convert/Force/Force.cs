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

        [Description("Convert a force into SI units (newtons).")]
        [Input("force", "The quantity to convert.")]
        [Input("unit", "The unit in which the quantity is defined.")]
        [Output("newtons", "The equivalent number of newtons.")]
        public static double FromForce(this double force, object unit)
        {
            UN.QuantityValue qv = force;
            return UN.UnitConverter.Convert(qv, ToForceUnit(unit), UNU.ForceUnit.Newton);
        }

        /***************************************************/


        [Description("Convert SI units (newtons) into another force unit.")]
        [Input("newtons", "The number of newtons to convert.")]
        [Input("unit", "The unit to convert to.")]
        [Output("force", "The equivalent quantity defined in the specified unit.")]
        public static double ToForce(this double newtons, object unit)
        {
            UN.QuantityValue qv = newtons;
            return UN.UnitConverter.Convert(qv, UNU.ForceUnit.Newton, ToForceUnit(unit));
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        private static UNU.ForceUnit ToForceUnit(object unit)
        {
            if (unit.GetType() == typeof(string))
                unit = unit.ToString().ToLower();

            switch (unit)
            {
                case ForceUnit.Decanewton:
                    return UNU.ForceUnit.Decanewton;
                case ForceUnit.Dyn:
                    return UNU.ForceUnit.Dyn;
                case ForceUnit.KilogramForce:
                    return UNU.ForceUnit.KilogramForce;
                case "kn":
                case ForceUnit.Kilonewton:
                    return UNU.ForceUnit.Kilonewton;
                case ForceUnit.KiloPond:
                    return UNU.ForceUnit.KiloPond;
                case "kip":
                case ForceUnit.KilopoundForce:
                    return UNU.ForceUnit.KilopoundForce;
                case ForceUnit.Meganewton:
                    return UNU.ForceUnit.Meganewton;
                case ForceUnit.Micronewton:
                    return UNU.ForceUnit.Micronewton;
                case ForceUnit.Millinewton:
                    return UNU.ForceUnit.Millinewton;
                case ForceUnit.Newton:
                    return UNU.ForceUnit.Newton;
                case ForceUnit.OunceForce:
                    return UNU.ForceUnit.OunceForce;
                case ForceUnit.Poundal:
                    return UNU.ForceUnit.Poundal;
                case "pound":
                case "lb":
                case ForceUnit.PoundForce:
                    return UNU.ForceUnit.PoundForce;
                case ForceUnit.TonneForce:
                    return UNU.ForceUnit.TonneForce;
                case ForceUnit.Undefined:
                default:
                    return UNU.ForceUnit.Undefined;
            }
        }
    }
}


