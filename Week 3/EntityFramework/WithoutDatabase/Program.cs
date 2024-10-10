using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WithoutDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // In dit project gaan we beginnen vanuit code
            // Voeg in App.config de xml-code van entityframework en connectionstrings toe
            // Pas indien gewenst de naam van de database (initial catalog)

           /* UserContext context = new UserContext();

            User u = new User("Jens", "Baetens");
            User u2 = new User("Elon", "Musk");
            context.Users.Add(u);
            context.Users.Add(u2);

            Car c = new Car("Volvo");
            Car c2 = new Car("Mercedes");
            Car c3 = new Car("Kia");

            context.Cars.Add(c);
            context.Cars.Add(c2);
            context.Cars.Add(c3);

            u2.Cars.Add(c);
            u2.Cars.Add(c2);
            u2.FavoriteCar = c2;

            u.Cars.Add(c);
            u.Cars.Add(c3);

            context.SaveChanges();*/

            UserRepository userRepository = new UserRepository();

            List<User> users = userRepository.GetAll();

            Console.WriteLine(users.Count);
        }
    }
}
