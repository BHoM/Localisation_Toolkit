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

using UN = UnitsNet; //This is to avoid clashes between UnitsNet quantity attributes and BHoM quantity attributes

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

        [Description("Converts a value from the given unit symbol to SI, e.g. 12 \"mm\" → 0.012 m.")]
        [Input("value", "The value in the specified unit.")]
        [Input("unitSymbol", "Unit symbol (e.g. \"mm\", \"kN\", \"MPa\"). Case-sensitive. An empty symbol or \"-\" leaves the value unchanged.")]
        [Output("siValue", "The value in SI units, or NaN if the unit is unrecognised.")]
        public static double FromUnit(this double value, string unitSymbol)
        {
            UnitSpec spec = Query.ResolveUnit(unitSymbol);
            if (spec == null)
                return double.NaN;

            if (spec.Unit == null)
                return value;

            return ConvertUnit(value, spec.Unit, spec.SIUnit, unitSymbol);
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        // Shared conversion step for FromUnit and ToUnit. The unit and its SI counterpart both come from the
        // same UnitSpec, so the only difference between the two is which way round they are passed.
        private static double ConvertUnit(double value, Enum fromUnit, Enum toUnit, string unitSymbol)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
            {
                Compute.RecordError("Quantity is not a real number.");
                return double.NaN;
            }

            if (UN.UnitConverter.TryConvert(value, fromUnit, toUnit, out double result))
                return result;

            Compute.RecordError($"No conversion is available between '{unitSymbol}' and its SI unit.");
            return double.NaN;
        }

        /***************************************************/
    }
}
