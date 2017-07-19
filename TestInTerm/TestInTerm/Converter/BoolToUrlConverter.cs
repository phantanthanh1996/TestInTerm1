using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestInTerm
{ 
    public class BoolToUrlConverter: IValueConverter
    {
        public string TrueValue { get; set; }

        public string FalseValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool status = (bool) value;



            if (status == true)
            {
                return "check.png";
            }
            else
            {
                return "checkempty.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return false;
        }
    }
}
