﻿using NUnit.Framework;
using S_M_D.Camp;
using S_M_D.Character;
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
        [Test]
        public void PutAndDeleteAnHeroInArmory()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find(HerosEnum.Warrior.ToString()).CreateHero();
            Armory armory = ctx.PlayerInfo.GetBuilding(BuildingName.Armory) as Armory;
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
            Bar bar = ctx.PlayerInfo.GetBuilding(BuildingName.Bar) as Bar;
            bar.setHero(ctx.PlayerInfo.MyHeros.First());
            bar.setHero(ctx.PlayerInfo.MyHeros[1]);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First(), bar.Hero1);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[1], bar.Hero2);
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
            Cemetery cemetery = ctx.PlayerInfo.GetBuilding(BuildingName.Cemetery) as Cemetery;
            ctx.HeroManager.Find(HerosEnum.Mage.ToString()).CreateHero();
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
    }
}
