using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VSporteAPI.Entities
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronym { get  ; set;}//отчество
        public int FieldNumber { get; set; }
        public virtual ICollection<PlayerClub?> PlayerClubs { get; set; }= new List<PlayerClub?>();

        public List<MatchEvent?> MatchEvents { get; set; } = new List<MatchEvent?>();

        public void Update(Player player)
        {
            if (player == null)
            {
                return;
            }
            this.Name = player.Name;
            Surname = player.Surname;
            Patronym = player.Patronym;
            FieldNumber = player.FieldNumber;
        }
       /* public List<PlayerClub?> PlayerClubs { get; set; }=new();

       ;*/
    }
}
