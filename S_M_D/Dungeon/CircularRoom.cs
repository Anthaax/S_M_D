using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace S_M_D.Dungeon
{
    class CircularRoom : Room
    {
        private int radius;

        /// <summary>
        /// Use Pythgora to determine if the point is within the circular room
        /// </summary>
        /// <param name="x"> X coordinate of the input point </param>
        /// <param name="y"> Y coordinate of the input point </param>
        /// <returns></returns>
        public override bool pointIsInsideRoom(int x, int y)
        {
            return Math.Pow((x - path[0].X), 2) + Math.Pow((y - path[0].Y), 2) <= Math.Pow(radius, 2) ? true : false;
        }
    }
}
