using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WithDatabase
{
    public partial class StudentenContext : DbContext
    {
        public StudentenContext()
            : base("name=StudentenContext")  // wat is de connectionstring?
        {
        }

        public virtual DbSet<Student> Student { get; set; } // Alle studenten zitten in deze DbSet

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(e => e.Naam)
                .IsUnicode(false);
        }
    }
}
