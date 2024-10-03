using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEncrypter
{
    internal class Achterstevoren : IEncrypter
    {
        public string decrypt(string text)
        {
            string result = "";

            foreach(char c in text) {
                result = c + result;
            }

            return result;
        }

        public string encrypt(string text)
        {
            return decrypt(text);
        }

        public override string ToString()
        {
            return "Achterstevoren";
        }
    }
}
