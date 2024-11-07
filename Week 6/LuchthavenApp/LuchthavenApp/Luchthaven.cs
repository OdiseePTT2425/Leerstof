using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuchthavenApp
{
    public class Luchthaven
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Country {  get; set; }
        [Required]
        public String City {  get; set; }
        [Required]
        [StringLength(3)]
        public String Code { get; set; }

        public Luchthaven(int id, String naam, String land, String stad, String code) { 
            Id = id;
            Name = naam;
            Country = land;
            City = stad;
            Code = code;
        }

        public Luchthaven() { }
    }
}
