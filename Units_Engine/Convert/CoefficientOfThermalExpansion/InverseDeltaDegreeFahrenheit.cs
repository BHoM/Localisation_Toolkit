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
using UnitsNet;

namespace BH.Engine.Units
{
    public static partial class Convert
    {
        [Description("Convert SI units (inverse delta Kelvins) into inverse delta degress Fahrenheit")]
        [Input("inverseDeltaKelvins", "The number of inverse delta Kelvins to convert", typeof(ThermalExpansionCoefficient))]
        [Output("inverseDeltaDegreesFahrenheit", "The number of inverse delta degrees Fahrenheit")]
        public static double ToInverseDeltaDegreeFahrenheit(this double inverseDeltaKelvins)
        {
            UN.QuantityValue qv = inverseDeltaKelvins;
            return UN.UnitConverter.Convert(qv, CoefficientOfThermalExpansionUnit.PerKelvin, CoefficientOfThermalExpansionUnit.PerDegreeFahrenheit);
        }

        [Description("Convert inverse delta degrees Fahrenheit into SI units (inverse delta Kelvins)")]
        [Input("inverseDeltaDegreesFahrenheit", "The number of inverse delta degrees Fahrenheit to convert")]
        [Output("inverseDeltaKelvins", "The number of inverse delta Kelvins", typeof(ThermalExpansionCoefficient))]
        public static double FromInverseDeltaDegreeFahrenheit(this double inverseDeltaDegreesFahrenheit)
        {
            UN.QuantityValue qv = inverseDeltaDegreesFahrenheit;
            return UN.UnitConverter.Convert(qv, CoefficientOfThermalExpansionUnit.PerDegreeFahrenheit, CoefficientOfThermalExpansionUnit.PerKelvin);
        }
    }
}





