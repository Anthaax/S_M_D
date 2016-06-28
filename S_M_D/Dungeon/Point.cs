using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Dungeon
{
    [Serializable]
    public struct Point
    {
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}
