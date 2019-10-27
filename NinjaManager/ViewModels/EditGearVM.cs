using GalaSoft.MvvmLight.Command;
using NinjaManager.Models;
using System.Linq;
using System.Windows.Input;
using System.Data.Entity;
using System;
using System.Windows;

namespace NinjaManager.ViewModels
{
    public class EditGearVM : BaseVM
    {
        public Gear Gear { get; set; }
        public ICommand EditGearCommand { get; set; }
        public Array Items { get; set; }
        public Category SelectedItem { get; set; }

        public EditGearVM(int gearId)
        {
            Gear = _db.Gear.FirstOrDefault(n => n.Id == gearId);
            EditGearCommand = new RelayCommand(EditGear);
            Items = Enum.GetValues(typeof(Category));

            SelectedItem = Gear.Category;
        }

        public void EditGear()
        {
            if(Gear.Name.Length < 5)
            {
                MessageBox.Show("Name must be more than 5 characters long, the window will be closed.");
                return;
            }
            if(Gear.Price < 1)
            {
                MessageBox.Show("Prices must be higher than 0, the window will be closed.");
                return;
            }
               
            Gear.Category = SelectedItem;
            _db.SaveChanges();

            GetInstance<GearListVM>().Refresh();
        }
    }
}
