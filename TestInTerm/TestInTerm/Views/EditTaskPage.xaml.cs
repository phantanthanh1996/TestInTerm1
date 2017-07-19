using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestInTerm
{
    public partial class EditTaskPage : ContentPage
    {
        Task task1;

        public EditTaskPage(Task t)
        {
            InitializeComponent();
            task1 = t;
            this.Title = "Edit " + task1.TaskName;
            BindingContext = task1;
            timestart.Time = task1.TimeStart.TimeOfDay;
            timedead.Time = task1.Deadline.TimeOfDay;
        }

        private void Save_Task(object sender, EventArgs e)
        {
            PriorityType rs = PriorityType.Cristical;
            if (PiorityPicker.SelectedItem.ToString() == "Cristical")
            {
                rs = PriorityType.Cristical;
            }
            else if (PiorityPicker.SelectedItem.ToString() == "High")
            {
                rs = PriorityType.High;
            }
            else if (PiorityPicker.SelectedItem.ToString() == "Normal")
            {
                rs = PriorityType.Normal;
            }
            if (PiorityPicker.SelectedItem.ToString() == "Low")
            {
                rs = PriorityType.Low;
            }
            var stask = new Task()
            {

                TaskName = taskname.Text,
                Deadline = new DateTime
                (
                    datedead.Date.Year,
                    datedead.Date.Month,
                    datedead.Date.Day,
                    timedead.Time.Hours,
                    timedead.Time.Minutes,
                    timedead.Time.Seconds
                ),
                DesShort = desshort.Text,
                TimeStart = new DateTime
                (
                    datestart.Date.Year,
                    datestart.Date.Month,
                    datestart.Date.Day,
                    timestart.Time.Hours,
                    timestart.Time.Minutes,
                    timestart.Time.Seconds
                ),

                Description = description.Text,
                Priority = rs,
            };
            App.DAUtil.SaveTask(stask);
            Navigation.PushAsync(new ListTaskPage());
        }

    }
}