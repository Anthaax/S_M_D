using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using S_M_D.Dungeon;
//using System.Drawing;

namespace DungeonTest
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

        [Test]
        public void Arrange_Points_Reorders_Correctly_A_Rectangle()
        {
            // Arrange
            List<Point> testRoomPts = new List<Point>();
            Point pt1 = new Point(10, 10);
            Point pt2 = new Point(10, 20);
            Point pt3 = new Point(20, 10);
            Point pt4 = new Point(20, 20);
            testRoomPts.Add(pt1);
            testRoomPts.Add(pt2);
            testRoomPts.Add(pt3);
            testRoomPts.Add(pt4);
            PolygonRoom testRoom = new PolygonRoom(testRoomPts);

            // Act
            testRoom.arrangePoints();

            // Assert
            Assert.AreEqual(pt1, testRoom.Path[0]);
            Assert.AreEqual(pt2, testRoom.Path[1]);
            Assert.AreEqual(pt4, testRoom.Path[2]);
            Assert.AreEqual(pt3, testRoom.Path[3]);
        }
    }
}
