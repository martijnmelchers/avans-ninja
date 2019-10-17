using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NinjaManager.Models
{
    public class Ninja : ObservableObject
    {
        private string _name;
        private int _gold;
        private int _inventory;

        public int Agility;
        public int Intelligence;
        public int Strength;

        public string Name {
            get
            {
                return _name;
            }

            set
            {
                Set<string>(() => this.Name, ref _name, value);
            }
        }


        public int Gold { get; set; }
        public List<Equipment> Inventory { get; set; }
    }
}
