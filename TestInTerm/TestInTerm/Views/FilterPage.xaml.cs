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
        public bool priorityCristicalcheck;
        public bool priorityHighcheck;
        public bool priorityNormalcheck;
        public bool priorityLowcheck;
        public bool priorityAllcheck;
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
            else
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
            else
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
            else
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
                priorityCristicalcheck = false;
            }
            else
            {
                item.Source = "check.png";
                priorityCristicalcheck = true;
                priorityAll.Source = "checkempty.png";

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
                priorityHighcheck = false;
            }
            else
            {
                item.Source = "check.png";
                priorityHighcheck = true;
                priorityAll.Source = "checkempty.png";
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
                priorityNormalcheck = false;
            }
            else
            {
                item.Source = "check.png";
                priorityNormalcheck = true;
                priorityAll.Source = "checkempty.png";
            }
        }

        public void priorityLow_OnTapped(object sender, EventArgs e)
        {
            var item = (Image)sender;
            //DisplayAlert("A", item..ToString(),"OK");

            var source = item.Source as FileImageSource;
            if (source.File == "check.png")
            {
                priorityLowcheck = false;
                item.Source = "checkempty.png";

            }
            else
            {
                item.Source = "check.png";
                priorityLowcheck = true;
                priorityAll.Source = "checkempty.png";
            }
        }

        public void priorityAll_OnTapped(object sender, EventArgs e)
        {
            var item = (Image)sender;
            //DisplayAlert("A", item..ToString(),"OK");

            var source = item.Source as FileImageSource;
            if (source.File == "check.png")
            {
                priorityAllcheck = false;
                item.Source = "checkempty.png";


            }
            else
            {
                item.Source = "check.png";
                priorityAllcheck = true;
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
            else
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
            else
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
            else
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
            else
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
                pioritySort.SelectedItem = null;
            }
            else
            {
                item.Source = "check.png";
                sortPriority1 = 1;
                pioritySort.SelectedItem = "Increase";
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
                DeadlineSort.SelectedItem = null;
            }
            else
            {
                DeadlineSort.SelectedItem = "Increase";
                sortDeadline1 = 1;
                item.Source = "check.png";
            }
        }

        private void Cancel_Filter(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HomePage());
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

                if (pioritySort.SelectedItem == "Increase")
                {
                    showPriority = false;
                }
                else
                {
                    showPriority = true;
                }

            }
            if (sortDeadline1 == 0)
            {

                showDeadline = false;
            }
            else
            {
                if (DeadlineSort.SelectedItem == "Increase")
                {
                    showDeadline = false;
                }
                else
                {
                    showDeadline = true;
                }
            }
            if (priorityCristicalcheck == false &&
                priorityHighcheck == false &&
                priorityNormalcheck == false &&
                priorityLowcheck == false)
            {
                priorityAllcheck = true;
            }
            var filter = new Filter()
            {

                StatusFilter = statusFilter,
                Priority_Cristical = priorityCristicalcheck,
                Priority_High = priorityHighcheck,
                Priority_Normal = priorityNormalcheck,
                Priority_Low = priorityLowcheck,
                Priority_All = priorityAllcheck,
                TimeFilter = timeFilter,
                SortPriority1 = sortPriority1,
                ShowPriority = showPriority,
                SortDeadline1 = sortDeadline1,
                ShowDeadline = showDeadline,
                FilterCheck = true
            };
            App.DAUtil.SaveFilter(filter);
            Navigation.PushAsync(new HomePage());
        }
    }
}
