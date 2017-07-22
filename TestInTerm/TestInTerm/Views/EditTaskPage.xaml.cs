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

            PiorityPicker.SelectedItem = ((int)(task1.Priority)).ToString();
        }

        private void Save_Task(object sender, EventArgs e)
        {
            task1.TaskName = taskname.Text;
                task1.Deadline = new DateTime
                (
                    datedead.Date.Year,
                    datedead.Date.Month,
                    datedead.Date.Day,
                    timedead.Time.Hours,
                    timedead.Time.Minutes,
                    timedead.Time.Seconds
                );
            task1.DesShort = desshort.Text;
            task1.TimeStart = new DateTime
           (
               datestart.Date.Year,
               datestart.Date.Month,
               datestart.Date.Day,
               timestart.Time.Hours,
               timestart.Time.Minutes,
               timestart.Time.Seconds
           );

            task1.Description = description.Text;
            task1.Priority = (PriorityType)Int32.Parse(PiorityPicker.SelectedItem.ToString());
            App.DAUtil.EditTask(task1);
            Navigation.PopAsync();
        }

    }
}