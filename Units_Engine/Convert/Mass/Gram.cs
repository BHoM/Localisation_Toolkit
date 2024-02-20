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
        [Description("Convert SI units (kilograms) into grams.")]
        [Input("kilograms", "The number of kilograms to convert.", typeof(Mass))]
        [Output("grams", "The number of grams.")]
        public static double ToGram(this double kilograms)
        {
            UN.QuantityValue qv = kilograms;
            return UN.UnitConverter.Convert(qv, MassUnit.Kilogram, MassUnit.Gram);
        }

        [Description("Convert grams into SI units (kilograms).")]
        [Input("grams", "The number of grams to convert.")]
        [Output("kilograms", "The number of kilograms.", typeof(Mass))]
        public static double FromGram(this double grams)
        {
            UN.QuantityValue qv = grams;
            return UN.UnitConverter.Convert(qv, MassUnit.Gram, MassUnit.Kilogram);
        }
    }
}
