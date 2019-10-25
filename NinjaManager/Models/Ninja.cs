using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NinjaManager.Models
{
    public class Ninja : ObservableObject, IStats
    {
        public Ninja()
        {

        }
        public Ninja(string name, int gold)
        {
            Name = name;
            Gold = gold;
            Gear = new List<Gear>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        private string _name;
        public string Name
        {
            get => _name;
            set => Set(nameof(Name), ref _name, value);
        }

        private int _gold;
        public int Gold
        {
            get => _gold;
            set => Set(nameof(Gold), ref _gold, value);
        }

        public virtual List<Gear> Gear { get; set; }


        // Clears inventory and returns the gold spent.
        public void Clear()
        {
            var invValue = 0;
            foreach(Gear equipment in Gear)
                invValue += equipment.Price;

            Gold += invValue;

            Gear.Clear();
        }


        private int InventoryStat(string stat)
        {

            var statPoints = 0;

            try
            {
                foreach (Gear equipment in Gear)
                    statPoints += (int)equipment.GetType().GetProperty(stat).GetValue(equipment, null);
            }

            catch (Exception e)
            {
                throw e;
            }
        
            return statPoints;
        }

        // These values are calculated based on inventory.
        public int Strength => InventoryStat("Strength");
        public int Intelligence => InventoryStat("Intelligence");
        public int Agility => InventoryStat("Agility");

    }
}
