using System;
using Xamarin.Forms;

namespace TestInTerm
{
    public partial class DetailTaskPage : ContentPage
    {
        Task task1;

        public DetailTaskPage(Task t)
        {

            InitializeComponent();
            task1 = t;
            this.Title = task1.TaskName;
            BindingContext = task1;
            deadline.Text = task1.Deadline.ToString("g");
            timestart.Text = task1.TimeStart.ToString("g");
            var source = statuschange.Source as FileImageSource;
            if (source == "check.png")
            {
                status.Text = "Done";
            }
            else
            {
                status.Text = "Open";
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            if(App.DAUtil.GetTasks(task1.TaskId) != null)
            {
                Task x = App.DAUtil.GetTasks(task1.TaskId);
                this.Title = x.TaskName;
                BindingContext = x;
            }


        }
            public void Edit_Task(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditTaskPage(task1));
        }

        public async void Delete_Task(object sender, EventArgs e)
        {
            bool accepted = await DisplayAlert("Confirm", "Are you sure to delele '" + task1.TaskName + "'?", "Yes", "No");
            if (accepted)
            {
                App.DAUtil.DeleteTask(task1);
                await Navigation.PushAsync(new HomePage());
            }
            
        }

        private void Save_Status(object sender, ToggledEventArgs e)
        {
            task1.Status = e.Value;
            App.DAUtil.EditTask(task1);
        }

        public void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            var item = (Image)sender;

            var sTask = item.BindingContext as Task;
            var source = item.Source as FileImageSource;
            if (source.File == "check.png")
            {
                item.Source = "checkempty.png";
                sTask.Status = false;
                status.Text = "Open";
            }
            else if (source.File == "checkempty.png")
            {
                item.Source = "check.png";
                sTask.Status = true;
                status.Text = "Done";
            }

            App.DAUtil.EditTask(sTask);

        }
    }
}