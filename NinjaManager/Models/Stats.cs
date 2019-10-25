using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaManager.Models
{
    public interface IStats
    {
        // Stats
        public int Strength { get;  }
        public int Intelligence { get; }
        public int Agility { get; }
    }
}
