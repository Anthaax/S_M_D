using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_M_D.Dungeon
{
    public class Map
    {

        public int Width { get; set; }
        public int Height { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Corridor> Corridors { get; set; }
        public MapItem[,] Grid { get; set; }

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
        }


    }
}
