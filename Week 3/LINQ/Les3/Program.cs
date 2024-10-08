using Spectre.Console;
using System.Linq;

namespace Les3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // opdracht berekenen van een gemiddelde origineel
            List<int> list = new List<int>() { 17,5,8,14,369,7};

            double som = 0;
            for (int i = 0; i < list.Count; i++)
            {
                som += list[i];
            }
            Console.WriteLine("Average original methode " + som/list.Count);

            Console.WriteLine("Average via LINQ " + list.Average());

            double min = list.Min();
            double max = list.Max();
            double sum = list.Sum();

            // LINQ zijn een reeks handige functies gebouwd boven de IEnumerable interface
            // Alle collecties in C# zijn van deze interfaces en kunnen dus van LINQ gebruik maken
            som = 0;
            foreach(int listItem in list) // Dit gaat ook werken op alles dat van het type IEnumerable dus (dus op alle standaardcollecties)
            {
                som += listItem;
            }

            // Select
            print(list);
            print(list.Select(Square)); // Voer de square functie uit op elk element in de lijst
            // De select functie (en eigenlijk heel veel LINQ functies) accepteren een Delegate / een referentie naar een functie

            //lambda expressie / lambda functie
            // soort van tijdelijke / naamloze functies
            print(list.Select((int x) => { return x * x; }));
            // Dit is de lambda expressie: (int x) => { return x * x; }
            // Tussen de () ronde haakjes staan je inputs
            // Tussen de {} accolades staat de body -> eindigt in return
            // Dit kan nog vereenvoudigd worden
                // Types in de ronde haakjes mogen weg als er geen verwarring mogelijk is
                // Daarnaast als er 1 maar 1 parameter is mogen de ronde haakjes weg
                // Als de output 1 lijn is in de body dan mogen de accolades en return ook weg

            print(list.Select( x => x * x));

            // Where -> filteren
            print(list.Where()); // filter eens enkel de even getallen eruit -> gewenste output is 8,14
        }

        public static int Square(int x)
        {
            return x * x;
        }

        public static void print(IEnumerable<int> list)
        {
            AnsiConsole.Write('[');
            foreach (int x in list) { 
                AnsiConsole.Write(x.ToString());
                AnsiConsole.Write(" , ");
            }
            AnsiConsole.Write("]\n");
        }
    }
}