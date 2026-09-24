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
using UnitsNet.Units;

using System.ComponentModel;
using BH.oM.Base.Attributes;
using BH.oM.Quantities.Attributes;

namespace BH.Engine.Units
{
    public static partial class Convert
    {
        [Description("Convert SI units (metres to the sixth) into millimetres to the sixth.")]
        [Input("metresToTheSixth", "The number of metres to the sixth to convert.", typeof(WarpingMomentOfInertiaUnit))]
        [Output("millimetresToTheSixth", "The number of millimetres to the sixth.")]
        public static double ToMillimetreToTheSixth(this double metresToTheSixth)
        {
            UN.QuantityValue qv = metresToTheSixth;
            return UN.UnitConverter.Convert(qv, WarpingMomentOfInertiaUnit.MeterToTheSixth, WarpingMomentOfInertiaUnit.MillimeterToTheSixth);
        }

        [Description("Convert millimetres to the sixth into SI units (metres to the sixth).")]
        [Input("millimetresToTheSixth", "The number of millimetres to the sixth to convert.")]
        [Output("metresToTheSixth", "The number of metres to the sixth.", typeof(WarpingMomentOfInertiaUnit))]
        public static double FromMillimetreToTheSixth(this double millimetresToTheSixth)
        {
            UN.QuantityValue qv = millimetresToTheSixth;
            return UN.UnitConverter.Convert(qv, WarpingMomentOfInertiaUnit.MillimeterToTheSixth, WarpingMomentOfInertiaUnit.MeterToTheSixth);
        }
    }
}




