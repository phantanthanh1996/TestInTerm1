using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestInTerm
{
    class CutStringConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                PriorityType priority = (PriorityType)value;



                if (priority == PriorityType.Cristical)
                {
                    return "C";
                }
                else if (priority == PriorityType.High)
                {
                    return "H";
                }
                else if (priority == PriorityType.Normal)
                {
                    return "N";
                }
                else
                {
                    return "L";
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
