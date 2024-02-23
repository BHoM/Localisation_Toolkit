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
using UnitsNet.Units;

using System.ComponentModel;
using BH.oM.Base.Attributes;
using BH.Engine.Base;
using BH.oM.Quantities.Attributes;

namespace BH.Engine.Units
{
    public static partial class Convert
    {
        [Description("Convert SI units (kilograms) into long tons.")]
        [Input("kilograms", "The number of kilograms to convert.", typeof(Mass))]
        [Output("longTons", "The number of long tons.")]
        public static double ToLongTon(this double kilograms)
        {
            UN.QuantityValue qv = kilograms;
            return UN.UnitConverter.Convert(qv, MassUnit.Kilogram, MassUnit.LongTon);
        }

        [Description("Convert long tons into SI units (kilograms).")]
        [Input("longTons", "The number of long tons to convert.")]
        [Output("kilograms", "The number of kilograms.", typeof(Mass))]
        public static double FromLongTon(this double longTons)
        {
            UN.QuantityValue qv = longTons;
            return UN.UnitConverter.Convert(qv, MassUnit.LongTon, MassUnit.Kilogram);
        }
    }
}

