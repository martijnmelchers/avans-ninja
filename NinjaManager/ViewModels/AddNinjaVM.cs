using GalaSoft.MvvmLight.Command;
using NinjaManager.Models;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NinjaManager.ViewModels
{
    public class AddNinjaVM : BaseVM
    {

        public string Name { get; set; }
        public int Gold { get; set; }
        public ICommand CreateNinjaCommand { get; set; }

        public AddNinjaVM()
        {
            CreateNinjaCommand = new RelayCommand(CreateNinja);
            
        }

        public void CreateNinja()
        {
            if (Gold <= 0 || Name.Length <= 3)
            {
                MessageBox.Show("Name has to be longer then 3 characters, and ninja has to start with more then 0 gold", "Invalid values!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            var ninja = new Ninja(Name, Gold);


            _db.Ninjas.Add(ninja);
            _db.SaveChanges();

            GetInstance<NinjaListVM>().AddNinja(new NinjaVM(ninja.Id));

            
        }

    }
}
