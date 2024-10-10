using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutDatabase
{
    internal class UserContext: DbContext
    {
        // Hier stel je in met welke database er geconnecteerd wordt
        public UserContext() : base("name=Users") { }

        // Hier maak je de tabellen aan
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany<Car>(x => x.Cars)
                .WithMany(x => x.Users);
        }
    }
}
