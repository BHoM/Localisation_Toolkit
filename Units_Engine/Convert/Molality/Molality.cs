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

        [Description("Convert a molality into SI units (molePerKilogram).")]
        [Input("molality", "The quantity to convert.")]
        [Input("unit", "The unit in which the quantity is defined. This can be a string, or you can use the BHoM Enum MolalityUnit.")]
        [Output("molePerKilograms", "The equivalent number of kilograms.")]
        public static double FromMolality(this double molality, object unit)
        {
            if (Double.IsNaN(molality) || Double.IsInfinity(molality))
            {
                Compute.RecordError("Quantity is not a real number.");
                return double.NaN;
            }

            UN.QuantityValue qv = molality;
            UNU.MolalityUnit unitSI = UNU.MolalityUnit.MolePerKilogram;
            UNU.MolalityUnit unUnit = ToMolalityUnit(unit);
            return UN.UnitConverter.Convert(qv, unUnit, unitSI);
        }

        /***************************************************/

        [Description("Convert SI units (molePerKilogram) into another duration unit.")]
        [Input("molePerKilograms", "The number of molePerKilograms to convert.")]
        [Input("unit", "The unit to convert to. This can be a string, or you can use the BHoM Enum MolalityUnit.")]
        [Output("molality", "The equivalent quantity defined in the specified unit.")]
        public static double ToMolality(this double molality, object unit)
        {
            if (Double.IsNaN(molality) || Double.IsInfinity(molality))
            {
                Compute.RecordError("Quantity is not a real number.");
                return double.NaN;
            }

            UN.QuantityValue qv = molality;
            UNU.MolalityUnit unitSI = UNU.MolalityUnit.MolePerKilogram;
            UNU.MolalityUnit unUnit = ToMolalityUnit(unit);
            return UN.UnitConverter.Convert(qv, unitSI, unUnit);
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        private static UNU.MolalityUnit ToMolalityUnit(object unit)
        {
            if (unit == null || unit.ToString() == null)
                return UNU.MolalityUnit.MolePerKilogram;
            if (unit.GetType() == typeof(string))
            {
                DurationUnit unitEnum;
                if (Enum.TryParse<DurationUnit>(unit.ToString(), out unitEnum))
                    unit = unitEnum;
                else
                    unit = unit.ToString().ToLower();
            }

            switch (unit)
            {
                case MolalityUnit.MolePerGram:
                    return UNU.MolalityUnit.MolePerGram;
                case MolalityUnit.MolePerKilogram:
                default:
                    return UNU.MolalityUnit.MolePerKilogram;
            }
        }
    }
}
