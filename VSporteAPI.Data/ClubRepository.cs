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
    public class ClubRepository : IClubRepository
    {
        private readonly VSporteAPIDbContext _context;

        public ClubRepository(VSporteAPIDbContext context)
        {
            this._context = context;
        }
        public async Task<Club> AddClub(Club club)
        {   
            //нужно для присвоения клубу индекса базой данных, иначе - присваивается тот, что указан в клубе.
            //Почему - не понятно, там стоит ограничение по ключу, и констраинт на то, что он автоматически генерируется
            club.Id = 0; 
            await _context.Clubs.AddAsync(club);
            await _context.SaveChangesAsync();
            return club;
        }

        public async Task<Club> DeleteClubById(int id)
        {
            var club = await _context.Clubs.FirstOrDefaultAsync(x => x.Id == id);
            if (club != null)
            {
                _context.Clubs.Remove(club);
                await _context.SaveChangesAsync();
                return club;
            }
            return null;
            //return new Club();
        }

        public async Task<IList<Club>> GetAllClubs()
        {
            IList<Club> clubs = await _context.Clubs.Include(x => x.PlayerClubs).ToListAsync();
            return clubs;
        }

        public async Task<Club> GetClubById(int id)
        {
            var club = await _context.Clubs.Include(x => x.PlayerClubs).FirstOrDefaultAsync(x => x.Id == id);
            return club;
        }

       

        public async Task<Club> UpdateClub(Club club)
        {
            var Clubindb = await _context.Clubs.FirstOrDefaultAsync(x => x.Id == club.Id);
            if (Clubindb == null)
            {
                return null;
            }
            Clubindb.Update(club);
            _context.Clubs.Update(Clubindb);
            await _context.SaveChangesAsync();
            return Clubindb;
        }

    


    }
}

