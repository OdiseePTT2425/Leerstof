using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuchthavenApp
{
    public class AppLogic
    {
        private ILuchthavenRepository _luchthavenRepository;
        private IVluchtenRepository _vluchtenRepository;
        private ITicketsRepository _ticketsRepository;

        public AppLogic(ILuchthavenRepository luchthavenRepository, IVluchtenRepository vluchtenRepository, ITicketsRepository ticketsRepository)
        {
            _luchthavenRepository = luchthavenRepository;
            _vluchtenRepository = vluchtenRepository;
            _ticketsRepository = ticketsRepository;
        }

        public AppLogic(ILuchthavenRepository luchthavenRepository, ITicketsRepository ticketsRepository) : this(luchthavenRepository, null, ticketsRepository) { }

        public AppLogic(ITicketsRepository ticketsRepository):this(null, null, ticketsRepository) { }

        public AppLogic(ILuchthavenRepository luchthavenRepository): this(luchthavenRepository, null, null) { }
        public AppLogic():this(new LuchthavenRepository(), new VluchtenRepository(), new TicketsRepository()) { }

        public bool AddAirport(Luchthaven luchthaven)
        {
            if (luchthaven.Name.IsNullOrEmpty() || luchthaven.Country.IsNullOrEmpty() || luchthaven.Code.IsNullOrEmpty() || luchthaven.City.IsNullOrEmpty())
            {
                return false;
            }

            if(_luchthavenRepository.GetAllLuchthavens().Any(l => l.Code == luchthaven.Code))
            {
                return false;
            }

            _luchthavenRepository.AddLuchthaven(luchthaven);
            return true;

        }
    }
}
