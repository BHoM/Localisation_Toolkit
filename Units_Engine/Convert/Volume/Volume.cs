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
        [Description("Convert a volume into SI units (cubicMeter).")]
        [Input("volume", "The quantity to convert.")]
        [Input("unit", "The unit in which the quantity is defined. This can be a string, or you can use the BHoM Enum VolumeUnit.")]
        [Output("cubicMeter", "The equivalent number of cubicMeter.")]
        public static double FromVolume(this double volume, object unit)
        {
            UN.QuantityValue qv = volume;
            return UN.UnitConverter.Convert(qv, ToVolumeUnit(unit), UNU.VolumeUnit.CubicMeter);
        }

        /***************************************************/

        [Description("Convert SI units (cubicMeter) into another volume unit.")]
        [Input("cubicMeter", "The number of cubicMeter to convert.")]
        [Input("unit", "The unit to convert to. This can be a string, or you can use the BHoM Enum VolumeUnit.")]
        [Output("volume", "The equivalent quantity defined in the specified unit.")]
        public static double ToVolume(this double cubicMeter, object unit)
        {
            UN.QuantityValue qv = cubicMeter;
            return UN.UnitConverter.Convert(qv, UNU.VolumeUnit.CubicMeter, ToVolumeUnit(unit));
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        private static UNU.VolumeUnit ToVolumeUnit(object unit)
        {
            if (unit.GetType() == typeof(string))
                unit = unit.ToString().ToLower();

            switch (unit)
            {
                case "acrefoot":
                case "acre-foot":
                case "acre-ft":
                case VolumeUnit.AcreFoot:
                    return UNU.VolumeUnit.AcreFoot;
                case VolumeUnit.AuTablespoon:
                    return UNU.VolumeUnit.AuTablespoon;
                case VolumeUnit.Centiliter:
                    return UNU.VolumeUnit.Centiliter;
                case VolumeUnit.CubicCentimeter:
                    return UNU.VolumeUnit.CubicCentimeter;
                case VolumeUnit.CubicDecimeter:
                    return UNU.VolumeUnit.CubicDecimeter;
                case VolumeUnit.CubicFoot:
                    return UNU.VolumeUnit.CubicFoot;
                case VolumeUnit.CubicHectometer:
                    return UNU.VolumeUnit.CubicHectometer;
                case "inch^3":
                case VolumeUnit.CubicInch:
                    return UNU.VolumeUnit.CubicInch;
                case VolumeUnit.CubicKilometer:
                    return UNU.VolumeUnit.CubicKilometer;
                case "m^3":
                case VolumeUnit.CubicMeter:
                    return UNU.VolumeUnit.CubicMeter;
                case VolumeUnit.CubicMicrometer:
                    return UNU.VolumeUnit.CubicMicrometer;
                case VolumeUnit.CubicMile:
                    return UNU.VolumeUnit.CubicMile;
                case VolumeUnit.CubicMillimeter:
                    return UNU.VolumeUnit.CubicMillimeter;
                case VolumeUnit.CubicYard:
                    return UNU.VolumeUnit.CubicYard;
                case VolumeUnit.DecausGallon:
                    return UNU.VolumeUnit.DecausGallon;
                case VolumeUnit.Deciliter:
                    return UNU.VolumeUnit.Deciliter;
                case VolumeUnit.DeciusGallon:
                    return UNU.VolumeUnit.DeciusGallon;
                case VolumeUnit.HectocubicFoot:
                    return UNU.VolumeUnit.HectocubicFoot;
                case VolumeUnit.HectocubicMeter:
                    return UNU.VolumeUnit.HectocubicMeter;
                case VolumeUnit.Hectoliter:
                    return UNU.VolumeUnit.Hectoliter;
                case VolumeUnit.HectousGallon:
                    return UNU.VolumeUnit.HectousGallon;
                case VolumeUnit.ImperialBeerBarrel:
                    return UNU.VolumeUnit.ImperialBeerBarrel;
                case VolumeUnit.ImperialGallon:
                    return UNU.VolumeUnit.ImperialGallon;
                case VolumeUnit.ImperialOunce:
                    return UNU.VolumeUnit.ImperialOunce;
                case VolumeUnit.ImperialPint:
                    return UNU.VolumeUnit.ImperialPint;
                case VolumeUnit.KilocubicFoot:
                    return UNU.VolumeUnit.KilocubicFoot;
                case VolumeUnit.KilocubicMeter:
                    return UNU.VolumeUnit.KilocubicMeter;
                case VolumeUnit.KiloimperialGallon:
                    return UNU.VolumeUnit.KiloimperialGallon;
                case VolumeUnit.Kiloliter:
                    return UNU.VolumeUnit.Kiloliter;
                case VolumeUnit.KilousGallon:
                    return UNU.VolumeUnit.KilousGallon;
                case "liter":
                case VolumeUnit.Liter:
                    return UNU.VolumeUnit.Liter;
                case VolumeUnit.MegacubicFoot:
                    return UNU.VolumeUnit.MegacubicFoot;
                case VolumeUnit.MegaimperialGallon:
                    return UNU.VolumeUnit.MegaimperialGallon;
                case VolumeUnit.Megaliter:
                    return UNU.VolumeUnit.Megaliter;
                case VolumeUnit.MegausGallon:
                    return UNU.VolumeUnit.MegausGallon;
                case VolumeUnit.MetricCup:
                    return UNU.VolumeUnit.MetricCup;
                case VolumeUnit.MetricTeaspoon:
                    return UNU.VolumeUnit.MetricTeaspoon;
                case VolumeUnit.Microliter:
                    return UNU.VolumeUnit.Microliter;
                case VolumeUnit.Milliliter:
                    return UNU.VolumeUnit.Milliliter;
                case VolumeUnit.OilBarrel:
                    return UNU.VolumeUnit.OilBarrel;
                case VolumeUnit.UkTablespoon:
                    return UNU.VolumeUnit.UkTablespoon;
                case VolumeUnit.UsBeerBarrel:
                    return UNU.VolumeUnit.UsBeerBarrel;
                case VolumeUnit.UsCustomaryCup:
                    return UNU.VolumeUnit.UsCustomaryCup;
                case VolumeUnit.UsGallon:
                    return UNU.VolumeUnit.UsGallon;
                case VolumeUnit.UsLegalCup:
                    return UNU.VolumeUnit.UsLegalCup;
                case VolumeUnit.UsOunce:
                    return UNU.VolumeUnit.UsOunce;
                case VolumeUnit.UsPint:
                    return UNU.VolumeUnit.UsPint;
                case VolumeUnit.UsQuart:
                    return UNU.VolumeUnit.UsQuart;
                case VolumeUnit.UsTablespoon:
                    return UNU.VolumeUnit.UsTablespoon;
                case VolumeUnit.UsTeaspoon:
                    return UNU.VolumeUnit.UsTeaspoon;
                case VolumeUnit.Undefined:
                default:
                    return UNU.VolumeUnit.Undefined;
            }
        }
    }
}


