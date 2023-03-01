using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSporteAPI.Entities
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public virtual ICollection<PlayerClub?> PlayerClubs { get; set; } = new List<PlayerClub>();

        public void Update(Club club)
        {
            if (club == null)
            {
                return;
            }
            this.Name = club.Name;
            ShortName = club.ShortName;
        }
        // public List<PlayerClub?> PlayerClubs { get; set; } = new();
    }
}
