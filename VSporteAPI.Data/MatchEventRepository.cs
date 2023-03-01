using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSporteAPI.Data.Abstract;
using VSporteAPI.Entities;

namespace VSporteAPI.Data
{
    public class MatchEventRepository:IMatchEventRepository
    {
        private readonly VSporteAPIDbContext _context;

        public MatchEventRepository(VSporteAPIDbContext context)
        {
            this._context = context;
        }
        public async Task<MatchEvent> AddMatchEvent(MatchEvent matchEvent)
        {
            matchEvent.Id = 0;
            await _context.MatchEvents.AddAsync(matchEvent);
            await _context.SaveChangesAsync();
            return matchEvent;
        }

        public async Task<MatchEvent> DeleteMatchEventById(int id)
        {
            var matchEvent = await _context.MatchEvents.FirstOrDefaultAsync(x => x.Id == id);
            if (matchEvent != null)
            {
                _context.MatchEvents.Remove(matchEvent);
                await _context.SaveChangesAsync();
                return matchEvent;
            }
            return null;
 
        }

        public async Task<IList<MatchEvent>> GetAllMatchEvents()
        {
            IList<MatchEvent> matchEvents = await _context.MatchEvents.ToListAsync();
            return matchEvents;
        }

        public async Task<MatchEvent> GetMatchEventById(int id)
        {
            var matchEvent = await _context.MatchEvents.FirstOrDefaultAsync(x => x.Id == id);
            return matchEvent;
        }



        public async Task<MatchEvent> UpdateMatchEvent(MatchEvent matchEvent)
        {
            var MatchEventindb = await _context.MatchEvents.FirstOrDefaultAsync(x => x.Id == matchEvent.Id);
            if (MatchEventindb == null)
            {
                return null;
            }
            MatchEventindb.Update(matchEvent);
            _context.MatchEvents.Update(MatchEventindb);
            await _context.SaveChangesAsync();
            return MatchEventindb;
        }


    }
}
