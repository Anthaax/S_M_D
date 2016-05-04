using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace S_M_D.Dungeon
{
    public class PolygonRoom : Room
    {

        public const int MIN_VERTICES_NB = 3;
        public const int MAX_VERTICES_NB = 6;
        public const int BOUNDING_RECT_HEIGHT = 10;
        public const int BOUNDING_RECT_WIDTH = 10;

        /// <summary>
        /// Checks whether a vertex is already in the room's vertices list.
        /// </summary>
        /// <param name="p">Tested vertex</param>
        /// <returns>True if the vertex is already in the room's vertices list, false if not</returns>
        private bool isAlreadyAPoint(Point p)
        {
            for (int i = 0; i < path.Count; i++)
            {
                if (p.X == path[i].X && p.Y == path[i].Y)
                    return true;
            }
            return false;
        }

        public PolygonRoom(int roomWidth, int roomHeight)
        {
            System.Random rand = new System.Random();
            int nbVertices = rand.Next(MIN_VERTICES_NB, MAX_VERTICES_NB);

            Rectangle r = new Rectangle();
            r.X = rand.Next(0, roomWidth - BOUNDING_RECT_WIDTH);
            r.Y = rand.Next(0, roomHeight - BOUNDING_RECT_HEIGHT);
            r.Width = BOUNDING_RECT_WIDTH;
            r.Height = BOUNDING_RECT_HEIGHT;
            bool correctPoint;
            for (int i = 0; i < nbVertices; i++)
            {
                correctPoint = false;
                Point p = new Point();
                while (!correctPoint)
                {
                    p.X = rand.Next(r.X, r.X + r.Width);
                    p.Y = rand.Next(r.Y, r.Y + r.Height);
                    if (!isAlreadyAPoint(p))
                        correctPoint = true;
                }
                path.Add(p);
            }
        }

        /// <summary>
        /// Using Jordan Curve theorem to checks whether a point is inside a polygon
        /// </summary>
        /// <remarks>
        /// Raycasting, increasing the x axis. 
        /// </remarks>
        /// <param name="x">X coordinate of the tested point.</param>
        /// <param name="y">Y coordinate of the tested point.</param>
        /// <returns>True if the point is inside the room, false if not.</returns>
        public override bool pointIsInsideRoom(int x, int y)
        {
            int i, j;
            bool inside = false;
            for (i = 0, j = path.Count - 1; i < path.Count; j = i++)
            {
                if (path[j].Y - path[i].Y == 0)
                    break;
                if (((path[i].Y > y) != (path[j].Y > y)) &&
                 (x < (path[j].X - path[i].X) * (y - path[i].Y) / (path[j].Y - path[i].Y) + path[i].X))
                    inside = !inside;
            }
            return inside;
        }
    }
}
