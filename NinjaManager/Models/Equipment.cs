using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaManager.Models
{
    public class Equipment : ObservableObject,  IStats
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Category Category { get; private set; }

        private int _strength;
        private int _intelligence;
        private int _agility;

        public int Strength {
            get
            {
                return _strength;
            }
            set
            {
                Set(() => this.Strength, ref _strength, value);
            }
        }

        public int Intelligence
        {
            get
            {
                return _intelligence;
            }
            set
            {
                Set(() => this.Intelligence, ref _intelligence, value);
            }
        }

        public int Agility
        {
            get
            {
                return _agility;
            }
            set
            {
                Set(() => this.Agility, ref _agility, value);
            }
        }

        public Equipment()
        {
                        
        }
    }
}
