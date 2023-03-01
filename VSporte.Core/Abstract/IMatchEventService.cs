using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSporteAPI.Entities;

namespace VSporte.Core.Abstract
{
    public interface IMatchEventService
    {
        public Task<MatchEvent> AddMatchEvent(MatchEvent matchEvent);
        public Task<MatchEvent> GetMatchEventById(int id);
        public Task<IList<MatchEvent>> GetAllMatchEvents();
        public Task<MatchEvent> DeleteMatchEventById(int id);
        public Task<MatchEvent> UpdateMatchEvent(MatchEvent matchEvent);
    }
}
