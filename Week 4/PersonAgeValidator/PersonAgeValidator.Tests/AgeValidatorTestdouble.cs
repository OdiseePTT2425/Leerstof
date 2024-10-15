using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonAgeValidator.Tests
{
    internal class AgeValidatorTestdouble : IAgeValidator
    {
        private bool returnValue;

        public AgeValidatorTestdouble(bool returnValue) { 
            this.returnValue = returnValue;
        }

        public bool IsValidAge(int age)
        {
            return returnValue;
        }
    }
}
