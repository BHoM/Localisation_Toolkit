/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2020, the respective contributors. All rights reserved.
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
using BH.oM.Reflection.Attributes;
using BH.oM.Quantities.Attributes;

namespace BH.Engine.Units
{
    public static partial class Convert
    {
        [Description("Convert SI units (metre) into feet")]
        [Input("metres", "The number of metres to convert", typeof(Length))]
        [Output("feet", "The number of feet")]
        public static double ToFeet(double metres)
        {
            UN.QuantityValue qv = metres;
            return UN.UnitConverter.Convert(qv, LengthUnit.Meter, LengthUnit.Foot);
        }

        [Description("Convert feet into SI units (metre)")]
        [Input("feet", "The number of feet to convert")]
        [Output("metres", "The number of metres", typeof(Length))]
        public static double FromFeet(double feet)
        {
            UN.QuantityValue qv = feet;
            return UN.UnitConverter.Convert(qv, LengthUnit.Foot, LengthUnit.Meter);
        }
    }
}
