using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSporteAPI.Entities
{
    public class PlayerClub
    {
     
        [Column(Order = 0)]
        [ForeignKey("Player")]
        public int PlayerId { get; set; }

        public Player? Player { get; set; }
       
        [Column(Order = 1)]
        [ForeignKey("Club")]
        public int ClubId { get; set; }
        public Club? Club { get; set; }
    }
}
