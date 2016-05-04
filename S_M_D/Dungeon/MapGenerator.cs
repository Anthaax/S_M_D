using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    r.Init(map.Width, map.Height);
                    if (r.canPlaceRoom(map.Grid, map.Width, map.Height))
                        roomPlaced = true;
                }
            }
        }
        public void Generate(Map map)
        {
            this.generateRooms(map);

            ICorridorGenerator corGen = new CorridorGenerator();
            corGen.Generate(map);
        }

        public void GenerateParts(int width, int height, int x, int y, Map map)
        {
            throw new NotImplementedException();
        }
    }
}
