using GalaSoft.MvvmLight.Command;
using NinjaManager.Models;
using System.Linq;
using System.Windows.Input;
using System.Data.Entity;

namespace NinjaManager.ViewModels
{
    public class EditNinjaVM : BaseVM
    {
        public Ninja Ninja { get; set; }
        public ICommand EditNinjaCommand { get; set; }

        public EditNinjaVM(int ninjaId)
        {
            Ninja = _db.Ninjas.Include(x => x.Gear).FirstOrDefault(n => n.Id == ninjaId);
            EditNinjaCommand = new RelayCommand(EditNinja);
        }

        public void EditNinja()
        {
            if (Ninja.Gold < 0)
                return;

            _db.SaveChanges();

            var instance = GetInstance<NinjaListVM>();

            instance.Ninjas.Remove(instance.Ninjas.Where(x => x.Ninja.Id == Ninja.Id).FirstOrDefault());
            instance.AddNinja(new NinjaVM(Ninja.Id));
        }

    }
}
