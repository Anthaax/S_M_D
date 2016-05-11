using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace S_M_D.Dungeon
{
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

        public bool isNotVisited(MapItem room)
        {
            for (int i = 0; i < this.NotVisited.Count; i++)
            {
                if (room.Equals(this.NotVisited[i]))
                    return true;
            }
            return false;
        }

        public bool isVisited(MapItem room)
        {
            for (int i = 0; i < this.Visited.Count; i++)
            {
                if (room.Equals(this.Visited[i]));
                    return true;
            }
            return false;
        }
    }
}
