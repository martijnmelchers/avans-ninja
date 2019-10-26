using NinjaManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Data.Entity;
using System.Linq;
using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace NinjaManager.ViewModels
{
    class ShopVM : BaseVM
    {
        private List<Gear> ShopItems;
        public ObservableCollection<Gear> ShownShopItems { get; set; }
        public Ninja Ninja { get; set; }
        public RelayCommand<string> ToggleShopCategory { get; set; }
        public ShopVM(int ninjaId)
        {
            InitiateViewModel(ninjaId);
        }

        private void InitiateViewModel(int ninjaId)
        {
            Ninja = _db.Ninjas.Include(x => x.Gear).FirstOrDefault(n => n.Id == ninjaId);
            ShopItems = _db.Gear.ToList();
            ShownShopItems = new ObservableCollection<Gear>();
            ToggleShopCategory = new RelayCommand<string>(category => {
                Enum.TryParse(category, out Category cat);
                ShowShopCategory(cat);
                });
            ShowShopCategory(Category.Head);
        }

        public void ShowShopCategory(Category category)
        {
            ShownShopItems.Clear();
            ShownShopItems.Add(new Gear());
            MessageBox.Show(category.ToString());
        }
    }
}
