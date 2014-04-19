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


    public class SecondsToTimeValueConvertor : IValueConverter
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

            int secs = -1;
            int.TryParse(value.ToString(), out secs);
            if (secs == -1) return "-";

            TimeSpan t = TimeSpan.FromSeconds(secs);

            return string.Format("{0:D2}ч:{1:D2}м:{2:D2}с",
                            t.Hours,
                            t.Minutes,
                            t.Seconds);



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

            int secs = -1;
            int.TryParse(value.ToString(), out secs);
            if (secs == -1) return "-";

            TimeSpan t = TimeSpan.FromSeconds(secs);

            return string.Format("{0:D2}ч:{1:D2}м:{2:D2}с",
                            t.Hours,
                            t.Minutes,
                            t.Seconds);


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}
