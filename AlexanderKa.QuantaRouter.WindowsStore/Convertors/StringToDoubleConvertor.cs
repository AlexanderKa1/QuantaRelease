using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexanderKa.QuantaRouter.WindowsStore.Convertors
{
    using System.Globalization;

    using Windows.UI.Xaml.Data;

    public class StringToDoubleConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            double rsrp = double.MinValue;
            {
                double.TryParse(value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out rsrp);
            }
            if (Math.Abs(rsrp - double.MinValue) < 1)
            {
                return null;
            }
            return rsrp;



        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
