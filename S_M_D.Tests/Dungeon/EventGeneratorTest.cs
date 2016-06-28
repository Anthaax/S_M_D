using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using S_M_D.Dungeon;
using S_M_D.Character;

namespace S_M_D.Tests.Dungeon
{
    [TestFixture]
    class EventGeneratorTest
    {
        [Test]
        public void FillChest_Return_A_BaseItem()
        {
            //Arrange
            EventGenerator testEventGen = new EventGenerator( );
            RectangularRoom testRoom = new RectangularRoom( );
            Map testMap = new Map(GameContext.CreateNewGame());

            //Act
            testEventGen.AttachChestEvent( testRoom );
            int monsterNb = (int)((float)(testMap.Rooms.Count + 1) * (60f / 100f));
            testMap.Rooms.Insert(monsterNb, testRoom );
            testEventGen.Generate( testMap );

            //Assert

            Assert.IsNotEmpty( testRoom.events );
            Assert.IsNotEmpty( testRoom.chest );
            Assert.IsInstanceOf<BaseItem>( testRoom.chest[ 0 ] );
        }
    }
}
