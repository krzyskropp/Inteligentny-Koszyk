using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using System.Windows;
using InteligentnyKoszyk.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace InteligentnyKoszyk
{
    public partial class DetailsPage : PhoneApplicationPage
    {
        // Constructor
        public DetailsPage()
        {
            InitializeComponent();
            //BuildLocalizedApplicationBar();
        }

        // When page is navigated to set data context to selected item in list
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Set the customer being edited to the selected customer and then open it

            // If no customer is selected, just return
            if (List.SelectedItem == null) return;

            // Get the parent application that contains the customer being edited
            App thisApp = Application.Current as App;

            // Set this to the selected customer
            thisApp.ActiveList = List.SelectedItem as List;

            // Navigate to the detail page
            NavigationService.Navigate(new Uri("/DetailsPage.xaml",
                               UriKind.RelativeOrAbsolute));
        }

        private void dodaj_produkt(object sender, RoutedEventArgs e)
        {
            App thisApp = Application.Current as App;

            thisApp.ListNameAdd = Nazwa_listy.Text;
            thisApp.ListDateAdd = Data_listy.Text;
            thisApp.IDAdd = ID.Text;

            NavigationService.Navigate(new Uri("/create_product.xaml", System.UriKind.Relative));
        }

        private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

            App thisApp = Application.Current as App;

            List<Product> produkty = await App.MobileService.GetTable<Product>().Where(c => c.Listname == thisApp.SelectedList.Listname).ToListAsync();

            Nazwa_listy.Text = thisApp.SelectedList.Listname;
            Data_listy.Text = thisApp.SelectedList.Date;
            ID.Text = thisApp.SelectedList.ID;

            MainLongListSelector.ItemsSource = produkty;

        }

        private void powrot(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/logged.xaml", UriKind.Relative));
        }
    }
    }
