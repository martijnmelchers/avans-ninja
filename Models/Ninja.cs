using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Ninja : Stats
    {
        public string Name { get; set; }
        public int Gold { get; set; }
        public List<Equipment> Inventory { get; set; }
    }
}
