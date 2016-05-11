using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace S_M_D.Dungeon
{
    public abstract class MapItem
    {
        protected List<Point> path;
        protected List<MapItem> neighbor;
        protected bool isCorridor;

        public List<Point> Path { get; set; }
        public bool IsCorridor { get; set; }
        public List<MapItem> Neighbor { get; set; }
        public void SetNeighbor( MapItem item)
        {
            Neighbor.Add(item);
        }
    }
}
