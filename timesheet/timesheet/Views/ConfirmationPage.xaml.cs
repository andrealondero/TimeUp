using System;
using timesheet.Helpers;
using timesheet.Models;
using timesheet.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace timesheet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfirmationPage : ContentPage
    {
        public TsItems Item { get; set; }
        ItemPageViewModel viewModel;

        public ConfirmationPage(ItemPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        public ConfirmationPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            if (radConf.IsChecked && !radRef.IsChecked)
            {
                radRef.IsDisabled = true;
            }
            if (!radConf.IsChecked && radRef.IsChecked)
            {
                radConf.IsDisabled = true;
            }

            base.OnAppearing();
        }

        async void OnSave(object sender, EventArgs e)
        {
            if (!radConf.IsDisabled && !radRef.IsDisabled)
            {
                await DisplayAlert("ERROR", "Please choose CONFIRM OR REFUSE", "OK");
            }
            else
            {
                if (radConf.IsDisabled && !radRef.IsDisabled || !radConf.IsDisabled && radRef.IsDisabled)
                {
                    bool CreateItem = await Application.Current.MainPage.DisplayAlert("CONFIRM", "Save the timesheet?", "YES", "NO");
                    if (CreateItem)
                    {
                        var item = (TsItems)BindingContext;
                        await App.Database.SaveItemAsync(item);
                        Navigation.InsertPageBefore(new ConfirmationListPage(),
                            Navigation.NavigationStack[Navigation.NavigationStack.Count - 3]);
                        await Navigation.PopAsync();
                    }
                }
            }
        }
        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void RadConf_Clicked(object sender, EventArgs e)
        {
            if (radConf.IsChecked)
            {
                radRef.IsDisabled = true;
            }
            if (!radConf.IsChecked)
            {
                radRef.IsDisabled = false;
            }
        }
        private void RadRef_Clicked(object sender, EventArgs e)
        {
            if (radRef.IsChecked)
            {
                radConf.IsDisabled = true;
            }
            if (!radRef.IsChecked)
            {
                radConf.IsDisabled = false;
            }
        }
    }
}