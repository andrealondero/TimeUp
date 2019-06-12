using System;
using System.Threading.Tasks;
using timesheet.Helpers;
using timesheet.Models;
using timesheet.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace timesheet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class DashBoardPage : ContentPage
    {
        public static DBHelper db;
        public static Action EmulateBackPressed;
        private bool AcceptBack;
        public DashBoardPage()
        {
            InitializeComponent();
            BindingContext = new LoginPageViewModel(Navigation);
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
                AcceptBack = true;
                EmulateBackPressed();
            }
        }
    }
}