/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2024, the respective contributors. All rights reserved.
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
        [Description("Convert SI units (Pascals) into tonnes-force per square millimetre")]
        [Input("pascals", "The number of Pascals to convert", typeof(Pressure))]
        [Output("tonnesForcePerSquareMillimetre", "The number of tonnes-force per square millimetre")]
        public static double ToTonneForcePerSquareMillimetre(this double pascals)
        {
            UN.QuantityValue qv = pascals;
            return UN.UnitConverter.Convert(qv, PressureUnit.Pascal, PressureUnit.TonneForcePerSquareMillimeter);
        }

        [Description("Convert tonnes-force per square millimetre into SI units (Pascals)")]
        [Input("tonnesForcePerSquareMillimetre", "The number of tonnes-force per square millimetre to convert")]
        [Output("pascals", "The number of Pascals", typeof(Pressure))]
        public static double FromTonneForcePerSquareMillimetre(this double tonnesForcePerSquareMillimetre)
        {
            UN.QuantityValue qv = tonnesForcePerSquareMillimetre;
            return UN.UnitConverter.Convert(qv, PressureUnit.TonneForcePerSquareMillimeter, PressureUnit.Pascal);
        }
    }
}




