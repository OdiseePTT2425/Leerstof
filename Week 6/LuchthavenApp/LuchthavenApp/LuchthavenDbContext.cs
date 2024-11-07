using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuchthavenApp
{
    public class LuchthavenDbContext: DbContext, IDesignTimeDbContextFactory<LuchthavenDbContext>
    {
        public LuchthavenDbContext(DbContextOptions<LuchthavenDbContext> options):base(options) { }
        public LuchthavenDbContext() { }

        public DbSet<Luchthaven> Luchthavens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"(localdb)/MSSQLLocalDb;Database=Luchthavens"); // connectionstring
            }
        }

        public LuchthavenDbContext CreateDbContext(string[] args)
        {
            return new LuchthavenDbContext();
        }
    }
}
