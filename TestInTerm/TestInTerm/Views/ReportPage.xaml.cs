using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestInTerm;
using TestInTerm.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestInTerm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReportPage : ContentPage
    {
        List<Task> Tasks = new List<Task>();

        public ReportPage()
        {
            Tasks = App.DAUtil.GetAllTasks();

            InitializeComponent();

            BindingContext = new PieChartViewModel();
            var counTaskDone = App.DAUtil.CountX(true);
            var counTaskInprogress = App.DAUtil.CountX(false);
            NumTaskDone.Text = counTaskDone.ToString();
            NumTaskInprogress.Text = counTaskInprogress.ToString();
            SelectTimePicker.SelectedItem = "Today";
            //Khai bao bien


            float JobCriticalDone = 0;
            float JobHighDone = 0;
            float JobNormalDone = 0;
            float JobLowDone = 0;

            float JobCriticalInprogress = 0;
            float JobHighInprogress = 0;
            float JobNormalInprogress = 0;
            float JobLowInprogress = 0;
            float JobCritical;
            float JobHigh;
            float JobNormal;
            float JobLow;
            foreach (var t in Tasks)
            {
                if (t.Deadline.Date == DateTime.Now.Date)
                {

                    JobCriticalDone += App.DAUtil.CountY(4, true, t);
                    JobHighDone += App.DAUtil.CountY(3, true, t);
                    JobNormalDone += App.DAUtil.CountY(2, true, t);
                    JobLowDone += App.DAUtil.CountY(1, true, t);
                    JobCriticalInprogress += App.DAUtil.CountY(4, false, t);
                    JobHighInprogress += App.DAUtil.CountY(3, false, t);
                    JobNormalInprogress += App.DAUtil.CountY(2, false, t);
                    JobLowInprogress += App.DAUtil.CountY(1, false, t);
                }
            }
            JobCritical = JobCriticalDone + JobCriticalInprogress;
            JobHigh = JobHighDone + JobHighInprogress;
            JobNormal = JobNormalDone + JobNormalInprogress;
            JobLow = JobLowDone + JobLowInprogress;

            float B = JobCritical * 4 + JobHigh * 3 + JobNormal * 2 + JobLow * 1;
            float A = JobCriticalDone * 4 + JobHighDone * 3 + JobNormalDone * 2 + JobLowDone;
            if (B != 0)
            {
                var rs = Math.Round(((A / B) * 100), 2);
                CompleteProcess.Text = rs + "%";
                List<PieChartModel> Data = new List<PieChartModel>()
                {
                    new PieChartModel {Name = "Done", Value = rs},
                    new PieChartModel {Name = "Inprogress", Value = (100 - rs)},
                };
                lstChart.ItemsSource = Data;
            }
        }

        public void SelectTimePicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectTimePicker.SelectedItem == "Today")
            {
                float JobCriticalDone = 0;
                float JobHighDone = 0;
                float JobNormalDone = 0;
                float JobLowDone = 0;

                float JobCriticalInprogress = 0;
                float JobHighInprogress = 0;
                float JobNormalInprogress = 0;
                float JobLowInprogress = 0;
                float JobCritical;
                float JobHigh;
                float JobNormal;
                float JobLow;
                foreach (var t in Tasks)
                {
                    if (t.Deadline.Date == DateTime.Now.Date)
                    {

                        JobCriticalDone += App.DAUtil.CountY(4, true, t);
                        JobHighDone += App.DAUtil.CountY(3, true, t);
                        JobNormalDone += App.DAUtil.CountY(2, true, t);
                        JobLowDone += App.DAUtil.CountY(1, true, t);
                        JobCriticalInprogress += App.DAUtil.CountY(4, false, t);
                        JobHighInprogress += App.DAUtil.CountY(3, false, t);
                        JobNormalInprogress += App.DAUtil.CountY(2, false, t);
                        JobLowInprogress += App.DAUtil.CountY(1, false, t);
                    }
                }
                JobCritical = JobCriticalDone + JobCriticalInprogress;
                JobHigh = JobHighDone + JobHighInprogress;
                JobNormal = JobNormalDone + JobNormalInprogress;
                JobLow = JobLowDone + JobLowInprogress;

                float B = JobCritical * 4 + JobHigh * 3 + JobNormal * 2 + JobLow * 1;
                float A = JobCriticalDone * 4 + JobHighDone * 3 + JobNormalDone * 2 + JobLowDone;
                if (B != 0)
                {
                    var rs = Math.Round(((A / B) * 100), 2);
                    CompleteProcess.Text = rs + "%";
                    List<PieChartModel> Data = new List<PieChartModel>()
                    {
                        new PieChartModel {Name = "Done", Value = rs},
                        new PieChartModel {Name = "Inprogress", Value = (100 - rs)},
                    };
                    lstChart.ItemsSource = Data;
                }
            }
            else if (SelectTimePicker.SelectedItem == "This Week")
            {
                float JobCriticalDone = 0;
                float JobHighDone = 0;
                float JobNormalDone = 0;
                float JobLowDone = 0;

                float JobCriticalInprogress = 0;
                float JobHighInprogress = 0;
                float JobNormalInprogress = 0;
                float JobLowInprogress = 0;
                float JobCritical;
                float JobHigh;
                float JobNormal;
                float JobLow;
                foreach (var t in Tasks)
                {
                    if (t.Deadline.Date.Day <= DateTime.Now.Date.Day && t.Deadline.Date.Day >= (DateTime.Now.Date.Day - 7))
                    {
                        JobCriticalDone += App.DAUtil.CountY(4, true, t);
                        JobHighDone += App.DAUtil.CountY(3, true, t);
                        JobNormalDone += App.DAUtil.CountY(2, true, t);
                        JobLowDone += App.DAUtil.CountY(1, true, t);
                        JobCriticalInprogress += App.DAUtil.CountY(4, false, t);
                        JobHighInprogress += App.DAUtil.CountY(3, false, t);
                        JobNormalInprogress += App.DAUtil.CountY(2, false, t);
                        JobLowInprogress += App.DAUtil.CountY(1, false, t);
                    }
                }
                JobCritical = JobCriticalDone + JobCriticalInprogress;
                JobHigh = JobHighDone + JobHighInprogress;
                JobNormal = JobNormalDone + JobNormalInprogress;
                JobLow = JobLowDone + JobLowInprogress;

                float B = JobCritical * 4 + JobHigh * 3 + JobNormal * 2 + JobLow * 1;
                float A = JobCriticalDone * 4 + JobHighDone * 3 + JobNormalDone * 2 + JobLowDone;
                if (B != 0)
                {
                    var rs = Math.Round(((A / B) * 100), 2);
                    CompleteProcess.Text = rs + "%";
                    List<PieChartModel> Data = new List<PieChartModel>()
                    {
                        new PieChartModel {Name = "Done", Value = rs},
                        new PieChartModel {Name = "Inprogress", Value = (100 - rs)},
                    };
                    lstChart.ItemsSource = Data;
                }
            }
            else
            {
                float JobCriticalDone = 0;
                float JobHighDone = 0;
                float JobNormalDone = 0;
                float JobLowDone = 0;

                float JobCriticalInprogress = 0;
                float JobHighInprogress = 0;
                float JobNormalInprogress = 0;
                float JobLowInprogress = 0;
                float JobCritical;
                float JobHigh;
                float JobNormal;
                float JobLow;
                foreach (var t in Tasks)
                {
                    if (t.Deadline.Date.Month == DateTime.Now.Date.Month)
                    {
                        JobCriticalDone += App.DAUtil.CountY(4, true, t);
                        JobHighDone += App.DAUtil.CountY(3, true, t);
                        JobNormalDone += App.DAUtil.CountY(2, true, t);
                        JobLowDone += App.DAUtil.CountY(1, true, t);
                        JobCriticalInprogress += App.DAUtil.CountY(4, false, t);
                        JobHighInprogress += App.DAUtil.CountY(3, false, t);
                        JobNormalInprogress += App.DAUtil.CountY(2, false, t);
                        JobLowInprogress += App.DAUtil.CountY(1, false, t);
                    }
                }
                JobCritical = JobCriticalDone + JobCriticalInprogress;
                JobHigh = JobHighDone + JobHighInprogress;
                JobNormal = JobNormalDone + JobNormalInprogress;
                JobLow = JobLowDone + JobLowInprogress;

                float B = JobCritical * 4 + JobHigh * 3 + JobNormal * 2 + JobLow * 1;
                float A = JobCriticalDone * 4 + JobHighDone * 3 + JobNormalDone * 2 + JobLowDone;
                if (B != 0)
                {
                    var rs = Math.Round(((A / B) * 100), 2);
                    CompleteProcess.Text = rs + "%";
                    List<PieChartModel> Data = new List<PieChartModel>()
                    {
                        new PieChartModel {Name = "Done", Value = rs},
                        new PieChartModel {Name = "Inprogress", Value = (100 - rs)},
                    };
                    lstChart.ItemsSource = Data;
                }
            }


        }
    }
}