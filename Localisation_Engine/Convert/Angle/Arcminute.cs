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

namespace BH.Engine.Localisation.Angle
{
    public static partial class Convert
    {
        [Description("Convert arcminute into SI units (radians)")]
        [Input("arcminute", "Arcminute measurement")]
        [Output("si", "Arcminute represented as SI units (radians)")]
        public static double FromArcminute(this double arcminute)
        {
            return arcminute * Math.PI / (60 * 180);
        }

        [Description("Convert SI units (radians) into arcminute")]
        [Input("si", "SI measurement (radians)")]
        [Output("arcminute", "SI units (radians) represented as arcminute")]
        public static double ToArcminute(this double si)
        {
            return si * (60 * 180) / Math.PI;
        }
    }
}
