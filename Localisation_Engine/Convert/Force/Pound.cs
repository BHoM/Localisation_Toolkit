/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2019, the respective contributors. All rights reserved.
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

using System.ComponentModel;
using BH.oM.Reflection.Attributes;

namespace BH.Engine.Localisation.Length
{
    public static partial class Convert
    {
        [Description("Convert pound force into SI units (Newton)")]
        [Input("pound", "Pound force measurement")]
        [Output("si", "Pound force represented as SI units (Newton)")]
        public static double FromPoundF(this double pound)
        {
            return pound * 4.4482216152605;
        }

        [Description("Convert SI units (Newton) into pound force")]
        [Input("si", "SI measurement (Newton)")]
        [Output("pound", "SI units (Newton) represented as pound force")]
        public static double ToPoundF(this double si)
        {
            return si / 4.4482216152605;
        }
    }
}
