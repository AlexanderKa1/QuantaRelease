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
  

    public class StateConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return "-";
            }
            var result = value.ToString();
            switch (value.ToString())
            {
                case "Connected":
                    {
                        result = "Подключен";
                        break;
                    }
                case "Connecting":
                    {
                        result = "Подключение";
                        break;
                    }
                case "Disconnected":
                    {
                        result = "Отключен";
                        break;
                    }
                case "Disconnecting":
                    {
                        result = "Отключение";
                        break;
                    }
                case "connection_error":
                    {
                        result = "Ошибка подключения";
                        break;
                    }
                case "NoNetwork":
                    {
                        result = "Отключен";
                        break;
                    }
                default:
                    {
                        break;
                    }

            }

            return result;


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
            var result = value.ToString();
            switch (value.ToString())
            {
                case "Connected":
                    {
                        result = "Подключен";
                        break;
                    }
                case "Connecting":
                    {
                        result = "Подключение";
                        break;
                    }
                case "Disconnected":
                    {
                        result = "Отключен";
                        break;
                    }
                case "Disconnecting":
                    {
                        result = "Отключение";
                        break;
                    }
                case "connection_error":
                    {
                        result = "Ошибка подключения";
                        break;
                    }
                case "NoNetwork":
                    {
                        result = "Отключен";
                        break;
                    }
                default:
                    {
                        break;
                    }

            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}
