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

        [Description("Convert a density into SI units (kilogramPerCubicMetres).")]
        [Input("density", "The quantity to convert.")]
        [Input("unit", "The unit in which the quantity is defined. This can be a string, or you can use the BHoM Enum DensityUnit.")]
        [Output("kilogramPerCubicMetres", "The equivalent number of kilogramPerCubicMetres.")]
        public static double FromDensity(this double density, object unit)
        {
            if (Double.IsNaN(density) || Double.IsInfinity(density))
            {
                Compute.RecordError("Quantity is not a real number.");
                return double.NaN;
            }

            UN.QuantityValue qv = density;
            UNU.DensityUnit unitSI = UNU.DensityUnit.KilogramPerCubicMeter;
            UNU.DensityUnit unUnit = ToDensityUnit(unit);

            if (unUnit != UNU.DensityUnit.Undefined)
                return UN.UnitConverter.Convert(qv, unUnit, unitSI);

            Compute.RecordError("Unit was undefined. Please use the appropriate BHoM Units Enum.");
            return double.NaN;
        }

        /***************************************************/

        [Description("Convert SI units (kilogramPerCubicMetres) into another density unit.")]
        [Input("kilogramPerCubicMetres", "The number of kilogramPerCubicMetres to convert.")]
        [Input("unit", "The unit to convert to. This can be a string, or you can use the BHoM Enum DensityUnit.")]
        [Output("density", "The equivalent quantity defined in the specified unit.")]
        public static double ToDensity(this double kilogramPerCubicMetres, object unit)
        {
            if (Double.IsNaN(kilogramPerCubicMetres) || Double.IsInfinity(kilogramPerCubicMetres))
            {
                Compute.RecordError("Quantity is not a real number.");
                return double.NaN;
            }

            UN.QuantityValue qv = kilogramPerCubicMetres;
            UNU.DensityUnit unitSI = UNU.DensityUnit.KilogramPerCubicMeter;
            UNU.DensityUnit unUnit = ToDensityUnit(unit);

            if (unUnit != UNU.DensityUnit.Undefined)
                return UN.UnitConverter.Convert(qv, unitSI, unUnit);

            Compute.RecordError("Unit was undefined. Please use the appropriate BHoM Units Enum.");
            return double.NaN;
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        private static UNU.DensityUnit ToDensityUnit(object unit)
        {
            if (unit == null || unit.ToString() == null)
                return UNU.DensityUnit.Undefined;

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
                case DensityUnit.CentigramPerDeciliter:
                    return UNU.DensityUnit.CentigramPerDeciliter;
                case DensityUnit.CentigramPerLiter:
                    return UNU.DensityUnit.CentigramPerLiter;
                case DensityUnit.CentigramPerMilliliter:
                    return UNU.DensityUnit.CentigramPerMilliliter;
                case DensityUnit.DecigramPerDeciliter:
                    return UNU.DensityUnit.DecigramPerDeciliter;
                case DensityUnit.DecigramPerLiter:
                    return UNU.DensityUnit.DecigramPerLiter;
                case DensityUnit.DecigramPerMilliliter:
                    return UNU.DensityUnit.DecigramPerMilliliter;
                case DensityUnit.GramPerCubicCentimeter:
                    return UNU.DensityUnit.GramPerCubicCentimeter;
                case DensityUnit.GramPerCubicMeter:
                    return UNU.DensityUnit.GramPerCubicMeter;
                case DensityUnit.GramPerCubicMillimeter:
                    return UNU.DensityUnit.GramPerCubicMillimeter;
                case DensityUnit.GramPerDeciliter:
                    return UNU.DensityUnit.GramPerDeciliter;
                case DensityUnit.GramPerLiter:
                    return UNU.DensityUnit.GramPerLiter;
                case DensityUnit.GramPerMilliliter:
                    return UNU.DensityUnit.GramPerMilliliter;
                case DensityUnit.KilogramPerCubicCentimeter:
                    return UNU.DensityUnit.KilogramPerCubicCentimeter;
                case DensityUnit.KilogramPerCubicMeter:
                    return UNU.DensityUnit.KilogramPerCubicMeter;
                case DensityUnit.KilogramPerCubicMillimeter:
                    return UNU.DensityUnit.KilogramPerCubicMillimeter;
                case DensityUnit.KilogramPerLiter:
                    return UNU.DensityUnit.KilogramPerLiter;
                case "kcf":
                case DensityUnit.KilopoundPerCubicFoot:
                    return UNU.DensityUnit.KilopoundPerCubicFoot;
                case DensityUnit.KilopoundPerCubicInch:
                    return UNU.DensityUnit.KilopoundPerCubicInch;
                case DensityUnit.MicrogramPerCubicMeter:
                    return UNU.DensityUnit.MicrogramPerCubicMeter;
                case DensityUnit.MicrogramPerDeciliter:
                    return UNU.DensityUnit.MicrogramPerDeciliter;
                case DensityUnit.MicrogramPerLiter:
                    return UNU.DensityUnit.MicrogramPerLiter;
                case DensityUnit.MicrogramPerMilliliter:
                    return UNU.DensityUnit.MicrogramPerMilliliter;
                case DensityUnit.MilligramPerCubicMeter:
                    return UNU.DensityUnit.MilligramPerCubicMeter;
                case DensityUnit.MilligramPerDeciliter:
                    return UNU.DensityUnit.MilligramPerDeciliter;
                case DensityUnit.MilligramPerLiter:
                    return UNU.DensityUnit.MilligramPerLiter;
                case DensityUnit.MilligramPerMilliliter:
                    return UNU.DensityUnit.MilligramPerMilliliter;
                case DensityUnit.NanogramPerDeciliter:
                    return UNU.DensityUnit.NanogramPerDeciliter;
                case DensityUnit.NanogramPerLiter:
                    return UNU.DensityUnit.NanogramPerLiter;
                case DensityUnit.NanogramPerMilliliter:
                    return UNU.DensityUnit.NanogramPerMilliliter;
                case DensityUnit.PicogramPerDeciliter:
                    return UNU.DensityUnit.PicogramPerDeciliter;
                case DensityUnit.PicogramPerLiter:
                    return UNU.DensityUnit.PicogramPerLiter;
                case DensityUnit.PicogramPerMilliliter:
                    return UNU.DensityUnit.PicogramPerMilliliter;
                case "pcf":
                case DensityUnit.PoundPerCubicFoot:
                    return UNU.DensityUnit.PoundPerCubicFoot;
                case "pci":
                case DensityUnit.PoundPerCubicInch:
                    return UNU.DensityUnit.PoundPerCubicInch;
                case DensityUnit.PoundPerImperialGallon:
                    return UNU.DensityUnit.PoundPerImperialGallon;
                case DensityUnit.PoundPerUSGallon:
                    return UNU.DensityUnit.PoundPerUSGallon;
                case DensityUnit.SlugPerCubicFoot:
                    return UNU.DensityUnit.SlugPerCubicFoot;
                case DensityUnit.TonnePerCubicCentimeter:
                    return UNU.DensityUnit.TonnePerCubicCentimeter;
                case DensityUnit.TonnePerCubicMeter:
                    return UNU.DensityUnit.TonnePerCubicMeter;
                case DensityUnit.TonnePerCubicMillimeter:
                    return UNU.DensityUnit.TonnePerCubicMillimeter;
                case DensityUnit.Undefined:
                default:
                    return UNU.DensityUnit.Undefined;
            }
        }
    }
}




