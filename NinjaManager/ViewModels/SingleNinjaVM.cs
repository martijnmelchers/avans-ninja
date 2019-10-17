using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NinjaManager.Models;
namespace NinjaManager.ViewModels
{
    public class SingleNinjaVM : ViewModelBase
    {
        public string Saus { get; set; }
        public Ninja Ninja { get; set; }
        public ICommand NinjaChangeCommand { get; set; }


        public SingleNinjaVM()
        {
            NinjaChangeCommand = new RelayCommand(NinjaChange);
        }

        public void NinjaChange()
        {
            Ninja.Name = "Saus";
        }
    }
}
