using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSporte.Core.Abstract;
using VSporteAPI.Data.Abstract;
using VSporteAPI.Entities;

namespace VSporte.Core
{
    public class MatchEventService:IMatchEventService
    {
        private readonly IMatchEventRepository matchEventRepository;
        public MatchEventService(IMatchEventRepository matchEventRepository)
        {
            this.matchEventRepository = matchEventRepository;
        }
        public async Task<MatchEvent> AddMatchEvent(MatchEvent matchEvent)
        {
            
            if (matchEvent != null)
            {
                await matchEventRepository.AddMatchEvent(matchEvent);
                return matchEvent;

            }
            return null;

        }

        public async Task<MatchEvent> DeleteMatchEventById(int id)
        {
            var result = await matchEventRepository.DeleteMatchEventById(id);
            return result;
        }

        public async Task<IList<MatchEvent>> GetAllMatchEvents()
        {
            var result = await matchEventRepository.GetAllMatchEvents();
            return result;
        }

        public async Task<MatchEvent> GetMatchEventById(int id)
        {
            var matchEvent = await matchEventRepository.GetMatchEventById(id);
            return matchEvent;
        }

        public async Task<MatchEvent> UpdateMatchEvent(MatchEvent matchEvent)
        {
            var result = await matchEventRepository.UpdateMatchEvent(matchEvent);
            return result;
        }
    }
}
