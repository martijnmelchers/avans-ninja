using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Equipment : Stats
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Category Category { get; set; }
    }
}
