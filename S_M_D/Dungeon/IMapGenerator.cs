using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Dungeon
{
    public interface IMapGenerator
    {
        void Generate(Map map);

        void GenerateParts(int width, int height, int x, int y, Map map);
    }
}
