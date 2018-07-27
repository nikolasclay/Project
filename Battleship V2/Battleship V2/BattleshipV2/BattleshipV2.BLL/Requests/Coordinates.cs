using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipV2.BLL.Requests
{
    public class Coordinates
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        public Coordinates(int x, int y)
        {
            XCoordinate = x;
            YCoordinate = y;
        }

        public override bool Equals(object obj)
        {
            Coordinates otherCoordinate = obj as Coordinates;
            if(otherCoordinate == null)
            {
                return false;
            }
            else
            {
                return otherCoordinate.XCoordinate == this.XCoordinate &&
                       otherCoordinate.YCoordinate == this.YCoordinate;
            }            
        }

        public override int GetHashCode()
        {
            string uniqueHash = this.XCoordinate.ToString() + this.YCoordinate.ToString() + "00";
            return (Convert.ToInt32(uniqueHash));
        }
    }
}
