using System;
using System.IO;

using timesheet.Helpers;
using timesheet.ViewModels;
using timesheet.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace timesheet

{
    public class App : Application
    {
        static DBHelper database;
        public App()
        {
            Resources = new ResourceDictionary();
            Resources.Add("primaryGray", Color.FromHex("E5E9EA"));
            Resources.Add("primaryDarkGray", Color.FromHex("2D2A2A"));
            Resources.Add("primaryAqua", Color.FromHex("83D3D4"));
            Resources.Add("primaryDarkAqua", Color.FromHex("2D8183"));
            Resources.Add("primaryRed", Color.FromHex("FF5657"));
            Resources.Add("primaryDarkRed", Color.FromHex("910C07"));

            SetMainPage();
        }
        /*private void SetMainPage()
        {
            if (!string.IsNullOrEmpty(UserSettings.Mail)
                  && !string.IsNullOrEmpty(UserSettings.Password))
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new NavigationPage(new DashBoardPage());
            }
        }*/
        private void SetMainPage()
        {
            if (!string.IsNullOrEmpty(UserSettings.Mail)
                && !string.IsNullOrEmpty(UserSettings.Password))
            {
                if (UserSettings.Mail == "andrea.londero" && UserSettings.Password == "aryonsolutions")
                {
                    var nav = new NavigationPage(new DashBoardPage());
                    nav.BarBackgroundColor = (Color)App.Current.Resources["primaryAqua"];
                    nav.BarBackgroundColor = (Color)App.Current.Resources["primaryAqua"];
                    MainPage = nav;
                }
                else if (UserSettings.Mail == "paolo.loconsole" && UserSettings.Password == "supervisore")
                {
                    var nav = new NavigationPage(new DashBoardSuperPage());
                    nav.BarBackgroundColor = (Color)App.Current.Resources["primaryAqua"];
                    nav.BarBackgroundColor = (Color)App.Current.Resources["primaryAqua"];
                    MainPage = nav;
                }
            }
            else MainPage = new NavigationPage(new LoginPage());
        }
        public static DBHelper Database
        {
            get
            {
                if (database == null)
                {
                    database = new DBHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ManagerDB.db3"));
                }
                return database;
            }
        }
        public int ResumeAtTodoId { get; set; }
        protected override void OnStart()
        {
        }
        protected override void OnSleep()
        {
        }
        protected override void OnResume()
        {
        }
    }
}
