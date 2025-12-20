/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2026, the respective contributors. All rights reserved.
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

using BH.oM.Base.Attributes;
using BH.oM.Quantities.Attributes;
using System.ComponentModel;
using UN = UnitsNet; //This is to avoid clashes between UnitsNet quantity attributes and BHoM quantity attributes
using UnitsNet.Units;

namespace BH.Engine.Units
{
    public static partial class Convert
    {
        [Description("Convert SI units (joules) into kilowatt-hours.")]
        [Input("joules", "The number of joules to convert.", typeof(Energy))]
        [Output("kilowattHours", "The number of kilowatt-hours.")]
        public static double ToKilowattHour(this double joules)
        {
            UN.QuantityValue qv = joules;
            return UN.UnitConverter.Convert(qv, EnergyUnit.Joule, EnergyUnit.KilowattHour);
        }

        [Description("Convert kilowatt-hours into SI units (joules).")]
        [Input("kilowattHours", "The number of kilowatt-hours to convert.")]
        [Output("joules", "The number of joules.", typeof(Energy))]
        public static double FromKilowattHour(this double kilowattHours)
        {
            UN.QuantityValue qv = kilowattHours;
            return UN.UnitConverter.Convert(qv, EnergyUnit.KilowattHour, EnergyUnit.Joule);
        }
    }
}



