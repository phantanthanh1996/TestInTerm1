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
    public partial class AddTaskPage : ContentPage
    {
        public AddTaskPage()
        {
            InitializeComponent();

            datedead.Date = DateTime.Now.Date;
            timedead.Time = DateTime.Now.TimeOfDay;
            timestart.Time = DateTime.Now.TimeOfDay;
            datedead.Date = DateTime.Now.Date;


        }

        public void Save_Task(object sender, EventArgs e)
        {

            DateTime aDateTime = new DateTime(datedead.Date.Year,
                datedead.Date.Month,
                datedead.Date.Day,
                timedead.Time.Hours,
                timedead.Time.Minutes,
                0);
            DateTime bDateTime = new DateTime(datestart.Date.Year,
                datestart.Date.Month,
                datestart.Date.Day,
                timestart.Time.Hours,
                timestart.Time.Minutes,
                0);
            if (taskname.Text != null && desshort.Text != null && description.Text != null && PiorityPicker.SelectedItem != null)
            {
                if (aDateTime <= bDateTime)
                {
                    DisplayAlert("Alert", "Deadline must be bigger than StartTime", "Ok");
                }
                else
                {
                    var task = new Task()
                    {

                        TaskName = taskname.Text,
                        Deadline = new DateTime
                        (
                            datedead.Date.Year,
                            datedead.Date.Month,
                            datedead.Date.Day,
                            timedead.Time.Hours,
                            timedead.Time.Minutes,
                            0
                        ),
                        DesShort = desshort.Text,
                        TimeStart = new DateTime
                        (
                            datestart.Date.Year,
                            datestart.Date.Month,
                            datestart.Date.Day,
                            timestart.Time.Hours,
                            timestart.Time.Minutes,
                            0
                        ),
                        Description = description.Text,

                        Priority = (PriorityType)Int32.Parse(PiorityPicker.SelectedItem.ToString()),
                        Status = false
                    };
                    TimeSpan aInterval = new TimeSpan(0, 7, 0, 0);
                    task.Deadline = task.Deadline.Add(aInterval);
                    task.TimeStart = task.TimeStart.Add(aInterval);
                    App.DAUtil.SaveTask(task);
                    Navigation.PopAsync();
                }

            }
            else
            {
                DisplayAlert("Alert", "Please enter full information!", "OK");
            }

        }
    }
}