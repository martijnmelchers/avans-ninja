using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using NinjaManager.Models;
namespace NinjaManager.ViewModels
{
    public class SingleNinjaVM : BaseVM
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

            var inv = new ObservableCollection<Gear>(Ninja.Gear);

            inv.Add(new Gear { Agility = 10, Strength = 20, Intelligence = 30 });

            Ninja.Gear = new List<Gear>(inv);

            RaisePropertyChanged(nameof(Ninja));

        }
    }
}
