using BattleshipV2.BLL.Requests;
using BattleshipV2.BLL.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipV2.BLL.Ships
{
    public class Ship
    {
        public ShipType ShipType { get; private set; }
        public string ShipName { get { return ShipType.ToString(); } }
        public Coordinates[] BoardPositions { get; set; }
        private int _lifeRemaining;
        public bool isSunk { get { return _lifeRemaining == 0; } }


        public Ship(ShipType shipType, int numberOfSlots)
        {
            ShipType = shipType;
            _lifeRemaining = numberOfSlots;
            BoardPositions = new Coordinates[numberOfSlots];
        }
        public ShotStatus FireAtShip(Coordinates position)
        {
            if (BoardPositions.Contains(position))
            {
                _lifeRemaining--;

                if (_lifeRemaining == 0)
                {
                    return ShotStatus.HitAndSunk;
                }
                return ShotStatus.Hit;
            }
            return ShotStatus.Miss;
        }
    }
}
