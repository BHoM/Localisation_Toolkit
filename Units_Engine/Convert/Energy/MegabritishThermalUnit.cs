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
        [Description("Convert SI units (joules) into mega british thermal units")]
        [Input("joules", "The number of joules to convert", typeof(Energy))]
        [Output("MBTUs", "The number of mega british thermal units")]
        public static double ToMegabritishThermalUnit(this double joules)
        {
            UN.QuantityValue qv = joules;
            return UN.UnitConverter.Convert(qv, EnergyUnit.Joule, EnergyUnit.MegabritishThermalUnit);
        }

        [Description("Convert mega british thermal units into SI units (joules)")]
        [Input("MBTUs", "The number of mega british thermal units to convert")]
        [Output("joules", "The number of joules", typeof(Energy))]
        public static double FromMegabritishThermalUnit(this double MBTUs)
        {
            UN.QuantityValue qv = MBTUs;
            return UN.UnitConverter.Convert(qv, EnergyUnit.MegabritishThermalUnit, EnergyUnit.Joule);
        }
    }
}
