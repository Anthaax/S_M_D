using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGenerator
{
    public interface IMapGenerator
    {
        void Generate(Map map);

        void GenerateParts(int width, int height, int x, int y, Map map);
    }
}
