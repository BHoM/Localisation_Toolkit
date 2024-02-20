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
using BH.oM.Quantities.Attributes;

namespace BH.Engine.Units
{
    public static partial class Convert
    {
        [Description("Convert SI units (joules) into british thermal units")]
        [Input("joules", "The number of joules to convert", typeof(Energy))]
        [Output("BTUs", "The number of british thermal units")]
        public static double ToBritishThermalUnit(this double joules)
        {
            UN.QuantityValue qv = joules;
            return UN.UnitConverter.Convert(qv, EnergyUnit.Joule, EnergyUnit.BritishThermalUnit);
        }

        [Description("Convert british thermal units into SI units (joules)")]
        [Input("BTUs", "The number of british thermal units to convert")]
        [Output("joules", "The number of joules", typeof(Energy))]
        public static double FromBritishThermalUnit(this double BTUs)
        {
            UN.QuantityValue qv = BTUs;
            return UN.UnitConverter.Convert(qv, EnergyUnit.BritishThermalUnit, EnergyUnit.Joule);
        }
    }
}
