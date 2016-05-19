using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Dungeon
{
    public interface IEventGenerator
    {
        void Generate( Map map );
    }
}
