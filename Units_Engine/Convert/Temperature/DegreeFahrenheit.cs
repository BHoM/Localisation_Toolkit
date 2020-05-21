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
        [Description("Convert SI units (Kelvins) into degrees Fahrenheit")]
        [Input("kelvins", "The number of Kelvins to convert", typeof(Temperature))]
        [Output("DegreesFahrenheit", "The number of degrees Fahrenheit")]
        public static double ToDegreeFahrenheit(this double kelvins)
        {
            UN.QuantityValue qv = kelvins;
            return UN.UnitConverter.Convert(qv, TemperatureUnit.Kelvin, TemperatureUnit.DegreeFahrenheit);
        }

        [Description("Convert degrees Fahrenheit into SI units (Kelvins)")]
        [Input("degreesFahrenheit", "The number of degrees Fahrenheit to convert")]
        [Output("kelvins", "The number of Kelvins", typeof(Temperature))]
        public static double FromDegreeFahrenheit(this double degreesFahrenheit)
        {
            UN.QuantityValue qv = degreesFahrenheit;
            return UN.UnitConverter.Convert(qv, TemperatureUnit.DegreeFahrenheit, TemperatureUnit.Kelvin);
        }
    }
}
