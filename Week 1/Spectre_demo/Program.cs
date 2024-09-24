using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spectre_demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Om spectre te gebruiken
            //  -> Ga naar manage nuget packages
            //  -> Installeer de Spectre.Console package

            AnsiConsole.Write(new Markup("[bold yellow]Hello[/] [red]World![/]"));

            int prijs = AnsiConsole.Ask<int>("Wat is de prijs van ijscreme?");
            AnsiConsole.WriteLine($"De prijs van ijscreme is {prijs}");

            AnsiConsole.Clear();

            List<string> favorieteSmaaken = AnsiConsole.Prompt(new MultiSelectionPrompt<string>()
                .Title("Wat is je favoriete smaak")
                .AddChoices("Vanille", "Chocolade", "Aardbei")
                );


            switch (favorieteSmaaken.First())
            {
                case "Chocolade":
                    AnsiConsole.Write("eikes");
                    break;
                default:
                    AnsiConsole.Write("Goed gekozen!");
                    break;
            }

            bool check = AnsiConsole.Confirm("Eet je graag ijscreme?");

            if (check)
            {
                AnsiConsole.WriteLine("Leuk voor jou");
            }
            else
            {
                AnsiConsole.WriteLine("jammer");
            }
        }
    }
}
