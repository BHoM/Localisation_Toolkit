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
using UNU = UnitsNet.Units;

using System.ComponentModel;
using BH.oM.Base.Attributes;
using BH.oM.Units;
using BH.Engine.Base;
using UnitsNet.Units;

namespace BH.Engine.Units
{
    public static partial class Convert
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        [Description("Convert a conductivity into SI units (siemens per metre).")]
        [Input("conductivity", "The quantity to convert.")]
        [Input("unit", "The unit in which the quantity is defined. This can be a string, or you can use the BHoM Enum ConductivityUnit.")]
        [Output("siemensPerMetre", "The equivalent number of siemens per metre.")]
        public static double FromElectricConductivity(this double conductivity, object unit)
        {
            if (Double.IsNaN(conductivity) || Double.IsInfinity(conductivity))
            {
                Compute.RecordError("Quantity is not a real number.");
                return double.NaN;
            }

            UN.QuantityValue qv = conductivity;
            UNU.ElectricConductivityUnit unitSI = UNU.ElectricConductivityUnit.SiemensPerMeter;
            UNU.ElectricConductivityUnit? unUnit = ToElectricConductivityUnit(unit);

            if (unUnit != null)
                return UN.UnitConverter.Convert(qv, unUnit, unitSI);

            Compute.RecordError("Unit was undefined. Please use the appropriate BHoM Units Enum.");
            return double.NaN;
        }

        /***************************************************/

        [Description("Convert SI units (siemensPerMetre) into another conductivity unit.")]
        [Input("siemensPerMetre", "The number of siemensPerMetre to convert.")]
        [Input("unit", "The unit to convert to. This can be a string, or you can use the BHoM Enum ConductivityUnit.")]
        [Output("conductivity", "The equivalent quantity defined in the specified unit.")]
        public static double ToElectricConductivity(this double siemensPerMetre, object unit)
        {
            if (Double.IsNaN(siemensPerMetre) || Double.IsInfinity(siemensPerMetre))
            {
                Compute.RecordError("Quantity is not a real number.");
                return double.NaN;
            }

            UN.QuantityValue qv = siemensPerMetre;
            UNU.ElectricConductivityUnit unitSI = UNU.ElectricConductivityUnit.SiemensPerMeter;
            UNU.ElectricConductivityUnit? unUnit = ToElectricConductivityUnit(unit);

            if (unUnit != null)
                return UN.UnitConverter.Convert(qv, unitSI, unUnit);

            Compute.RecordError("Unit was undefined. Please use the appropriate BHoM Units Enum.");
            return double.NaN;
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        private static UNU.ElectricConductivityUnit? ToElectricConductivityUnit(object unit)
        {
            if (unit == null || unit.ToString() == null)
                return null;

            if (unit.GetType() == typeof(string))
            {
                UNU.ElectricConductivityUnit unitEnum;
                if (Enum.TryParse<UNU.ElectricConductivityUnit>(unit.ToString(), out unitEnum))
                    unit = unitEnum;
                else
                    unit = unit.ToString().ToLower();
            }

            switch (unit)
            {
                case oM.Units.ElectricConductivityUnit.SiemensPerCentimetre:
                    return UNU.ElectricConductivityUnit.SiemensPerCentimeter;
                case oM.Units.ElectricConductivityUnit.SiemensPerFoot:
                    return UNU.ElectricConductivityUnit.SiemensPerFoot;
                case oM.Units.ElectricConductivityUnit.SiemensPerInch:
                    return UNU.ElectricConductivityUnit.SiemensPerInch;
                case oM.Units.ElectricConductivityUnit.SiemensPerMetre:
                    return UNU.ElectricConductivityUnit.SiemensPerMeter;
                default:
                    return null;
            }
        }
    }
}





