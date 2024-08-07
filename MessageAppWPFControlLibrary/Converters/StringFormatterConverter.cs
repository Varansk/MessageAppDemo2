using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MessageAppWPFCustomControlLibrary.Converters
{
    public class StringFormatterConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < values.Length; i++)
            {
                stringBuilder.Append(values[i]);
            }

           return stringBuilder.ToString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
