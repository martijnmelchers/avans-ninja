using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NinjaManager.Models
{
    public class Ninja : Stats
    {
        public string Name { get; set; }
        public int Gold { get; set; }
        public List<Equipment> Inventory { get; set; }
    }
}
