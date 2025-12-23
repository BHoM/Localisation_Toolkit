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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UN = UnitsNet; //This is to avoid clashes between UnitsNet quantity attributes and BHoM quantity attributes
using UNU = UnitsNet.Units;

using System.ComponentModel;
using BH.oM.Base.Attributes;
using BH.oM.Units;
using BH.Engine.Base;

namespace BH.Engine.Units
{
    public static partial class Convert
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        [Description("Convert a measure of energy into SI units (joule).")]
        [Input("energy", "The quantity to convert.")]
        [Input("unit", "The unit in which the quantity is defined. This can be a string, or you can use the BHoM Enum EnergyUnit.")]
        [Output("joule", "The equivalent number of joules.")]
        public static double FromEnergy(this double energy, object unit)
        {
            if (Double.IsNaN(energy) || Double.IsInfinity(energy))
            {
                Compute.RecordError("Quantity is not a real number.");
                return double.NaN;
            }

            UN.QuantityValue qv = energy;
            UNU.EnergyUnit unitSI = UNU.EnergyUnit.Joule;
            UNU.EnergyUnit? unUnit = ToEnergyUnit(unit);

            if (unUnit != null)
                return UN.UnitConverter.Convert(qv, unUnit, unitSI);

            Compute.RecordError("Unit was undefined. Please use the appropriate BHoM Units Enum.");
            return double.NaN;
        }

        /***************************************************/

        [Description("Convert SI units (joule) into another energy unit.")]
        [Input("joule", "The number of joule to convert.")]
        [Input("unit", "The unit to convert to. This can be a string, or you can use the BHoM Enum EnergyUnit.")]
        [Output("energy", "The equivalent quantity defined in the specified unit.")]
        public static double ToEnergy(this double joule, object unit)
        {
            if (Double.IsNaN(joule) || Double.IsInfinity(joule))
            {
                Compute.RecordError("Quantity is not a real number.");
                return double.NaN;
            }

            UN.QuantityValue qv = joule;
            UNU.EnergyUnit unitSI = UNU.EnergyUnit.Joule;
            UNU.EnergyUnit? unUnit = ToEnergyUnit(unit);

            if (unUnit != null)
                return UN.UnitConverter.Convert(qv, unitSI, unUnit);

            Compute.RecordError("Unit was undefined. Please use the appropriate BHoM Units Enum.");
            return double.NaN;

        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        private static UNU.EnergyUnit? ToEnergyUnit(object unit)
        {
            if (unit == null || unit.ToString() == null)
                return null;

            if (unit.GetType() == typeof(string))
            {
                EnergyUnit unitEnum;
                if (Enum.TryParse<EnergyUnit>(unit.ToString(), out unitEnum))
                    unit = unitEnum;
                else
                    unit = unit.ToString().ToLower();
            }

            switch (unit)
            {
                case "btu":
                case EnergyUnit.BritishThermalUnit:
                    return UNU.EnergyUnit.BritishThermalUnit;
                case "j":
                case "joule":
                case EnergyUnit.Joule:
                    return UNU.EnergyUnit.Joule;
                case "kbtu":
                case EnergyUnit.KiloBritishThermalUnit:
                    return UNU.EnergyUnit.KilobritishThermalUnit;
                case "kj":
                case EnergyUnit.Kilojoule:
                    return UNU.EnergyUnit.Kilojoule;
                case "kwh":
                case EnergyUnit.KilowattHour:
                    return UNU.EnergyUnit.KilowattHour;
                case "mmbtu":
                case EnergyUnit.MegaBritishThermalUnit:
                    return UNU.EnergyUnit.MegabritishThermalUnit;
                case EnergyUnit.Megajoule:
                    return UNU.EnergyUnit.Megajoule;
                case EnergyUnit.MegawattHour:
                    return UNU.EnergyUnit.MegawattHour;
                case "wh":
                case EnergyUnit.WattHour:
                    return UNU.EnergyUnit.WattHour;
                case EnergyUnit.Undefined:
                default:
                    return null;
            }
        }
    }
}



