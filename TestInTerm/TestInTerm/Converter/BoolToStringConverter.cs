using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestInTerm
{
    public class BoolToStringConverter: IValueConverter
    {
        public string TrueValue { get; set; }

        public string FalseValue { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //bool item = (bool)value;
            //var source = item.Source as FileImageSource;


            if (value.ToString() == "check.png")
            {
                return "A";
            }
            else
            {
                return "B";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return false;
        }
    }
}
