using NUnit.Framework;
using S_M_D.Camp;
using S_M_D.Character;
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
        [Test]
        public void PutAndDeleteAnHeroInArmory()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find(HerosEnum.Warrior.ToString()).CreateHero();
            ctx.BuildingManager.Find(BuildingName.Townhall).CreateBuilding();
            ctx.BuildingManager.Find(BuildingName.Armory).CreateBuilding();
            Armory armory = ctx.PlayerInfo.MyBuildings[1] as Armory;
            armory.SetHero(ctx.PlayerInfo.MyHeros.First());
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First(), armory.Hero);
            armory.deleteHero();
            Assert.IsNull(armory.Hero);
        }
        [Test]
        public void PutAndDeleteAnHeroInBar()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find(HerosEnum.Warrior.ToString()).CreateHero();
            ctx.HeroManager.Find(HerosEnum.Mage.ToString()).CreateHero();
            ctx.BuildingManager.Find(BuildingName.Bar).CreateBuilding();
            Bar bar = ctx.PlayerInfo.MyBuildings[0] as Bar;
            bar.setHero(ctx.PlayerInfo.MyHeros.First());
            bar.setHero(ctx.PlayerInfo.MyHeros[1]);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First(), bar.Hero1);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[1], bar.Hero2);
            bar.deleteHeros();
            Assert.IsNull(bar.Hero1);
            Assert.IsNull(bar.Hero2);
        }
    }
}
