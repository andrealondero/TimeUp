using System;
using timesheet.Helpers;
using timesheet.Models;
using timesheet.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace timesheet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public static Action EmulateBackPressed;
        private bool AcceptBack;
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new LoginPageViewModel(Navigation);
        }

        private void IsPassword_Toggled(object sender, ToggledEventArgs e)
        {
            if (isPassword.IsToggled)
            {
                passwordEntry.IsPassword = false;
            }
            if (!isPassword.IsToggled)
            {
                passwordEntry.IsPassword = true;
            }
        }

        protected override bool OnBackButtonPressed()
        {
            if (AcceptBack)
                return false;
            PromptForExit();
            return true;
        }
        private async void PromptForExit()
        {
            if (await DisplayAlert("QUIT", "Are you sure?", "YES", "NO"))
            {
                UserSettings.ClearAllData();
                AcceptBack = true;
                EmulateBackPressed();
            }
        }

        public class User : Users
        {
            public User(string UserName, string Password)
            {
                this.Mail = UserName;
                this.Password = Password;
            }
        }
        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            var userCredits = new Users
            {
                Mail = UserSettings.Mail,
                Password = UserSettings.Password
            };

            var userMail = UserMail(userCredits);
            var superMail = SuperMail(userCredits);
            var userPass = UserPass(userCredits);
            var superPass = SuperPass(userCredits);

            string name = usernameEntry.Text;

            var IsUser = UserUser(userCredits);
            var IsSuperUser = SuperUserUser(userCredits);

            if (String.IsNullOrEmpty(usernameEntry.Text))
            {
                DisplayAlert("LOGIN ERROR", "Insert a UserName", "OK");
            }
            if (String.IsNullOrEmpty(passwordEntry.Text))
            {
                DisplayAlert("LOGIN ERROR", "Insert a Password", "OK");
            }
            if (!userMail && !superMail && !String.IsNullOrEmpty(usernameEntry.Text))
            {
                DisplayAlert("LOGIN ERROR", "incorrect username", "OK");
            }
            if (!userPass && !superPass && !String.IsNullOrEmpty(passwordEntry.Text))
            {
                DisplayAlert("LOGIN ERROR", "incorrect password", "OK");
            }
            else
            {
                if (IsUser && !IsSuperUser)
                {
                    UserSettings.GetUserData();
                    Application.Current.MainPage.DisplayAlert("WELCOME", "andrea.londero", "OK");
                    //Navigation.PushAsync(new DashBoardPage());
                    Navigation.InsertPageBefore(new DashBoardPage(),
                            Navigation.NavigationStack[Navigation.NavigationStack.Count -1]);
                    Navigation.PopAsync();
                }
                if (!IsUser && IsSuperUser)
                {
                    UserSettings.GetSuperuserData();
                    Application.Current.MainPage.DisplayAlert("WELCOME", "paolo.loconsole", "OK");
                    Navigation.InsertPageBefore(new DashBoardSuperPage(),
                            Navigation.NavigationStack[Navigation.NavigationStack.Count - 1]);
                    Navigation.PopAsync();
                }
            }
        }
        bool UserUser(Users user)
        {
            return user.Mail == "andrea.londero" && user.Password == "aryonsolutions";
        }
        bool SuperUserUser(Users user)
        {
            return user.Mail == "paolo.loconsole" && user.Password == "supervisore";
        }
        bool UserMail(Users u)
        {
            return u.Mail == "andrea.londero";
        }
        bool UserPass(Users u)
        {
            return u.Password == "aryonsolutions";
        }
        bool SuperMail(Users u)
        {
            return u.Mail == "paolo.loconsole";
        }
        bool SuperPass(Users u)
        {
            return u.Password == "supervisore";
        }       
    }
}