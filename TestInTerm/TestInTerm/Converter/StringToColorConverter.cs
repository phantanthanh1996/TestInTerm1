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
    public class StringToColorConverter: IValueConverter
    {
        //public Color CriticalColor { get; set; }

        //public Color HighColor { get; set; }
        //public Color NormalColor { get; set; }
        //public Color LowColor { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                PriorityType priority = (PriorityType)value;



                if (priority == PriorityType.Cristical)
                {
                    return Color.Red;
                }
                else if (priority == PriorityType.High)
                {
                    return Color.Orange;
                }
                else if (priority == PriorityType.Normal)
                {
                    return Color.Yellow;
                }
                else
                {
                    return Color.Blue;
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return Color.White;
            }

           
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return false;
        }
    }
}
