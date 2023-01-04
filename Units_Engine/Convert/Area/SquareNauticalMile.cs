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
        [Description("Convert SI units (square metres) into square nautical miles")]
        [Input("squareMetres", "The number of square metres to convert", typeof(Area))]
        [Output("squareNauticalMiles", "The number of square nautical miles")]
        public static double ToSquareNauticalMile(this double squareMetres)
        {
            UN.QuantityValue qv = squareMetres;
            return UN.UnitConverter.Convert(qv, AreaUnit.SquareMeter, AreaUnit.SquareNauticalMile);
        }

        [Description("Convert square nautical miles into SI units (square metres)")]
        [Input("squareNauticalMiles", "The number of square nautical miles to convert")]
        [Output("squareMetres", "The number of square metres", typeof(Area))]
        public static double FromSquareNauticalMile(this double squareNauticalMiles)
        {
            UN.QuantityValue qv = squareNauticalMiles;
            return UN.UnitConverter.Convert(qv, AreaUnit.SquareNauticalMile, AreaUnit.SquareMeter);
        }
    }
}



