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

using UN = UnitsNet; //This is to avoid clashes between UnitsNet quantity attributes and BHoM quantity attributes

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

        [Description("Converts a value from the given unit to SI, e.g. 12 LengthUnit.Millimeter → 0.012 m. " +
            "The inverse of ToUnit.")]
        [Input("value", "The value in the given unit.")]
        [Input("unit", "The unit the value is in, as a member of one of the BH.oM.Units unit enums, e.g. " +
            "LengthUnit.Millimeter. A UnitsNet unit is read as well, but records a warning.")]
        [Output("siValue", "The value in SI units, or NaN when the unit has no conversion.")]
        public static double FromUnit(this double value, Enum unit)
        {
            Enum bhomUnit = BHoMUnit(unit);
            if (bhomUnit == null)
                return double.NaN;

            // The unit's type names its quantity, so the type is the whole of the dispatch. A symbol that two
            // quantities both publish - "t" for both a tonne and a teaspoon - cannot arise here as it does
            // when the unit arrives as text, because the caller has already said which quantity it means.
            switch (bhomUnit.GetType().Name)
            {
                case nameof(LengthUnit):                        return value.FromLength(bhomUnit);
                case nameof(AreaUnit):                          return value.FromArea(bhomUnit);
                case nameof(VolumeUnit):                        return value.FromVolume(bhomUnit);
                case nameof(AreaMomentOfInertiaUnit):           return value.FromAreaMomentOfInertia(bhomUnit);
                case nameof(PressureUnit):                      return value.FromPressure(bhomUnit);
                case nameof(ForceUnit):                         return value.FromForce(bhomUnit);
                case nameof(TorqueUnit):                        return value.FromTorque(bhomUnit);
                case nameof(ForcePerLengthUnit):                return value.FromForcePerLength(bhomUnit);
                case nameof(TorquePerLengthUnit):               return value.FromMomentPerLength(bhomUnit);
                case nameof(MassUnit):                          return value.FromMass(bhomUnit);
                case nameof(AngleUnit):                         return value.FromAngle(bhomUnit);
                case nameof(AccelerationUnit):                  return value.FromAcceleration(bhomUnit);
                case nameof(DensityUnit):                       return value.FromDensity(bhomUnit);
                case nameof(EnergyUnit):                        return value.FromEnergy(bhomUnit);
                case nameof(SpeedUnit):                         return value.FromSpeed(bhomUnit);
                case nameof(DurationUnit):                      return value.FromDuration(bhomUnit);
                case nameof(TemperatureUnit):                   return value.FromTemperature(bhomUnit);
                case nameof(TemperatureDeltaUnit):              return value.FromTemperatureDelta(bhomUnit);
                case nameof(CoefficientOfThermalExpansionUnit): return value.FromCoefficientOfThermalExpansion(bhomUnit);
                case nameof(ElectricConductivityUnit):          return value.FromElectricConductivity(bhomUnit);
                case nameof(MassFractionUnit):                  return value.FromMassFraction(bhomUnit);
                case nameof(MolalityUnit):                      return value.FromMolality(bhomUnit);

                default:
                    Compute.RecordError($"BH.Engine.Units has no conversion for a {bhomUnit.GetType().Name}.");
                    return double.NaN;
            }
        }

        /***************************************************/

        [Description("Converts a value from the given unit symbol to SI, e.g. 12 \"mm\" → 0.012 m.")]
        [Input("value", "The value in the specified unit.")]
        [Input("unitSymbol", "Unit symbol (e.g. \"mm\", \"kN\", \"MPa\"). Case-sensitive. An empty symbol or \"-\" leaves the value unchanged.")]
        [Output("siValue", "The value in SI units, or NaN if the unit is unrecognised.")]
        public static double FromUnit(this double value, string unitSymbol)
        {
            UnitSpec spec = Query.ResolveUnit(unitSymbol);
            if (spec == null)
                return double.NaN;

            // A dimensionless unit carries no Unit and a Factor of 1, so it passes straight through; the
            // units no quantity in UnitsNet can express carry a Factor instead of a Unit.
            if (spec.Unit == null)
                return value * spec.Factor;

            return ConvertUnit(value, spec.Unit, spec.SIUnit, unitSymbol);
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        // Shared by both FromUnit and ToUnit overloads. BH.oM.Units.ForceUnit and UnitsNet.Units.ForceUnit
        // share a Type.Name, so this has to run before the switch: a UnitsNet unit would otherwise match its
        // case and then come back NaN from FromForce, which reads only BHoM units.
        private static Enum BHoMUnit(Enum unit)
        {
            if (unit == null)
            {
                Compute.RecordError("No unit was given to convert with.");
                return null;
            }

            Enum bhomUnit = unit.GetType().Namespace == "BH.oM.Units" ? unit : ToBHoMUnit(unit);
            if (bhomUnit == null)
                return null;

            // Every BH.oM.Units enum carries one, and it names no unit.
            if (bhomUnit.ToString() == "Undefined")
            {
                Compute.RecordError($"{bhomUnit.GetType().Name}.Undefined names no unit, so there is nothing to convert to.");
                return null;
            }

            return bhomUnit;
        }

        /***************************************************/

        // The bridge is by NAME, not value: the two enums' integer values disagree - BH.oM.Units.LengthUnit
        // .Meter is 18 where UnitsNet's is 21 - so a cast would hand back a different unit entirely.
        private static Enum ToBHoMUnit(Enum unit)
        {
            Type type = unit.GetType();

            Compute.RecordWarning($"{type.FullName} is not a BHoM unit. Use BH.oM.Units.{type.Name}.{unit} " +
                "instead - BH.Engine.Units converts BHoM units, and reads any other unit enum as a fallback only.");

            Type bhomType;
            lock (m_BHoMUnitTypes)
            {
                if (!m_BHoMUnitTypes.TryGetValue(type, out bhomType))
                {
                    bhomType = typeof(LengthUnit).Assembly.GetType("BH.oM.Units." + type.Name);
                    m_BHoMUnitTypes[type] = bhomType;
                }
            }

            if (bhomType == null)
            {
                Compute.RecordError($"BH.oM.Units has no {type.Name}, so {unit} cannot be converted.");
                return null;
            }

            string name = unit.ToString();
            if (!Enum.IsDefined(bhomType, name))
            {
                Compute.RecordError($"BH.oM.Units.{type.Name} has no {name}, so it cannot be converted.");
                return null;
            }

            return (Enum)Enum.Parse(bhomType, name);
        }

        /***************************************************/

        // Shared conversion step for the FromUnit and ToUnit symbol overloads. The unit and its SI counterpart
        // both come from the same UnitSpec, so the only difference between the two is which way round they are passed.
        private static double ConvertUnit(double value, Enum fromUnit, Enum toUnit, string unitSymbol)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
            {
                Compute.RecordError("Quantity is not a real number.");
                return double.NaN;
            }

            if (UN.UnitConverter.TryConvert(value, fromUnit, toUnit, out double result))
                return result;

            Compute.RecordError($"No conversion is available between '{unitSymbol}' and its SI unit.");
            return double.NaN;
        }

        /***************************************************/
        /**** Private Fields                            ****/
        /***************************************************/

        // One reflection lookup per foreign unit enum type, not per call.
        private static readonly Dictionary<Type, Type> m_BHoMUnitTypes = new Dictionary<Type, Type>();

        /***************************************************/
    }
}
