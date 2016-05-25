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
using System.IO;
using System.Xml.Serialization;

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
            Assert.AreEqual(9, ctx.PlayerInfo.MyBuildings.Count());
        }
        [Test]
        public void UpgradeBuildingTest()
        {
            GameContext ctx = GameContext.CreateNewGame();

            Assert.AreEqual(1, ctx.PlayerInfo.GetBuilding(BuildingNameEnum.Caravan).Level);
            TownHall townhall = ctx.PlayerInfo.GetBuilding(BuildingNameEnum.Townhall) as TownHall;
            townhall.UpgradeBuilding(ctx.PlayerInfo.GetBuilding(BuildingNameEnum.Caravan));

            Assert.AreEqual(2, ctx.PlayerInfo.GetBuilding(BuildingNameEnum.Caravan).Level);
        }
        [Test]
        public void PutAndDeleteAnHeroInArmory()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Armory armory = ctx.PlayerInfo.GetBuilding(BuildingNameEnum.Armory) as Armory;
            armory.Hero = ctx.PlayerInfo.MyHeros.First();
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First(), armory.Hero);
            armory.deleteHero();
            Assert.IsNull(armory.Hero);
        }
        [Test]
        public void UseEffectAnHeroInArmory()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Armory armory = ctx.PlayerInfo.GetBuilding(BuildingNameEnum.Armory) as Armory;
            armory.Hero = ctx.PlayerInfo.MyHeros.First();
            armory.UpgrateItemOfAnHero(armory.Hero.Equipement[1]);
            armory.UpgrateItemOfAnHero(armory.Hero.Equipement[0]);
            armory.UpgrateItemOfAnHero(armory.Hero.Equipement[2]);
            Assert.AreEqual(1, armory.Hero.Equipement[1].Lvl);
            Assert.AreEqual(1, armory.Hero.Equipement[2].Lvl);
            Assert.AreEqual(1, armory.Hero.Equipement[0].Lvl);
            armory.deleteHero();
            Assert.IsNull(armory.Hero);
        }
        [Test]
        public void PutAndDeleteAnHeroInBarAndGiveThemARelation()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Bar bar = ctx.PlayerInfo.GetBuilding(BuildingNameEnum.Bar) as Bar;
            bar.setHeros(ctx.PlayerInfo.MyHeros.First(), ctx.PlayerInfo.MyHeros[1]);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First(), bar.Hero1);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[1], bar.Hero2);
            bar.CreateRelationHero();
            Assert.AreEqual(1,ctx.PlayerInfo.MyHeros.First().Relationship.Count);
            Assert.AreEqual(1,ctx.PlayerInfo.MyHeros[1].Relationship.Count);
            bar.deleteHeros();
            Assert.IsNull(bar.Hero1);
            Assert.IsNull(bar.Hero2);
        }
        /**
        *Cemetery
        */
        
        [Test]
        public void AddDeadHeroTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Cemetery cemetery = ctx.PlayerInfo.GetBuilding(BuildingNameEnum.Cemetery) as Cemetery;
            BaseHeros hero = ctx.PlayerInfo.MyHeros.First();
            hero.Die();
            Assert.AreEqual(1, cemetery.GetDeadHeros.Count());
        }
        /*
        *caravane
        */
        [Test]
        public void InitTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Caravan caravan = ctx.PlayerInfo.GetBuilding(BuildingNameEnum.Caravan) as Caravan;
            caravan.Initialized();
            Assert.AreEqual(caravan.MaxNewHero, caravan.HerosDispo.Count());
        }
        [Test]
        public void BuyHeroTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Caravan caravan = ctx.PlayerInfo.GetBuilding(BuildingNameEnum.Caravan) as Caravan;
            caravan.Initialized();
            caravan.BuyHero(caravan.HerosDispo.First());
            Assert.AreEqual(5, ctx.PlayerInfo.MyHeros.Count());
        }
    }
}
