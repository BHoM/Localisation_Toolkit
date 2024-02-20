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
        [Description("Convert SI units (kilograms) into short tons.")]
        [Input("kilograms", "The number of kilograms to convert.", typeof(Mass))]
        [Output("shortTons", "The number of short tons.")]
        public static double ToShortTon(this double kilograms)
        {
            UN.QuantityValue qv = kilograms;
            return UN.UnitConverter.Convert(qv, MassUnit.Kilogram, MassUnit.ShortTon);
        }

        [Description("Convert short tons into SI units (kilograms).")]
        [Input("shortTons", "The number of short tons to convert.")]
        [Output("kilograms", "The number of kilograms.", typeof(Mass))]
        public static double FromShortTon(this double shortTons)
        {
            UN.QuantityValue qv = shortTons;
            return UN.UnitConverter.Convert(qv, MassUnit.ShortTon, MassUnit.Kilogram);
        }
    }
}
