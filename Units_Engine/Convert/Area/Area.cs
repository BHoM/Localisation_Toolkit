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

        [Description("Convert a area into SI units (squareMetres).")]
        [Input("area", "The quantity to convert.")]
        [Input("unit", "The unit in which the quantity is defined. This can be a string, or you can use the BHoM Enum AreaUnit.")]
        [Output("squareMetres", "The equivalent number of squareMetres.")]
        public static double FromArea(this double area, object unit)
        {
            UN.QuantityValue qv = area;
            return UN.UnitConverter.Convert(qv, ToAreaUnit(unit), UNU.AreaUnit.SquareMeter);
        }

        /***************************************************/

        [Description("Convert SI units (squareMetres) into another area unit.")]
        [Input("squareMetres", "The number of squareMetres to convert.")]
        [Input("unit", "The unit to convert to. This can be a string, or you can use the BHoM Enum AreaUnit.")]
        [Output("area", "The equivalent quantity defined in the specified unit.")]
        public static double ToArea(this double squareMetres, object unit)
        {
            UN.QuantityValue qv = squareMetres;
            return UN.UnitConverter.Convert(qv, UNU.AreaUnit.SquareMeter, ToAreaUnit(unit));
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        private static UNU.AreaUnit ToAreaUnit(object unit)
        {
            if (unit.GetType() == typeof(string))
                unit = unit.ToString().ToLower();

            switch (unit)
            {
                case AreaUnit.Acre:
                    return UNU.AreaUnit.Acre;
                case AreaUnit.Hectare:
                    return UNU.AreaUnit.Hectare;
                case AreaUnit.SquareCentimeter:
                    return UNU.AreaUnit.SquareCentimeter;
                case AreaUnit.SquareDecimeter:
                    return UNU.AreaUnit.SquareDecimeter;
                case AreaUnit.SquareFoot:
                    return UNU.AreaUnit.SquareFoot;
                case AreaUnit.SquareInch:
                    return UNU.AreaUnit.SquareInch;
                case AreaUnit.SquareKilometer:
                    return UNU.AreaUnit.SquareKilometer;
                case AreaUnit.SquareMeter:
                    return UNU.AreaUnit.SquareMeter;
                case AreaUnit.SquareMicrometer:
                    return UNU.AreaUnit.SquareMicrometer;
                case AreaUnit.SquareMile:
                    return UNU.AreaUnit.SquareMile;
                case AreaUnit.SquareMillimeter:
                    return UNU.AreaUnit.SquareMillimeter;
                case AreaUnit.SquareNauticalMile:
                    return UNU.AreaUnit.SquareNauticalMile;
                case AreaUnit.SquareYard:
                    return UNU.AreaUnit.SquareYard;
                case AreaUnit.UsSurveySquareFoot:
                    return UNU.AreaUnit.UsSurveySquareFoot;
                case AreaUnit.Undefined:
                default:
                    return UNU.AreaUnit.Undefined;
            }
        }
    }
}


