using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEncrypter
{
    internal class ShiftEncrypter : IEncrypter
    {
        private int shift;

        public ShiftEncrypter(int shift)
        {
            this.shift = shift; 
        }
  
        public string decrypt(string text)
        {
            return Shift(text, -shift);
        }

        public string encrypt(string text)
        {
            return Shift(text, shift);
        }

        private string Shift(string text, int shift)
        {
            string result = "";

            foreach (char c in text)
            {
                int new_c = c + shift;
                if (c >= 'a' && c <='z' && new_c > 'z')
                {
                    new_c -= 26;
                }
                else if (c >= 'a' && c <= 'z' && new_c < 'a')
                {
                    new_c += 26;
                }
                else if (c >= 'A' && c <= 'Z' && new_c > 'Z')
                {
                    new_c -= 26;
                } else if(c >= 'A' && c <= 'Z' && new_c < 'A')
                {
                    new_c += 26;
                }
                result += (char)new_c;
            }
            return result;
        }

        public override string ToString()
        {
            return "A=B, B=C, C=D, ...., Z=A";
        }
    }
}
