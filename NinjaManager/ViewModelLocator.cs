using System;
using System.Collections.Generic;
using System.Text;
using CommonServiceLocator;
using NinjaManager.ViewModels;

namespace NinjaManager
{
    class ViewModelLocator
    {
        public MainWindowVM NinjaList
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainWindowVM>();
            }
        }
    }
}
