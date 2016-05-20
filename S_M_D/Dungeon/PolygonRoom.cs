using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            this.Path = new List<Point>(path);
            this.IsCorridor = false;
            this.Neighbor = new List<MapItem>();
        }
        
        /// <summary>
        /// Reorders the points of the path in order to create a viable polygon.
        /// <remarks>
        /// Given the polygon:
        ///          x (1)          x(3)
        ///          
        /// 
        /// 
        ///          x (2)          x(4)
        /// If the points are not reorders, the following polygon will be created:
        ///         x     x
        ///         |    /|
        ///         |   / |
        ///         |  /  |
        ///         | /   |
        ///         x     x
        ///  It is not really viable, as there is no point inside the polygon.
        ///  This method will reorder the points like that:
        ///         x (1)          x (4)
        ///         
        /// 
        /// 
        ///         x (2)          x (3)
        ///   Which will give the following polygon:
        ///         x            x
        ///         |            |
        ///         |            |
        ///         |            |
        ///         x------------x
        ///   We obtain a viable rectangle.
        /// </remarks>
        /// </summary>
        public void arrangePoints()
        {
            Point ptTop, ptBot;
            ptTop = Path[0];
            ptBot = Path[0];
            for (int i = 0; i < Path.Count; i++)
            {
                if (Path[i].Y > ptTop.Y)
                    ptTop = Path[i];
                if (Path[i].Y < ptBot.Y)
                    ptBot = Path[i];
            }
            List<Point> left = new List<Point>();
            List<Point> right = new List<Point>();
            List<Point> newPath = new List<Point>();
            for (int i = 0; i < Path.Count; i++)
            {
                if (Path[i].X <= ptBot.X)
                    left.Add(Path[i]);
                else
                    right.Add(Path[i]);
            }
            int idx;
            int value;
            while (left.Count != 0)
            {
                idx = 0; value = left[0].Y;
                for (int i = 0; i < left.Count; i++)
                {
                    if (left[i].Y < value)
                    {
                        value = left[i].Y;
                        idx = i;
                    }
                }
                newPath.Add(left[idx]);
                left.RemoveAt(idx);
            }
            while (right.Count != 0)
            {
                idx = 0; value = right[0].Y;
                for (int i = 0; i < right.Count; i++)
                {
                    if (right[i].Y > value)
                    {
                        value = right[i].Y;
                        idx = i;
                    }
                }
                newPath.Add(right[idx]);
                right.RemoveAt(idx);
            }
            this.Path = newPath;
        }

        public override bool Init(int roomWidth, int roomHeight)
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

            arrangePoints();

            List<Point> roomCoords = new List<Point>();
            for (int y = 0; y < roomHeight; y++)
            {
                for (int x = 0; x < roomWidth; x++)
                {
                    if (pointIsInsideRoom(x, y))
                        roomCoords.Add(new Point(x, y));
                }
            }
            if (roomCoords.Count == 0)
                return false;
            Center = roomCoords[(roomCoords.Count / 2)];
            return true;
        }
        
        /// <summary>
        /// Checks whether a given point is inside the room.
        /// </summary>
        /// <remarks>
        /// Uses Jordan's Curve's theorem. Raycasting a point by increasing the x.
        /// </remarks>
        /// <param name="x">X coordinate of the tested point.</param>
        /// <param name="y">Y coordinate of the tested point.</param>
        /// <returns>True if the point is inside the room, false if not.</returns>
        public override bool pointIsInsideRoom(int x, int y)
        {
            int i, j;
            bool inside = false;
            for (i = 0, j = this.Path.Count - 1; i < this.Path.Count; j = i++)
            {
                if (this.Path[j].Y - this.Path[i].Y != 0)
                {
                    if (((Path[i].Y >= y) != (Path[j].Y >= y)) &&
                     (x <= (Path[j].X - Path[i].X) * (y - Path[i].Y) / (Path[j].Y - Path[i].Y) + Path[i].X))
                        inside = !inside;
                }
            }
            return inside;
        }
    }
}
