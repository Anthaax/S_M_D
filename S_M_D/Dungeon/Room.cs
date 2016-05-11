using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace S_M_D.Dungeon
{
    public abstract class Room : MapItem
    {
        protected Point center;
        public Point Center { get; set; }

        /// <summary>
        /// Initializes the room, setting its characteristics (randomly generated).
        /// </summary>
        /// <param name="width">Width of the map's grid.</param>
        /// <param name="height">Height of the map's grid.</param>
        /// <returns>True if the room is correct, false otherwise</returns>
        public abstract bool Init(int width, int height);

        /// <summary>
        /// Checks whether you can place a room in the map or not. 
        /// You can place a room if there is no room currently occupying the space the new room will take.
        /// </summary>
        /// <param name="grid">The grid we will search through to ensure we can place the room.</param>
        /// <returns>True if you can place the room, False if not.</returns>
        public bool canPlaceRoom(MapItem[,] grid, int width, int height)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (pointIsInsideRoom(x, y) && grid[y, x] != null)
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Checks whether a given point is inside the room.
        /// </summary>
        /// <param name="x">X coordinate of the tested point.</param>
        /// <param name="y">Y coordinate of the tested point.</param>
        /// <returns>True if the given point is inside the room, False if not.</returns>
        public abstract bool pointIsInsideRoom(int x, int y);

        /// <summary>
        /// Place the room on the map's grid.
        /// </summary>
        /// <param name="grid">Grid the room will be placed on.</param>
        public void placeRoom(MapItem[,] grid, int width, int height)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (pointIsInsideRoom(x, y))
                        grid[y, x] = this;
                }
            }
        }

    }
}
