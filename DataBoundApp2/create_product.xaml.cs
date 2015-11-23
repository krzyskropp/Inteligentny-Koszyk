using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using System.Windows.Navigation;
using InteligentnyKoszyk.ViewModels;
using System;

namespace InteligentnyKoszyk
{
    public partial class Create_Product : PhoneApplicationPage
    {
        public Create_Product()
        {
            InitializeComponent();
        }

        private void DropDown_ItemSelected(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PrintText(object sender, SelectionChangedEventArgs e)
        {
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            App thisApp = Application.Current as App;

            string item = (lista_sklepow.SelectedItem as ListBoxItem).Content.ToString();
            
            var Product = new Product { Listname = ListName.Text, Date = ListDate.Text,
                productName = nazwa_produktu.Text, productType = kategoria_produktu.Text, productShop = item, productPrice = Convert.ToDouble(cenaProduktu.Text)};

            await App.MobileService.GetTable<Product>().InsertAsync(Product);

            NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + ID, UriKind.Relative));
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            App thisApp = Application.Current as App;
            ListName.Text = thisApp.ListNameAdd;
            ListDate.Text = thisApp.ListDateAdd;
            ID.Text = thisApp.IDAdd;

        }

        private void nazwa_produktu_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void kategoria_produktu_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void powrot(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/DetailsPage.xaml", UriKind.Relative));
        }
    }
}