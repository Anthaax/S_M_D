﻿using NUnit.Framework;
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
            armory.DeleteHero();
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
            armory.DeleteHero();
            Assert.IsNull(armory.Hero);
        }
        [Test]
        public void PutAndDeleteAnHeroInBarAndGiveThemARelation()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Bar bar = ctx.PlayerInfo.GetBuilding(BuildingNameEnum.Bar) as Bar;
            bar.SetHeros(ctx.PlayerInfo.MyHeros.First(), ctx.PlayerInfo.MyHeros[1]);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First(), bar.Hero1);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[1], bar.Hero2);
            bar.CreateRelationHero();
            Assert.AreEqual(1,ctx.PlayerInfo.MyHeros.First().Relationship.Count);
            Assert.AreEqual(1,ctx.PlayerInfo.MyHeros[1].Relationship.Count);
            bar.DeleteHeros();
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
        [Test]
        public void BuyAnUnlockSpell()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Casern casern = ctx.PlayerInfo.GetBuilding( BuildingNameEnum.Casern ) as Casern;
            Assert.Throws<ArgumentException>( () => casern.BuySpellToHero( ctx.PlayerInfo.MyHeros.First().Spells.First() ) );
            casern.setHero( ctx.PlayerInfo.MyHeros.First() );
            Assert.NotNull( casern.Hero );
            Assert.Throws<ArgumentException>( () => casern.BuySpellToHero( casern.Hero.Spells.First() ) );
            casern.Hero.Spells.First().IsBuy = false;
            casern.BuySpellToHero( casern.Hero.Spells.First() );
            Assert.AreEqual( true, casern.Hero.Spells.First().IsBuy );
            Assert.AreEqual( 10000 - casern.Hero.Spells.First().Price, ctx.MoneyManager.Money );
        }
        [Test]
        public void UpgrateASpell()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Casern casern = ctx.PlayerInfo.GetBuilding( BuildingNameEnum.Casern ) as Casern;
            Assert.Throws<ArgumentException>( () => casern.UpgradeSpellToHero( ctx.PlayerInfo.MyHeros.First().Spells.First() ) );
            casern.setHero( ctx.PlayerInfo.MyHeros.First() );
            casern.Hero.Spells.First().IsBuy = false;
            casern.LevelUP();
            Assert.Throws<ArgumentException>( () => casern.UpgradeSpellToHero( casern.Hero.Spells.First() ) );
            casern.Hero.Spells.First().IsBuy = true;
            casern.UpgradeSpellToHero( casern.Hero.Spells.First() );
            Assert.AreEqual( 1, casern.Hero.Spells.First().Lvl );
            Assert.AreEqual( 10000 - (casern.Hero.Spells.First().Price + (1000 / (casern.Level + 1)) + (100 * casern.Hero.Spells.First().Lvl)), ctx.MoneyManager.Money );

        }
        [Test]
        public void SuppressASicknessFromAnHero()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Hospital hospital = ctx.PlayerInfo.GetBuilding( BuildingNameEnum.Hospital ) as Hospital;
            hospital.LevelUP();
            Assert.Throws<ArgumentException>( () => hospital.HealHero( new Diarrhea() ) );
            hospital.setHero( ctx.PlayerInfo.MyHeros.First() );
            Assert.Throws<ArgumentException>( () => hospital.HealHero( new Diarrhea() ) );
            ctx.PlayerInfo.MyHeros.First().GetSickness( new Diarrhea() );
            hospital.HealHero( hospital.Hero.Sicknesses.First());
            Assert.AreEqual( 0, hospital.Hero.Sicknesses.Count );
            Assert.AreEqual( 10000 - (1000/hospital.Level), ctx.MoneyManager.Money );
        }
        [Test]
        public void AddRelationBetweenTwoHero()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Hotel hotel = ctx.PlayerInfo.GetBuilding( BuildingNameEnum.Hotel ) as Hotel;
            hotel.LevelUP();
            Assert.Throws<ArgumentException>( () => hotel.CreateRelationHeroHero() );
            hotel.SetHeros( ctx.PlayerInfo.MyHeros[0], ctx.PlayerInfo.MyHeros[1] );
            hotel.CreateRelationHeroHero();
            Assert.AreEqual( 1, ctx.PlayerInfo.MyHeros[0].Relationship.Count );
            Assert.AreEqual( 1, ctx.PlayerInfo.MyHeros[1].Relationship.Count );
            Assert.Throws<ArgumentException>( () => hotel.CreateRelationHeroHero() );
            hotel.DeleteHeros();
            Assert.AreEqual( 10000 - (1000 / hotel.Level), ctx.MoneyManager.Money );
            Assert.IsNull( hotel.Hero1 );
            Assert.IsNull( hotel.Hero2 );
        }
        public void DeletePsyco()
        {
            GameContext ctx = GameContext.CreateNewGame();
            MentalHospital MH = ctx.PlayerInfo.GetBuilding( BuildingNameEnum.MentalHospital ) as MentalHospital;
            MH.LevelUP();
            Assert.Throws<ArgumentException>( () => MH.DeletePsychologyHero( new Agressivity() ) );
            MH.setHero( ctx.PlayerInfo.MyHeros[0] );
            Assert.Throws<ArgumentException>( () => MH.DeletePsychologyHero( new Agressivity() ) );
            ctx.PlayerInfo.MyHeros[0].GetPsycho( new Agressivity() );
            MH.DeletePsychologyHero( MH.Hero.Psycho.First() );
            Assert.AreEqual( 0, MH.Hero.Psycho.Count );
            Assert.AreEqual( 10000 - (1000 / MH.Level), ctx.MoneyManager.Money );

        }
    }
}
