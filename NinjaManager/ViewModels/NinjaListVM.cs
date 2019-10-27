using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using NinjaManager.Models;

namespace NinjaManager.ViewModels
{
    public class NinjaListVM : BaseVM, IRefreshable
    {
        public ObservableCollection<NinjaVM> Ninjas { get; set; }
        public ICommand AddNinjaCommand { get; set; }
        public ICommand OpenGearCommand { get; set; }
        public NinjaListVM()
        {
            Ninjas = new ObservableCollection<NinjaVM>(FetchNinjas());
            AddNinjaCommand = new RelayCommand(OpenNinjaScreen);
            OpenGearCommand = new RelayCommand(OpenGearScreen);
        }

        public void AddNinja(NinjaVM ninja)
        {
            Ninjas.Add(ninja);
        }

        public void OpenNinjaScreen()
        {
            OpenWindow<AddNinja, AddNinjaVM>(new AddNinjaVM());
        }

        public void OpenGearScreen()
        {
            OpenWindow<GearWindow, GearListVM>();
        }

        private List<NinjaVM> FetchNinjas()
        {
            var ids = _db.Ninjas.Select(x => x.Id).ToList();
            var ninjas = new List<NinjaVM>();
            ids.ForEach(id => ninjas.Add(new NinjaVM(id)));

            return ninjas;
        }

        public void Refresh()
        {
            Ninjas.Clear();
            FetchNinjas().ForEach(x => Ninjas.Add(x));
        }
    }
}
