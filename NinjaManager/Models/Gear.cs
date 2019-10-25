using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NinjaManager.Models
{
    public class Gear : ObservableObject,  IStats
    {
        public Gear()
        {

        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Category Category { get; private set; }

        private int _strength;
        public int Strength {
            get => _strength;
            set => Set(nameof(Strength), ref _strength, value);
        }

        private int _intelligence;

        public int Intelligence
        {
            get => _intelligence;
            set => Set(nameof(Intelligence), ref _intelligence, value);

        }

        private int _agility;
        public int Agility
        {
            get => _agility;
            set => Set(nameof(Agility), ref _agility, value);
        }
        
        public virtual ICollection<Ninja> Ninjas { get; set; }
    }
}
