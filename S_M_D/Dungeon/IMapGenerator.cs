using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_M_D.Dungeon
{
    public interface IMapGenerator
    {
        /// <summary>
        /// Generates the map (rooms and corridors)
        /// </summary>
        /// <param name="map">Map which will be completed.</param>
        void Generate(Map map);

        /// <summary>
        /// Regenerates the map between the given boundaries.
        /// </summary>
        /// <param name="width">Width of the rectangle which will be regenerated.</param>
        /// <param name="height">Height of the rectangle which will be regenerated.</param>
        /// <param name="x">X coordinate of the rectangle which will be regenerated. (Top left corner)</param>
        /// <param name="y">Y coordinate of the rectangle which will be regenerated. (Top left corner)(</param>
        /// <param name="map">Map which will be regenerated.</param>
        void GenerateParts(int width, int height, int x, int y, Map map);
    }
}
