using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conducteur
{
    internal interface IKaart
    {
        bool valideerKaart(string[] route);
    }
}
