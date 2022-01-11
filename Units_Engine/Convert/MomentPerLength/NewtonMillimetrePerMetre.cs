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
        [Description("Convert SI units (Newton-metres per metre) into Newton-millimetres per metre")]
        [Input("newtonMetresPerMetre", "The number of Newton-metres per metre to convert", typeof(MomentPerUnitLength))]
        [Output("newtonMillimetresPerMetre", "The number of Newton-millimetres per metre")]
        public static double ToNewtonMillimetrePerMetre(this double newtonMetresPerMetre)
        {
            UN.QuantityValue qv = newtonMetresPerMetre;
            return UN.UnitConverter.Convert(qv, TorquePerLengthUnit.NewtonMeterPerMeter, TorquePerLengthUnit.NewtonMillimeterPerMeter);
        }

        [Description("Convert Newton-millimetres per metre into SI units (Newton-metres per metre)")]
        [Input("newtonMillimetresPerMetre", "The number of Newton-millimetres per metre to convert")]
        [Output("newtonMetresPerMetre", "The number of Newton-metres per metre", typeof(ForcePerUnitLength))]
        public static double FromNewtonMillimetrePerMetre(this double newtonMillimetresPerMetre)
        {
            UN.QuantityValue qv = newtonMillimetresPerMetre;
            return UN.UnitConverter.Convert(qv, TorquePerLengthUnit.NewtonMillimeterPerMeter, TorquePerLengthUnit.NewtonMeterPerMeter);
        }
    }
}


