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
            Assert.AreEqual( 500, ctx.PlayerInfo.GetBuilding(BuildingNameEnum.Townhall).BuildingCost );
            Assert.AreEqual( 1, ctx.PlayerInfo.GetBuilding(BuildingNameEnum.Townhall).Level);
            Assert.AreEqual( "Townhall", ctx.PlayerInfo.GetBuilding(BuildingNameEnum.Townhall).Name.ToString());
        }
        [Test]
        public void CreationArmoryTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Assert.AreEqual( 600, ctx.PlayerInfo.GetBuilding(BuildingNameEnum.Armory).BuildingCost);
            Assert.AreEqual( 0, ctx.PlayerInfo.GetBuilding(BuildingNameEnum.Armory).Level);
            Assert.AreEqual( "Armory", ctx.PlayerInfo.GetBuilding(BuildingNameEnum.Armory).Name.ToString());
        }
        [Test]
        public void CreationBarTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Assert.AreEqual( 900, ctx.PlayerInfo.GetBuilding(BuildingNameEnum.Bar).BuildingCost);
            Assert.AreEqual( 0, ctx.PlayerInfo.GetBuilding(BuildingNameEnum.Bar).Level);
            Assert.AreEqual( "Bar", ctx.PlayerInfo.GetBuilding(BuildingNameEnum.Bar).Name.ToString());
        }
        [Test]
        public void CreationCaravanTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Assert.AreEqual( 500, ctx.PlayerInfo.GetBuilding(BuildingNameEnum.Caravan).BuildingCost);
            Assert.AreEqual( 1, ctx.PlayerInfo.GetBuilding(BuildingNameEnum.Caravan).Level);
            Assert.AreEqual( "Caravan", ctx.PlayerInfo.GetBuilding(BuildingNameEnum.Caravan).Name.ToString());
        }
        [Test]
        public void CreationCasernTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Assert.AreEqual( 400, ctx.PlayerInfo.GetBuilding(BuildingNameEnum.Casern).BuildingCost);
            Assert.AreEqual( 0, ctx.PlayerInfo.GetBuilding(BuildingNameEnum.Casern).Level);
            Assert.AreEqual( "Casern", ctx.PlayerInfo.GetBuilding(BuildingNameEnum.Casern).Name.ToString());
        }
        [Test]
        public void CreationCemeteryTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Assert.AreEqual( 0, ctx.PlayerInfo.GetBuilding(BuildingNameEnum.Cemetery).BuildingCost);
            Assert.AreEqual( 1, ctx.PlayerInfo.GetBuilding(BuildingNameEnum.Cemetery).Level);
            Assert.AreEqual( "Cemetery", ctx.PlayerInfo.GetBuilding(BuildingNameEnum.Cemetery).Name.ToString());
        }
        [Test]
        public void CreationHospitalTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Assert.AreEqual( 1500, ctx.PlayerInfo.GetBuilding(BuildingNameEnum.Hospital).BuildingCost);
            Assert.AreEqual( 0, ctx.PlayerInfo.GetBuilding(BuildingNameEnum.Hospital).Level);
            Assert.AreEqual( "Hospital", ctx.PlayerInfo.GetBuilding(BuildingNameEnum.Hospital).Name.ToString());
        }
        [Test]
        public void CreationHotelTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Assert.AreEqual( 1000, ctx.PlayerInfo.GetBuilding(BuildingNameEnum.Hotel).BuildingCost);
            Assert.AreEqual( 0, ctx.PlayerInfo.GetBuilding(BuildingNameEnum.Hotel).Level);
            Assert.AreEqual( "Hotel", ctx.PlayerInfo.GetBuilding(BuildingNameEnum.Hotel).Name.ToString());
        }
        [Test]
        public void CreationMentalHospitalTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Assert.AreEqual( 500, ctx.PlayerInfo.GetBuilding(BuildingNameEnum.MentalHospital).BuildingCost);
            Assert.AreEqual( 0, ctx.PlayerInfo.GetBuilding(BuildingNameEnum.MentalHospital).Level);
            Assert.AreEqual( "MentalHospital", ctx.PlayerInfo.GetBuilding(BuildingNameEnum.MentalHospital).Name.ToString());
        }
    }
}
