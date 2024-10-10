using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WithDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // We gaan nu het ORM-framework: EntityFramework gebruiken
            // Hiervoor moet het Entityframework nuget package geinstalleerd worden 

            // Manier 1: Maak eerst de sql-database aan met tabellen, kolommen, hieruit worden de dataklassen gegenereerd
            // Manier 2: Maak dataklassen aan en hieruit wordt de sql-database gegenereerd

            // In dit project manier 1, in het project withoutdatabase manier 2

            // Rechtsklikken op het project -> add item -> ado object model
            // Kies voor manier 1 het rechtse code first from database
            // Kies de connectiedatabase
            // Kies welke tabellen te importeren/te gebruiken (typisch alles)

            // Hierdoor worden 2 klassen aangemaakt 
            // StudentenContext -> naam bij toevoegen item
                    // Deze bevat hoe de database opgebouwd is
                    // Deze erft over van dbcontext
                    // Legt in de constructor de link met de connectionstring
                    // Bevat een dbset voor elke tabel in de database (deze houden de rijen/objecten bij)
            // Student
                    // Voor elke tabel in de database is er zo een data-klasse genoemd

            // Hoe dit gebruiken?
            
            // Select
            StudentenContext context = new StudentenContext();
            foreach(Student s in context.Student)
            {
                Console.WriteLine(s.Naam);
            }

            // maximum zoeken
            Console.WriteLine("Hoogste score: " + context.Student.Max(s => s.Score));

            // Insert
            Student newStudent = new Student();
            newStudent.Naam = "Fradeur2";
            newStudent.Score = 110;

            context.Student.Add(newStudent);
            context.SaveChanges();

            // Update
            newStudent.Score = 130;
            context.SaveChanges();

            // Delete
            IEnumerable<Student> studentenToRemove = context.Student.Where(s => s.Naam.StartsWith("Fradeur"));
            foreach (Student s in studentenToRemove)
            {
                context.Student.Remove(s);
            }
            context.SaveChanges();

            Console.WriteLine("Done");

            Console.ReadLine();
        }
    }
}
