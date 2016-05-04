using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_M_D.Dungeon
{
    public interface ICorridorGenerator
    {
        void Generate(Map map);
    }
}
