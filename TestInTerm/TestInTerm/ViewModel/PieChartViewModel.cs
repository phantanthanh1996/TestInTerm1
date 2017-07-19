using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestInTerm;
using Xamarin.Forms;

namespace TestInTerm.ViewModel
{
    public class PieChartViewModel
    {
        public List<PieChartModel> Data { get; set; }

        public List<Color> DataColor { get; set; }

        public PieChartViewModel()
        {
            Data = new List<PieChartModel>()
            {
                new PieChartModel { Name = "Done", Value = 0},
                new PieChartModel { Name = "Inprogress", Value = 100 },
            };

            DataColor = new List<Color>()
            {
                new Color(0,0,255),
                new Color(255,0,0),
            };
        }
    }
}
