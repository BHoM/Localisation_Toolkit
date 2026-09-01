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

        [Description("Converts an SI value to the given unit symbol, e.g. 0.012 m → 12 \"mm\".")]
        [Input("siValue", "The value in SI units.")]
        [Input("unitSymbol", "Unit symbol to convert to (e.g. \"mm\", \"kN\", \"MPa\"). Case-sensitive. An empty symbol or \"-\" leaves the value unchanged.")]
        [Output("value", "The value in the specified unit, or NaN if the unit is unrecognised.")]
        public static double ToUnit(this double siValue, string unitSymbol)
        {
            UnitSpec spec = Query.ResolveUnit(unitSymbol);
            if (spec == null)
                return double.NaN;

            if (spec.Unit == null)
                return siValue;

            return ConvertUnit(siValue, spec.SIUnit, spec.Unit, unitSymbol);
        }

        /***************************************************/
    }
}
