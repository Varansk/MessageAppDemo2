using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace YazilimCalismasiWPF8.Converters
{
    public class GridLenghtConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (double.TryParse(value.ToString(), out double valueconverted) && double.TryParse(parameter.ToString(), out double parameterconverted))
            {
                if (double.IsNaN(valueconverted) || valueconverted == 0D)
                {
                    return new GridLength(parameterconverted, GridUnitType.Star);
                }
                else
                {
                    return value;
                }
            }
            else
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
