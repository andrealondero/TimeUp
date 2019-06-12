using System;
using timesheet.Helpers;
using timesheet.Models;
using timesheet.ViewModels;
using Xamarin.Forms;

namespace timesheet.Views
{
    public partial class ItemPage : ContentPage
    {
        public TsItems Item { get; set; }
        ItemPageViewModel viewModel;
        public ItemPage(ItemPageViewModel viewModel)
        {
            Init();
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        public ItemPage()
        {
            InitializeComponent();
        }

        public void Init()
        {
            datePicker.DateSelected += (s, e) => hoursLabel.Focus();
            hoursLabel.BindingContextChanged += (s, e) => descriptionEditor.Focus();
            descriptionEditor.Completed += (s, e) => OnSaveClicked(s, e);
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(hoursLabel.Text))
            {
                await DisplayAlert("Compiling error", "Insert worked hours number", "OK");
            }
            if (String.IsNullOrEmpty(descriptionEditor.Text))
            {
                await DisplayAlert("Compiling error", "Insert activities description", "OK");
            }
            else
            {
                if (!String.IsNullOrEmpty(hoursLabel.Text) && !String.IsNullOrEmpty(descriptionEditor.Text))
                {
                    bool CreateItem = await Application.Current.MainPage.DisplayAlert("MODIFY ITEM", "Save changes?", "YES", "NO");
                    if (CreateItem)
                    {
                        var item = (TsItems)BindingContext;
                        await App.Database.SaveItemAsync(item);
                        Navigation.InsertPageBefore(new ItemListPage(),
                            Navigation.NavigationStack[Navigation.NavigationStack.Count - 3]);
                        await Navigation.PopAsync();
                    }
                }
            }
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            bool CreateItem = await Application.Current.MainPage.DisplayAlert("DELETE ITEM", "Delete timesheet?", "YES", "NO");
            if (CreateItem)
            {
                var item = (TsItems)BindingContext;
                await App.Database.DeleteItemAsync(item);
                await Navigation.PopAsync();
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
    }
}