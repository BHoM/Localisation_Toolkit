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

using System.ComponentModel;

namespace BH.oM.Units
{
    [Description("Categorises physical quantities for dispatch to the correct conversion method.")]
    public enum QuantityFamily
    {
        None = 0,
        Length = 1,
        Area = 2,
        Volume = 3,
        AreaMomentOfInertia = 4,
        Pressure = 5,
        Force = 6,
        Torque = 7,
        ForcePerLength = 8,
        Angle = 9,
        Mass = 10,
        Acceleration = 11,
        Density = 12,
        Energy = 13,
        Power = 14,
        Speed = 15,
        Temperature = 16,
        Time = 17,
    }
}
