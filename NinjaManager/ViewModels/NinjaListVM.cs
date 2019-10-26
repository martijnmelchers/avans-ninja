using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
namespace NinjaManager.ViewModels
{
    public class NinjaListVM : BaseVM
    {
        public ObservableCollection<NinjaVM> Ninjas { get; set; }
        public ICommand AddNinjaCommand { get; set; }
        public NinjaListVM()
        {
            Ninjas = new ObservableCollection<NinjaVM>(FetchNinjas());
            AddNinjaCommand = new RelayCommand(OpenNinjaScreen);
        }

        public void AddNinja(NinjaVM ninja)
        {
            Ninjas.Add(ninja);
        }

        public void OpenNinjaScreen()
        {
            OpenWindow<AddNinja, AddNinjaVM>();
        }

        private List<NinjaVM> FetchNinjas()
        {
            var ninjas = _db.Ninjas.Select(x => x.Id).ToList();



            var ninjaVMs = new List<NinjaVM>();


            ninjas.ForEach((ninja) =>
            {
                ninjaVMs.Add(new NinjaVM(ninja));
            });

            return ninjaVMs;
        }
    }
}
