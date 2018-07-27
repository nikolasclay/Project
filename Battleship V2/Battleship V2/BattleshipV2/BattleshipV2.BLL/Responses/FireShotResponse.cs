using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipV2.BLL.Responses
{
    /* What will we need to send back in the response package?
       1. Shot status (invalid, hit, miss, duplicate, hit and sunk
       2. Which ship has been hit
       */
    public class FireShotResponse
    {
        public ShotStatus Status { get; set; }
        public string ShipImpacted { get; set; }
    }
}
