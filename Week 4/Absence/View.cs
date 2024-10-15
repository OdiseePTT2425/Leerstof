using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Absence
{
    public class View: IView
    {
        public View() { }
        public Student AskForStudent()
        {
            // Wat als we met input van een user zitten
            Console.WriteLine("Geef een studentid in");
            string? id = Console.ReadLine();
            Console.WriteLine("Geef een voornaam in");
            string? voornaam = Console.ReadLine();
            Console.WriteLine("Geef een achternaam in");
            string? achternaam = Console.ReadLine();

            return new Student(id, voornaam, achternaam);
        }
    }
}
