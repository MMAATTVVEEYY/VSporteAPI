using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSporteAPI.Entities;

namespace VSporteAPI.Data.Abstract
{
    public interface IPlayerRepository
    {
        Task<IList<Player>> GetAllPlayers();
        Task<Player> GetPlayerById(int id);
        Task<Player> AddPlayer(Player player);
        Task<Player> UpdatePlayer(Player player);
        Task<Player> DeletePlayerById(int id);
        Task PlayerAddToClub(int PlayerId, int ClubId);
        Task PlayerRemoveFromClub(int PlayerId, int ClubId);
        Task <bool> IsExistPlayerClub(int PlayerId, int ClubId);

    }
}
