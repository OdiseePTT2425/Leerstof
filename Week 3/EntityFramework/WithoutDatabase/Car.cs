using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace WithoutDatabase
{
    internal class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Model {  get; set; }

        public List<User> Users { get; set; }

        public Car(string model)
        {
            Model = model;
        }

        // De constructors zonder argument moeten er nog steeds staan
        // Het entity framework gebruikt deze
        public Car() { }

    }
}
