using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conducteur
{
    internal class EnkelTicket : IKaart
    {
        public string VanLocatie { get; private set; }
        public string NaarLocatie { get; private set; }
        public DateTime Datum { get; private set; }

        public EnkelTicket(string vanLocatie, string naarLocatie, DateTime datum)
        {
            VanLocatie = vanLocatie;
            NaarLocatie = naarLocatie;
            Datum = datum;
        }

        public bool valideerKaart(string[] route)
        {
            // Check of het ticket voor vandaag is
            if(Datum != DateTime.Today)
            {
                return false;
            }

            // Controleren of we op het juiste traject zitten
            if(!(route.Contains(VanLocatie) && route.Contains(NaarLocatie))){
                return false;
            }

            // Rijden we in de juiste richting
            int indexVan = route.ToList().IndexOf(VanLocatie);
            int indexNaar = route.ToList().IndexOf(NaarLocatie);

            if(indexVan < indexNaar)
            {
                return true;
            } else { 
                return false;
            }

        }
    }
}
