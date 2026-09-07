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

        [Description("Convert a warping moment of inertia into SI units (metresToTheSixth).")]
        [Input("warpingMomentOfInertia", "The quantity to convert.")]
        [Input("unit", "The unit in which the quantity is defined. This can be a string, or you can use the BHoM Enum WarpingMomentOfInertiaUnit.")]
        [Output("metresToTheSixth", "The equivalent number of metresToTheSixth.")]
        public static double FromWarpingMomentOfInertia(this double warpingMomentOfInertia, object unit)
        {
            if (Double.IsNaN(warpingMomentOfInertia) || Double.IsInfinity(warpingMomentOfInertia))
            {
                Compute.RecordError("Quantity is not a real number.");
                return double.NaN;
            }

            UN.QuantityValue qv = warpingMomentOfInertia;
            UNU.WarpingMomentOfInertiaUnit unitSI = UNU.WarpingMomentOfInertiaUnit.MeterToTheSixth;
            UNU.WarpingMomentOfInertiaUnit? unUnit = ToWarpingMomentOfInertiaUnit(unit);

            if (unUnit != null)
                return UN.UnitConverter.Convert(qv, unUnit, unitSI);

            Compute.RecordError("Unit was undefined. Please use the appropriate BHoM Units Enum.");
            return double.NaN;
        }

        /***************************************************/

        [Description("Convert SI units (metresToTheSixth) into another warping moment of inertia unit.")]
        [Input("metresToTheSixth", "The number of metresToTheSixth to convert.")]
        [Input("unit", "The unit to convert to. This can be a string, or you can use the BHoM Enum WarpingMomentOfInertiaUnit.")]
        [Output("warpingMomentOfInertia", "The equivalent quantity defined in the specified unit.")]
        public static double ToWarpingMomentOfInertia(this double metresToTheSixth, object unit)
        {
            if (Double.IsNaN(metresToTheSixth) || Double.IsInfinity(metresToTheSixth))
            {
                Compute.RecordError("Quantity is not a real number.");
                return double.NaN;
            }

            UN.QuantityValue qv = metresToTheSixth;
            UNU.WarpingMomentOfInertiaUnit unitSI = UNU.WarpingMomentOfInertiaUnit.MeterToTheSixth;
            UNU.WarpingMomentOfInertiaUnit? unUnit = ToWarpingMomentOfInertiaUnit(unit);

            if (unUnit != null)
                return UN.UnitConverter.Convert(qv, unitSI, unUnit);

            Compute.RecordError("Unit was undefined. Please use the appropriate BHoM Units Enum.");
            return double.NaN;
        }

        /***************************************************/
        /**** Internal Methods                          ****/
        /***************************************************/

        internal static UNU.WarpingMomentOfInertiaUnit? ToWarpingMomentOfInertiaUnit(object unit)
        {
            if (unit == null || unit.ToString() == null)
                return null;

            if (unit.GetType() == typeof(string))
            {
                WarpingMomentOfInertiaUnit unitEnum;
                if (Enum.TryParse<WarpingMomentOfInertiaUnit>(unit.ToString(), out unitEnum))
                    unit = unitEnum;
                else
                    unit = unit.ToString().ToLower();
            }

            switch (unit)
            {
                case WarpingMomentOfInertiaUnit.MillimeterToTheSixth:
                    return UNU.WarpingMomentOfInertiaUnit.MillimeterToTheSixth;
                case WarpingMomentOfInertiaUnit.CentimeterToTheSixth:
                    return UNU.WarpingMomentOfInertiaUnit.CentimeterToTheSixth;
                case WarpingMomentOfInertiaUnit.DecimeterToTheSixth:
                    return UNU.WarpingMomentOfInertiaUnit.DecimeterToTheSixth;
                case WarpingMomentOfInertiaUnit.MeterToTheSixth:
                    return UNU.WarpingMomentOfInertiaUnit.MeterToTheSixth;
                case WarpingMomentOfInertiaUnit.InchToTheSixth:
                    return UNU.WarpingMomentOfInertiaUnit.InchToTheSixth;
                case WarpingMomentOfInertiaUnit.FootToTheSixth:
                    return UNU.WarpingMomentOfInertiaUnit.FootToTheSixth;
                default:
                    return null;
            }
        }
    }
}
