using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conducteur
{
    internal class Conducteur
    {

        private string[] route;

        public Conducteur(string[] route)
        {
            this.route = route;
        }

        public bool CheckSingleTicket(EnkelTicket ticket) 
        {
            return false;
        }
        public bool CheckAbonnement(Abonnement abonnement)
        {
            return false;
        }
        
        public bool CheckMultipass(Multipass multipass)
        {
            return false;
        }
    }
}
