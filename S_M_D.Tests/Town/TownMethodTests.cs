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

            Assert.AreEqual(1, ctx.PlayerInfo.GetBuilding(BuildingName.Caravan).Level);
            TownHall townhall = ctx.PlayerInfo.GetBuilding(BuildingName.Townhall) as TownHall;
            townhall.UpgradeBuilding(ctx.PlayerInfo.GetBuilding(BuildingName.Caravan));

            Assert.AreEqual(2, ctx.PlayerInfo.GetBuilding(BuildingName.Caravan).Level);
        }
        //ARMORY
        [Test]
        public void PutAndDeleteAnHeroInArmory()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Armory armory = ctx.PlayerInfo.GetBuilding(BuildingName.Armory) as Armory;
            armory.Hero = ctx.PlayerInfo.MyHeros.First();
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First(), armory.Hero);
            armory.deleteHero();
            Assert.IsNull(armory.Hero);
        }
        [Test]
        public void UseEffectAnHeroInArmory()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Armory armory = ctx.PlayerInfo.GetBuilding(BuildingName.Armory) as Armory;
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
        //BAR
        [Test]
        public void PutAndDeleteAnHeroInBarAndGiveThemARelation()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Bar bar = ctx.PlayerInfo.GetBuilding(BuildingName.Bar) as Bar;
            //bar.setHeros(ctx.PlayerInfo.MyHeros.First(), ctx.PlayerInfo.MyHeros[1]);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First(), bar.Hero1);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[1], bar.Hero2);
            bar.CreateRelationHero();
            Assert.AreEqual(1,ctx.PlayerInfo.MyHeros.First().Relationship.Count);
            Assert.AreEqual(1,ctx.PlayerInfo.MyHeros[1].Relationship.Count);
            bar.deleteHeros();
            Assert.IsNull(bar.Hero1);
            Assert.IsNull(bar.Hero2);
        }
        //Hotel
        [Test]
        public void PutAndDeleteAnHeroInHotelAndGiveThemARelation()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find(HerosEnum.Warrior.ToString()).CreateHero();
            ctx.HeroManager.Find(HerosEnum.Mage.ToString()).CreateHero();
            Hotel h = ctx.PlayerInfo.GetBuilding(BuildingName.Hotel) as Hotel;
            //h.setHeros(ctx.PlayerInfo.MyHeros.First(), ctx.PlayerInfo.MyHeros[1]);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First(), h.Hero1);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[1], h.Hero2);
            h.CreateRelationHero();
            Assert.AreEqual(1, ctx.PlayerInfo.MyHeros.First().Relationship.Count);
            Assert.AreEqual(1, ctx.PlayerInfo.MyHeros[1].Relationship.Count);
            h.deleteHeros();
            Assert.IsNull(h.Hero1);
            Assert.IsNull(h.Hero2);
        }
        //Caserne
        [Test]
        public void PutAndDeleteAnHeroInCasern()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find(HerosEnum.Warrior.ToString()).CreateHero();
            Casern casern = ctx.PlayerInfo.GetBuilding(BuildingName.Casern) as Casern;
            casern.Hero = ctx.PlayerInfo.MyHeros.First();
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First(), casern.Hero);
            casern.deleteHero();
            Assert.IsNull(casern.Hero);
        }
        //Hospital
        [Test]
        public void PutAndDeleteAnHeroInHospital()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find(HerosEnum.Warrior.ToString()).CreateHero();
            Hospital h = ctx.PlayerInfo.GetBuilding(BuildingName.Hospital) as Hospital;
            h.Hero = ctx.PlayerInfo.MyHeros.First();
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First(), h.Hero);
            h.deleteHero();
            Assert.IsNull(h.Hero);
        }
        //MentalHospital
        [Test]
        public void PutAndDeleteAnHeroInMentalHospital()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find(HerosEnum.Warrior.ToString()).CreateHero();
            MentalHospital h = ctx.PlayerInfo.GetBuilding(BuildingName.MentalHospital) as MentalHospital;
            h.Hero = ctx.PlayerInfo.MyHeros.First();
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First(), h.Hero);
            h.deleteHero();
            Assert.IsNull(h.Hero);
        }
        /**
        *Cemetery
        */

        [Test]
        public void AddDeadHeroTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Cemetery cemetery = ctx.PlayerInfo.GetBuilding(BuildingName.Cemetery) as Cemetery;
            BaseHeros hero = ctx.PlayerInfo.MyHeros.First();
            cemetery.AddDeadHero(hero);
            Assert.AreEqual(1, cemetery.GetDeadHeros.Count());
        }
        /*
        *caravane
        */
        [Test]
        public void InitTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Caravan caravan = ctx.PlayerInfo.GetBuilding(BuildingName.Caravan) as Caravan;
            caravan.Initialized();
            Assert.AreEqual(4, caravan.HerosDispo.Count());
        }
        [Test]
        public void BuyHeroTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Caravan caravan = ctx.PlayerInfo.GetBuilding(BuildingName.Caravan) as Caravan;
            caravan.Initialized();
            caravan.BuyHero(caravan.HerosDispo.First());
            Assert.AreEqual(5, ctx.PlayerInfo.MyHeros.Count());
        }
    }
}
