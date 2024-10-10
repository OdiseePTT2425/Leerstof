using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutDatabase
{
    [Table("users")]
    internal class User
    {
        [Required]
        [StringLength(50)]
        [Column("voornaam")]
        public string Firstname { get; set; }

        [Required]
        [Column("achternaam")]
        public string Lastname { get; set; }

        [Key]
        public int Id { get; set; }

        [NotMapped] // voor zaken die niet in de database moeten komen
        public string naam { get => Firstname + " " + Lastname; }

        public List<Car> Cars { get; set; }
        public Car FavoriteCar { get; set; }

        public User(string firstName, string lastName)
        {
            Firstname = firstName;
            Lastname = lastName;
            Cars = new List<Car>();
        }

        // De constructors zonder argument moeten er nog steeds staan
        // Het entity framework gebruikt deze
        public User() { }
    }
}
