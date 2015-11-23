using System;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using InteligentnyKoszyk;
using InteligentnyKoszyk.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace InteligentnyKoszyk
{
    public partial class Page1 : PhoneApplicationPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void body_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/logged.xaml", UriKind.Relative));
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        ShellTile primaryTile = ShellTile.ActiveTiles.FirstOrDefault();
        App thisApp = Application.Current as App;


        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            App thisApp = Application.Current as App;

            List<List> MainList = await App.MobileService.GetTable<List>().OrderByDescending(c => c.Date).ToListAsync();
            thisApp.count = MainList.Count;


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
            base.OnNavigatedTo(e);
        }



    }
}