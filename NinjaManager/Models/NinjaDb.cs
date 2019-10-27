using System.Data.Entity;

namespace NinjaManager.Models
{
    public class NinjaDb : DbContext
    {
        public NinjaDb() : base("Server=localhost;Database=master;Trusted_Connection=True;")
        {

        }
        public DbSet<Ninja> Ninjas { get; set; }
        public DbSet<Gear> Gear { get; set; }

    }
}
