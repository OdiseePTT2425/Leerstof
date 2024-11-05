using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigherLowerGameCore
{
    public interface IRandomWrapper
    {
        int Next(int count);
    }

    public class RandomWrapper : IRandomWrapper
    {
        public int Next(int count)
        {
            return new Random().Next(count);
        }
    }
}
