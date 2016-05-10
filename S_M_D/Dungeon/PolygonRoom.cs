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
            for (int i = 0; i < Path.Count; i++)
            {
                if (p.X == Path[i].X && p.Y == Path[i].Y)
                    return true;
            }
            return false;
        }

        public PolygonRoom()
        {
            this.Path = new List<Point>();
            this.IsCorridor = false;
            this.Neighbor = new List<MapItem>();
        }

        public PolygonRoom(List<Point> path)
        {
            this.Path = path;
            this.IsCorridor = false;
            this.Neighbor = new List<MapItem>();
        }

        public override void Init(int roomWidth, int roomHeight)
        {
            Path.Clear();
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
                Path.Add(p);
            }

            List<Point> roomCoords = new List<Point>();
            for (int y = 0; y < roomHeight; y++)
            {
                for (int x = 0; x < roomWidth; x++)
                {
                    if (pointIsInsideRoom(x, y))
                        roomCoords.Add(new Point(x, y));
                }
            }
            Center = roomCoords[(roomCoords.Count / 2)];
        }

        public bool onSegment(Point p, Point q, Point r)
        {
            if (q.X <= Math.Max(p.X, r.X) && q.X >= Math.Min(p.X, r.X)
                    && q.Y <= Math.Max(p.Y, r.Y) && q.Y >= Math.Min(p.Y, r.Y))
                return true;
            return false;
        }
        
        public int orientation(Point p, Point q, Point r)
        {
            int val = (q.Y - p.Y) * (r.X - q.X) - (q.X - p.X) * (r.Y - q.Y);

            if (val == 0)
                return 0;

            return (val > 0) ? 1 : 2;
        }

        public bool doIntersect(Point p1, Point q1, Point p2, Point q2)
        {
            int o1 = orientation(p1, q1, p2);
            int o2 = orientation(p1, q1, q2);
            int o3 = orientation(p2, q2, p1);
            int o4 = orientation(p2, q2, q1);

            if (o1 != o2 && o3 != o4)
                return true;
            if (o1 == 0 && onSegment(p1, p2, q1))
                return true;
            if (o2 == 0 && onSegment(p1, q2, q1))
                return true;
            if (o3 == 0 && onSegment(p2, p1, q2))
                return true;
            if (o4 == 0 && onSegment(p2, q1, q2))
                return true;
            return false;
        }


        /// <summary>
        /// Checks whether a point is inside a polygon
        /// </summary>
        /// <param name="x">X coordinate of the tested point.</param>
        /// <param name="y">Y coordinate of the tested point.</param>
        /// <returns>True if the point is inside the room, false if not.</returns>
        public override bool pointIsInsideRoom(int x, int y)
        {
            int INF = 10000;

            if (Path.Count < 3)
                return false;

            Point extreme = new Point(INF, y);
            Point p = new Point(x, y);
            int count = 0, i = 0;
            do
            {

                int next = (i + 1) % Path.Count;

                if (doIntersect(Path[i], Path[next], p, extreme))

                {

                    if (orientation(Path[i], p, Path[next]) == 0)
                        return onSegment(Path[i],p, Path[next]);
                    count++;
                }
                i = next;
            } while (i != 0);
            
            return (count & 1) == 1 ? true : false;

            /*
            int i, j;
            bool inside = false;
            for (i = 0, j = this.Path.Count - 1; i < this.Path.Count; j = i++)
            {
                if (this.Path[j].Y - this.Path[i].Y != 0)
                {
                    if (((Path[i].Y > y) != (Path[j].Y > y)) &&
                     (x < (Path[j].X - Path[i].X) * (y - Path[i].Y) / (Path[j].Y - Path[i].Y) + Path[i].X))
                        inside = !inside;
                }
            }
            return inside;
            */
        }
    }
}
