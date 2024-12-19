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

using System.ComponentModel;
using BH.oM.Base.Attributes;
using BH.Engine.Base;
using BH.oM.Quantities.Attributes;
using UnitsNet.Units;

namespace BH.Engine.Units
{
    public static partial class Convert
    {
        [Description("Convert SI units (joules) into British thermal units")]
        [Input("joules", "The number of joules to convert", typeof(Energy))]
        [Output("britishThermalUnits", "The number of British thermal units")]
        public static double ToBritishThermalUnit(this double joules)
        {
            UN.QuantityValue qv = joules;
            return UN.UnitConverter.Convert(qv, EnergyUnit.Joule, EnergyUnit.BritishThermalUnit);
        }

        [Description("Convert British thermal units into SI units (joules)")]
        [Input("britishThermalUnits", "The number of British thermal units to convert")]
        [Output("joules", "The number of joules", typeof(Energy))]
        public static double FromBritishThermalUnit(this double britishThermalUnits)
        {
            UN.QuantityValue qv = britishThermalUnits;
            return UN.UnitConverter.Convert(qv, EnergyUnit.BritishThermalUnit, EnergyUnit.Joule);
        }
    }
}


