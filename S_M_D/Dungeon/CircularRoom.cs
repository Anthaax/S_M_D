using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace S_M_D.Dungeon
{
    public class CircularRoom : Room
    {
        private int radius;


        public CircularRoom()
        {
            Random rand = new Random();

            radius = rand.Next(2, 10);

            Path = new List<Point>();

            //center = path[0];

            IsCorridor = false;

            Neighbor = new List<MapItem>();
        }

        /// <summary>
        /// Initialize the Circular Room, place the center of the room within the map borders
        /// </summary>
        /// <param name="width">Width of the map</param>
        /// <param name="height">Height of the map</param>
        public override bool Init(int width, int height)
        {
            Random rand = new Random();

            Path.Clear();

            Point center = new Point(rand.Next(radius, width-radius) , rand.Next(radius, height-radius));

            Path.Add(center);

            Center = Path[0];

            return true;
        }

        /// <summary>
        /// Use Pythgora to determine if the point is within the circular room
        /// </summary>
        /// <param name="x"> X coordinate of the input point </param>
        /// <param name="y"> Y coordinate of the input point </param>
        /// <returns></returns>
        public override bool pointIsInsideRoom(int x, int y)
        {
            if(Math.Pow((x - Path[0].X), 2) + Math.Pow((y - Path[0].Y), 2) <= Math.Pow(radius, 2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
