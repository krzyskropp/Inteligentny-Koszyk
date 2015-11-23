using System.ComponentModel;

namespace InteligentnyKoszyk.ViewModels
{
    public class Product : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string ID { get; set; }

        private string _productName;
        public string productName
        {
            get { return _productName; }
            set
            {
                if (value == _productName)
                    return;

                _productName = value;
                NotifyPropertyChanged("productName");
            }
        }

        private string _productType;
        public string productType
        {
            get { return _productType; }
            set
            {
                if (value == _productType)
                    return;

                _productType = value;
                NotifyPropertyChanged("productType");
            }
        }

        private string _productShop;
        public string productShop
        {
            get { return _productShop; }
            set
            {
                if (value == _productShop)
                    return;

                _productShop = value;
                NotifyPropertyChanged("productShop");
            }
        }

        private double _productPrice;
        public double productPrice
        {
            get { return _productPrice; }
            set
            {
                if (value == _productPrice)
                    return;

                _productPrice = value;
                NotifyPropertyChanged("productPrice");
            }
        }


        private string _listname;
        public string Listname
        {
            get { return _listname; }
            set
            {
                if (value == _listname)
                    return;

                _listname = value;
                NotifyPropertyChanged("Listname");
            }
        }

        private string _date;
        public string Date
        {
            get { return _date; }
            set
            {
                if (value == _date)
                    return;

                _date = value;
                NotifyPropertyChanged("Date");
            }
        }

        public static List SelectedItem { get; internal set; }

        private void NotifyPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
