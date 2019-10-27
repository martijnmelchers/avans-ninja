using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using NinjaManager.ViewModels.GearViews;
using NinjaManager.ViewModels.NinjaViews;

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

            SimpleIoc.Default.Register<NinjaListVM>();
            SimpleIoc.Default.Register<SingleNinjaVM>();
            SimpleIoc.Default.Register<AddNinjaVM>();
            SimpleIoc.Default.Register<GearListVM>();

        }

        public NinjaListVM Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NinjaListVM>();
            }
        }


        public GearListVM Gears
        {
            get
            {
                return ServiceLocator.Current.GetInstance<GearListVM>();
            }
        }

        public SingleNinjaVM Ninja
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SingleNinjaVM>();
            }  
        }

        public AddNinjaVM AddNinja
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddNinjaVM>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
