using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuchthavenApp
{
    public class LuchthavenRepository: ILuchthavenRepository
    {
        private LuchthavenDbContext context;

        public LuchthavenRepository(LuchthavenDbContext context)
        {
            this.context = context;
        }

        public LuchthavenRepository() : this(new LuchthavenDbContext()){ }

        public List<Luchthaven> GetAllLuchthavens()
        {
            return context.Luchthavens.ToList();
        }

        public void AddLuchthaven(Luchthaven luchthaven)
        {
            context.Luchthavens.Add(luchthaven);
            context.SaveChanges();
        }

        public void UpdateLuchthaven(Luchthaven luchthaven)
        {
            throw new NotImplementedException();
        }

        public void RemoveLuchthaven(Luchthaven luchthaven)
        {
            throw new NotImplementedException();
        }
    }
}
