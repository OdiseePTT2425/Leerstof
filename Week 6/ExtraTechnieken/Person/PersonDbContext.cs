using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigherLowerGame
{
    public partial class PersonDbContext : DbContext
    {
        public PersonDbContext()
            : base("name=Persons")
        {
        }
        

        public virtual DbSet<Person> Persons { get; set; }
    }
}
