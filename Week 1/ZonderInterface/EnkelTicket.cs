using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conducteur
{
    internal class EnkelTicket
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
    }
}
