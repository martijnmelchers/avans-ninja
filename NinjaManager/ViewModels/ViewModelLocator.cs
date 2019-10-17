using System;
using System.Collections.Generic;
using System.Text;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using NinjaManager.ViewModels;

namespace NinjaManager.ViewModels
{
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<NinjaListVM>();
            SimpleIoc.Default.Register<SingleNinjaVM>();
        }

        public NinjaListVM Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NinjaListVM>();
            }
        }


        public SingleNinjaVM Ninja
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SingleNinjaVM>();
            }  
        }


        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
