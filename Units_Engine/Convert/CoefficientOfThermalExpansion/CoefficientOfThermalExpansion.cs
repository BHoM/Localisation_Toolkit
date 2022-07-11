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

        [Description("Convert a coefficientOfThermalExpansion into SI units (inverseDeltaKelvins).")]
        [Input("coefficientOfThermalExpansion", "The quantity to convert.")]
        [Input("unit", "The unit in which the quantity is defined.")]
        [Output("inverseDeltaKelvins", "The equivalent number of inverseDeltaKelvins.")]
        public static double FromCoefficientOfThermalExpansion(this double coefficientOfThermalExpansion, object unit)
        {
            UN.QuantityValue qv = coefficientOfThermalExpansion;
            return UN.UnitConverter.Convert(qv, ToCoefficientOfThermalExpansionUnit(unit), CoefficientOfThermalExpansionUnit.InverseKelvin);
        }

        /***************************************************/

        [Description("Convert SI units (inverseDeltaKelvins) into another coefficientOfThermalExpansion unit.")]
        [Input("inverseDeltaKelvins", "The number of inverseDeltaKelvins to convert.")]
        [Input("unit", "The unit to convert to.")]
        [Output("coefficientOfThermalExpansion", "The equivalent quantity defined in the specified unit.")]
        public static double ToCoefficientOfThermalExpansion(this double inverseDeltaKelvins, object unit)
        {
            UN.QuantityValue qv = inverseDeltaKelvins;
            return UN.UnitConverter.Convert(qv, CoefficientOfThermalExpansionUnit.InverseKelvin, ToCoefficientOfThermalExpansionUnit(unit));
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        private static UNU.CoefficientOfThermalExpansionUnit ToCoefficientOfThermalExpansionUnit(object unit)
        {
            if (unit.GetType() == typeof(string))
                unit = unit.ToString().ToLower();

            switch (unit)
            {
                case CoefficientOfThermalExpansionUnit.InverseDegreeCelsius:
                    return UNU.CoefficientOfThermalExpansionUnit.InverseDegreeCelsius;
                case CoefficientOfThermalExpansionUnit.InverseDegreeFahrenheit:
                    return UNU.CoefficientOfThermalExpansionUnit.InverseDegreeFahrenheit;
                case CoefficientOfThermalExpansionUnit.InverseKelvin:
                    return UNU.CoefficientOfThermalExpansionUnit.InverseKelvin;
                case CoefficientOfThermalExpansionUnit.Undefined:
                default:
                    return UNU.CoefficientOfThermalExpansionUnit.Undefined;
            }
        }
    }
}


