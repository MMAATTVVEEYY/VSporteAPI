using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSporteAPI.Entities;

namespace VSporte.Core.Abstract
{
    public interface IClubService
    {
        public Task<Club> AddClub(Club club);
        public Task<Club> GetClubById(int id);
        public Task<IList<Club>> GetAllClubs();
        public Task<Club> DeleteClubById(int id);
        public Task<Club> UpdateClub(Club club);
    }
}
