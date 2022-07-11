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
using BH.oM.Quantities.Attributes;
using BH.oM.Units;

namespace BH.Engine.Units
{
    public static partial class Convert
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        [Description("Convert a torque into SI units (newtonMeter).")]
        [Input("torque", "The quantity to convert.")]
        [Input("unit", "The unit in which the quantity is defined.")]
        [Output("newtonMeter", "The equivalent number of newtonMeter.")]
        public static double FromTorque(this double torque, object unit)
        {
            UN.QuantityValue qv = torque;
            return UN.UnitConverter.Convert(qv, ToTorqueUnit(unit), TorqueUnit.NewtonMeter);
        }

        /***************************************************/

        [Description("Convert SI units (newtonMeter) into another torque unit.")]
        [Input("newtonMeter", "The number of newtonMeter to convert.")]
        [Input("unit", "The unit to convert to.")]
        [Output("torque", "The equivalent quantity defined in the specified unit.")]
        public static double ToTorque(this double newtonMeter, object unit)
        {
            UN.QuantityValue qv = newtonMeter;
            return UN.UnitConverter.Convert(qv, TorqueUnit.NewtonMeter, ToTorqueUnit(unit));
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        private static UNU.TorqueUnit ToTorqueUnit(object unit)
        {
            if (unit.GetType() == typeof(string))
                unit = unit.ToString().ToLower();

            switch (unit)
            {
                case TorqueUnit.KilogramForceCentimeter:
                    return UNU.TorqueUnit.KilogramForceCentimeter;
                case TorqueUnit.KilogramForceMeter:
                    return UNU.TorqueUnit.KilogramForceMeter;
                case TorqueUnit.KilogramForceMillimeter:
                    return UNU.TorqueUnit.KilogramForceMillimeter;
                case TorqueUnit.KilonewtonCentimeter:
                    return UNU.TorqueUnit.KilonewtonCentimeter;
                case TorqueUnit.KilonewtonMeter:
                    return UNU.TorqueUnit.KilonewtonMeter;
                case TorqueUnit.KilonewtonMillimeter:
                    return UNU.TorqueUnit.KilonewtonMillimeter;
                case TorqueUnit.KilopoundForceFoot:
                    return UNU.TorqueUnit.KilopoundForceFoot;
                case TorqueUnit.KilopoundForceInch:
                    return UNU.TorqueUnit.KilopoundForceInch;
                case TorqueUnit.MeganewtonCentimeter:
                    return UNU.TorqueUnit.MeganewtonCentimeter;
                case TorqueUnit.MeganewtonMeter:
                    return UNU.TorqueUnit.MeganewtonMeter;
                case TorqueUnit.MeganewtonMillimeter:
                    return UNU.TorqueUnit.MeganewtonMillimeter;
                case TorqueUnit.MegapoundForceFoot:
                    return UNU.TorqueUnit.MegapoundForceFoot;
                case TorqueUnit.MegapoundForceInch:
                    return UNU.TorqueUnit.MegapoundForceInch;
                case TorqueUnit.NewtonCentimeter:
                    return UNU.TorqueUnit.NewtonCentimeter;
                case TorqueUnit.NewtonMeter:
                    return UNU.TorqueUnit.NewtonMeter;
                case TorqueUnit.NewtonMillimeter:
                    return UNU.TorqueUnit.NewtonMillimeter;
                case TorqueUnit.PoundForceFoot:
                    return UNU.TorqueUnit.PoundForceFoot;
                case TorqueUnit.PoundForceInch:
                    return UNU.TorqueUnit.PoundForceInch;
                case TorqueUnit.TonneForceCentimeter:
                    return UNU.TorqueUnit.TonneForceCentimeter;
                case TorqueUnit.TonneForceMeter:
                    return UNU.TorqueUnit.TonneForceMeter;
                case TorqueUnit.TonneForceMillimeter:
                    return UNU.TorqueUnit.TonneForceMillimeter;
                case TorqueUnit.Undefined:
                default:
                    return UNU.TorqueUnit.Undefined;
            }
    }
}


