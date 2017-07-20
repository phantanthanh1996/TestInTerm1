using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestInTerm
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilterPage : ContentPage
    {
        public int statusFilter = 0;
        public int priorityFilter;
        public int timeFilter = 0;
        public int sortPriority1 = 0;
        public int sortDeadline1 = 0;
        public FilterPage()
        {
            InitializeComponent();
        }


        public void statusDone_OnTapped(object sender, EventArgs e)
        {
            var item = (Image)sender;
            //DisplayAlert("A", item..ToString(),"OK");

            var source = item.Source as FileImageSource;
            if (source.File == "check.png")
            {
       
                item.Source = "checkempty.png";
                statusFilter = 0;

            }
            else if (source.File == "checkempty.png")
            {
                item.Source = "check.png";
                statusAll.Source = "checkempty.png";
                statusUndone.Source = "checkempty.png";
                statusFilter = 1;
            }
        }

        public void statusUndone_OnTapped(object sender, EventArgs e)
        {
            var item = (Image)sender;
            //DisplayAlert("A", item..ToString(),"OK");

            var source = item.Source as FileImageSource;
            if (source.File == "check.png")
            {
   
                item.Source = "checkempty.png";
                statusFilter = 0;
            }
            else if (source.File == "checkempty.png")
            {

                item.Source = "check.png";
                statusDone.Source = "checkempty.png";
                statusAll.Source = "checkempty.png";
                statusFilter = 2;
            }
        }

        public void statusAll_OnTapped(object sender, EventArgs e)
        {
            var item = (Image)sender;
            //DisplayAlert("A", item..ToString(),"OK");

            var source = item.Source as FileImageSource;
            if (source.File == "check.png")
            {
                
                item.Source = "checkempty.png";
                statusFilter = 0;
            }
            else if (source.File == "checkempty.png")
            {
                item.Source = "check.png";
                statusDone.Source = "checkempty.png";
                statusUndone.Source = "checkempty.png";
                statusFilter = 0;
            }
        }

        public void priorityCristical_OnTapped(object sender, EventArgs e)
        {
            var item = (Image)sender;
            //DisplayAlert("A", item..ToString(),"OK");

            var source = item.Source as FileImageSource;
            if (source.File == "check.png")
            {
             
                item.Source = "checkempty.png";

            }
            else if (source.File == "checkempty.png")
            {
                item.Source = "check.png";
                priorityFilter = 1;
            }
        }

        public void priorityHigh_OnTapped(object sender, EventArgs e)
        {
            var item = (Image)sender;
            //DisplayAlert("A", item..ToString(),"OK");

            var source = item.Source as FileImageSource;
            if (source.File == "check.png")
            {
        
                item.Source = "checkempty.png";

            }
            else if (source.File == "checkempty.png")
            {
                item.Source = "check.png";
                priorityFilter = 2;
            }
        }

        public void priorityNormal_OnTapped(object sender, EventArgs e)
        {
            var item = (Image)sender;
            //DisplayAlert("A", item..ToString(),"OK");

            var source = item.Source as FileImageSource;
            if (source.File == "check.png")
            {
       
                item.Source = "checkempty.png";

            }
            else if (source.File == "checkempty.png")
            {
                item.Source = "check.png";
                priorityFilter = 3;
            }
        }

        public void priorityLow_OnTapped(object sender, EventArgs e)
        {
            var item = (Image)sender;
            //DisplayAlert("A", item..ToString(),"OK");

            var source = item.Source as FileImageSource;
            if (source.File == "check.png")
            {
         
                item.Source = "checkempty.png";

            }
            else if (source.File == "checkempty.png")
            {
                item.Source = "check.png";
                priorityFilter = 4;
            }
        }

        public void priorityAll_OnTapped(object sender, EventArgs e)
        {
            var item = (Image)sender;
            //DisplayAlert("A", item..ToString(),"OK");

            var source = item.Source as FileImageSource;
            if (source.File == "check.png")
            {
       
                item.Source = "checkempty.png";

            }
            else if (source.File == "checkempty.png")
            {
                item.Source = "check.png";
                priorityFilter = 0;
                priorityCristical.Source = "checkempty.png";
                priorityHigh.Source = "checkempty.png";
                priorityNormal.Source = "checkempty.png";
                priorityLow.Source = "checkempty.png";
            }
        }

        public void timeToday_OnTapped(object sender, EventArgs e)
        {
            var item = (Image)sender;
            //DisplayAlert("A", item..ToString(),"OK");

            var source = item.Source as FileImageSource;
            if (source.File == "check.png")
            {
  
                item.Source = "checkempty.png";
                timeFilter = 0;

            }
            else if (source.File == "checkempty.png")
            {
                item.Source = "check.png";
                timeThisWeek.Source = "checkempty.png";
                timeThisMonth.Source = "checkempty.png";
                timeAll.Source = "checkempty.png";
                timeFilter = 1;
            }
        }

        public void timeThisWeek_OnTapped(object sender, EventArgs e)
        {
            var item = (Image)sender;
            //DisplayAlert("A", item..ToString(),"OK");

            var source = item.Source as FileImageSource;
            if (source.File == "check.png")
            {

                item.Source = "checkempty.png";
                timeFilter = 0;
            }
            else if (source.File == "checkempty.png")
            {
                item.Source = "check.png";
                timeToday.Source = "checkempty.png";
                timeThisMonth.Source = "checkempty.png";
                timeAll.Source = "checkempty.png";
                timeFilter = 2;
            }
        }

        public void timeThisMonth_OnTapped(object sender, EventArgs e)
        {
            var item = (Image)sender;
            //DisplayAlert("A", item..ToString(),"OK");

            var source = item.Source as FileImageSource;
            if (source.File == "check.png")
            {
                timeFilter = 0;
                item.Source = "checkempty.png";

            }
            else if (source.File == "checkempty.png")
            {
                item.Source = "check.png";
                timeThisWeek.Source = "checkempty.png";
                timeToday.Source = "checkempty.png";
                timeAll.Source = "checkempty.png";
                timeFilter = 3;
            }
        }

        public void timeAll_OnTapped(object sender, EventArgs e)
        {
            var item = (Image)sender;
            //DisplayAlert("A", item..ToString(),"OK");

            var source = item.Source as FileImageSource;
            if (source.File == "check.png")
            {
                timeFilter = 0;
                item.Source = "checkempty.png";

            }
            else if (source.File == "checkempty.png")
            {
                item.Source = "check.png";
                timeThisWeek.Source = "checkempty.png";
                timeThisMonth.Source = "checkempty.png";
                timeToday.Source = "checkempty.png";
                timeFilter = 0;
            }
        }

        public void sortPriority_OnTapped(object sender, EventArgs e)
        {
            var item = (Image)sender;
            //DisplayAlert("A", item..ToString(),"OK");

            var source = item.Source as FileImageSource;
            if (source.File == "check.png")
            {
                sortPriority1 = 0;
                item.Source = "checkempty.png";

            }
            else if (source.File == "checkempty.png")
            {
                item.Source = "check.png";
                sortPriority1 = 1;
            }
        }

        public void sortDeadline_OnTapped(object sender, EventArgs e)
        {
            var item = (Image)sender;
            //DisplayAlert("A", item..ToString(),"OK");

            var source = item.Source as FileImageSource;
            if (source.File == "check.png")
            {
                sortDeadline1 = 0;
                item.Source = "checkempty.png";

            }
            else if (source.File == "checkempty.png")
            {
                sortDeadline1 = 1;
                item.Source = "check.png";
            }
        }

        private void Cancel_Filter(object sender, EventArgs e)
        {
            Navigation.PushAsync(HomePage.Instance);
        }

        private void Ok_Filter(object sender, EventArgs e)
        {
            bool showPriority, showDeadline;
            if (sortPriority1 == 0)
            {
                showPriority = false;
            }
            else
            {
                showPriority = true;
            }
            if (sortDeadline1 == 0)
            {
                showDeadline = false;
            }
            else
            {
                showDeadline = true;
            }
            var filter = new Filter()
            {

                StatusFilter = statusFilter,
                PriorityFilter = priorityFilter,
                TimeFilter = timeFilter,
                SortPriority1 = sortPriority1,
                ShowPriority = showPriority,
                SortDeadline1 = sortDeadline1,
                ShowDeadline = showDeadline
            };
            App.DAUtil.SaveFilter(filter);
        Navigation.PushAsync(new HomePage());
        }
    }
}

//statusFilter,  priorityFilter,  timeFilter,  sortPriority1,  showPriority,  sortDeadline1, showDeadline