using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace S_M_D.Dungeon
{
    public class Corridor : MapItem
    {
        public Corridor()
        {
            path = new List<Point>();
            IsCorridor = true;
            neighbor = new List<MapItem>();
        }

        public Corridor(Room r1, Room r2)
        {
            path = new List<Point>();
            path[0] = r1.Center;
            path[1] = r2.Center;
            IsCorridor = true;
            neighbor = new List<MapItem>();
        }
    }
}
