using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSporteAPI.Entities;

namespace VSporteAPI.Data.Abstract
{
    public interface IClubRepository
    {
        Task<IList<Club>> GetAllClubs();
        Task<Club> GetClubById(int id);
        Task<Club> AddClub(Club club);
        Task<Club> UpdateClub(Club club);
        Task<Club> DeleteClubById(int id);
    }
}
