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
        [Description("Convert SI units (kilograms) into pounds.")]
        [Input("kilograms", "The number of kilograms to convert.", typeof(Mass))]
        [Output("pounds", "The number of pounds.")]
        public static double ToPound(this double kilograms)
        {
            UN.QuantityValue qv = kilograms;
            return UN.UnitConverter.Convert(qv, MassUnit.Kilogram, MassUnit.Pound);
        }

        [Description("Convert pounds into SI units (kilograms).")]
        [Input("pounds", "The number of pounds to convert.")]
        [Output("kilograms", "The number of kilograms.", typeof(Mass))]
        public static double FromPound(this double pounds)
        {
            UN.QuantityValue qv = pounds;
            return UN.UnitConverter.Convert(qv, MassUnit.Pound, MassUnit.Kilogram);
        }
    }
}
