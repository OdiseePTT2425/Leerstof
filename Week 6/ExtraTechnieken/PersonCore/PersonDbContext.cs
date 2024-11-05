using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public partial class PersonDbContext : DbContext, IDesignTimeDbContextFactory<PersonDbContext>
    {
        // Wat ik hier ga doen, gaat enkel met een .net core applicatie
        // entity framework -> nuget packages: entityframeworkcore + tools + sqlserver        en voor te testen ook de sqlite
        // IDesignTimeDbContextFactory<PersonDbContext> dit is nodig voor te testen

        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options) { } 
        // Deze constructor gaan we gebruiken om met een sqlite database te connecteren bij de testen ipv van met de sql-server

        public PersonDbContext()
        {
        }
        
        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            if (!optionsBuilder.IsConfigured)
            {
                // Dit is het standaard gedrag zonder options mee te geven aan de constructor
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Persons"); // Gebruik sql server database met naam persons
                // Dit is onze connection string
            }
        }
        public PersonDbContext CreateDbContext(string[] args)
        {
            return new PersonDbContext();
        }
    }
}
