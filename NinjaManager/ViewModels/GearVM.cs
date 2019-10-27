using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Windows.Input;
using System.Data.Entity;
using System.Linq;
using NinjaManager.Models;

namespace NinjaManager.ViewModels
{
    public class GearVM : BaseVM
    {
        public Gear Gear { get; set; }

        public ICommand EditGearCommand { get; set;  }
        public ICommand DeleteGearCommand { get; set; }

        public GearVM(int gearId)
        {
            InitiateViewModel(gearId);
            //Ninja.Inventory.CollectionChanged += OnCollectionChanged;
        }

        public void EditGear()
        {
            OpenWindow<EditGear, EditGearVM>(new EditGearVM(Gear.Id));
        }

        public void DeleteGear()
        {
            _db.Gear.Remove(Gear);
            _db.SaveChanges();

            GetInstance<GearListVM>().Gears.Remove(this);

        }

        void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Gear.RaisePropertyChanged("");
        }

        private void InitiateViewModel(int gearId)
        {
            /* The database context can't track across multiple entities so we get the Ninja in the VM itself */
            Gear = _db.Gear.FirstOrDefault(n => n.Id == gearId);

            EditGearCommand = new RelayCommand(EditGear);
            DeleteGearCommand = new RelayCommand(DeleteGear);

            /*DeleteNinjaCommand = new RelayCommand(DeleteNinja);
            OpenNinjaCommand = new RelayCommand(OpenNinja);
            OpenNinjaShopCommand = new RelayCommand(OpenNinjaShop);*/
        }

    }
}
