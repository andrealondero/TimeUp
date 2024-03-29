﻿using Plugin.InputKit.Shared.Controls;
using System;
using System.Collections.Generic;

using timesheet.Models;
using timesheet.ViewModels;

using Xamarin.Forms;

namespace timesheet.Views
{
    public partial class ItemListPage : ContentPage
    {
        public TsItems Item { get; set; }
        ListViewModel viewModel;
        List<TsItems> Items;

        public ItemListPage()
        {
            InitializeComponent();
            BindingContext = viewModel;
            ItemsList();
        }
        public void ItemsList()
        {
            Items = new List<TsItems>();
            Items.Add(new TsItems
            {
                ID = 1,
                User_ID = 1,
                Hours = 0,
                Description = "your activities",
                ConfirmedStatus = false,
                RefusedStatus = false,
                Date = DateTime.Now
            });
            listView.ItemsSource = Items;
        }
        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddItemPage
            {
                BindingContext = new TsItems()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ItemPage
                {
                    BindingContext = e.SelectedItem as TsItems
                });
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ((App)App.Current).ResumeAtTodoId = -1;
            listView.ItemsSource = await App.Database.GetAllItemsAsync();
        }

        async void Radio_SelectedItemChanged(object sender, EventArgs e)
        {
            var button = (RadioButtonGroupView)sender;
            int selectedIndex = button.SelectedIndex;

            if (selectedIndex == 0)
            {
                listView.ItemsSource = await App.Database.GetItemsConfirmedAsync();
            }

            else if (selectedIndex == 1)
            {
                listView.ItemsSource = await App.Database.GetItemsRefusedAsync();
            }

            else if (selectedIndex == 2)
            {
                listView.ItemsSource = await App.Database.GetItemsSuspendedAsync();
            }

            else if (selectedIndex == 3)
            {
                listView.ItemsSource = await App.Database.GetAllItemsAsync();
            }
        }
    }
}