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

        [Description("Convert a momentPerLength into SI units (newtonMeterPerMeter).")]
        [Input("momentPerLength", "The quantity to convert.")]
        [Input("unit", "The unit in which the quantity is defined.")]
        [Output("newtonMeterPerMeter", "The equivalent number of newtonMeterPerMeter.")]
        public static double FromMomentPerLength(this double momentPerLength, object unit)
        {
            UN.QuantityValue qv = momentPerLength;
            return UN.UnitConverter.Convert(qv, ToTorquePerLengthUnit(unit), UNU.TorquePerLengthUnit.NewtonMeterPerMeter);
        }

        /***************************************************/

        [Description("Convert SI units (newtonMeterPerMeter) into another momentPerLength unit.")]
        [Input("newtonMeterPerMeter", "The number of newtonMeterPerMeter to convert.")]
        [Input("unit", "The unit to convert to.")]
        [Output("momentPerLength", "The equivalent quantity defined in the specified unit.")]
        public static double ToMomentPerLength(this double newtonMeterPerMeter, object unit)
        {
            UN.QuantityValue qv = newtonMeterPerMeter;
            return UN.UnitConverter.Convert(qv, UNU.TorquePerLengthUnit.NewtonMeterPerMeter, ToTorquePerLengthUnit(unit));
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        private static UNU.TorquePerLengthUnit ToTorquePerLengthUnit(object unit)
        {
            if (unit.GetType() == typeof(string))
                unit = unit.ToString().ToLower();

            switch (unit)
            {
                case TorquePerLengthUnit.KilogramForceCentimeterPerMeter:
                    return UNU.TorquePerLengthUnit.KilogramForceCentimeterPerMeter;
                case TorquePerLengthUnit.KilogramForceMeterPerMeter:
                    return UNU.TorquePerLengthUnit.KilogramForceMeterPerMeter;
                case TorquePerLengthUnit.KilogramForceMillimeterPerMeter:
                    return UNU.TorquePerLengthUnit.KilogramForceMillimeterPerMeter;
                case TorquePerLengthUnit.KilonewtonCentimeterPerMeter:
                    return UNU.TorquePerLengthUnit.KilonewtonCentimeterPerMeter;
                case TorquePerLengthUnit.KilonewtonMeterPerMeter:
                    return UNU.TorquePerLengthUnit.KilonewtonMeterPerMeter;
                case TorquePerLengthUnit.KilonewtonMillimeterPerMeter:
                    return UNU.TorquePerLengthUnit.KilonewtonMillimeterPerMeter;
                case TorquePerLengthUnit.KilopoundForceFootPerFoot:
                    return UNU.TorquePerLengthUnit.KilopoundForceFootPerFoot;
                case TorquePerLengthUnit.KilopoundForceInchPerFoot:
                    return UNU.TorquePerLengthUnit.KilopoundForceInchPerFoot;
                case TorquePerLengthUnit.MeganewtonCentimeterPerMeter:
                    return UNU.TorquePerLengthUnit.MeganewtonCentimeterPerMeter;
                case TorquePerLengthUnit.MeganewtonMeterPerMeter:
                    return UNU.TorquePerLengthUnit.MeganewtonMeterPerMeter;
                case TorquePerLengthUnit.MeganewtonMillimeterPerMeter:
                    return UNU.TorquePerLengthUnit.MeganewtonMillimeterPerMeter;
                case TorquePerLengthUnit.MegapoundForceFootPerFoot:
                    return UNU.TorquePerLengthUnit.MegapoundForceFootPerFoot;
                case TorquePerLengthUnit.MegapoundForceInchPerFoot:
                    return UNU.TorquePerLengthUnit.MegapoundForceInchPerFoot;
                case TorquePerLengthUnit.NewtonCentimeterPerMeter:
                    return UNU.TorquePerLengthUnit.NewtonCentimeterPerMeter;
                case TorquePerLengthUnit.NewtonMeterPerMeter:
                    return UNU.TorquePerLengthUnit.NewtonMeterPerMeter;
                case TorquePerLengthUnit.NewtonMillimeterPerMeter:
                    return UNU.TorquePerLengthUnit.NewtonMillimeterPerMeter;
                case TorquePerLengthUnit.PoundForceFootPerFoot:
                    return UNU.TorquePerLengthUnit.PoundForceFootPerFoot;
                case TorquePerLengthUnit.PoundForceInchPerFoot:
                    return UNU.TorquePerLengthUnit.PoundForceInchPerFoot;
                case TorquePerLengthUnit.TonneForceCentimeterPerMeter:
                    return UNU.TorquePerLengthUnit.TonneForceCentimeterPerMeter;
                case TorquePerLengthUnit.TonneForceMeterPerMeter:
                    return UNU.TorquePerLengthUnit.TonneForceMeterPerMeter;
                case TorquePerLengthUnit.TonneForceMillimeterPerMeter:
                    return UNU.TorquePerLengthUnit.TonneForceMillimeterPerMeter;
                case TorquePerLengthUnit.Undefined:
                default:
                    return UNU.TorquePerLengthUnit.Undefined;
            }
        }
    }
}


