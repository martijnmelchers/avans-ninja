using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using NinjaManager.Models;
namespace NinjaManager.ViewModels
{
    public class NinjaVM
    {
        public Ninja Ninja { get; set; }

        public RelayCommand OpenNinjaCommand { get; set; }
 
        public NinjaVM()
        {
            Ninja = new Ninja();
            OpenNinjaCommand = new RelayCommand(OpenNinja);
        }

        public NinjaVM(Ninja ninja)
        {
            Ninja = ninja; 
        
            OpenNinjaCommand = new RelayCommand(OpenNinja);
        }

        public void OpenNinja()
        {
            var dataContext = SimpleIoc.Default.GetInstance<SingleNinjaVM>();
            // Open single ninja.
            var window = new NinjaWindow();
            dataContext.Ninja = Ninja;
            window.DataContext = dataContext;
            window.Visibility = Visibility.Visible;
        }
    }
}
