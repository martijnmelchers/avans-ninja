using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NinjaManager.Models
{
    public class Ninja : Stats, INotifyPropertyChanged
    {

        private string _name;
        private int _gold;
        private List<Equipment> _inventory;

        public string Name
        {
            get
            {
                return _name;
            }
            set {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public int Gold {
            get
            {
                return _gold;
            }

            set
            {
                _gold = value;
                OnPropertyChanged("Gold");
            }
        }

        public List<Equipment> Inventory {
            get {
                return _inventory;
            }
            set {
                _inventory = value;
                OnPropertyChanged("Inventory");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
