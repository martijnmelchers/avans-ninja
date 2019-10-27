using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using NinjaManager.Models;
using NinjaManager.Models.Interfaces;

namespace NinjaManager.ViewModels.GearViews
{
    public class GearListVM : BaseVM, IRefreshable
    {
        public ObservableCollection<GearVM> Gears { get; set; }
        public ICommand AddGearCommand { get; set; }
        public GearListVM() => InitiateViewModel();
        public void AddGear(GearVM gear) => Gears.Add(gear);

        public void OpenGearScreen() => OpenWindow<AddGear, AddGearVM>(new AddGearVM());

        private List<GearVM> FetchGear()
        {
            var ids = _db.Gear.Select(x => x.Id).ToList();
            var gear = new List<GearVM>();
            ids.ForEach(id => gear.Add(new GearVM(id)));

            return gear;
        }

        public void Refresh()
        {
            Gears.Clear();
            FetchGear().ForEach(x => Gears.Add(x));
        }

        private void InitiateViewModel()
        {
            Gears = new ObservableCollection<GearVM>(FetchGear());
            AddGearCommand = new RelayCommand(OpenGearScreen);
        }
    }
}
