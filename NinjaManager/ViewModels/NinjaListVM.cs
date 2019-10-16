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
    public class NinjaListVM
    {

        public ObservableCollection<NinjaVM> Ninjas { get; set; }

        public ICommand AddNinjaCommand { get; set; }

        public NinjaListVM()
        {

            var ninjas = new List<Ninja>
            {
                new Ninja{ Name = "Joep", Gold = 100, Inventory = new List<Equipment>(), Agility = 10,Strength = 10, Inteligience = 0 },
                new Ninja{ Name = "Kanker", Gold = 100, Inventory = new List<Equipment>(), Agility = 10,Strength = 10, Inteligience = 0 },
                new Ninja{ Name = "Mogool", Gold = 1000, Inventory = new List<Equipment>(), Agility = 10,Strength = 10, Inteligience = 0 },
                new Ninja{ Name = "Stoeptegel", Gold = 1, Inventory = new List<Equipment>(), Agility = 10,Strength = 10, Inteligience = 10000 },
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
            Ninjas.Add(new NinjaVM(new Ninja { Name = "Gekke harry", Gold = 1, Inventory = new List<Equipment>(), Agility = 10, Strength = 10, Inteligience = 10000 }));
        }
    }
}
