using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using S_M_D.Dungeon;
using System.Drawing;

namespace DungeonTest
{
    [TestFixture]
    class RoomTest
    {
        [Test]
        public void Can_Place_Room_Returns_False_If_There_Is_Already_A_Room()
        {
            // Arrange
            List<Point> testRoom1Pts = new List<Point>();
            testRoom1Pts.Add(new Point(10, 10));
            testRoom1Pts.Add(new Point(10, 20));
            testRoom1Pts.Add(new Point(20, 10));
            testRoom1Pts.Add(new Point(20, 20));
            PolygonRoom testRoom1 = new PolygonRoom(testRoom1Pts);

            List<Point> testRoom2Pts = new List<Point>();
            testRoom2Pts.Add(new Point(15, 17));
            testRoom2Pts.Add(new Point(15, 15));
            testRoom2Pts.Add(new Point(17, 15));
            testRoom2Pts.Add(new Point(17, 17));
            PolygonRoom testRoom2 = new PolygonRoom(testRoom2Pts);

            MapItem[,] grid = new MapItem[50, 50];
            // Act
            testRoom1.arrangePoints();
            testRoom1.placeRoom(grid, 50, 50);
            testRoom2.arrangePoints();
            // Assert

            Assert.False(testRoom2.canPlaceRoom(grid, 50, 50));
        }

        [Test]
        public void Can_Place_Room_Returns_True_If_There_Is_No_Room()
        {
            // Arrange
            List<Point> testRoom1Pts = new List<Point>();
            testRoom1Pts.Add(new Point(10, 10));
            testRoom1Pts.Add(new Point(10, 20));
            testRoom1Pts.Add(new Point(20, 10));
            testRoom1Pts.Add(new Point(20, 20));
            PolygonRoom testRoom1 = new PolygonRoom(testRoom1Pts);

            List<Point> testRoom2Pts = new List<Point>();
            testRoom2Pts.Add(new Point(30, 40));
            testRoom2Pts.Add(new Point(40, 40));
            testRoom2Pts.Add(new Point(40, 30));
            testRoom2Pts.Add(new Point(30, 30));
            PolygonRoom testRoom2 = new PolygonRoom(testRoom2Pts);

            MapItem[,] grid = new MapItem[50, 50];

            // Act
            testRoom1.arrangePoints();
            testRoom1.placeRoom(grid, 50, 50);
            testRoom2.arrangePoints();

            // Assert
            Assert.True(testRoom2.canPlaceRoom(grid, 50, 50));
        }

        [Test]
        public void Place_Room_Test()
        {
            // Arrange
            List<Point> testRoom1Pts = new List<Point>();
            testRoom1Pts.Add(new Point(10, 10));
            testRoom1Pts.Add(new Point(10, 20));
            testRoom1Pts.Add(new Point(20, 10));
            testRoom1Pts.Add(new Point(20, 20));
            PolygonRoom testRoom1 = new PolygonRoom(testRoom1Pts);
            
            MapItem[,] grid = new MapItem[50, 50];

            // Act
            testRoom1.arrangePoints();
            testRoom1.placeRoom(grid, 50, 50);

            // Assert
            for (int y = 11; y < 20; y++)
            {
                for (int x = 11; x < 20; x++)
                {
                    Assert.AreEqual(testRoom1, grid[y, x]);
                }
            }
        }
    }
}
