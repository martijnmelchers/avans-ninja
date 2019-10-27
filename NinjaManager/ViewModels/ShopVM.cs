using NinjaManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Data.Entity;
using System.Linq;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;

namespace NinjaManager.ViewModels
{
    class ShopVM : BaseVM
    {
        private List<Gear> ShopItems;
        public ObservableCollection<Gear> ShownShopItems { get; set; }
        public Ninja Ninja { get; set; }
        public ICommand ToggleShopCategory { get; set; }
        public ICommand SelectShopItem { get; set; }
        public ShopVM(int ninjaId)
        {
            InitiateViewModel(ninjaId);
        }

        private void InitiateViewModel(int ninjaId)
        {
            Ninja = _db.Ninjas.Include(x => x.Gear).FirstOrDefault(n => n.Id == ninjaId);
            ShopItems = _db.Gear.ToList();
            ShownShopItems = new ObservableCollection<Gear>();
            ToggleShopCategory = new RelayCommand<string>(category =>
            {
                Enum.TryParse(category, out Category cat);
                ShowShopCategory(cat);
            });
            SelectShopItem = new RelayCommand<int>(SelectItem);
            ShowShopCategory(Category.Head);
        }

        public void ShowShopCategory(Category category)
        {
            ShownShopItems.Clear();

            ShopItems.Where(x => x.Category == category).ToList().ForEach(item => ShownShopItems.Add(item));
            var c = new Gear()
            {
                Name = "Headband",
                Intelligence = 5,
                Agility = 3,
                Strength = 10,
                Price = 500,
                Category = Category.Head
            };

            ShownShopItems.Add(c);
        }

        public void SelectItem(int id)
        {
            MessageBox.Show("Het ontvangen ID is", id.ToString());
        }
    }
}
