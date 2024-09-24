using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conducteur
{
    public class Abonnement: IKaart
    {
        public DateTime GeldigVan { get; private set; }
        public DateTime GeldigTot { get; private set; }
        public string VanLocatie { get; private set; }
        public string NaarLocatie { get; private set; }

        public Abonnement(DateTime geldigVan, DateTime geldigTot, string vanLocatie, string naarLocatie)
        {
            GeldigVan = geldigVan;
            GeldigTot = geldigTot;
            VanLocatie = vanLocatie;
            NaarLocatie = naarLocatie;
        }

        public bool valideerKaart(string[] route)
        {
            // Controleer de datum
            if(DateTime.Today < GeldigVan ||  DateTime.Today > GeldigTot)
            {
                return false; 
            }

            // Traject is op de route
            if (!(route.Contains(VanLocatie) && route.Contains(NaarLocatie)))
            {
                return false;
            }


            return true;
        }
    }
}
