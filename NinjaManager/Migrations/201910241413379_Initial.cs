namespace NinjaManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gears",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        Category = c.Int(nullable: false),
                        Strength = c.Int(nullable: false),
                        Intelligence = c.Int(nullable: false),
                        Agility = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ninjas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Gold = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NinjaGears",
                c => new
                    {
                        Ninja_Id = c.Int(nullable: false),
                        Gear_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ninja_Id, t.Gear_Id })
                .ForeignKey("dbo.Ninjas", t => t.Ninja_Id, cascadeDelete: true)
                .ForeignKey("dbo.Gears", t => t.Gear_Id, cascadeDelete: true)
                .Index(t => t.Ninja_Id)
                .Index(t => t.Gear_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NinjaGears", "Gear_Id", "dbo.Gears");
            DropForeignKey("dbo.NinjaGears", "Ninja_Id", "dbo.Ninjas");
            DropIndex("dbo.NinjaGears", new[] { "Gear_Id" });
            DropIndex("dbo.NinjaGears", new[] { "Ninja_Id" });
            DropTable("dbo.NinjaGears");
            DropTable("dbo.Ninjas");
            DropTable("dbo.Gears");
        }
    }
}
