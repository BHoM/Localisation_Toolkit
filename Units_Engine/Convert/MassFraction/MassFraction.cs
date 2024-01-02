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
        [Description("Convert a mass fraction into SI units (kilogramsPerkilogram).")]
        [Input("massFraction", "The quantity to convert.")]
        [Input("unit", "The unit in which the quantity is defined. This can be a string, or you can use the BHoM Enum MassFractionUnit.")]
        [Output("kilogramsPerKilogram", "The equivalent number of kilogramsPerKilogram.")]
        public static double FromMassFraction(this double massFraction, object unit)
        {
            if (Double.IsNaN(massFraction) || Double.IsInfinity(massFraction))
            {
                Compute.RecordError("Quantity is not a real number.");
                return double.NaN;
            }

            UN.QuantityValue qv = massFraction;
            UNU.MassFractionUnit unitSI = UNU.MassFractionUnit.KilogramPerKilogram;
            UNU.MassFractionUnit unUnit = ToMassFractionUnit(unit);
            if (unUnit != UNU.MassFractionUnit.Undefined)
                return UN.UnitConverter.Convert(qv, unUnit, unitSI);
            Compute.RecordError("Unit was undefined. Please use the appropriate BHoM Units Enum.");
            return double.NaN;
        }

        /***************************************************/
        [Description("Convert SI units (kilogramsPerKilogram) into another massFraction unit.")]
        [Input("kilogramsPerKilogram", "The number of kilogramsPerKilogram to convert.")]
        [Input("unit", "The unit to convert to. This can be a string, or you can use the BHoM Enum massFractionUnit.")]
        [Output("massFraction", "The equivalent quantity defined in the specified unit.")]
        public static double ToMassFraction(this double kilogramsPerKilogram, object unit)
        {
            if (Double.IsNaN(kilogramsPerKilogram) || Double.IsInfinity(kilogramsPerKilogram))
            {
                Compute.RecordError("Quantity is not a real number.");
                return double.NaN;
            }

            UN.QuantityValue qv = kilogramsPerKilogram;
            UNU.MassFractionUnit unitSI = UNU.MassFractionUnit.KilogramPerKilogram;
            UNU.MassFractionUnit unUnit = ToMassFractionUnit(unit);
            if (unUnit != UNU.MassFractionUnit.Undefined)
                return UN.UnitConverter.Convert(qv, unitSI, unUnit);
            Compute.RecordError("Unit was undefined. Please use the appropriate BHoM Units Enum.");
            return double.NaN;
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/
        private static UNU.MassFractionUnit ToMassFractionUnit(object unit)
        {
            if (unit == null || unit.ToString() == null)
                return UNU.MassFractionUnit.Undefined;
            if (unit.GetType() == typeof(string))
            {
                DensityUnit unitEnum;
                if (Enum.TryParse<DensityUnit>(unit.ToString(), out unitEnum))
                    unit = unitEnum;
                else
                    unit = unit.ToString().ToLower();
            }

            switch (unit)
            {
                case MassFractionUnit.NanogramPerKilogram:
                    return UNU.MassFractionUnit.NanogramPerKilogram;
                case MassFractionUnit.MicrogramPerKilogram:
                    return UNU.MassFractionUnit.MicrogramPerKilogram;
                case MassFractionUnit.MilligramPerKilogram:
                    return UNU.MassFractionUnit.MilligramPerKilogram;
                case MassFractionUnit.CentigramPerKilogram:
                    return UNU.MassFractionUnit.CentigramPerKilogram;
                case MassFractionUnit.DecigramPerKilogram:
                    return UNU.MassFractionUnit.DecigramPerKilogram;
                case MassFractionUnit.GramPerKilogram:
                    return UNU.MassFractionUnit.GramPerKilogram;
                case DensityUnit.Undefined:
                default:
                    return UNU.MassFractionUnit.Undefined;
            }
        }
    }
}
