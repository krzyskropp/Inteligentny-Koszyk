using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using System;
using InteligentnyKoszyk.ViewModels;
using System.Windows;
using System.Collections.Generic;

namespace InteligentnyKoszyk
{
    public partial class LoggedPage : PhoneApplicationPage
    {
        // Constructor
        public LoggedPage()
        {
            InitializeComponent();
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }

        // Handle selection changed on LongListSelector
        private void MainLongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            App CurrentApp = Application.Current as App;

            // If selected item is null (no selection) do nothing
            if (MainLongListSelector.SelectedItem == null)
                return;

            CurrentApp.SelectedList = MainLongListSelector.SelectedItem as List;
            NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + (MainLongListSelector.SelectedItem as List).ID, UriKind.Relative));


            // Reset selected item to null (no selection)
            MainLongListSelector.SelectedItem = null;
        }

        private void button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/create.xaml", UriKind.Relative));
        }

        private void button_Copy_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            App thisApp = Application.Current as App;

            List<List> MainList = await App.MobileService.GetTable<List>().OrderByDescending(c => c.Date).ToListAsync();
            MainLongListSelector.ItemsSource = MainList;
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}