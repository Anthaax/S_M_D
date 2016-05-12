using NUnit.Framework;
using S_M_D.Camp;
using S_M_D.Camp.Class;
using S_M_D.Camp.ClassConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_M_D.Tests
{
    [TestFixture]
    public class TownCreationTests
    {
        [Test]
        public void CreationTownHallTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.BuildingManager.Find(BuildingName.Townhall).CreateBuilding();
            Assert.AreEqual( 500, ctx.PlayerInfo.MyBuildings.First().BuildingCost );
            Assert.AreEqual( 1, ctx.PlayerInfo.MyBuildings.First().Level);
            Assert.AreEqual( "Townhall", ctx.PlayerInfo.MyBuildings.First().Name.ToString());
        }
        [Test]
        public void CreationArmoryTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.BuildingManager.Find(BuildingName.Armory).CreateBuilding();
            Assert.AreEqual( 600, ctx.PlayerInfo.MyBuildings.First().BuildingCost);
            Assert.AreEqual( 0, ctx.PlayerInfo.MyBuildings.First().Level);
            Assert.AreEqual( "Armory", ctx.PlayerInfo.MyBuildings.First().Name.ToString());
        }
        [Test]
        public void CreationBarTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.BuildingManager.Find(BuildingName.Bar).CreateBuilding();
            Assert.AreEqual( 900, ctx.PlayerInfo.MyBuildings.First().BuildingCost);
            Assert.AreEqual( 0, ctx.PlayerInfo.MyBuildings.First().Level);
            Assert.AreEqual( "Bar", ctx.PlayerInfo.MyBuildings.First().Name.ToString());
        }
        [Test]
        public void CreationCaravanTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.BuildingManager.Find(BuildingName.Caravan).CreateBuilding();
            Assert.AreEqual( 500, ctx.PlayerInfo.MyBuildings.First().BuildingCost);
            Assert.AreEqual( 1, ctx.PlayerInfo.MyBuildings.First().Level);
            Assert.AreEqual( "Caravan", ctx.PlayerInfo.MyBuildings.First().Name.ToString());
        }
        [Test]
        public void CreationCasernTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.BuildingManager.Find(BuildingName.Casern).CreateBuilding();
            Assert.AreEqual( 400, ctx.PlayerInfo.MyBuildings.First().BuildingCost);
            Assert.AreEqual( 0, ctx.PlayerInfo.MyBuildings.First().Level);
            Assert.AreEqual( "Casern", ctx.PlayerInfo.MyBuildings.First().Name.ToString());
        }
        [Test]
        public void CreationCemeteryTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.BuildingManager.Find(BuildingName.Cemetery).CreateBuilding();
            Assert.AreEqual( 0, ctx.PlayerInfo.MyBuildings.First().BuildingCost);
            Assert.AreEqual( 1, ctx.PlayerInfo.MyBuildings.First().Level);
            Assert.AreEqual( "Cemetery", ctx.PlayerInfo.MyBuildings.First().Name.ToString());
        }
        [Test]
        public void CreationHospitalTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.BuildingManager.Find(BuildingName.Hospital).CreateBuilding();
            Assert.AreEqual( 1500, ctx.PlayerInfo.MyBuildings.First().BuildingCost);
            Assert.AreEqual( 0, ctx.PlayerInfo.MyBuildings.First().Level);
            Assert.AreEqual( "Hospital", ctx.PlayerInfo.MyBuildings.First().Name.ToString());
        }
        [Test]
        public void CreationHotelTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.BuildingManager.Find(BuildingName.Hotel).CreateBuilding();
            Assert.AreEqual( 1000, ctx.PlayerInfo.MyBuildings.First().BuildingCost);
            Assert.AreEqual( 0, ctx.PlayerInfo.MyBuildings.First().Level);
            Assert.AreEqual( "Hotel", ctx.PlayerInfo.MyBuildings.First().Name.ToString());
        }
        [Test]
        public void CreationMentalHospitalTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.BuildingManager.Find(BuildingName.MentalHospital).CreateBuilding();
            Assert.AreEqual( 500, ctx.PlayerInfo.MyBuildings.First().BuildingCost);
            Assert.AreEqual( 0, ctx.PlayerInfo.MyBuildings.First().Level);
            Assert.AreEqual( "MentalHospital", ctx.PlayerInfo.MyBuildings.First().Name.ToString());
        }
    }
}
