using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using S_M_D.Dungeon;
using System.Drawing;

namespace ClassLibrary1
{
    [TestFixture]
    class PolygonRoomTest
    {

        [Test]
        public void Points_are_inside_rectangular_room()
        {
            // Arrange
            List<Point> roomPoints = new List<Point>();
            roomPoints.Add(new Point(10, 10));
            roomPoints.Add(new Point(10, 20));
            roomPoints.Add(new Point(20, 10));
            roomPoints.Add(new Point(20, 20));
            PolygonRoom testRoom = new PolygonRoom(roomPoints);

            // Act
            testRoom.arrangePoints();

            // Assert
            for (int y = 11; y < 20; y++)
            {
                for (int x = 11; x < 20; x++)
                {
                    Assert.True(testRoom.pointIsInsideRoom(x, y), "x = " + x + " y = " + y);
                }
            }
        }
    }
}
