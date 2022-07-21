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
using BH.Engine.Base;

namespace BH.Engine.Units
{
    public static partial class Convert
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        [Description("Convert a pressure into SI units (pascal).")]
        [Input("pressure", "The quantity to convert.")]
        [Input("unit", "The unit in which the quantity is defined. This can be a string, or you can use the BHoM Enum PressureUnit.")]
        [Output("pascal", "The equivalent number of pascal.")]
        public static double FromPressure(this double pressure, object unit)
        {
            if (Double.IsNaN(pressure) || Double.IsInfinity(pressure))
            {
                Compute.RecordError("Quantity is not a real number.");
                return double.NaN;
            }

            UN.QuantityValue qv = pressure;
            UNU.PressureUnit unitSI = UNU.PressureUnit.Pascal;
            UNU.PressureUnit unUnit = ToPressureUnit(unit);

            if (unUnit != UNU.PressureUnit.Undefined)
                return UN.UnitConverter.Convert(qv, unUnit, unitSI);

            Compute.RecordError("Unit was undefined. Please use the appropriate BHoM Units Enum.");
            return double.NaN;
        }

        /***************************************************/

        [Description("Convert SI units (pascal) into another pressure unit.")]
        [Input("pascal", "The number of pascal to convert.")]
        [Input("unit", "The unit to convert to. This can be a string, or you can use the BHoM Enum PressureUnit.")]
        [Output("pressure", "The equivalent quantity defined in the specified unit.")]
        public static double ToPressure(this double pascal, object unit)
        {
            if (Double.IsNaN(pascal) || Double.IsInfinity(pascal))
            {
                Compute.RecordError("Quantity is not a real number.");
                return double.NaN;
            }

            UN.QuantityValue qv = pascal;
            UNU.PressureUnit unitSI = UNU.PressureUnit.Pascal;
            UNU.PressureUnit unUnit = ToPressureUnit(unit);

            if (unUnit != UNU.PressureUnit.Undefined)
                return UN.UnitConverter.Convert(qv, unitSI, unUnit);

            Compute.RecordError("Unit was undefined. Please use the appropriate BHoM Units Enum.");
            return double.NaN;
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        private static UNU.PressureUnit ToPressureUnit(this object unit)
        {
            if (unit == null || unit.ToString() == null)
                return UNU.PressureUnit.Undefined;

            if (unit.GetType() == typeof(string))
            {
                PressureUnit unitEnum;
                if (Enum.TryParse<PressureUnit>(unit.ToString(), out unitEnum))
                    unit = unitEnum;
                else
                    unit = unit.ToString().ToLower();
            }

            switch (unit)
            {
                case PressureUnit.Atmosphere:
                    return UNU.PressureUnit.Atmosphere;
                case PressureUnit.Bar:
                    return UNU.PressureUnit.Bar;
                case PressureUnit.Centibar:
                    return UNU.PressureUnit.Centibar;
                case PressureUnit.Decapascal:
                    return UNU.PressureUnit.Decapascal;
                case PressureUnit.Decibar:
                    return UNU.PressureUnit.Decibar;
                case PressureUnit.DynePerSquareCentimeter:
                    return UNU.PressureUnit.DynePerSquareCentimeter;
                case PressureUnit.FootOfHead:
                    return UNU.PressureUnit.FootOfHead;
                case PressureUnit.Gigapascal:
                    return UNU.PressureUnit.Gigapascal;
                case PressureUnit.Hectopascal:
                    return UNU.PressureUnit.Hectopascal;
                case PressureUnit.InchOfMercury:
                    return UNU.PressureUnit.InchOfMercury;
                case PressureUnit.InchOfWaterColumn:
                    return UNU.PressureUnit.InchOfWaterColumn;
                case PressureUnit.Kilobar:
                    return UNU.PressureUnit.Kilobar;
                case PressureUnit.KilogramForcePerSquareCentimeter:
                    return UNU.PressureUnit.KilogramForcePerSquareCentimeter;
                case PressureUnit.KilogramForcePerSquareMeter:
                    return UNU.PressureUnit.KilogramForcePerSquareMeter;
                case PressureUnit.KilogramForcePerSquareMillimeter:
                    return UNU.PressureUnit.KilogramForcePerSquareMillimeter;
                case PressureUnit.KilonewtonPerSquareCentimeter:
                    return UNU.PressureUnit.KilonewtonPerSquareCentimeter;
                case PressureUnit.KilonewtonPerSquareMeter:
                    return UNU.PressureUnit.KilonewtonPerSquareMeter;
                case PressureUnit.KilonewtonPerSquareMillimeter:
                    return UNU.PressureUnit.KilonewtonPerSquareMillimeter;
                case PressureUnit.Kilopascal:
                    return UNU.PressureUnit.Kilopascal;
                case PressureUnit.KilopoundForcePerSquareFoot:
                    return UNU.PressureUnit.KilopoundForcePerSquareFoot;
                case PressureUnit.KilopoundForcePerSquareInch:
                    return UNU.PressureUnit.KilopoundForcePerSquareInch;
                case PressureUnit.Megabar:
                    return UNU.PressureUnit.Megabar;
                case PressureUnit.MeganewtonPerSquareMeter:
                    return UNU.PressureUnit.MeganewtonPerSquareMeter;
                case PressureUnit.Megapascal:
                    return UNU.PressureUnit.Megapascal;
                case PressureUnit.MeterOfHead:
                    return UNU.PressureUnit.MeterOfHead;
                case PressureUnit.Microbar:
                    return UNU.PressureUnit.Microbar;
                case PressureUnit.Micropascal:
                    return UNU.PressureUnit.Micropascal;
                case PressureUnit.Millibar:
                    return UNU.PressureUnit.Millibar;
                case PressureUnit.MillimeterOfMercury:
                    return UNU.PressureUnit.MillimeterOfMercury;
                case PressureUnit.Millipascal:
                    return UNU.PressureUnit.Millipascal;
                case PressureUnit.NewtonPerSquareCentimeter:
                    return UNU.PressureUnit.NewtonPerSquareCentimeter;
                case PressureUnit.NewtonPerSquareMeter:
                    return UNU.PressureUnit.NewtonPerSquareMeter;
                case PressureUnit.NewtonPerSquareMillimeter:
                    return UNU.PressureUnit.NewtonPerSquareMillimeter;
                case PressureUnit.Pascal:
                    return UNU.PressureUnit.Pascal;
                case PressureUnit.PoundForcePerSquareFoot:
                    return UNU.PressureUnit.PoundForcePerSquareFoot;
                case PressureUnit.PoundForcePerSquareInch:
                    return UNU.PressureUnit.PoundForcePerSquareInch;
                case PressureUnit.PoundPerInchSecondSquared:
                    return UNU.PressureUnit.PoundPerInchSecondSquared;
                case PressureUnit.TechnicalAtmosphere:
                    return UNU.PressureUnit.TechnicalAtmosphere;
                case PressureUnit.TonneForcePerSquareCentimeter:
                    return UNU.PressureUnit.TonneForcePerSquareCentimeter;
                case PressureUnit.TonneForcePerSquareMeter:
                    return UNU.PressureUnit.TonneForcePerSquareMeter;
                case PressureUnit.TonneForcePerSquareMillimeter:
                    return UNU.PressureUnit.TonneForcePerSquareMillimeter;
                case PressureUnit.Torr:
                    return UNU.PressureUnit.Torr;
                case PressureUnit.Undefined:
                default:
                    return UNU.PressureUnit.Undefined;
            }
        }
    }
}


