using System.Collections.Generic;
using System.ComponentModel;

namespace InteligentnyKoszyk.ViewModels
{
    public class List : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string ID { get; set; }

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
