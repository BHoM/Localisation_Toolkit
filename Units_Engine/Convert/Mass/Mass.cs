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

        [Description("Convert a mass into SI units (kiloGram).")]
        [Input("mass", "The quantity to convert.")]
        [Input("unit", "The unit in which the quantity is defined. This can be a string, or you can use the BHoM Enum MassUnit.")]
        [Output("kilogram", "The equivalent number of kilograms.")]
        public static double FromMass(this double mass, object unit)
        {
            if (Double.IsNaN(mass) || Double.IsInfinity(mass))
            {
                Compute.RecordError("Quantity is not a real number.");
                return double.NaN;
            }

            UN.QuantityValue qv = mass;
            UNU.MassUnit unitSI = UNU.MassUnit.Kilogram;
            UNU.MassUnit? unUnit = ToMassUnit(unit);

            if (unUnit != null)
                return UN.UnitConverter.Convert(qv, unUnit, unitSI);

            Compute.RecordError("Unit was undefined. Please use the appropriate BHoM Units Enum.");
            return double.NaN;
        }

        /***************************************************/

        [Description("Convert SI units (kilogram) into another mass unit.")]
        [Input("kilogram", "The number of kiloGram to convert.")]
        [Input("unit", "The unit to convert to. This can be a string, or you can use the BHoM Enum MassUnit.")]
        [Output("mass", "The equivalent quantity defined in the specified unit.")]
        public static double ToMass(this double kilogram, object unit)
        {
            if (Double.IsNaN(kilogram) || Double.IsInfinity(kilogram))
            {
                Compute.RecordError("Quantity is not a real number.");
                return double.NaN;
            }

            UN.QuantityValue qv = kilogram;
            UNU.MassUnit unitSI = UNU.MassUnit.Kilogram;
            UNU.MassUnit? unUnit = ToMassUnit(unit);

            if (unUnit != null)
                return UN.UnitConverter.Convert(qv, unitSI, unUnit);

            Compute.RecordError("Unit was undefined. Please use the appropriate BHoM Units Enum.");
            return double.NaN;

        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        private static UNU.MassUnit? ToMassUnit(object unit)
        {
            if (unit == null || unit.ToString() == null)
                return null;

            if (unit.GetType() == typeof(string))
            {
                MassUnit unitEnum;
                if (Enum.TryParse<MassUnit>(unit.ToString(), out unitEnum))
                    unit = unitEnum;
                else
                    unit = unit.ToString().ToLower();
            }

            switch (unit)
            {
                case "g":
                case MassUnit.Gram:
                    return UNU.MassUnit.Gram;
                case "kg":
                case "kilogram":
                case MassUnit.Kilogram:
                    return UNU.MassUnit.Kilogram;
                case "mg":
                case MassUnit.Milligram:
                    return UNU.MassUnit.Milligram;
                case MassUnit.LongTon:
                    return UNU.MassUnit.LongTon;
                case "oz":
                case MassUnit.Ounce:
                    return UNU.MassUnit.Ounce;
                case "lb":
                case MassUnit.Pound:
                    return UNU.MassUnit.Pound;
                case MassUnit.ShortTon:
                    return UNU.MassUnit.ShortTon;
                case "tonne":
                case MassUnit.Tonne:
                    return UNU.MassUnit.Tonne;
                case MassUnit.Undefined:
                default:
                    return null;
            }
        }
    }
}

