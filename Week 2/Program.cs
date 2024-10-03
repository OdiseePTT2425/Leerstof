using Spectre.Console;

namespace TextEncrypter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*List<ITest> result = AnsiConsole.Prompt(
                new MultiSelectionPrompt<ITest>()
                    .Title("What are your [green]favorite fruits[/]?")
                    .AddChoices<ITest>(new[]
                    {
                        new Test(),
                        new Test()
                    })
                    .UseConverter(x => x.ToString())
                );*/

            string task = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Do you want to encrypt or decrypt")
                    .AddChoices(new[] {
                        "encrypt", "decrypt"
                    }));

            IEncrypter encrypter = AnsiConsole.Prompt(
                new SelectionPrompt<IEncrypter>()
                    .Title("Pick an encrypter")
                    .AddChoices(new IEncrypter[] {
                        new Achterstevoren(),
                        new ShiftEncrypter(1),
                    })
                    .UseConverter(x => x.ToString()));

            string text = AnsiConsole.Ask<string>("Input text: ");

            if(task == "encrypt")
            {
                AnsiConsole.Write(encrypter.encrypt(text));
            } else
            {
                AnsiConsole.Write(encrypter.decrypt(text));
            }

            return;

        }
    }
}