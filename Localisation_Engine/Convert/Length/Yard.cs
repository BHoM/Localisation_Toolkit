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
        [Description("Convert yard into SI units (meter)")]
        [Input("yard", "Yard measurement")]
        [Output("si", "Yard represented as SI units (meter)")]
        public static double FromYard(this double yard)
        {
            return yard * 0.9144;
        }

        [Description("Convert SI units (meter) into yard")]
        [Input("si", "SI measurement (meter)")]
        [Output("yard", "SI units (meter) represented as yard")]
        public static double ToYard(this double si)
        {
            return si / 0.9144;
        }
    }
}
