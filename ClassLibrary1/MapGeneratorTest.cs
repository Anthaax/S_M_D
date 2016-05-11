﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using S_M_D.Dungeon;

namespace DungeonTest
{
    [TestFixture]
    class MapGeneratorTest
    {

        [Test]
        public void GenerateRoom_Put_Rooms_On_The_Grid()
        {
            //Arrange
            Map testMap = new Map();

            //Act           

            bool roomDetected = false;

            for(int x = 0; x < testMap.Width; x++)
            {
                for( int y = 0; y < testMap.Height; y++)
                {
                    if(testMap.Grid[x,y] is Room)
                    {
                        roomDetected = true;
                    }

                }
            }

            //Assert
            Assert.IsTrue(roomDetected);
            
        }

        [Test]
        public void Add_Neighbor_Work_As_Expected()
        {
            //Arrange

            Room testRoom1 = new CircularRoom();
            Room testRoom2 = new PolygonRoom();

            MapGenerator testMapGen = new MapGenerator();

            //Act

            testMapGen.addNeighbor(testRoom1, testRoom2);

            //Assert
            Assert.AreEqual(testRoom2, testRoom1.Neighbor[0], "testRoom1 Neighbor actual value : " + testRoom1.Neighbor[0].ToString());
            Assert.AreEqual(testRoom1, testRoom2.Neighbor[0], "testRoom2 Neighbor actual value : " + testRoom2.Neighbor[0].ToString());
        }

    }
}
