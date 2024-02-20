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
        [Description("Convert SI units (joules) into kilowatt-hours.")]
        [Input("joules", "The number of joules to convert.", typeof(Energy))]
        [Output("kWhs", "The number of kilowatt-hours.")]
        public static double ToKilowattHour(this double joules)
        {
            UN.QuantityValue qv = joules;
            return UN.UnitConverter.Convert(qv, EnergyUnit.Joule, EnergyUnit.KilowattHour);
        }

        [Description("Convert kilowatt-hours into SI units (joules).")]
        [Input("kWhs", "The number of kilowatt-hours to convert.")]
        [Output("joules", "The number of joules.", typeof(Energy))]
        public static double FromKilowattHour(this double kWhs)
        {
            UN.QuantityValue qv = kWhs;
            return UN.UnitConverter.Convert(qv, EnergyUnit.KilowattHour, EnergyUnit.Joule);
        }
    }
}
