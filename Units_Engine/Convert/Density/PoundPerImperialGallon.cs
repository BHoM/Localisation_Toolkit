/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
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
        [Description("Convert SI units (kilograms per cubic metre) into pounds per imperial gallon")]
        [Input("kilogramsPerCubicMetre", "The number of kilograms per cubic metre to convert", typeof(Density))]
        [Output("poundsPerImperialGallon", "The number of pounds per cubic imperial gallon")]
        public static double ToPoundPerImperialGallon(this double kilogramsPerCubicMetre)
        {
            UN.QuantityValue qv = kilogramsPerCubicMetre;
            return UN.UnitConverter.Convert(qv, DensityUnit.KilogramPerCubicMeter, DensityUnit.PoundPerImperialGallon);
        }

        [Description("Convert pounds per imperial gallon into SI units (kilograms per cubic metre)")]
        [Input("poundsPerImperialGallon", "The number of pounds per imperial gallon to convert")]
        [Output("kilogramsPerCubicMetre", "The number of kilograms per cubic metre", typeof(Density))]
        public static double FromPoundPerImperialGallon(this double poundsPerImperialGallon)
        {
            UN.QuantityValue qv = poundsPerImperialGallon;
            return UN.UnitConverter.Convert(qv, DensityUnit.PoundPerImperialGallon, DensityUnit.KilogramPerCubicMeter);
        }
    }
}



