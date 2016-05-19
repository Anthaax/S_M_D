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
            putItemInAHero(armory.Hero);
            armory.UpgrateItemOfAnHero(armory.Hero.Equipement[1]);
            Assert.AreEqual(1, armory.Hero.Equipement[1].Lvl);
            armory.deleteHero();
            Assert.IsNull(armory.Hero);
        }
        [Test]
        public void PutAndDeleteAnHeroInBarAndGiveThemARelation()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Bar bar = ctx.PlayerInfo.GetBuilding(BuildingName.Bar) as Bar;
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

        private void putItemInAHero(BaseHeros hero)
        {
            using (FileStream myFileStream = new FileStream("../../../S_M_D/Items/Armors.xml", FileMode.Open))
            {
                XmlSerializer reader = new XmlSerializer(typeof(List<BaseArmor>));
                List<BaseArmor> overview = (List<BaseArmor>)reader.Deserialize(myFileStream);
                hero.GetNewItem(overview.First());
                Assert.AreEqual(overview.First(), hero.Equipement[1]);
                Assert.AreEqual(hero.EffectCritChance, hero.CritChance += overview.First().CritChance);
                Assert.AreEqual(hero.EffectivAffectRes, hero.AffectRes += overview.First().AffectRes);
                Assert.AreEqual(hero.EffectivBleedingRes, hero.BleedingRes += overview.First().BleedingRes);
                Assert.AreEqual(hero.EffectivDamage, hero.Damage += overview.First().Damage);
                Assert.AreEqual(hero.EffectivDefense, hero.Defense += overview.First().Defense);
                Assert.AreEqual(hero.EffectivDodgeChance, hero.DodgeChance += overview.First().DodgeChance);
                Assert.AreEqual(hero.EffectivFireRes, hero.FireRes += overview.First().FireRes);
                Assert.AreEqual(hero.EffectivHitChance, hero.HitChance += overview.First().HitChance);
                Assert.AreEqual(hero.EffectivHPMax, hero.HPmax += overview.First().HP);
                Assert.AreEqual(hero.EffectivMagicRes, hero.MagicRes += overview.First().MagicRes);
                Assert.AreEqual(hero.EffectivManaMax, hero.ManaMax += overview.First().Mana);
                Assert.AreEqual(hero.EffectivPoisonRes, hero.PoisonRes += overview.First().PoisonRes);
                Assert.AreEqual(hero.EffectivSpeed, hero.Speed += overview.First().Speed);
                Assert.AreEqual(hero.EffectivWaterRes, hero.WaterRes += overview.First().WaterRes);
            }
        }
        private void UseRndMultipleTime(Random rnd, int nbTime)
        {
            for (int i = 0; i < nbTime; i++)
            {
                rnd.Next();
            }
        }
    }
}
