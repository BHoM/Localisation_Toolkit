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

        [Description("Convert a momentPerLength into SI units (newtonMeterPerMeter).")]
        [Input("momentPerLength", "The quantity to convert.")]
        [Input("unit", "The unit in which the quantity is defined. This can be a string, or you can use the BHoM Enum TorquePerLengthUnit.")]
        [Output("newtonMeterPerMeter", "The equivalent number of newtonMeterPerMeter.")]
        public static double FromMomentPerLength(this double momentPerLength, object unit)
        {
            if (Double.IsNaN(momentPerLength) || Double.IsInfinity(momentPerLength))
            {
                Compute.RecordError("Quantity is not a real number.");
                return double.NaN;
            }

            UN.QuantityValue qv = momentPerLength;
            UNU.TorquePerLengthUnit unitSI = UNU.TorquePerLengthUnit.NewtonMeterPerMeter;
            UNU.TorquePerLengthUnit unUnit = ToTorquePerLengthUnit(unit);

            if (unUnit != UNU.TorquePerLengthUnit.Undefined)
                return UN.UnitConverter.Convert(qv, unUnit, unitSI);

            Compute.RecordError("Unit was undefined. Please use the appropriate BHoM Units Enum.");
            return double.NaN;
        }

        /***************************************************/

        [Description("Convert SI units (newtonMeterPerMeter) into another momentPerLength unit.")]
        [Input("newtonMeterPerMeter", "The number of newtonMeterPerMeter to convert.")]
        [Input("unit", "The unit to convert to. This can be a string, or you can use the BHoM Enum TorquePerLengthUnit.")]
        [Output("momentPerLength", "The equivalent quantity defined in the specified unit.")]
        public static double ToMomentPerLength(this double newtonMeterPerMeter, object unit)
        {
            if (Double.IsNaN(newtonMeterPerMeter) || Double.IsInfinity(newtonMeterPerMeter))
            {
                Compute.RecordError("Quantity is not a real number.");
                return double.NaN;
            }

            UN.QuantityValue qv = newtonMeterPerMeter;
            UNU.TorquePerLengthUnit unitSI = UNU.TorquePerLengthUnit.NewtonMeterPerMeter;
            UNU.TorquePerLengthUnit unUnit = ToTorquePerLengthUnit(unit);

            if (unUnit != UNU.TorquePerLengthUnit.Undefined)
                return UN.UnitConverter.Convert(qv, unitSI, unUnit);

            Compute.RecordError("Unit was undefined. Please use the appropriate BHoM Units Enum.");
            return double.NaN;
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        private static UNU.TorquePerLengthUnit ToTorquePerLengthUnit(object unit)
        {
            if (unit == null || unit.ToString() == null)
                return UNU.TorquePerLengthUnit.Undefined;

            if (unit.GetType() == typeof(string))
            {
                TorquePerLengthUnit unitEnum;
                if (Enum.TryParse<TorquePerLengthUnit>(unit.ToString(), out unitEnum))
                    unit = unitEnum;
                else
                    unit = unit.ToString().ToLower();
            }

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



