using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Dungeon
{
    public class MapGenerator : IMapGenerator
    {
        // Room characteristics
        public const int STANDARD_MIN_ROOM_NB = 5;
        public const int STANDARD_MAX_ROOM_NB = 10;
        public const int STANDARD_MIN_ROOM_WIDTH = 3;
        public const int STANDARD_MAX_ROOM_WIDTH = 6;
        public const int STANDARD_MIN_ROOM_HEIGHT = 3;
        public const int STANDARD_MAX_ROOM_HEIGHT = 6;

        public void generateRooms(Map map)
        {
            Random rand = new Random();
            int nbRoom = rand.Next(STANDARD_MIN_ROOM_NB, STANDARD_MAX_ROOM_NB);
            for (int i = 0; i < nbRoom; i++)
            {
                int roomType = rand.Next(0, 2);
                Room r;
                if (roomType == 0)
                {
                    r = new CircularRoom();
                }
                else
                {
                    r = new PolygonRoom();
                }
                bool roomPlaced = false;
                while (!roomPlaced)
                {
                    bool correct = r.Init(map.Width, map.Height);
                    if (correct && r.canPlaceRoom(map.Grid, map.Width, map.Height))
                        roomPlaced = true;
                }
                map.Rooms.Add(r);
                r.placeRoom(map.Grid,map.Width,map.Height);
            }
        }

        public void addNeighbor(MapItem i1, MapItem i2)
        {
            i1.SetNeighbor(i2);
            i2.SetNeighbor(i1);
        }

        public void setNeighbors(Map map)
        {
            for (int i = 0; i < map.Rooms.Count; i++)
            {
                Room r = map.Rooms[i];
                for (int y = 0; y < map.Height; y++)
                {
                    for (int x = 0; x < map.Width; x++)
                    {
                        if (r.pointIsInsideRoom(x, y))
                        {
                            if (x - 1 >= 0 && map.Grid[y, x - 1] != null && map.Grid[y, x - 1] != r)
                                addNeighbor(r, map.Grid[y, x - 1]);
                            if (x + 1 < map.Width && map.Grid[y, x + 1] != null && map.Grid[y, x + 1] != r)
                                addNeighbor(r, map.Grid[y, x + 1]);
                            if (y - 1 >= 0 && map.Grid[y - 1, x] != null && map.Grid[y - 1, x] != r)
                                addNeighbor(r, map.Grid[y - 1, x]);
                            if (y + 1 < map.Height && map.Grid[y + 1, x] != null && map.Grid[y + 1, x] != r)
                                addNeighbor(r, map.Grid[y + 1, x]);
                        }
                    }
                }
            }
        }

        public void Generate(Map map)
        {
            this.generateRooms(map);

            ICorridorGenerator corGen = new CorridorGenerator();
            IEventGenerator eventGen = new EventGenerator( );

            corGen.Generate(map);
            eventGen.Generate( map );

            this.setNeighbors(map);
        }

        public void GenerateParts(int width, int height, int x, int y, Map map)
        {
            throw new NotImplementedException();
        }
    }
}
