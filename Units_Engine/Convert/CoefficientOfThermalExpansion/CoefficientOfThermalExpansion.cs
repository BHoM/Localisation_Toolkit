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

        [Description("Convert a coefficientOfThermalExpansion into SI units (inverseDeltaKelvins).")]
        [Input("coefficientOfThermalExpansion", "The quantity to convert.")]
        [Input("unit", "The unit in which the quantity is defined. This can be a string, or you can use the BHoM Enum CoefficientOfThermalExpansionUnit.")]
        [Output("inverseDeltaKelvins", "The equivalent number of inverseDeltaKelvins.")]
        public static double FromCoefficientOfThermalExpansion(this double coefficientOfThermalExpansion, object unit)
        {
            if (Double.IsNaN(coefficientOfThermalExpansion) || Double.IsInfinity(coefficientOfThermalExpansion))
            {
                Compute.RecordError("Quantity is not a real number.");
                return double.NaN;
            }

            UN.QuantityValue qv = coefficientOfThermalExpansion;
            UNU.CoefficientOfThermalExpansionUnit unitSI = UNU.CoefficientOfThermalExpansionUnit.PerKelvin;
            UNU.CoefficientOfThermalExpansionUnit? unUnit = ToCoefficientOfThermalExpansionUnit(unit);

            if (unUnit != null)
                return UN.UnitConverter.Convert(qv, unUnit, unitSI);

            Compute.RecordError("Unit was undefined. Please use the appropriate BHoM Units Enum.");
            return double.NaN;
        }

        /***************************************************/

        [Description("Convert SI units (inverseDeltaKelvins) into another coefficientOfThermalExpansion unit.")]
        [Input("inverseDeltaKelvins", "The number of inverseDeltaKelvins to convert.")]
        [Input("unit", "The unit to convert to. This can be a string, or you can use the BHoM Enum CoefficientOfThermalExpansionUnit.")]
        [Output("coefficientOfThermalExpansion", "The equivalent quantity defined in the specified unit.")]
        public static double ToCoefficientOfThermalExpansion(this double inverseDeltaKelvins, object unit)
        {
            if (Double.IsNaN(inverseDeltaKelvins) || Double.IsInfinity(inverseDeltaKelvins))
            {
                Compute.RecordError("Quantity is not a real number.");
                return double.NaN;
            }

            UN.QuantityValue qv = inverseDeltaKelvins;
            UNU.CoefficientOfThermalExpansionUnit unitSI = UNU.CoefficientOfThermalExpansionUnit.PerKelvin;
            UNU.CoefficientOfThermalExpansionUnit? unUnit = ToCoefficientOfThermalExpansionUnit(unit);

            if (unUnit != null)
                return UN.UnitConverter.Convert(qv, unitSI, unUnit);

            Compute.RecordError("Unit was undefined. Please use the appropriate BHoM Units Enum.");
            return double.NaN;
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        private static UNU.CoefficientOfThermalExpansionUnit? ToCoefficientOfThermalExpansionUnit(object unit)
        {
            if (unit == null || unit.ToString() == null)
                return null;

            if (unit.GetType() == typeof(string))
            {
                CoefficientOfThermalExpansionUnit unitEnum;
                if (Enum.TryParse<CoefficientOfThermalExpansionUnit>(unit.ToString(), out unitEnum))
                    unit = unitEnum;
                else
                    unit = unit.ToString().ToLower();
            }

            switch (unit)
            {
                case CoefficientOfThermalExpansionUnit.InverseDegreeCelsius:
                    return UNU.CoefficientOfThermalExpansionUnit.PerDegreeCelsius;
                case CoefficientOfThermalExpansionUnit.InverseDegreeFahrenheit:
                    return UNU.CoefficientOfThermalExpansionUnit.PerDegreeFahrenheit;
                case CoefficientOfThermalExpansionUnit.InverseKelvin:
                    return UNU.CoefficientOfThermalExpansionUnit.PerKelvin;
                default:
                    return null;

            }
        }
    }
}






