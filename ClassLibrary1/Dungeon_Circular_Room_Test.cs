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
    public class Dungeon_Circular_Room_Test
    {
        [Test]
        public void Point_Is_Inside_Room_Return_True_When_Input_Point_Is_In_The_Room()
        {
            //Arrange
            CircularRoom testRoom = new CircularRoom();
            testRoom.Init(50, 50);
            Point testPoint = new Point(testRoom.Center.X - 1, testRoom.Center.Y);

            //Act

            //Assert
            Assert.AreEqual(true, testRoom.pointIsInsideRoom(testPoint.X, testPoint.Y), testRoom.Center.X + ", " + testRoom.Center.Y);
        }

        [Test]
        public void Init_Place_Center_within_Map_Border()
        {
            //Arrange
            Map testMap = new Map();
            Room testRoom;
            testRoom = new CircularRoom();

            //Act
            testRoom.Init(testMap.Width, testMap.Height);

            //Assert
            Assert.Less(testRoom.Center.X, testMap.Width, "Map width : " + testMap.Width);
            Assert.Less(testRoom.Center.Y, testMap.Height, "Map height : " + testMap.Height);
            Assert.GreaterOrEqual(testRoom.Center.X, 0);
            Assert.GreaterOrEqual(testRoom.Center.Y, 0);
        }

        [Test]
        public void Init_Add_Center_to_Path()
        {

        }
    }
}
