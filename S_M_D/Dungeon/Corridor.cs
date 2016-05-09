﻿using System;
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
            this.Path = new List<Point>();
            IsCorridor = true;
            this.Neighbor = new List<MapItem>();
        }

        public Corridor(Room r1, Room r2)
        {
            this.Path = new List<Point>();
            path.Add(r1.Center);
            path.Add(r2.Center);
            IsCorridor = true;
            this.Neighbor = new List<MapItem>();
        }
    }
}
