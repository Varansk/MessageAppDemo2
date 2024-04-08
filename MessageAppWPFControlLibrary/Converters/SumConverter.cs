using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace YazilimCalismasiWPF8.Converters
{
    class SumConverter : IMultiValueConverter
    {
        private object[] values;
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            this.values = values;
            double sum = 0;
            for (int i = 0; i < values.Length; i++)
            {
                if (!double.TryParse(values[i].ToString(), out double value))
                {
                    return value;
                }
                else
                {
                    sum += value;
                }
            }
            if (parameter is null)
            {
                return sum;
            }
            else if (double.TryParse(parameter.ToString(), out double parameterD))
            {
                sum += parameterD;
                return sum;
            }
            else
            {
                return null;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            foreach (object[] myvalue in this.values)
            {
                if (!double.TryParse(myvalue.ToString(), out _))
                {
                    return null;
                }
            }
            return values;
        }
    }
}
