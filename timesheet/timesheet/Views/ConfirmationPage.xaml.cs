using System;
using timesheet.Helpers;
using timesheet.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace timesheet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfirmationPage : ContentPage
    {
        public ConfirmationPage()
        {
            InitializeComponent();
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
                        var todoItem = (TsItems)BindingContext;
                        await App.Database.SaveItemAsync(todoItem);
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