using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleshipV2.BLL.Ships;

namespace BattleshipV2.BLL.Requests
{
    //Identify what we will be receiving in the request package:
    /* 1. we'll need coordinates from the user
     * 2. we'll need the ship type
     * 3. we'll need the ship direction
     */
    public class PlacementRequest
    {
        public Coordinates Coordinate { get; set; }
        public ShipType SelectedShip { get; set; }
        public ShipDirection Direction { get; set; }
    }
}
