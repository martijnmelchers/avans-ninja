using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NinjaManager.Models;
namespace NinjaManager.ViewModels
{
    public class SingleNinjaVM : ViewModelBase
    {
        public string Saus { get; set; }
        public Ninja Ninja { get; set; }
        public ICommand NinjaChangeCommand { get; set; }


        public SingleNinjaVM()
        {
            NinjaChangeCommand = new RelayCommand(NinjaChange);
        }


        public void NinjaChange()
        {

            var inv = new ObservableCollection<Equipment>();
            inv = Ninja.Inventory;

            Ninja.Inventory = new ObservableCollection<Equipment>();
            inv.Add(new Equipment { Agility = 10, Strength = 20, Intelligence = 30 });

            Ninja.Inventory = inv;

            RaisePropertyChanged("Ninja");

        }
    }
}
