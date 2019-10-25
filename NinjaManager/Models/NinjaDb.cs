using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace NinjaManager.Models
{
    public class NinjaDb : DbContext
    {
        public NinjaDb() : base("Server=localhost;Database=master;Trusted_Connection=True;")
        {

        }
        public DbSet<Ninja> Ninjas { get; set; }
        public DbSet<Gear> Equipment { get; set; }

    }
}
