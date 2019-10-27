using GalaSoft.MvvmLight.Command;
using NinjaManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NinjaManager.ViewModels
{
    public class AddGearVM : BaseVM
    {

        public string Name { get; set; }
        public int Gold { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Agility { get; set; }
        public int Price { get; set; }
        public Array Items { get; set; }
        public Category SelectedItem { get; set; }
        public Category Category { get; set; }

        

        public ICommand CreateGearCommand { get; set; }

        public AddGearVM()
        {
            CreateGearCommand = new RelayCommand(CreateGear);
            Items = Enum.GetValues(typeof(Category));
        }

        public void CreateGear()
        {


            if (Name.Length < 5)
            {
                MessageBox.Show("Name must be more than 5 characters long, the window will be closed.");
                return;
            }
            if (Price < 1)
            {
                MessageBox.Show("Prices must be higher than 0, the window will be closed.");
                return;
            }


            var gear = new Gear {
                Intelligence = Intelligence,
                Strength = Strength,
                Agility = Agility,
                Price = Price,
                Category = SelectedItem,
                Name = Name,
            };


            _db.Gear.Add(gear);
            _db.SaveChanges();

            GetInstance<GearListVM>().AddGear(new GearVM(gear.Id));
        }

    }
}
