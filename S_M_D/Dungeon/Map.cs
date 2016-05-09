using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_M_D.Dungeon
{
    public class Map
    {
        private int width;
        private int height;
        private List<Room> rooms;
        private List<Corridor> corridors;
        private MapItem[,] grid;

        public int Width { get; set; }
        public int Height { get; set; }
        public MapItem[,] Grid { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Corridor> Corridors { get; set; }

        public Map()
        {
            this.width = 50;
            this.height = 50;
            rooms = new List<Room>();
            corridors = new List<Corridor>();
            grid = new MapItem[width, height];
            IMapGenerator mapGen = new MapGenerator();
            IEventGenerator eventGen = new EventGenerator();
            mapGen.Generate(this);
        }


    }
}
