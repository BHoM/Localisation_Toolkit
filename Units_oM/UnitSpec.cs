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

using System;
using System.ComponentModel;

namespace BH.oM.Units
{
    [Description("Specification linking a unit symbol to its unit enumeration value and the SI unit its quantity converts to.")]
    public class UnitSpec
    {
        [Description("The resolved unit. Null for a dimensionless value, in which case no conversion is applied.")]
        public virtual Enum Unit { get; set; } = null;

        [Description("The SI unit that this quantity converts to and from, as defined by the BHoM convention for the quantity.")]
        public virtual Enum SIUnit { get; set; } = null;

        [Description("Name of the quantity the unit belongs to, e.g. \"Force\". Empty for a dimensionless value.")]
        public virtual string QuantityName { get; set; } = "";
    }
}
