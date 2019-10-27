namespace NinjaManager.Migrations
{
    using NinjaManager.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NinjaManager.Models.NinjaDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NinjaManager.Models.NinjaDb context)
        {
            context.Ninjas.AddOrUpdate(new Ninja("Martijn", 5000));
            context.Ninjas.AddOrUpdate(new Ninja("Sascha", 3000));
            context.Ninjas.AddOrUpdate(new Ninja("Dennis", 8000));

            context.Gear.AddOrUpdate(new Gear() { Name = "Headband", Price = 500, Category = Category.Head, Agility = -5, Intelligence = 50, Strength = 15 });
            context.Gear.AddOrUpdate(new Gear() { Name = "Hydroband", Price = 1250, Category = Category.Head, Agility = 15, Intelligence = 75, Strength = 20 });
            context.Gear.AddOrUpdate(new Gear() { Name = "Ultimateband", Price = 4500, Category = Category.Head, Agility = 150, Intelligence = 150, Strength = 150 });

            context.Gear.AddOrUpdate(new Gear() { Name = "Shoulder Prot 1", Price = 500, Category = Category.Shoulders, Agility = -5, Intelligence = 0, Strength = 15 });
            context.Gear.AddOrUpdate(new Gear() { Name = "Shoulder Prot 2", Price = 750, Category = Category.Shoulders, Agility = -15, Intelligence = 5, Strength = 25 });
            context.Gear.AddOrUpdate(new Gear() { Name = "Shoulder Prot 3", Price = 1000, Category = Category.Shoulders, Agility = -25, Intelligence = 15, Strength = 35 });

            context.Gear.AddOrUpdate(new Gear() { Name = "Chest-O", Price = 500, Category = Category.Chest, Agility = -30, Intelligence = 0, Strength = 25 });
            context.Gear.AddOrUpdate(new Gear() { Name = "Diamond Chest", Price = 1500, Category = Category.Chest, Agility = -15, Intelligence = 5, Strength = 50 });
            context.Gear.AddOrUpdate(new Gear() { Name = "Jewel Chest", Price = 5000, Category = Category.Chest, Agility = -55, Intelligence = 50, Strength = 500 });

            context.Gear.AddOrUpdate(new Gear() { Name = "Yellow Belt", Price = 500, Category = Category.Belt, Agility = 0, Intelligence = 50, Strength = 30 });
            context.Gear.AddOrUpdate(new Gear() { Name = "Brown Belt", Price = 1000, Category = Category.Belt, Agility = 0, Intelligence = 150, Strength = 70 });
            context.Gear.AddOrUpdate(new Gear() { Name = "Black Belt", Price = 1750, Category = Category.Belt, Agility = 0, Intelligence = 250, Strength = 110 });

            context.Gear.AddOrUpdate(new Gear() { Name = "Skinny Jeans", Price = 500, Category = Category.Legs, Agility = -30, Intelligence = 0, Strength = 15 });
            context.Gear.AddOrUpdate(new Gear() { Name = "Blue Pants", Price = 1250, Category = Category.Legs, Agility = 15, Intelligence = 0, Strength = 30 });
            context.Gear.AddOrUpdate(new Gear() { Name = "Ninja Pants", Price = 2500, Category = Category.Legs, Agility = 150, Intelligence = 10, Strength = 50 });

            context.Gear.AddOrUpdate(new Gear() { Name = "Sneakers", Price = 500, Category = Category.Boots, Agility = 50, Intelligence = -10, Strength = -10 });
            context.Gear.AddOrUpdate(new Gear() { Name = "Speedy Sneakers", Price = 500, Category = Category.Boots, Agility = 100, Intelligence = 0, Strength = 0 });
            context.Gear.AddOrUpdate(new Gear() { Name = "Sonic Boots", Price = 5000, Category = Category.Boots, Agility = 500, Intelligence = 50, Strength = 50 });

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
