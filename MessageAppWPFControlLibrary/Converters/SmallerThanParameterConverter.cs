using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MessageAppWPFCustomControlLibrary.Converters
{
    public class SmallerThanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double valued = (double)value;
            double parameterd = (double)parameter;

            if (valued < parameterd)
            {       
                return true;
            }
            else
            {
                return false;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
