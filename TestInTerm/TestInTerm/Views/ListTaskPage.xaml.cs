using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace TestInTerm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListTaskPage : ContentPage
    {
        List<Task> Tasks = new List<Task>();
        public ListTaskPage()
        {
            InitializeComponent();

            var vList = App.DAUtil.GetAllTasks();
            lstTask.ItemsSource = vList;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

                var Filter = App.DAUtil.GetFilter();
            if(Filter == null)
            {
                var vList = App.DAUtil.GetAllTasks();
                lstTask.ItemsSource = vList;
            }
            else
            {
                var vList = App.DAUtil.FilterAndSort(Filter.StatusFilter, Filter.PriorityFilter, Filter.TimeFilter, Filter.SortPriority1, Filter.ShowPriority, Filter.SortDeadline1, Filter.ShowDeadline);
                lstTask.ItemsSource = vList;
            }




        }
        public async void Add_Task(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTaskPage());
        }

        public void Upload_To_Server(object sender, EventArgs e)
        {

        }

        public void Edit_Task(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            var sTask = item.BindingContext as Task;
            Navigation.PushAsync(new EditTaskPage(sTask));
        }

        public async void Delete_Task(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            var sTask = item.BindingContext as Task;
            bool accepted = await DisplayAlert("Confirm", "Are you sure to delele '" + sTask.TaskName + "'?", "Yes", "No");
            if (accepted)
            {
                App.DAUtil.DeleteTask(sTask);
            }
            await Navigation.PushAsync(new ListTaskPage());
        }

        public async void LstTask_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            //Lấy phần tử dc chọn
            var sTask = (Task)e.Item;
            //Huy chon ptu
            lstTask.SelectedItem = null;
            //Chuyển page
            await Navigation.PushAsync(new DetailTaskPage(sTask));

        }

        //public async void Save_Status(object sender, ToggledEventArgs e)
        //{
        //    var item = (Switch)sender;
        //     var sTask = item.BindingContext as Task;
        //    sTask.Status = e.Value;
        //     App.DAUtil.EditTask(sTask);

        //}


        private void Search_TaskName(object sender, EventArgs e)
        {
            var searchType = SearchPicker.SelectedItem.ToString();
            if (searchType == "TaskName")
            {
                Tasks = App.DAUtil.GetAllTasks();
                var keyword = Search.Text;
                var suggestions = Tasks.Where(t => t.TaskName.ToLower().Contains(keyword.ToLower()));
                lstTask.ItemsSource = suggestions;
            }
            else
            {
                Tasks = App.DAUtil.GetAllTasks();
                var keyword = Search.Text;
                var suggestions = Tasks.Where(t => t.DesShort.ToLower().Contains(keyword.ToLower()));
                lstTask.ItemsSource = suggestions;
            }

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
            }
            else if (source.File == "checkempty.png")
            {
                item.Source = "check.png";
                sTask.Status = true;
            }

            App.DAUtil.EditTask(sTask);

        }

        private void FilterPicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void SortPicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string check = Sort.SelectedItem.ToString();
            switch (check)
            {
                case "Deadline A - Z":
                    Tasks = App.DAUtil.ArrangeListTask(1, "Deadline");

                    lstTask.ItemsSource = Tasks;

                    break;
                case "Deadline Z - A":
                    Tasks = App.DAUtil.ArrangeListTask(0, "Deadline");

                    lstTask.ItemsSource = Tasks;
                    break;
                case "Priority 1 - 4":
                    Tasks = App.DAUtil.ArrangeListTask(1, "Priority");

                    lstTask.ItemsSource = Tasks;
                    break;
                case "Priority 4 - 1":
                    Tasks = App.DAUtil.ArrangeListTask(0, "Priority");

                    lstTask.ItemsSource = Tasks;
                    break;
                case "Status Open - Done":
                    Tasks = App.DAUtil.ArrangeListTask(1, "Status");

                    lstTask.ItemsSource = Tasks;
                    break;
                case "Status Done - Open":
                    Tasks = App.DAUtil.ArrangeListTask(0, "Status");

                    lstTask.ItemsSource = Tasks;
                    break;

            }
        }
    }
}