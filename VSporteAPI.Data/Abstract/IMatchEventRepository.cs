using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSporteAPI.Entities;

namespace VSporteAPI.Data.Abstract
{
    public interface IMatchEventRepository
    {
        Task<IList<MatchEvent>> GetAllMatchEvents();
        Task<MatchEvent> GetMatchEventById(int id);
        Task<MatchEvent> AddMatchEvent(MatchEvent matchEvent);
        Task<MatchEvent> UpdateMatchEvent(MatchEvent matchEvent);
        Task<MatchEvent> DeleteMatchEventById(int id);
        //Task MatchEventAddToPlayer(int PlayerId, int MatchEventId);
        //Task MatchEventRemoveFromPlayer(int PlayerId, int MatchEventId);
    }
}
