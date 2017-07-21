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
            SearchPicker.SelectedItem = "TaskName";
        }

        //contructor
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var Filter = App.DAUtil.GetFilter();
            if(Filter.FilterCheck == true)
            {
                var vList = App.DAUtil.FilterAndSort(Filter.StatusFilter, Filter.Priority_Cristical, Filter.Priority_High, Filter.Priority_Normal, Filter.Priority_Low, Filter.Priority_All, Filter.TimeFilter, Filter.SortPriority1, Filter.ShowPriority, Filter.SortDeadline1, Filter.ShowDeadline);
                if (Filter.TimeFilter == 1)
                {
                    List<Task> vList1 = new List<Task>();
                    foreach (var t in vList)
                    {
                        if(t.Deadline.Date == DateTime.Now.Date)
                        {
                            
                            vList1.Add(t);
                            
                        }
                    }
                    lstTask.ItemsSource = vList1;
                }else if (Filter.TimeFilter == 2)
                {
                    
                    List<Task> vList1 = new List<Task>();
                    foreach (var t in vList)
                    {
                        DateTime FirstDayOfWeek = SetDateTime.GetFisrtDayOfWeek(DateTime.Now);
                        TimeSpan AddLastDayOfWeek = new TimeSpan(6, 0, 0, 0);
                        DateTime LastDayOfWeek = FirstDayOfWeek.Add(AddLastDayOfWeek);
                        if (t.Deadline.Date >= FirstDayOfWeek.Date && t.Deadline.Date <= LastDayOfWeek.Date)
                        {

                            vList1.Add(t);

                        }
                    }
                    lstTask.ItemsSource = vList1;
                } else if (Filter.TimeFilter == 3)
                {
                    List<Task> vList1 = new List<Task>();
                    foreach (var t in vList)
                    {
                        if (t.Deadline.Date.Month == DateTime.Now.Date.Month)
                        {

                            vList1.Add(t);

                        }
                    }
                    lstTask.ItemsSource = vList1;
                } else
                {
                    lstTask.ItemsSource = vList;
                }

                Filter.FilterCheck = false;
                App.DAUtil.EditFilter(Filter);

            }
            else
            {
                var vList = App.DAUtil.GetAllTasks();
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

        

    }
}