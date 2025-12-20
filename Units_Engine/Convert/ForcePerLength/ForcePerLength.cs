/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2026, the respective contributors. All rights reserved.
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

        [Description("Convert a forcePerLength into SI units (newtonPerMetre).")]
        [Input("forcePerLength", "The quantity to convert.")]
        [Input("unit", "The unit in which the quantity is defined. This can be a string, or you can use the BHoM Enum ForcePerLengthUnit.")]
        [Output("newtonPerMetre", "The equivalent number of newtonPerMetre.")]
        public static double FromForcePerLength(this double forcePerLength, object unit)
        {
            if (Double.IsNaN(forcePerLength) || Double.IsInfinity(forcePerLength))
            {
                Compute.RecordError("Quantity is not a real number.");
                return double.NaN;
            }

            UN.QuantityValue qv = forcePerLength;
            UNU.ForcePerLengthUnit unitSI = UNU.ForcePerLengthUnit.NewtonPerMeter;
            UNU.ForcePerLengthUnit? unUnit = ToForcePerLengthUnit(unit);

            if (unUnit != null)
                return UN.UnitConverter.Convert(qv, unUnit, unitSI);

            Compute.RecordError("Unit was undefined. Please use the appropriate BHoM Units Enum.");
            return double.NaN;
        }

        /***************************************************/

        [Description("Convert SI units (newtonPerMetre) into another forcePerLength unit.")]
        [Input("newtonPerMetre", "The number of newtonPerMetre to convert.")]
        [Input("unit", "The unit to convert to. This can be a string, or you can use the BHoM Enum ForcePerLengthUnit.")]
        [Output("forcePerLength", "The equivalent quantity defined in the specified unit.")]
        public static double ToForcePerLength(this double newtonPerMetre, object unit)
        {
            if (Double.IsNaN(newtonPerMetre) || Double.IsInfinity(newtonPerMetre))
            {
                Compute.RecordError("Quantity is not a real number.");
                return double.NaN;
            }

            UN.QuantityValue qv = newtonPerMetre;
            UNU.ForcePerLengthUnit unitSI = UNU.ForcePerLengthUnit.NewtonPerMeter;
            UNU.ForcePerLengthUnit? unUnit = ToForcePerLengthUnit(unit);

            if (unUnit != null)
                return UN.UnitConverter.Convert(qv, unitSI, unUnit);

            Compute.RecordError("Unit was undefined. Please use the appropriate BHoM Units Enum.");
            return double.NaN;
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        private static UNU.ForcePerLengthUnit? ToForcePerLengthUnit(object unit)
        {
            if (unit == null || unit.ToString() == null)
                return null;

            if (unit.GetType() == typeof(string))
            {
                ForcePerLengthUnit unitEnum;
                if (Enum.TryParse<ForcePerLengthUnit>(unit.ToString(), out unitEnum))
                    unit = unitEnum;
                else
                    unit = unit.ToString().ToLower();
            }

            switch (unit)
            {
                case ForcePerLengthUnit.CentinewtonPerCentimeter:
                    return UNU.ForcePerLengthUnit.CentinewtonPerCentimeter;
                case ForcePerLengthUnit.CentinewtonPerMeter:
                    return UNU.ForcePerLengthUnit.CentinewtonPerMeter;
                case ForcePerLengthUnit.CentinewtonPerMillimeter:
                    return UNU.ForcePerLengthUnit.CentinewtonPerMillimeter;
                case ForcePerLengthUnit.DecanewtonPerCentimeter:
                    return UNU.ForcePerLengthUnit.DecanewtonPerCentimeter;
                case ForcePerLengthUnit.DecanewtonPerMeter:
                    return UNU.ForcePerLengthUnit.DecanewtonPerMeter;
                case ForcePerLengthUnit.DecanewtonPerMillimeter:
                    return UNU.ForcePerLengthUnit.DecanewtonPerMillimeter;
                case ForcePerLengthUnit.DecinewtonPerCentimeter:
                    return UNU.ForcePerLengthUnit.DecinewtonPerCentimeter;
                case ForcePerLengthUnit.DecinewtonPerMeter:
                    return UNU.ForcePerLengthUnit.DecinewtonPerMeter;
                case ForcePerLengthUnit.DecinewtonPerMillimeter:
                    return UNU.ForcePerLengthUnit.DecinewtonPerMillimeter;
                case ForcePerLengthUnit.KilogramForcePerCentimeter:
                    return UNU.ForcePerLengthUnit.KilogramForcePerCentimeter;
                case ForcePerLengthUnit.KilogramForcePerMeter:
                    return UNU.ForcePerLengthUnit.KilogramForcePerMeter;
                case ForcePerLengthUnit.KilogramForcePerMillimeter:
                    return UNU.ForcePerLengthUnit.KilogramForcePerMillimeter;
                case ForcePerLengthUnit.KilonewtonPerCentimeter:
                    return UNU.ForcePerLengthUnit.KilonewtonPerCentimeter;
                case ForcePerLengthUnit.KilonewtonPerMeter:
                    return UNU.ForcePerLengthUnit.KilonewtonPerMeter;
                case ForcePerLengthUnit.KilonewtonPerMillimeter:
                    return UNU.ForcePerLengthUnit.KilonewtonPerMillimeter;
                case ForcePerLengthUnit.KilopoundForcePerFoot:
                    return UNU.ForcePerLengthUnit.KilopoundForcePerFoot;
                case ForcePerLengthUnit.KilopoundForcePerInch:
                    return UNU.ForcePerLengthUnit.KilopoundForcePerInch;
                case ForcePerLengthUnit.MeganewtonPerCentimeter:
                    return UNU.ForcePerLengthUnit.MeganewtonPerCentimeter;
                case ForcePerLengthUnit.MeganewtonPerMeter:
                    return UNU.ForcePerLengthUnit.MeganewtonPerMeter;
                case ForcePerLengthUnit.MeganewtonPerMillimeter:
                    return UNU.ForcePerLengthUnit.MeganewtonPerMillimeter;
                case ForcePerLengthUnit.MicronewtonPerCentimeter:
                    return UNU.ForcePerLengthUnit.MicronewtonPerCentimeter;
                case ForcePerLengthUnit.MicronewtonPerMeter:
                    return UNU.ForcePerLengthUnit.MicronewtonPerMeter;
                case ForcePerLengthUnit.MicronewtonPerMillimeter:
                    return UNU.ForcePerLengthUnit.MicronewtonPerMillimeter;
                case ForcePerLengthUnit.MillinewtonPerCentimeter:
                    return UNU.ForcePerLengthUnit.MillinewtonPerCentimeter;
                case ForcePerLengthUnit.MillinewtonPerMeter:
                    return UNU.ForcePerLengthUnit.MillinewtonPerMeter;
                case ForcePerLengthUnit.MillinewtonPerMillimeter:
                    return UNU.ForcePerLengthUnit.MillinewtonPerMillimeter;
                case ForcePerLengthUnit.NanonewtonPerCentimeter:
                    return UNU.ForcePerLengthUnit.NanonewtonPerCentimeter;
                case ForcePerLengthUnit.NanonewtonPerMeter:
                    return UNU.ForcePerLengthUnit.NanonewtonPerMeter;
                case ForcePerLengthUnit.NanonewtonPerMillimeter:
                    return UNU.ForcePerLengthUnit.NanonewtonPerMillimeter;
                case ForcePerLengthUnit.NewtonPerCentimeter:
                    return UNU.ForcePerLengthUnit.NewtonPerCentimeter;
                case ForcePerLengthUnit.NewtonPerMeter:
                    return UNU.ForcePerLengthUnit.NewtonPerMeter;
                case ForcePerLengthUnit.NewtonPerMillimeter:
                    return UNU.ForcePerLengthUnit.NewtonPerMillimeter;
                case ForcePerLengthUnit.PoundForcePerFoot:
                    return UNU.ForcePerLengthUnit.PoundForcePerFoot;
                case ForcePerLengthUnit.PoundForcePerInch:
                    return UNU.ForcePerLengthUnit.PoundForcePerInch;
                case ForcePerLengthUnit.PoundForcePerYard:
                    return UNU.ForcePerLengthUnit.PoundForcePerYard;
                case ForcePerLengthUnit.TonneForcePerCentimeter:
                    return UNU.ForcePerLengthUnit.TonneForcePerCentimeter;
                case ForcePerLengthUnit.TonneForcePerMeter:
                    return UNU.ForcePerLengthUnit.TonneForcePerMeter;
                case ForcePerLengthUnit.TonneForcePerMillimeter:
                    return UNU.ForcePerLengthUnit.TonneForcePerMillimeter;
                default:
                    return null;
            }
        }
    }
}






