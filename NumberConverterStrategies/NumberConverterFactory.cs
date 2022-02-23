using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk1_Strategies.NumberConverterStrategies
{
    public class NumberConverterFactory
    {
        #region class members
        private Dictionary<string, INumberConverter> _converters;
        #endregion

        public NumberConverterFactory()
        {
            _converters = new Dictionary<string, INumberConverter>
            {
                ["Numerical"] = new NumericalNumberConverter(),
                ["Binary"] = new BinaryNumberConverter(),
                ["Hexadecimal"] = new HexadecimalNumberConverter(),
                ["Roman"] = new RomanNumberConverter()
            };
        }

        public INumberConverter GetConverter(string converterName)
        {
            if (_converters.ContainsKey(converterName))
            {
                return _converters[converterName];
            }
            else
            {
                throw new ArgumentException($"Invalid converterName for {converterName}", "converterName");
            }
        }

        #region properties
        public IEnumerable<string> ConverterNames
        {
            get { return _converters.Keys; }
        }
        #endregion
    }
}
