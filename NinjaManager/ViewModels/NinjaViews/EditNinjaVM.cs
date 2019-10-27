using GalaSoft.MvvmLight.Command;
using NinjaManager.Models;
using System.Linq;
using System.Windows.Input;
using System.Data.Entity;
using System.Windows;

namespace NinjaManager.ViewModels.NinjaViews
{
    public class EditNinjaVM : BaseVM
    {
        public Ninja Ninja { get; set; }
        public ICommand EditNinjaCommand { get; set; }
        public EditNinjaVM(int ninjaId) => InitiateViewModel(ninjaId);

        public void EditNinja()
        {
            if (Ninja.Gold <= 0 || Ninja.Name.Length <= 3)
            {
                MessageBox.Show("Name has to be longer then 3 characters, and ninja has to start with more then 0 gold", "Invalid values!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            _db.SaveChanges();
            GetInstance<NinjaListVM>().Refresh();
        }

        private void InitiateViewModel(int ninjaId)
        {
            Ninja = _db.Ninjas.Include(x => x.Gear).FirstOrDefault(n => n.Id == ninjaId);
            EditNinjaCommand = new RelayCommand(EditNinja);
        }

    }
}
