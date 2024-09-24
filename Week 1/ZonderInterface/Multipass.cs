using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conducteur
{
    internal class Multipass
    {
        public string VanLocatie { get; private set; }
        public string NaarLocatie { get; private set; }
        public List<Rit> Ritten { get; private set; }
        
        public Multipass(string vanLocatie, string naarLocatie)
        {
            VanLocatie = vanLocatie;
            NaarLocatie = naarLocatie;
        }

        public bool RitToevoegen(string naarLocatie)
        {
            if (Ritten.Count < 10)
            {
                Ritten.Add(new Rit(naarLocatie));
                return true;
            }
            return false;
        }
    }
}
