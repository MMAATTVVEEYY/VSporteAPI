using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using VSporteAPI.Data.Abstract;
using VSporteAPI.Entities;

namespace VSporteAPI.Data
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly VSporteAPIDbContext _context;

        public PlayerRepository(VSporteAPIDbContext context)
        {
            this._context = context;
        }
        public async Task<Player> AddPlayer(Player player)
        {
            //нужно для присвоения игроку корректного индекса базой данных, иначе - присваивается тот, что указан в игроке.
            //Почему - не понятно, там стоит ограничение по ключу, и констраинт на то, что он автоматически генерируется
            player.Id = 0;
            await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task<Player> DeletePlayerById(int id)
        {
            var player = await _context.Players.FirstOrDefaultAsync(x => x.Id == id);
            if (player != null)
            {
                _context.Players.Remove(player);
                await _context.SaveChangesAsync();
                return player;
            }
            return null;
            //return new Player();
        }

        public async Task<IList<Player>> GetAllPlayers()
        {
            IList<Player> players = await _context.Players.Include(x => x.PlayerClubs).ToListAsync();
            return players;
        }

        public async Task<Player> GetPlayerById(int id)
        {
            var player = await _context.Players.Include(x=>x.PlayerClubs).FirstOrDefaultAsync(x => x.Id == id);
            return player;
        }

        public async Task PlayerAddToClub(int PlayerId, int ClubId)
        {
            var player = await _context.Players.FirstOrDefaultAsync(x => x.Id == PlayerId);
            var club = await _context.Clubs.FirstOrDefaultAsync(x => x.Id ==  ClubId);
            
            if (player == null || club==null) {
                return ;
            }
            //  await _context.PlayerClubs.AddAsync(new PlayerClub { PlayerId=player.Id,ClubId=club.Id,Player=player,Club=club });
            var playerclub = new PlayerClub { PlayerId = player.Id, ClubId = club.Id, Player = player, Club = club };
            //List<PlayerClub> list = new List<PlayerClub> {playerclub};
            //player.PlayerClubs.Add(playerclub);
            //club.PlayerClubs.Add(playerclub);
            //_context.Players.Update(player);
            //_context.Clubs.Update(club);
            _context.PlayerClubs.AddAsync(playerclub);
            await _context.SaveChangesAsync();
        }

        public async Task PlayerRemoveFromClub(int PlayerId, int ClubId)
        {
            var player = await _context.Players.FirstOrDefaultAsync(x => x.Id == PlayerId);
            var club = await _context.Clubs.FirstOrDefaultAsync(x => x.Id == ClubId);
            var playerClub = await _context.PlayerClubs.FirstOrDefaultAsync(x => x.ClubId == ClubId && x.PlayerId == PlayerId);
            if (player == null || club == null)
            {
                return;
            }
            //player.PlayerClubs.Remove(playerClub);
            //club.PlayerClubs.Remove(playerClub);
            //_context.Players.Update(player);
            //_context.Clubs.Update(club);
            _context.PlayerClubs.Remove(playerClub);
            await _context.SaveChangesAsync();
        }

        public async Task<Player> UpdatePlayer(Player player)
        {
            var Playerindb = await _context.Players.FirstOrDefaultAsync(x => x.Id == player.Id);
            if (Playerindb == null)
            {
                return null;
            }
            Playerindb.Update(player);
            _context.Players.Update(Playerindb);
            await _context.SaveChangesAsync();
            return Playerindb;
        }

        public async Task<bool> IsExistPlayerClub( int PlayerId,int ClubId)
           => await _context.PlayerClubs.Where(x => x.ClubId == ClubId && x.PlayerId == PlayerId).AnyAsync();
            
        
    }
}
