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
using System.ComponentModel;

namespace NinjaManager.ViewModels
{
    class ShopVM : BaseVM, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<Gear> ShopItems;
        public ObservableCollection<Gear> ShownShopItems { get; set; }
        private SelectedItem _selectedItem;
        public SelectedItem SelectedItem { 
            get => _selectedItem; 
            set {
                _selectedItem = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(SelectedItem)));
            }
        }

        private string _ninjaMoneyText;
        public string NinjaMoneyText
        {
            get => _ninjaMoneyText;
            set
            {
                _ninjaMoneyText = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(NinjaMoneyText)));
            }
        }
        public Ninja Ninja { get; set; }
        public ICommand ToggleShopCategory { get; set; }
        public ICommand SelectShopItem { get; set; }
        public ICommand BuySellItemCommand { get; set; }
        public ShopVM(int ninjaId) => InitiateViewModel(ninjaId);
        private void InitiateViewModel(int ninjaId)
        {
            Ninja = _db.Ninjas.Include(x => x.Gear).FirstOrDefault(n => n.Id == ninjaId);
            ShopItems = _db.Gear.ToList();
            ShownShopItems = new ObservableCollection<Gear>();
            ToggleShopCategory = new RelayCommand<string>(ShowShopCategory);
            SelectShopItem = new RelayCommand<int>(SelectItem);
            BuySellItemCommand = new RelayCommand<int>(BuySellItem);
            ShowShopCategory("Head");
            _ninjaMoneyText = $"You have {Ninja.Gold} gold";
        }

        public void ShowShopCategory(string category)
        {
            Enum.TryParse(category, out Category cat);
            ShownShopItems.Clear();
            ShopItems.Where(x => x.Category == cat).ToList().ForEach(item => ShownShopItems.Add(item));
        }

        public void SelectItem(int id)
        {
            var item = ShopItems.Where(x => x.Id == id).FirstOrDefault();

            SelectedItem = new SelectedItem()
            {
                Item = item,
                ButtonText = Ninja.Gear.Contains(item) ? "Verkopen" : "Kopen",
                Enabled = Ninja.Gear.Contains(item) ? true : Ninja.Gear.Any(x => x.Category == item.Category) ? false : Ninja.Gold >= item.Price ? true : false
            };
        }

        public void BuySellItem(int id)
        {
            var item = ShopItems.Where(x => x.Id == id).FirstOrDefault();

            if(Ninja.Gear.Contains(item))
            {
                Ninja.Gear.Remove(item);
                Ninja.Gold += item.Price;

                _db.SaveChanges();

                SelectItem(id);
            }
            else
            {
                Ninja.Gear.Add(item);
                Ninja.Gold -= item.Price;

                _db.SaveChanges();

                SelectItem(id);

            }

            GetInstance<NinjaListVM>().Refresh();
            NinjaMoneyText = $"You have {Ninja.Gold} gold";
        }
    }
}
