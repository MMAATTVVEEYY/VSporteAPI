using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using VSporte.Core.Abstract;
using VSporteAPI.Data.Abstract;
using VSporteAPI.Entities;

namespace VSporte.Core
{
    public class ClubService:IClubService
    {
        private readonly IClubRepository clubRepository;
        public ClubService(IClubRepository clubRepository)
        {
            this.clubRepository = clubRepository;
        }
        public async Task<Club> AddClub(Club club)
        {
            if (club != null)
            {
                await clubRepository.AddClub(club);
                return club;

            }
            return null;
            
        }

        public async Task<Club> DeleteClubById(int id)
        {
            var result = await clubRepository.DeleteClubById(id);
            return result;
        }

        public async Task<IList<Club>> GetAllClubs()
        {
            var result = await clubRepository.GetAllClubs();
            return result;
        }

        public async Task<Club> GetClubById(int id)
        {
            var club = await clubRepository.GetClubById(id);
            return club;
        }

        public async Task<Club> UpdateClub(Club club)
        {
            var result = await clubRepository.UpdateClub(club);
            return result;
        }
    }
}
