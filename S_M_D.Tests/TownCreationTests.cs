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
            Assert.AreEqual( 500, ctx.PlayerInfo.GetBuilding(BuildingName.Townhall).BuildingCost );
            Assert.AreEqual( 1, ctx.PlayerInfo.GetBuilding(BuildingName.Townhall).Level);
            Assert.AreEqual( "Townhall", ctx.PlayerInfo.GetBuilding(BuildingName.Townhall).Name.ToString());
        }
        [Test]
        public void CreationArmoryTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Assert.AreEqual( 600, ctx.PlayerInfo.GetBuilding(BuildingName.Armory).BuildingCost);
            Assert.AreEqual( 0, ctx.PlayerInfo.GetBuilding(BuildingName.Armory).Level);
            Assert.AreEqual( "Armory", ctx.PlayerInfo.GetBuilding(BuildingName.Armory).Name.ToString());
        }
        [Test]
        public void CreationBarTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Assert.AreEqual( 900, ctx.PlayerInfo.GetBuilding(BuildingName.Bar).BuildingCost);
            Assert.AreEqual( 0, ctx.PlayerInfo.GetBuilding(BuildingName.Bar).Level);
            Assert.AreEqual( "Bar", ctx.PlayerInfo.GetBuilding(BuildingName.Bar).Name.ToString());
        }
        [Test]
        public void CreationCaravanTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Assert.AreEqual( 500, ctx.PlayerInfo.GetBuilding(BuildingName.Caravan).BuildingCost);
            Assert.AreEqual( 1, ctx.PlayerInfo.GetBuilding(BuildingName.Caravan).Level);
            Assert.AreEqual( "Caravan", ctx.PlayerInfo.GetBuilding(BuildingName.Caravan).Name.ToString());
        }
        [Test]
        public void CreationCasernTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Assert.AreEqual( 400, ctx.PlayerInfo.GetBuilding(BuildingName.Casern).BuildingCost);
            Assert.AreEqual( 0, ctx.PlayerInfo.GetBuilding(BuildingName.Casern).Level);
            Assert.AreEqual( "Casern", ctx.PlayerInfo.GetBuilding(BuildingName.Casern).Name.ToString());
        }
        [Test]
        public void CreationCemeteryTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Assert.AreEqual( 0, ctx.PlayerInfo.GetBuilding(BuildingName.Cemetery).BuildingCost);
            Assert.AreEqual( 1, ctx.PlayerInfo.GetBuilding(BuildingName.Cemetery).Level);
            Assert.AreEqual( "Cemetery", ctx.PlayerInfo.GetBuilding(BuildingName.Cemetery).Name.ToString());
        }
        [Test]
        public void CreationHospitalTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Assert.AreEqual( 1500, ctx.PlayerInfo.GetBuilding(BuildingName.Hospital).BuildingCost);
            Assert.AreEqual( 0, ctx.PlayerInfo.GetBuilding(BuildingName.Hospital).Level);
            Assert.AreEqual( "Hospital", ctx.PlayerInfo.GetBuilding(BuildingName.Hospital).Name.ToString());
        }
        [Test]
        public void CreationHotelTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Assert.AreEqual( 1000, ctx.PlayerInfo.GetBuilding(BuildingName.Hotel).BuildingCost);
            Assert.AreEqual( 0, ctx.PlayerInfo.GetBuilding(BuildingName.Hotel).Level);
            Assert.AreEqual( "Hotel", ctx.PlayerInfo.GetBuilding(BuildingName.Hotel).Name.ToString());
        }
        [Test]
        public void CreationMentalHospitalTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Assert.AreEqual( 500, ctx.PlayerInfo.GetBuilding(BuildingName.MentalHospital).BuildingCost);
            Assert.AreEqual( 0, ctx.PlayerInfo.GetBuilding(BuildingName.MentalHospital).Level);
            Assert.AreEqual( "MentalHospital", ctx.PlayerInfo.GetBuilding(BuildingName.MentalHospital).Name.ToString());
        }
    }
}
