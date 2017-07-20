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
    public partial class HomePage : MasterDetailPage
    {
        private static HomePage _instance;
        public static HomePage Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HomePage();
                }
                return _instance;
            }
        }
        public HomePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as HomePageMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            if (page.Title == "Profile")
            {
                Detail = new NavigationPage(new ProfilePage());

            }
            else if (page.Title == "Report")
            {
                Detail = new NavigationPage(new ReportPage());
            }
            else if (page.Title == "Filter")
            {
                Detail = new NavigationPage(new FilterPage());
            }
            else if (page.Title == "Logout")
            {
                bool accepted = await DisplayAlert("Confirm", "Are you sure to logout", "ok", "cancel");
                if (accepted)
                {
                    await Navigation.PushAsync(new LoginPage());

                }
            }
            else
            {
                Detail = new NavigationPage(page);
            }
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}