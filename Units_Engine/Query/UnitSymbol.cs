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
using System.ComponentModel;
using System.Globalization;

using UN = UnitsNet; //This is to avoid clashes between UnitsNet quantity attributes and BHoM quantity attributes

using BH.oM.Base.Attributes;
using BH.Engine.Base;

namespace BH.Engine.Units
{
    public static partial class Query
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        [Description("The engineer-facing symbol for a unit, read from UnitsNet, e.g. LengthUnit.Millimeter " +
            "-> \"mm\" and AreaMomentOfInertiaUnit.CentimeterToTheFourth -> \"cm⁴\". UnitsNet is the only " +
            "thing in the stack that names a unit; a BH.oM.Units member carries no symbol of its own.")]
        [Input("unit", "A member of one of the BH.oM.Units unit enums, e.g. LengthUnit.Millimeter.")]
        [Output("symbol", "The unit's display symbol, or an empty string for a unit UnitsNet does not know.")]
        public static string UnitSymbol(this Enum unit)
        {
            Type netUnitType;
            int netUnitValue;
            if (!TryResolveUnitsNetUnit(unit, out netUnitType, out netUnitValue))
                return "";

            // The list, not GetDefaultAbbreviation: the list comes back empty for a unit UnitsNet has
            // registered no symbol for, where the single-value call is only safe once the unit is known to be
            // defined. Element 0 is the default abbreviation for every unit UnitsNet publishes.
            string[] symbols = UN.UnitsNetSetup.Default.UnitAbbreviations
                .GetUnitAbbreviations(netUnitType, netUnitValue, CultureInfo.CurrentCulture);

            if (symbols.Length == 0)
            {
                Compute.RecordError($"UnitsNet publishes no symbol for {unit}.");
                return "";
            }

            return symbols[0];
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        // The bridge to UnitsNet is by NAME, not value: their integer values disagree for LengthUnit,
        // AngleUnit, PressureUnit and others, so a cast would hand back a different unit (Radian -> Revolution).
        // Convert.ToBHoMUnit runs the same bridge in the opposite direction.
        private static bool TryResolveUnitsNetUnit(Enum unit, out Type netUnitType, out int netUnitValue)
        {
            netUnitType = null;
            netUnitValue = 0;

            if (unit == null)
            {
                Compute.RecordError("A unit symbol can only be taken from a unit enum member.");
                return false;
            }

            Type bhomType = unit.GetType();

            lock (m_UnitsNetTypes)
            {
                if (!m_UnitsNetTypes.TryGetValue(bhomType, out netUnitType))
                {
                    netUnitType = bhomType.Namespace == "UnitsNet.Units"
                        ? bhomType
                        : typeof(UN.UnitsNetSetup).Assembly.GetType("UnitsNet.Units." + bhomType.Name);

                    m_UnitsNetTypes[bhomType] = netUnitType;
                }
            }

            if (netUnitType == null)
            {
                Compute.RecordError($"UnitsNet has no {bhomType.Name}, so {unit} has no symbol.");
                return false;
            }

            string name = unit.ToString();
            if (!Enum.IsDefined(netUnitType, name))
            {
                // BH.oM.Units's own Undefined, and anything BHoM has added since, lands here.
                Compute.RecordError($"UnitsNet's {netUnitType.Name} has no {name}, so it has no symbol.");
                return false;
            }

            netUnitValue = System.Convert.ToInt32(Enum.Parse(netUnitType, name));
            return true;
        }

        /***************************************************/
        /**** Private Fields                            ****/
        /***************************************************/

        // One reflection lookup per unit enum type, not per call.
        private static readonly Dictionary<Type, Type> m_UnitsNetTypes = new Dictionary<Type, Type>();

        /***************************************************/
    }
}
