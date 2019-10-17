using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaManager.Models
{
    public interface IStats
    {
        // Stats
        public int Strength { get; set;  }
        public int Intelligence { get; set; }
        public int Agility { get; set; }
    }
}
