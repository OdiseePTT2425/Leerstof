using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conducteur
{
    internal class Multipass : IKaart
    {
        const int AANTAL_RITTEN = 10;
        public string VanLocatie { get; private set; }
        public string NaarLocatie { get; private set; }
        public List<Rit> Ritten { get; private set; }
        
        public Multipass(string vanLocatie, string naarLocatie)
        {
            VanLocatie = vanLocatie;
            NaarLocatie = naarLocatie;
            Ritten = new List<Rit>();
        }

        public bool RitToevoegen(string naarLocatie)
        {
            if (Ritten.Count < AANTAL_RITTEN)
            {
                Ritten.Add(new Rit(naarLocatie));
                return true;
            }
            return false;
        }

        public bool valideerKaart(string[] route)
        {
            // nog geen rit toegevoegd op de multipass
            if (Ritten.Count == 0)
            {
                return false;
            }

            Rit laatsteRit = Ritten.Last();

            

            // is de rit van de datum voor vandaag
            if (laatsteRit.Datum != DateTime.Today)
            {
                return false;
            }

            // Controleren of we op het juiste traject zitten
            if (!(route.Contains(VanLocatie) && route.Contains(NaarLocatie)))
            {
                return false;
            }

            return true;
        }
    }
}
