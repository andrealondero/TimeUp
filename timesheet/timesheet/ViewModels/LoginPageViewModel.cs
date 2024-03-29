﻿using System.Threading.Tasks;
using System.Windows.Input;

using timesheet.Helpers;
using timesheet.Models;
using timesheet.Validator;
using timesheet.Views;

using Xamarin.Forms;

namespace timesheet.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        public INavigation _navigation { get; private set; }
        public ICommand LogoutCommand { get; private set; }
        public ICommand CompilerUserCommand { get; private set; }
        public ICommand ViewerUserCommand { get; private set; }
        public ICommand ConfirmationSuperuserCommand { get; private set; }
        public LoginPage _login;

        public LoginPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _users = new Users();
            _userValidator = new UserValidator();
            LogoutCommand = new Command(() => ResetUserInfo());
            CompilerUserCommand = new Command(() => GoToAddItem());
            ViewerUserCommand = new Command(() => GoToListItem());
            ConfirmationSuperuserCommand = new Command(() => GoToConfirmItem());
        }
        //accesso alla compilazione timesheet solo per user
        public void GoToAddItem()
        {
            var userCredits = new Users
            {
                Mail = UserSettings.Mail,
                Password = UserSettings.Password
            };
            var IsUser = UserUser(userCredits);
            if (IsUser)
            {
                UserSettings.GetUserData();
                _navigation.PushAsync(new Views.CompilerPage
                {
                    BindingContext = new TsItems()
                });
            }
        }
        //accesso alla lista timesheet solo per user
        public void GoToListItem()
        {
            var userCredits = new Users
            {
                Mail = UserSettings.Mail,
                Password = UserSettings.Password
            };
            var IsUser = UserUser(userCredits);
            if (IsUser)
            {
                UserSettings.GetUserData();
                _navigation.PushAsync(new Views.ItemListPage
                {
                    BindingContext = new TsItems()
                });
            }
        }
        //accesso alla pagina conferma solo per supervisore
        public void GoToConfirmItem()
        {
            var userCredits = new Users
            {
                Mail = UserSettings.Mail,
                Password = UserSettings.Password
            };
            var IsSuperUser = SuperUserUser(userCredits);
            if (IsSuperUser)
            {
                UserSettings.GetSuperuserData();
                _navigation.PushAsync(new Views.ConfirmationListPage());
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

        async Task ResetUserInfo()
        {
            bool logoutAccept = await Application.Current.MainPage.DisplayAlert("LOGOUT", "Are you sure", "YES", "NO");
            if (logoutAccept)
            {
                UserSettings.ClearAllData();
                _navigation.InsertPageBefore(new LoginPage(),
                    _navigation.NavigationStack[_navigation.NavigationStack.Count - 1]);
                await _navigation.PopAsync();
            }
        }
    }
}
