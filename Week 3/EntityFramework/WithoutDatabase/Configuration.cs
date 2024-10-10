using System.Data.Entity.Migrations;
using WithoutDatabase;

internal sealed class Configuration : DbMigrationsConfiguration<UserContext>
{
    public Configuration()
    {
        AutomaticMigrationsEnabled = true;  // Enable automatic migrations
        AutomaticMigrationDataLossAllowed = true;  // Optional: Allows data loss during migrations
    }

    protected override void Seed(UserContext context)
    {
        // Seed initial data if needed
    }
}