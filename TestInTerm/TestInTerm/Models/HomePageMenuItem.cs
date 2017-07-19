using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInTerm
{

    public class HomePageMenuItem
    {
        public HomePageMenuItem()
        {
            TargetType = typeof(ListTaskPage);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }

        public string url { get; set; }
    }
}