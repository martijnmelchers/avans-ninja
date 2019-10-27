using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Data.Entity;
using NinjaManager.Models;

namespace NinjaManager.ViewModels.NinjaViews
{
    public class NinjaVM : BaseVM
    {
        public Ninja Ninja { get; set; }
        public ICommand OpenNinjaCommand { get; set; }
        public ICommand EditNinjaCommand { get; set; }
        public ICommand DeleteNinjaCommand { get; set; }
        public ICommand OpenNinjaShopCommand { get; set; }
        public ICommand ClearNinjaCommand { get; set; }
        public NinjaVM(int ninjaId) => InitiateViewModel(ninjaId);
        public void OpenNinja() => OpenWindow<NinjaWindow, SingleNinjaVM>(new SingleNinjaVM(Ninja));
        public void EditNinja() => OpenWindow<EditNinja, EditNinjaVM>(new EditNinjaVM(Ninja.Id));
        public void OpenNinjaShop() => OpenWindow<Shop, ShopVM>(new ShopVM(Ninja.Id));

        public void ClearNinja()
        {
            Ninja.Clear();
            _db.SaveChanges();
        }

        public void DeleteNinja()
        {
            _db.Ninjas.Remove(Ninja);
            _db.SaveChanges();

            GetInstance<NinjaListVM>().Ninjas.Remove(this);

        }

        private void InitiateViewModel(int ninjaId)
        {
            /* The database context can't track across multiple entities so we get the Ninja in the VM itself */
            Ninja = _db.Ninjas.Include(x => x.Gear).FirstOrDefault(n => n.Id == ninjaId);

            DeleteNinjaCommand = new RelayCommand(DeleteNinja);
            EditNinjaCommand = new RelayCommand(EditNinja);
            OpenNinjaCommand = new RelayCommand(OpenNinja);
            OpenNinjaShopCommand = new RelayCommand(OpenNinjaShop);
            ClearNinjaCommand = new RelayCommand(ClearNinja);
        }
    }
}
