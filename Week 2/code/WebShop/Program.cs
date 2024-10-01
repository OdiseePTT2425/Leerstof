using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();
            store.AddInventory(Product.Shampoo, 10);

            Customer sut = new Customer();
            sut.Purchase(store, Product.Shampoo, 5);


        }
    }
}
