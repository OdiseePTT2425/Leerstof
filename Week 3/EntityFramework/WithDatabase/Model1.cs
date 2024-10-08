using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WithDatabase
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Students")
        {
        }

        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(e => e.Naam)
                .IsUnicode(false);
        }
    }
}
