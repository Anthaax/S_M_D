using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace S_M_D.Dungeon
{
    [Serializable]
    public class Map
    {

        public int Width { get; set; }
        public int Height { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Corridor> Corridors { get; set; }
        public MapItem[,] Grid { get; set; }
        public List<MapItem> NotVisited { get; set; }
        public List<MapItem> Visited { get; set; }
        public Point HeroPosition { get; set; }

        public Map()
        {
            this.Width = 50;
            this.Height = 50;
            this.Rooms = new List<Room>();
            this.Corridors = new List<Corridor>();
            this.Grid = new MapItem[this.Height, this.Width];
            IMapGenerator mapGen = new MapGenerator();
            IEventGenerator eventGen = new EventGenerator();
            mapGen.Generate(this);

            this.Visited = new List<MapItem>();
            this.Visited.Add(this.Rooms[0]);
            this.NotVisited = this.Rooms[0].Neighbor;
            this.HeroPosition = this.Rooms[0].Center;
        }

        public Map(string descriptor)
        {
            string[] desc = descriptor.Split('\n');
            this.Width = int.Parse(desc[0]);
            this.Height = int.Parse(desc[1]);
            this.Grid = new MapItem[Width, Height];
            this.Rooms = new List<Room>();
            this.Corridors = new List<Corridor>();
            int nbRoom = int.Parse(desc[2]);
            int idx = 3;
            while (idx < desc.Length)
            {
                
                if (desc[idx] == "CircularRoom")
                {
                    CircularRoom cr = new CircularRoom();
                    
                    string[] coords = desc[idx + 1].Split(' ');
                    
                    cr.Path.Add(new Point(int.Parse(coords[0]), int.Parse(coords[1])));
                    cr.Center = cr.Path[0];
                    cr.Radius = int.Parse(desc[idx + 2]);
                    this.Rooms.Add(cr);
                    idx += 3;
                }
               else if (desc[idx] == "PolygonRoom")
                {
                    int nbPoint = int.Parse(desc[idx + 1]);
                    List<Point> pts = new List<Point>();
                    for (int i = 0; i < nbPoint; i++)
                    {
                        string[] coords = desc[idx + 2 + i].Split(' ');
                        pts.Add(new Point(int.Parse(coords[0]), int.Parse(coords[1])));
                    }
                    PolygonRoom pr = new PolygonRoom(pts);
                    string[] coordCenter = desc[idx + 2 + nbPoint].Split(' ');
                    pr.Center = new Point(int.Parse(coordCenter[0]), int.Parse(coordCenter[1]));
                    idx += 3 + nbPoint;
                    this.Rooms.Add(pr);
                }
                else if (desc[idx] == "RectangularRoom" )
                {

                    List<Point> pts = new List<Point>( );

                    string[ ] coords = desc[ idx + 1 ].Split( ' ' );
                    Point center = new Point( int.Parse( coords[ 0 ] ), int.Parse( coords[ 1 ] ) );
                    for (int i = 0; i < 4; i++ )
                    {
                        coords = desc[ idx + 2 + i ].Split( ' ' );
                        pts.Add( new Point( int.Parse( coords[ 0 ] ), int.Parse( coords[ 1 ] ) ) );
                    }
                    RectangularRoom rectroom = new RectangularRoom( pts );
                    rectroom.Center = center;
                    this.Rooms.Add(rectroom);
                    idx += 4;
                }
                else
                    idx++;
            }
            for (int i = 0; i < this.Rooms.Count; i++)
            {
                this.Rooms[i].placeRoom(this.Grid, this.Width, this.Height);
            }
            
            MapGenerator mapGen = new MapGenerator();
            IEventGenerator eventGen = new EventGenerator();
            ICorridorGenerator corGen = new CorridorGenerator();

            corGen.Generate(this);
            mapGen.setNeighbors(this);

            this.Visited = new List<MapItem>();
            this.Visited.Add(this.Rooms[0]);
            this.NotVisited = this.Rooms[0].Neighbor;
            this.HeroPosition = this.Rooms[0].Center;    
        }

        public bool isNotVisited(MapItem room)
        {
            for (int i = 0; i < this.NotVisited.Count; i++)
            {
                if (room == this.NotVisited[i])
                    return true;
            }
            return false;
        }

        public bool isVisited(MapItem room)
        {
            for (int i = 0; i < this.Visited.Count; i++)
            {
                if (room == this.Visited[i])
                    return true;
            }
            return false;
        }

        public List<Point> leeAlgorithm(Point posA, Point posB)
        {
            List<Point> cells = new List<Point>();

            int[,] leeMap = new int[this.Height, this.Width];
            // Memset
            for (int i = 0; i < this.Height; i++)
            {
                for (int j = 0; j < this.Width; j++)
                {
                    leeMap[i, j] = -1;
                }
            }
            int posX = posA.X;
            int posY = posA.Y;
            int targetX = posB.X;
            int targetY = posB.Y;
            
            int[] positionsX = new int[this.Height * this.Width * 8];
            int[] positionsY = new int[this.Height * this.Width * 8];
            int[] pointNb = new int[this.Height * this.Width * 8];

            int idx = 0;
            positionsX[0] = posX;
            positionsY[0] = posY;
            pointNb[0] = 0;
            int elemNb = 1;
            while (!(posX == targetX && posY == targetY))
            {
                posX = positionsX[idx];
                posY = positionsY[idx];
                leeMap[posY, posX] = pointNb[idx];
                if (posX - 1 >= 0 && leeMap[posY, posX - 1] == -1 && this.Grid[posY, posX - 1] != null)
                {
                    positionsX[elemNb] = posX - 1;
                    positionsY[elemNb] = posY;
                    pointNb[elemNb] = pointNb[idx] + 1;
                    leeMap[posY, posX - 1] = pointNb[idx] + 1;
                    elemNb++;
                }
                if (posX + 1 < this.Width && leeMap[posY, posX + 1] == -1 && this.Grid[posY, posX + 1] != null)
                {
                    positionsX[elemNb] = posX + 1;
                    positionsY[elemNb] = posY;
                    pointNb[elemNb] = pointNb[idx] + 1;
                    leeMap[posY, posX + 1] = pointNb[idx] + 1;
                    elemNb++;
                }
                if (posY + 1 < this.Height && leeMap[posY + 1, posX] == -1 && this.Grid[posY + 1, posX] != null)
                {
                    positionsX[elemNb] = posX;
                    positionsY[elemNb] = posY + 1;
                    pointNb[elemNb] = pointNb[idx] + 1;
                    leeMap[posY + 1, posX] = pointNb[idx] + 1;
                    elemNb++;
                }
                if (posY - 1 >= 0 && leeMap[posY - 1, posX] == -1 && this.Grid[posY - 1, posX] != null)
                {
                    positionsX[elemNb] = posX;
                    positionsY[elemNb] = posY - 1;
                    pointNb[elemNb] = pointNb[idx] + 1;
                    leeMap[posY - 1, posX] = pointNb[idx] + 1;
                    elemNb++;
                }
                idx++;
            }

            int y = targetY;
            int x = targetX;

            int targetPoint = leeMap[targetY, targetX];

            cells.Add(new Point(x,y));
            while (targetPoint > 0 && !(y == posA.Y && x == posA.X))
            {
                if (leeMap[y, x - 1] == targetPoint - 1 && leeMap[y, x - 1] != -1 && this.Grid[y, x - 1] != null)
                {
                    cells.Add(new Point(x - 1, y));
                    x = x - 1;
                }
                else if (leeMap[y, x + 1] == targetPoint - 1 && leeMap[y, x + 1] != -1 && this.Grid[y, x + 1] != null)
                {
                    cells.Add(new Point(x + 1, y));
                    x = x + 1;
                }
                else if (leeMap[y - 1, x] == targetPoint - 1 && leeMap[y - 1, x] != -1 && this.Grid[y - 1, x] != null)
                {
                    cells.Add(new Point(x, y - 1));
                    y = y - 1;
                }
                else if (leeMap[y + 1, x] == targetPoint - 1 && leeMap[y + 1, x] != -1 && this.Grid[y + 1, x] != null)
                {
                    cells.Add(new Point(x, y + 1));
                    y = y + 1;
                }
                targetPoint--;
            }
            return cells;
        }

        public void addNeighborsToNotVisited(MapItem room)
        {
            for (int i = 0; i < room.Neighbor.Count; i++)
            {
                if (!isVisited((room.Neighbor[i])))
                {
                    this.NotVisited.Add(room.Neighbor[i]);
                }
            }
        }

        public void removeRoomFromNotVisited(MapItem room)
        {
            for (int i = NotVisited.Count - 1; i >= 0; i--)
            {
                if (NotVisited[i] == room)
                    NotVisited.RemoveAt(i);
            }
        }
    }
}
