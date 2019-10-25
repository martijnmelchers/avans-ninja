using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using NinjaManager.Models;
namespace NinjaManager.ViewModels
{
    public class NinjaVM : BaseVM
    {
        public Ninja Ninja { get; set; }
        public RelayCommand OpenNinjaCommand { get; set; }
        private int InventoryCount => Ninja.Gear.Count;

        public NinjaVM()
        {
            Ninja = new Ninja();

            /* Commands */
            OpenNinjaCommand = new RelayCommand(OpenNinja);
        }

        public NinjaVM(Ninja ninja)
        {
            Ninja = ninja;
            OpenNinjaCommand = new RelayCommand(OpenNinja);
            //Ninja.Inventory.CollectionChanged += OnCollectionChanged;
        }

        public void OpenNinja()
        {
            // Open single ninja.
            var context = GetInstance<SingleNinjaVM>();
            context.Ninja = Ninja;

            OpenWindow<NinjaWindow, SingleNinjaVM>(context);
        }

        void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Ninja.RaisePropertyChanged("");
        }
    }
}
