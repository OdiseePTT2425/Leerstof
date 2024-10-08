using System;
using System.Data.SqlClient;
using System.Xml.Schema;

namespace ADO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Maak een connection string aan
            // Data source -> met welke server je connecteert
            // Welke database op de server : Initial Catalog
            string connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=studenten;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
            SqlConnection conn = new SqlConnection(connectionstring);

            // Maak je een commando aan
            SqlCommand cmd = new SqlCommand("select Naam from Student", conn);

            // Execute het commando
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(0));
            }

            // Sluit het commando/connection terug af
            reader.Close();
            conn.Close();

            //int score = AnsiConsole.Ask<int>("Boven welke score wil je de studenten zien")?
            String score = "10; Drop Table Student;--"; // SQL injection is als je ongefilterd user input aan sql commando's plakt
            // Op te lossen met prepared statements te werken --> hierbie moet je er wel elke keer op letten dat je het niet vergeet te gebruiken

            // Maak je een commando aan
            cmd = new SqlCommand("select Naam from Student where Score > " + score, conn);

            // Execute het commando
            conn.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(0));
            }

            // Sluit het commando/connection terug af
            reader.Close();
            conn.Close();


        }
    }
}
