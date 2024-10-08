using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les3Tests
{
    internal class Product
    {
        public String Naam { get; set; }
        public int Voorraad { get; set; }

        public Product(String naam, int voorraad)
        {
            this.Naam = naam;
            this.Voorraad = voorraad;
        }
    }
}
