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
        [Description("Convert SI units (kilograms) into long tons.")]
        [Input("kilograms", "The number of kilograms to convert.", typeof(Mass))]
        [Output("longTons", "The number of long tons.")]
        public static double ToLongTon(this double kilograms)
        {
            UN.QuantityValue qv = kilograms;
            return UN.UnitConverter.Convert(qv, MassUnit.Kilogram, MassUnit.LongTon);
        }

        [Description("Convert long tons into SI units (kilograms).")]
        [Input("longTons", "The number of long tons to convert.")]
        [Output("kilograms", "The number of kilograms.", typeof(Mass))]
        public static double FromLongTon(this double longTons)
        {
            UN.QuantityValue qv = longTons;
            return UN.UnitConverter.Convert(qv, MassUnit.LongTon, MassUnit.Kilogram);
        }
    }
}
