using FluentValidation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System;

using timesheet.Models;

namespace timesheet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompilerPage : ContentPage
    {
        public TsItems Item { get; set; }
        public IValidator _itemValidator;

        public CompilerPage()
        {
            InitializeComponent();
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(modifyDate.Text))
            {
                await DisplayAlert("Compiling error", "Select a date", "OK");
            }
            if (String.IsNullOrEmpty(hoursLabel.Text))
            {
                await DisplayAlert("Compiling error", "Insert worked hours number", "OK");
            }
            if (String.IsNullOrEmpty(descriptioneditor.Text))
            {
                await DisplayAlert("Compiling error", "Insert activities description", "OK");
            }
            else
            {
                if (!String.IsNullOrEmpty(hoursLabel.Text) && !String.IsNullOrEmpty(descriptioneditor.Text) && !String.IsNullOrEmpty(modifyDate.Text))
                {
                    bool CreateItem = await Application.Current.MainPage.DisplayAlert("NEW ITEM", "Add a new item?", "YES", "NO");
                    if (CreateItem)
                    {
                        var item = (TsItems)BindingContext;
                        await App.Database.SaveItemAsync(item);
                        Navigation.InsertPageBefore(new ItemListPage(),
                            Navigation.NavigationStack[Navigation.NavigationStack.Count - 1]);
                        await Navigation.PopAsync();
                    }
                }
            }
        }
        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            double value = e.NewValue;
            hoursLabel.Text = string.Format("{0}", value);
        }
        private void Datepicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            modifyDate.Text = e.NewDate.ToLongDateString();
            activateDate.IsVisible = false;
        }

        private void ActivateDate_Clicked(object sender, EventArgs e)
        {
            //datepicker.IsVisible = true;
            datepicker.Focus();
            datepicker.DateSelected += (s, a) =>
            {
                modifyDate.Text = datepicker.Date.ToString("dd  MMMM  yyyy");
            };
            activateDate.IsVisible = false;
            modifyDate.IsVisible = true;
        }
        private void ModifyDate_Clicked(object sender, EventArgs e)
        {
            //datepicker.IsVisible = true;
            datepicker.Focus();
            datepicker.DateSelected += (s, a) =>
            {
                modifyDate.Text = datepicker.Date.ToString("dd  MMMM  yyyy");
            };
        }
    }
}