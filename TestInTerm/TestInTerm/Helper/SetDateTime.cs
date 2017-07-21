using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInTerm
{
    public static class SetDateTime
    {
        public static DateTime GetFisrtDayOfWeek(DateTime d)
        {
            DateTime t = d;
            TimeSpan TuesDay = new TimeSpan(1, 0, 0, 0);
            TimeSpan Wednesday = new TimeSpan(2, 0, 0, 0);
            TimeSpan Thurday = new TimeSpan(3, 0, 0, 0);
            TimeSpan Friday = new TimeSpan(4, 0, 0, 0);
            TimeSpan Saturday = new TimeSpan(5, 0, 0, 0);
            TimeSpan Sunday = new TimeSpan(6, 0, 0, 0);
            switch (d.DayOfWeek.ToString())
            {
                case "Monday":
                    t = d;
                    break;
                case "Tuesday":
                    t = d.Subtract(TuesDay);
                    break;
                case "Wednesday":
                    t = d.Subtract(Wednesday);
                    break;
                case "Thurday":
                    t = d.Subtract(Thurday);
                    break;
                case "Friday":
                    t = d.Subtract(Friday);
                    break;
                case "Saturday":
                    t = d.Subtract(Saturday);
                    break;
                case "Sunday":
                    t = d.Subtract(Sunday);
                    break;
            }
            return t;
        }
    }

}
