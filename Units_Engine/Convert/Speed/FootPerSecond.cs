/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2025, the respective contributors. All rights reserved.
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
        [Description("Convert SI units (metres per second squared) into feet per second squared")]
        [Input("metresPerSecond", "The number of metres per second squared to convert", typeof(Acceleration))]
        [Output("feetPerSecond", "The number of feet per second squared")]
        public static double ToFootPerSecond(this double metresPerSecond)
        {
            UN.QuantityValue qv = metresPerSecond;
            return UN.UnitConverter.Convert(qv, SpeedUnit.MeterPerSecond, SpeedUnit.FootPerSecond);
        }

        [Description("Convert feet per second squared into SI units (metres per second squared)")]
        [Input("feetPerSecond", "The number of feet per second squared to convert")]
        [Output("metresPerSecond", "The number of metres per second squared", typeof(Acceleration))]
        public static double FromFootPerSecond(this double feetPerSecond)
        {
            UN.QuantityValue qv = feetPerSecond;
            return UN.UnitConverter.Convert(qv, SpeedUnit.FootPerSecond, SpeedUnit.MeterPerSecond);
        }
    }
}





