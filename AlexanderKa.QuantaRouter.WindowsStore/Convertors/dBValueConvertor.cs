using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if !WINDOWS_PHONE

using Windows.UI.Xaml.Data;
using System.Globalization;
namespace AlexanderKa.QuantaRouter.WindowsStore.Convertors
{
#endif

#if WINDOWS_PHONE
using System.Globalization;
    using System.Windows.Data;
     namespace CaliburnMicro.Convertors
    {
#endif
   public class dBValueConvertor : IValueConverter
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
            
            return value.ToString() + " dB";
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

            return value.ToString() + " dB";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}
