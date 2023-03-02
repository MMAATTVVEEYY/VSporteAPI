using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace VSporteAPI.Entities
{
    public class MatchEvent
    {
        public int Id { get; set; }
        public int? PlayerId { get; set; }
       // virtual public Player? Player { get; set; }
        //public int? PlayerId { get; set; }
        public int ClubId { get; set; }
        public string EventType { get; set; }
        public DateTime MatchTime { get; set; }

        public void Update(MatchEvent matchEvent)
        {
            if (matchEvent == null)
            {
                return;
            }
            PlayerId = matchEvent.PlayerId;
            ClubId = matchEvent.ClubId;
            EventType = matchEvent.EventType;
            MatchTime = matchEvent.MatchTime;
        }
    }
}
