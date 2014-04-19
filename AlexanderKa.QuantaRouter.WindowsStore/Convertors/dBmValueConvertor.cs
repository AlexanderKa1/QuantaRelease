using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if !WINDOWS_PHONE

using Windows.UI.Xaml.Data;
namespace AlexanderKa.QuantaRouter.WindowsStore.Convertors
{
    using System.Globalization;

#endif

#if WINDOWS_PHONE

using System.Globalization;
    using System.Windows.Data;
     namespace CaliburnMicro.Convertors
    {
#endif
    public class dBmValueConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return "-";
            }
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return "-";
            }

            return value.ToString() + " dBm";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return "";
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return "-";
            }
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return "-";
            }

            return value.ToString() + " dBm";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}
