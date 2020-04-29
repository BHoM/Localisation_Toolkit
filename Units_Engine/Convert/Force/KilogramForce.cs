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
        [Description("Convert SI units (Newtons) into kilograms-force")]
        [Input("newtons", "The number of Newtons to convert", typeof(Force))]
        [Output("kilogramsForce", "The number of kilograms-force")]
        public static double ToKilogramForce(this double newtons)
        {
            UN.QuantityValue qv = newtons;
            return UN.UnitConverter.Convert(qv, ForceUnit.Newton, ForceUnit.KilogramForce);
        }

        [Description("Convert kilograms-force into SI units (Newtons)")]
        [Input("kilogramsForce", "The number of kilograms-force to convert")]
        [Output("newtons", "The number of Newtons", typeof(Force))]
        public static double FromKilogramForce(this double kilogramsForce)
        {
            UN.QuantityValue qv = kilogramsForce;
            return UN.UnitConverter.Convert(qv, ForceUnit.KilogramForce, ForceUnit.Newton);
        }
    }
}
