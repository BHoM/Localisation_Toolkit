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
        [Description("Convert SI units (Kelvins) into degrees Celsius")]
        [Input("kelvins", "The change in Kelvins to convert", typeof(TemperatureDeltaUnit))]
        [Output("degreesCelsius", "The change in degrees Celsius")]
        public static double ToDeltaDegreeCelsius(this double kelvins)
        {
            UN.QuantityValue qv = kelvins;
            return UN.UnitConverter.Convert(qv, TemperatureDeltaUnit.Kelvin, TemperatureDeltaUnit.DegreeCelsius);
        }

        [Description("Convert degrees Celsius into SI units (Kelvins)")]
        [Input("degreesCelsius", "The change in degrees Celsius to convert")]
        [Output("kelvins", "The change in Kelvins", typeof(Temperature))]
        public static double FromDeltaDegreeCelsius(this double degreesCelsius)
        {
            UN.QuantityValue qv = degreesCelsius;
            return UN.UnitConverter.Convert(qv, TemperatureDeltaUnit.DegreeCelsius, TemperatureDeltaUnit.Kelvin);
        }
    }
}
