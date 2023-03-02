using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
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
        private readonly IPlayerRepository playerRepository;
        private readonly IClubRepository clubRepository;
        public MatchEventService(IMatchEventRepository matchEventRepository, IPlayerRepository playerRepository, IClubRepository clubRepository)
        {
            this.matchEventRepository = matchEventRepository;
            this.playerRepository = playerRepository;
            this.clubRepository = clubRepository;
        }
       

        public async Task<MatchEvent> AddMatchEvent(MatchEvent matchEvent)
        {
            
            if (matchEvent != null)
            {   //PlayerId Должен либо принадлежать существующему Player, либо Null. Нельзя присваивать несущетсвующих
                if (matchEvent.PlayerId != null)
                {
                var Presult = await playerRepository.GetPlayerById((int)matchEvent.PlayerId);
                if (Presult != null)
                    { // здесь player не равен 0 и существует в бд
                        var Cresult1= await clubRepository.GetClubById(matchEvent.ClubId);
                        if (Cresult1 != null)
                        {
                            await matchEventRepository.AddMatchEvent(matchEvent);
                            return matchEvent;
                        }
                        return null;
                    }
                    // здесь player не существует
                    return null;
                }
                // тут playerId = null
                var Cresult2 = await clubRepository.GetClubById(matchEvent.ClubId);
                if (Cresult2 != null)
                {
                    await matchEventRepository.AddMatchEvent(matchEvent);
                    return matchEvent;
                }
                return null;
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
            if (matchEvent != null)
            {   //PlayerId Должен либо принадлежать существующему Player, либо Null. Нельзя присваивать несущетсвующих
                if (matchEvent.PlayerId != null)
                {
                    var Presult = await playerRepository.GetPlayerById((int)matchEvent.PlayerId);
                    if (Presult != null)
                    { // здесь player не равен 0 и существует в бд
                        var Cresult1 = await clubRepository.GetClubById(matchEvent.ClubId);
                        if (Cresult1 != null)
                        {
                            await matchEventRepository.UpdateMatchEvent(matchEvent);
                            return matchEvent;
                        }
                        return null;
                    }
                    // здесь player не существует
                    return null;
                }
                // тут playerId = null
                var Cresult2 = await clubRepository.GetClubById(matchEvent.ClubId);
                if (Cresult2 != null)
                {
                    await matchEventRepository.UpdateMatchEvent(matchEvent);
                    return matchEvent;
                }
                return null;
            }
            return null;
        }
    }
}
