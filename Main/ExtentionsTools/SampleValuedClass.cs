using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.ExtentionsTools
{
    public class SampleValuedClass
    {
        public static Func<SampleValuedClass, float> GetValueFunc = (fff) => fff.Value;
        public SampleValuedClass(float value)
        {
            Value = value;
        }

        public float Value { get; set; }
        public override string ToString() =>
            Value.ToString();
    }
}
