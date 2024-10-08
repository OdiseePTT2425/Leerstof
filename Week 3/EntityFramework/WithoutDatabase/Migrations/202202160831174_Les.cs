namespace WithoutDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Les : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "BirthDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "BirthDate");
        }
    }
}
