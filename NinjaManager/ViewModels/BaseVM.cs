using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using NinjaManager.Models;
using System.Windows;
using System.Windows.Threading;

namespace NinjaManager.ViewModels
{
    public class BaseVM : ViewModelBase
    {
        protected readonly NinjaDb _db;

        public BaseVM()
        {
            _db = new NinjaDb();
        }

        protected TInstance GetInstance<TInstance>() => SimpleIoc.Default.GetInstance<TInstance>();

        protected void OpenWindow<TWindow, TContext>(TContext context = null)
            where TWindow : Window, new()
            where TContext : BaseVM
        {
            _ = new TWindow
            {
                DataContext = context ?? GetInstance<TContext>(),
                Visibility = Visibility.Visible,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
        }

    }
}
