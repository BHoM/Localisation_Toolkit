/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2022, the respective contributors. All rights reserved.
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
using UnitsNet;

namespace BH.Engine.Units
{
    public static partial class Convert
    {
        [Description("Convert SI units (Newton-metres) into Newton-centimetres")]
        [Input("newtonMetres", "The number of Newton-metres to convert", typeof(Moment))]
        [Output("newtonCentimetre", "The number of Newton-centimetres")]
        public static double ToNewtonCentimetre(this double newtonMetres)
        {
            UN.QuantityValue qv = newtonMetres;
            return UN.UnitConverter.Convert(qv, TorqueUnit.NewtonMeter, TorqueUnit.NewtonCentimeter);
        }

        [Description("Convert Newton-centimetres into SI units (Newton-metres)")]
        [Input("newtonCentimetres", "The number of Newton-centimetres to convert")]
        [Output("newtonMetres", "The number of Newton-metres", typeof(Moment))]
        public static double FromNewtonCentimetre(this double newtonCentimetres)
        {
            UN.QuantityValue qv = newtonCentimetres;
            return UN.UnitConverter.Convert(qv, TorqueUnit.NewtonCentimeter, TorqueUnit.NewtonMeter);
        }
    }
}


