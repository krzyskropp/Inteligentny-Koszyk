﻿using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using InteligentnyKoszyk.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Navigation;
using Microsoft.Phone.Shell;
using System.Linq;

namespace InteligentnyKoszyk
{
    public partial class create : PhoneApplicationPage
    {
        public create()
        {
            InitializeComponent();
            dateoflist.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
        }

        private void data_utworzenia_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Set the customer being edited to the selected customer and then open it

            // If no customer is selected, just return
            if (List.SelectedItem == null) return;

            // Get the parent application that contains the customer being edited
            App thisApp = Application.Current as App;

            // Set this to the selected customer
            thisApp.ActiveList = List.SelectedItem as List;
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            var List = new List { Listname = nameoflist.Text, Date = dateoflist.Text };

            await App.MobileService.GetTable<List>().InsertAsync(List);

            ShellTile primaryTile = ShellTile.ActiveTiles.FirstOrDefault();
            FlipTileData newTile = new FlipTileData()
            {
                Title = "           iKoszyk",
                Count = (await App.MobileService.GetTable<List>().ToListAsync()).Count,
                BackgroundImage = new Uri("/Assets/Tiles/basketmedium.png", UriKind.Relative),
                SmallBackgroundImage = new Uri("/Assets/Tiles/basket.png", UriKind.Relative),
                WideBackgroundImage = new Uri("/Assets/Tiles/basketwide.png", UriKind.Relative),
                BackTitle = "Inteligentny Koszyk",
                BackContent = "Zarządzaj swoim koszykiem",
                WideBackContent = "Inteligentna aplikacja wspomagająca zakupy :-)",
                BackBackgroundImage = new Uri("", UriKind.Relative),
                WideBackBackgroundImage = new Uri("", UriKind.Relative)
            };

            primaryTile.Update(newTile);
            NavigationService.Navigate(new Uri("/logged.xaml", UriKind.Relative));
        }

        private void powrot(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/logged.xaml", UriKind.Relative));
        }
    }
}