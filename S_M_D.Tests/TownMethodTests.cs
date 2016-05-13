using NUnit.Framework;
using S_M_D.Camp;
using S_M_D.Camp.Class;
using S_M_D.Camp.ClassConfig;
using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_M_D.Tests
{
    [TestFixture]
    public class TownMethodTests
    {
        /*
        TownHall
        */
        [Test]
        public void InitialisationBuildingTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.BuildingManager.Find(BuildingName.Townhall).CreateBuilding();
            ctx.BuildingManager.Find(BuildingName.Cemetery).CreateBuilding();
            ctx.BuildingManager.Find(BuildingName.Caravan).CreateBuilding();
            Assert.AreEqual(3, ctx.PlayerInfo.MyBuildings.Count());
        }
        [Test]
        public void UpgradeBuildingTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.BuildingManager.Find(BuildingName.Townhall).CreateBuilding();
            ctx.BuildingManager.Find(BuildingName.Caravan).CreateBuilding();
            TownHall townhall = ctx.PlayerInfo.GetBuilding(BuildingName.Townhall) as TownHall;
            Caravan caravan = ctx.PlayerInfo.GetBuilding(BuildingName.Caravan) as Caravan;

            Assert.AreEqual(1, caravan.Level);
            townhall.UpgradeBuilding(caravan);

            Assert.AreEqual(2,caravan.Level);

            Caravan caravan2 = ctx.PlayerInfo.GetBuilding(BuildingName.Caravan) as Caravan;
            Assert.AreEqual(2, caravan.Level);

        }
        /**
        *Cemetery
        */
        /*
        [Test]
        public void AddDeadHeroTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.BuildingManager.Find(BuildingName.Cemetery).CreateBuilding();
            Cemetery cemetery = ctx.PlayerInfo.GetBuilding(BuildingName.Cemetery) as Cemetery;
            ctx.HeroManager.Find(HerosEnum.Mage.ToString()).CreateHero();
            BaseHeros hero = ctx.PlayerInfo.MyHeros.First();
            cemetery.AddDeadHero(hero);
            Assert.AreEqual(1, cemetery.GetDeadHeros().Count());
        }
        */
    }
}
