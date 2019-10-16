using System;
using System.Collections.Generic;
using System.Text;
using NinjaManager.Models;
namespace NinjaManager.ViewModels
{
    public class NinjaVM
    {
        private Ninja _ninja;

        public string Name
        {
            get
            {
                return _ninja.Name;
            }
            set
            {
                _ninja.Name = value;
            }
        }

        public int  Gold
        {
            get
            {
                return _ninja.Gold;
            }
            set
            {
                _ninja.Gold = value;
            }
        }



        public NinjaVM()
        {
            _ninja = new Ninja();
        }

        public NinjaVM(Ninja ninja)
        {
            _ninja = ninja; 
            Gold = ninja.Gold;
            Name = ninja.Name;
        }
    }
}
