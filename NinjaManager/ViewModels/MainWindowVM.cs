using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using NinjaManager.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace NinjaManager.ViewModels
{
    public class MainWindowVM: ViewModelBase
    {

        public ICommand AddNinjaCommand { get; set; }

        private List<Ninja> _NinjaList;

        public MainWindowVM() {
            _NinjaList = new List<Ninja>
            {
                new Ninja{ Name = "Joep", Gold = 100, Inventory = new List<Equipment>(), Agility = 10,Strength = 10, Inteligience = 0 },
                new Ninja{ Name = "Kanker", Gold = 100, Inventory = new List<Equipment>(), Agility = 10,Strength = 10, Inteligience = 0 },
                new Ninja{ Name = "Mogool", Gold = 1000, Inventory = new List<Equipment>(), Agility = 10,Strength = 10, Inteligience = 0 },
                new Ninja{ Name = "Stoeptegel", Gold = 1, Inventory = new List<Equipment>(), Agility = 10,Strength = 10, Inteligience = 10000 },
            };

            AddNinjaCommand = new RelayCommand(AddNinja);
        }


        public List<Ninja> Ninjas
        {
            get
            {
                return _NinjaList;
            }

            set
            {
                _NinjaList = value;
            }
        }

        public void AddNinja()
        {
            var window = new AddNinja();
            window.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
