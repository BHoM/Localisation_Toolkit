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
        [Description("Convert SI units (meter) into nautical miles")]
        [Input("meters", "The number of meters to convert", typeof(Length))]
        [Output("nauticalMiles", "The number of nautical miles")]
        public static double ToNauticalMile(double meters)
        {
            UN.QuantityValue qv = meters;
            return UN.UnitConverter.Convert(qv, LengthUnit.Meter, LengthUnit.NauticalMile);
        }

        [Description("Convert inch into SI units (meter)")]
        [Input("nauticalMiles", "The number of nautical miles to convert")]
        [Output("meters", "The number of meters", typeof(Length))]
        public static double FromNauticalMile(double nauticalMiles)
        {
            UN.QuantityValue qv = nauticalMiles;
            return UN.UnitConverter.Convert(qv, LengthUnit.NauticalMile, LengthUnit.Meter);
        }
    }
}
