using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSporteAPI.Entities;

namespace VSporte.Core.Abstract
{
    public interface IPlayerService
    {
        public Task<Player> AddPlayer(Player player);
        public Task<Player> GetPlayerById(int id);
        public Task<IList<Player>> GetAllPlayers();
        public Task<Player> DeletePlayerById(int id);
        public Task<bool> PlayerAddToClub(int PlayerId, int ClubId);
        public Task<bool> PlayerRemoveFromClub(int PlayerId, int ClubId);
        public Task<Player> UpdatePlayer(Player player);
    }
}
