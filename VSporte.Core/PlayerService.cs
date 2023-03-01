using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSporte.Core.Abstract;
using VSporteAPI.Data;
using VSporteAPI.Data.Abstract;
using VSporteAPI.Entities;

namespace VSporte.Core
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository playerRepository;
        public PlayerService(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }
        public async Task<Player> AddPlayer(Player player)
        {
            await playerRepository.AddPlayer(player);
            return player;
        }

        public async Task<Player> DeletePlayerById(int id)
        {
            var result = await playerRepository.DeletePlayerById(id);
            return result;
        }

        public async Task<IList<Player>> GetAllPlayers()
        {
            var result = await playerRepository.GetAllPlayers();
            return result;
        }

        public async Task<Player> GetPlayerById(int id)
        {
            var player =  await playerRepository.GetPlayerById(id);
            return player;
        }

        public async Task<bool> PlayerAddToClub(int PlayerId, int ClubId)
        {
            var exists = await playerRepository.IsExistPlayerClub(PlayerId, ClubId);
            if (exists)
            {
                return false;
            }
            await playerRepository.PlayerAddToClub(PlayerId, ClubId);
            return true;

        }

        public async Task<bool> PlayerRemoveFromClub(int PlayerId, int ClubId)
        {
            var exists = await playerRepository.IsExistPlayerClub(PlayerId, ClubId);
            if (!exists)
            {
                return false;
            }
            await playerRepository.PlayerRemoveFromClub(PlayerId, ClubId);
            return true;
        }

        public async Task<Player> UpdatePlayer(Player player)
        {
            var result = await playerRepository.UpdatePlayer(player);
            return result;
        }
    }
}
