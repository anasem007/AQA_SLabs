using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace saucedemo.Utils
{
    public static class Converter
    {
        public static List<double> FromStringToDouble(IEnumerable<string> stringList)
        {
            try
            {
                return stringList
                    .Select(str =>
                        double.Parse(str,
                            NumberStyles.AllowCurrencySymbol | NumberStyles.AllowDecimalPoint |
                            NumberStyles.AllowThousands, new CultureInfo("en-US")))
                    .ToList();
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}