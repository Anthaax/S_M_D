using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace S_M_D.Dungeon
{
    [Serializable]
    public class Corridor : MapItem
    {
        public Corridor()
        {
            this.Path = new List<Point>();
            this.IsCorridor = true;
            this.Neighbor = new List<MapItem>();
        }

        public Corridor(Room r1, Room r2)
        {
            this.Path = new List<Point>();
            this.Path.Add(r1.Center);
            this.Path.Add(r2.Center);
            this.IsCorridor = true;
            this.Neighbor = new List<MapItem>();
        }
    }
}
