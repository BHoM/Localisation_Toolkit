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
using UnitsNet.Units;
using System.ComponentModel;
using BH.oM.Base.Attributes;
using BH.oM.Quantities.Attributes;

namespace BH.Engine.Units
{
    public static partial class Convert
    {
        [Description("Convert SI units (molePerKilogram) into molePerGram.")]
        [Input("molePerKilograms", "The number of molePerKilogram to convert.", typeof(Molality))]
        [Output("molePerGrams", "The number of molePerGram.")]
        public static double ToMolePerGram(this double molePerKilograms)
        {
            UN.QuantityValue qv = molePerKilograms;
            return UN.UnitConverter.Convert(qv, MolalityUnit.MolePerKilogram, MolalityUnit.MolePerGram);
        }

        /***************************************************/

        [Description("Convert molePerGram into SI units (molePerKilogram).")]
        [Input("molePerGrams", "The number of molePerGrams to convert.")]
        [Output("molePerKilograms", "The number of molePerKilograms.", typeof(Molality))]
        public static double FromMolePerGram(this double molePerGrams)
        {
            UN.QuantityValue qv = molePerGrams;
            return UN.UnitConverter.Convert(qv, MolalityUnit.MolePerGram, MolalityUnit.MolePerKilogram);
        }
    }
}


