using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System.Linq;
using NinjaManager.Models;

namespace NinjaManager.ViewModels.GearViews
{
    public class GearVM : BaseVM
    {
        public Gear Gear { get; set; }
        public ICommand EditGearCommand { get; set;  }
        public ICommand DeleteGearCommand { get; set; }
        public GearVM(int gearId) => InitiateViewModel(gearId);

        public void EditGear() => OpenWindow<EditGear, EditGearVM>(new EditGearVM(Gear.Id));

        public void DeleteGear()
        {
            _db.Gear.Remove(Gear);
            _db.SaveChanges();

            GetInstance<GearListVM>().Gears.Remove(this);

        }

        private void InitiateViewModel(int gearId)
        {
            Gear = _db.Gear.FirstOrDefault(n => n.Id == gearId);

            EditGearCommand = new RelayCommand(EditGear);
            DeleteGearCommand = new RelayCommand(DeleteGear);
        }

    }
}
