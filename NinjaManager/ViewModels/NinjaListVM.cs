using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NinjaManager.Models;
namespace NinjaManager.ViewModels
{
    public class NinjaListVM : ViewModelBase
    {

        public ObservableCollection<NinjaVM> Ninjas { get; set; }

        public ICommand AddNinjaCommand { get; set; }
        public NinjaListVM()
        {

            var ninjas = new List<Ninja>
            {
                new Ninja{ Name = "Joep", Gold = 100, Inventory = new ObservableCollection<Equipment>()},
                new Ninja{ Name = "Kanker", Gold = 100, Inventory =  new ObservableCollection<Equipment>()},
                new Ninja{ Name = "Mogool", Gold = 1000, Inventory =  new ObservableCollection<Equipment>()},
                new Ninja{ Name = "Stoeptegel", Gold = 1, Inventory =  new ObservableCollection<Equipment>()},
            };


            var ninjaVMs = new List<NinjaVM>();


            ninjas.ForEach((ninja) =>
            {
                ninjaVMs.Add(new NinjaVM(ninja));
            });

            Ninjas = new ObservableCollection<NinjaVM>(ninjaVMs);
            AddNinjaCommand = new RelayCommand(AddNinja);
        }

        public void AddNinja()
        {

            var ninjaVM  = new NinjaVM(new Ninja { Name = "Gekke harry", Gold = 1, Inventory = new ObservableCollection<Equipment>() });
            
            Ninjas.Add(ninjaVM);
        }
    }
}
