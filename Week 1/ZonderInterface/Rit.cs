using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conducteur
{
    public class Rit
    {
        public Rit(string naarLocatie)
        {
            NaarLocatie = naarLocatie;
            Datum = DateTime.Now;
        }

        public string NaarLocatie {get; private set; }

        public DateTime Datum { get; private set; }
    }
}
