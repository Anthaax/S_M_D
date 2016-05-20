using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using S_M_D.Dungeon;
//using System.Drawing;

namespace S_M_D.Dungeon.Tests
{
    [TestFixture]
    class CorridorGeneratorTest
    {

        [Test]
        public void Edge_exists_between_two_rooms_there_is_an_edge()
        {
            // Arrange
            List<Point> ptsRoom1 = new List<Point>();
            ptsRoom1.Add(new Point(10, 10));
            ptsRoom1.Add(new Point(10, 20));
            ptsRoom1.Add(new Point(20, 10));
            ptsRoom1.Add(new Point(20, 20));
            PolygonRoom room1 = new PolygonRoom(ptsRoom1);

            List<Point> ptsRoom2 = new List<Point>();
            ptsRoom2.Add(new Point(30, 30));
            ptsRoom2.Add(new Point(30, 40));
            ptsRoom2.Add(new Point(40, 30));
            ptsRoom2.Add(new Point(40, 40));
            PolygonRoom room2 = new PolygonRoom(ptsRoom2);

            WeightedEdge wEdge = new WeightedEdge(room1, room2, 10f);
            List<WeightedEdge> wEdgeList = new List<WeightedEdge>();
            wEdgeList.Add(wEdge);

            // Act

            // Assert
            CorridorGenerator corGen = new CorridorGenerator();
            Assert.True(corGen.edgeExists(wEdgeList, room1, room2));
        }

        [Test]
        public void Edge_exists_between_two_rooms_there_is_no_edge()
        {
            // Arrange
            List<Point> ptsRoom1 = new List<Point>();
            ptsRoom1.Add(new Point(10, 10));
            ptsRoom1.Add(new Point(10, 20));
            ptsRoom1.Add(new Point(20, 10));
            ptsRoom1.Add(new Point(20, 20));
            PolygonRoom room1 = new PolygonRoom(ptsRoom1);

            List<Point> ptsRoom2 = new List<Point>();
            ptsRoom2.Add(new Point(30, 30));
            ptsRoom2.Add(new Point(30, 40));
            ptsRoom2.Add(new Point(40, 30));
            ptsRoom2.Add(new Point(40, 40));
            PolygonRoom room2 = new PolygonRoom(ptsRoom2);

            List<Point> ptsRoom3 = new List<Point>();
            ptsRoom3.Add(new Point(0, 5));
            ptsRoom3.Add(new Point(5, 0));
            ptsRoom3.Add(new Point(0, 0));
            ptsRoom3.Add(new Point(5, 5));
            PolygonRoom room3 = new PolygonRoom(ptsRoom2);

            WeightedEdge wEdge = new WeightedEdge(room1, room3, 10f);
            List<WeightedEdge> wEdgeList = new List<WeightedEdge>();
            wEdgeList.Add(wEdge);

            // Act

            // Assert
            CorridorGenerator corGen = new CorridorGenerator();
            Assert.False(corGen.edgeExists(wEdgeList, room1, room2));
        }

        [Test]
        public void Connect_every_summit_every_summit_is_connected()
        {
            // Arrange
            Map testMap = new Map();
            CorridorGenerator corGen = new CorridorGenerator();

            // Act
            List<WeightedEdge> edges = corGen.connectEverySummit(testMap.Rooms);

            // Assert
            foreach (Room r1 in testMap.Rooms)
            {
                foreach (Room r2 in testMap.Rooms)
                {
                    if (r1 != r2)
                    {
                        Assert.True(corGen.edgeExists(edges, r1, r2));
                    }
                    else
                    {
                        Assert.False(corGen.edgeExists(edges, r1, r2));
                    }
                }
            }
        }

        [Test]
        public void Prim_Algorithm_Test()
        {
            // Arrange
            CircularRoom r1 = new CircularRoom();
            CircularRoom r2 = new CircularRoom();
            CircularRoom r3 = new CircularRoom();
            CircularRoom r4 = new CircularRoom();
            List<Room> listRooms = new List<Room>();
            listRooms.Add(r1);
            listRooms.Add(r2);
            listRooms.Add(r3);
            listRooms.Add(r4);

            WeightedEdge wE1 = new WeightedEdge(r1, r2, 10f);
            WeightedEdge wE2 = new WeightedEdge(r1, r3, 100f);
            WeightedEdge wE3 = new WeightedEdge(r2, r3, 15f);
            WeightedEdge wE4 = new WeightedEdge(r1, r4, 30f);
            WeightedEdge wE5 = new WeightedEdge(r2, r4, 70f);
            WeightedEdge wE6 = new WeightedEdge(r3, r4, 50f);
            List<WeightedEdge> wEdgeList = new List<WeightedEdge>();
            wEdgeList.Add(wE1);
            wEdgeList.Add(wE2);
            wEdgeList.Add(wE3);
            wEdgeList.Add(wE4);
            wEdgeList.Add(wE5);
            wEdgeList.Add(wE6);

            CorridorGenerator corGen = new CorridorGenerator();

            // Act
            List<Edge> listEdge = corGen.primAlgorithm(listRooms, wEdgeList);

            // Assert
            Assert.AreEqual(listEdge[0].Room1, r1);
            Assert.AreEqual(listEdge[0].Room2, r2);
            Assert.AreEqual(listEdge[1].Room1, r2);
            Assert.AreEqual(listEdge[1].Room2, r3);
            Assert.AreEqual(listEdge[2].Room1, r1);
            Assert.AreEqual(listEdge[2].Room2, r4);

        }

        [Test]
        public void draw_corridors_Test()
        {
            // Arrange
            Map testMap = new Map();
            CircularRoom rCenter = new CircularRoom();
            rCenter.Center = new Point(20, 20);
            CircularRoom rTopLeft = new CircularRoom();
            rTopLeft.Center = new Point(15, 15);
            CircularRoom rBotRight = new CircularRoom();
            rBotRight.Center = new Point(25, 25);

            for (int y = 0; y < testMap.Height; y++)
            {
                for (int x = 0; x < testMap.Width; x++)
                {
                    testMap.Grid[y, x] = null;
                }
            }
            testMap.Grid[20, 20] = rCenter;
            testMap.Grid[15, 15] = rTopLeft;
            testMap.Grid[25, 25] = rBotRight;

            List<Corridor> listCorridors = new List<Corridor>();
            listCorridors.Add(new Corridor(rCenter, rTopLeft));
            listCorridors.Add(new Corridor(rCenter, rBotRight));

            CorridorGenerator corGen = new CorridorGenerator();

            // Act
            corGen.drawCorridors(testMap, listCorridors);

            // Assert
            Assert.AreEqual(rTopLeft, testMap.Grid[15, 15]);
            for (int i = 19; i >= 15; i--)
            {
                Assert.AreEqual(listCorridors[0], testMap.Grid[i, 20]);
            }
            for (int i = 20; i > 15; i--)
            {
                Assert.AreEqual(listCorridors[0], testMap.Grid[15, i]);
            }
            Assert.AreEqual(rCenter, testMap.Grid[20, 20]);
            for (int i = 21; i <= 25; i++)
            {
                Assert.AreEqual(listCorridors[1], testMap.Grid[i, 20]);
            }
            for (int i = 20; i < 25; i++)
            {
                Assert.AreEqual(listCorridors[1], testMap.Grid[25, i]);
            }
            Assert.AreEqual(rBotRight, testMap.Grid[25, 25]);
        }
    }
}
