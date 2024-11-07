using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuchthavenApp
{
    public interface ILuchthavenRepository
    {
        List<Luchthaven> GetAllLuchthavens();
        void AddLuchthaven(Luchthaven luchthaven);

        void UpdateLuchthaven(Luchthaven luchthaven);

        void RemoveLuchthaven(Luchthaven luchthaven);
    }
}
