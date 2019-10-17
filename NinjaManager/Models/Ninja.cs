using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace NinjaManager.Models
{
    public class Ninja : ObservableObject, IStats
    {
        private string _name;
        private int _gold;
        private ObservableCollection<Equipment> _inventory;

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


        public int Gold
        {
            get
            {
                return _gold;
            }

            set
            {
                Set<int>(() => this.Gold,  ref _gold, value);
            }
        }

        public ObservableCollection<Equipment> Inventory {
            get
            {
                return _inventory;
            }
            set
            {
                Set<ObservableCollection<Equipment>>(() => this.Inventory, ref _inventory, value);
            }
        }

        // Clears inventory and returns the gold spent.
        public void Clear()
        {
            var invValue = 0;
            foreach(Equipment equipment in Inventory)
            {
                invValue += equipment.Price;
            }

            Gold += invValue;

            Inventory.Clear();
        }


        private int InventoryStat(string stat)
        {

            var statPoints = 0;

            try
            {
                foreach (Equipment equipment in Inventory)
                {
                    statPoints += (int)equipment.GetType().GetProperty(stat).GetValue(equipment, null);
                }
            }

            catch (InvalidCastException e)
            {
                throw e;
            }
        
            return statPoints;
        }

        // These values are calculated based on inventory.
        public int Strength {
            get
            {
                return InventoryStat("Strength");
            }

            set
            {
                return;
            }
        }

        public int Intelligence
        {
            get
            {
                return InventoryStat("Intelligence");
            }

            set
            {
                return;
            }
        }

        public int Agility
        {
            get
            {
                return InventoryStat("Agility");
            }

            set
            {
                return;
            }
        }

    }
}
