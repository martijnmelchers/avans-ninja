using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using NinjaManager.Models;
using System.Data.Entity;

namespace NinjaManager.ViewModels
{
    public class NinjaVM : BaseVM
    {
        public Ninja Ninja { get; set; }
        public ICommand OpenNinjaCommand { get; set; }
        public ICommand EditNinjaCommand { get; set; }
        public ICommand DeleteNinjaCommand { get; set; }
        public ICommand OpenNinjaShopCommand { get; set; }
        private int InventoryCount => Ninja.Gear.Count;


        public NinjaVM(int ninjaId)
        {
            InitiateViewModel(ninjaId);
            //Ninja.Inventory.CollectionChanged += OnCollectionChanged;
        }

        public void OpenNinja()
        {
            // Open single ninja.
            var context = GetInstance<SingleNinjaVM>();
            context.Ninja = Ninja;

            OpenWindow<NinjaWindow, SingleNinjaVM>(context);
        }

        public void EditNinja()
        {
            OpenWindow<EditNinja, EditNinjaVM>(new EditNinjaVM(Ninja.Id));
        }
        public void OpenNinjaShop()
        {
            OpenWindow<Shop, ShopVM>(new ShopVM(Ninja.Id));
        }

        public void DeleteNinja()
        {
            _db.Ninjas.Remove(Ninja);
            _db.SaveChanges();

            GetInstance<NinjaListVM>().Ninjas.Remove(this);

        }

        void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Ninja.RaisePropertyChanged("");
        }

        private void InitiateViewModel(int ninjaId)
        {
            /* The database context can't track across multiple entities so we get the Ninja in the VM itself */
            Ninja = _db.Ninjas.Include(x => x.Gear).FirstOrDefault(n => n.Id == ninjaId);

            DeleteNinjaCommand = new RelayCommand(DeleteNinja);
            EditNinjaCommand = new RelayCommand(EditNinja);
            OpenNinjaCommand = new RelayCommand(OpenNinja);
            OpenNinjaShopCommand = new RelayCommand(OpenNinjaShop);
        }
    }
}
