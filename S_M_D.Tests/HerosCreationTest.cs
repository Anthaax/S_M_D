using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using S_M_D.Character;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace S_M_D.Tests
{
    [TestFixture]
    public class HerosCreationTest
    {
        [Test]
        public void CreationHeroAddIntoListTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find( HerosEnum.Warrior.ToString() ).CreateHero();
            Assert.IsNotEmpty( ctx.PlayerInfo.MyHeros );
            ctx.HeroManager.Find( HerosEnum.Paladin.ToString() ).CreateHero();
            Assert.AreEqual( 2, ctx.PlayerInfo.MyHeros.Count );
            ctx.HeroManager.Find( HerosEnum.Mage.ToString() ).CreateHero();
            Assert.AreEqual( 3, ctx.PlayerInfo.MyHeros.Count );
            ctx.HeroManager.Find( HerosEnum.Priest.ToString() ).CreateHero();
            Assert.AreEqual( 4, ctx.PlayerInfo.MyHeros.Count );
        }
        [Test]
        public void CantCreateHerosWhen16HerosInHerosList()
        {
            GameContext ctx = GameContext.CreateNewGame();
            FullList( ctx.HeroManager );
            Assert.Throws<InvalidOperationException>( () => ctx.HeroManager.Find( HerosEnum.Warrior.ToString() ).CreateHero());
            Assert.IsNotEmpty( ctx.PlayerInfo.MyHeros.First().Spells );
            Assert.AreEqual( "BasicAttack", ctx.PlayerInfo.MyHeros.First().Spells.First().Name );
        }
        [Test]
        public void CreationHeroClassNameTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            string name = ctx.HeroManager.Find( HerosEnum.Warrior.ToString() ).CreateHero().CharacterClassName;
            Assert.AreEqual(HerosEnum.Warrior.ToString(), name);
            name = ctx.HeroManager.Find( HerosEnum.Paladin.ToString() ).CreateHero().CharacterClassName;
            Assert.AreEqual(HerosEnum.Paladin.ToString(), name);
            name = ctx.HeroManager.Find( HerosEnum.Mage.ToString() ).CreateHero().CharacterClassName;
            Assert.AreEqual( HerosEnum.Mage.ToString(), name );
            name = ctx.HeroManager.Find( HerosEnum.Priest.ToString() ).CreateHero().CharacterClassName;
            Assert.AreEqual( HerosEnum.Priest.ToString(), name );
        }
        [Test]
        public void CreationHeroClassPrimaryInformationStatTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            int price = ctx.HeroManager.Find( HerosEnum.Paladin.ToString() ).Price;
            Assert.AreEqual(400, price);
            price = ctx.HeroManager.Find( HerosEnum.Warrior.ToString() ).Price;
            Assert.AreEqual( 400, price );
            ctx.HeroManager.Find( HerosEnum.Mage.ToString() ).CreateHero();
            Assert.AreEqual( 400, price );
            ctx.HeroManager.Find( HerosEnum.Priest.ToString() ).CreateHero();
            Assert.AreEqual(400, price);
        }
        [Test]
        public void CreationPaladinStatTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find( HerosEnum.Paladin.ToString() ).CreateHero();
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().CharacterClassName, "Paladin" );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Price, 400 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().AffectRes, 50 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().BleedingRes, 40 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().CritChance, 12 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Damage, 7 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Defense, 40 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().DodgeChance, 15 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Evilness, 0 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().FireRes, 20 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().HitChance, 50 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().HP, 40 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().HPmax, 40 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Lvl, 0 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().MagicRes, 30 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Mana, 30 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().ManaMax, 30 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().PoisonRes, 40 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Speed, 8 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().WaterRes, 20 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Xp, 0 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().XpMax, 100 );
        }
        [Test]
        public void CreationWarriorStatTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find( HerosEnum.Warrior.ToString() ).CreateHero();
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().CharacterClassName, "Warrior" );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Price, 400 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().AffectRes, 30 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().BleedingRes, 45 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().CritChance, 20 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Damage, 11 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Defense, 40 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().DodgeChance, 15 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Evilness, 0 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().FireRes, 20 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().HitChance, 60 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().HP, 50 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().HPmax, 50 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Lvl, 0 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().MagicRes, 20 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Mana, 20 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().ManaMax, 20 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().PoisonRes, 20 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Speed, 5 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().WaterRes, 20 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Xp, 0 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().XpMax, 100 );
        }

        [Test]
        public void CreationMageStatTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find(HerosEnum.Mage.ToString()).CreateHero();
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().CharacterClassName, "Mage");
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Price, 400);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().AffectRes, 20);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().BleedingRes, 20);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().CritChance, 6);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Damage, 4);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Defense, 10);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().DodgeChance, 8);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Evilness, 0);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().FireRes, 20);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().HitChance, 80);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().HP, 25);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().HPmax, 25);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Lvl, 0);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().MagicRes, 60);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Mana, 50);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().ManaMax, 50);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().PoisonRes, 20);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Speed, 10);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().WaterRes, 20);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Xp, 0);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().XpMax, 100);
        }

        [Test]
        public void CreationPriestStatTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find(HerosEnum.Priest.ToString()).CreateHero();
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().CharacterClassName, "Priest");
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Price, 400);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().AffectRes, 30);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().BleedingRes, 30);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().CritChance, 10);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Damage, 5);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Defense, 20);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().DodgeChance, 10);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Evilness, 0);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().FireRes, 30);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().HitChance, 60);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().HP, 30);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().HPmax, 30);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Lvl, 0);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().MagicRes, 30);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Mana, 40);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().ManaMax, 40);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().PoisonRes, 30);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Speed, 8);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().WaterRes, 30);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Xp, 0);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().XpMax, 100);
        }
        [Test]
        public void HerosSexTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            FullList(ctx.HeroManager);
            Random rnd = new Random(1);
            Assert.AreEqual(rnd.Next(2) == 0, ctx.PlayerInfo.MyHeros[0].IsMale);
            rnd.Next();
            Assert.AreEqual(rnd.Next(2) == 0, ctx.PlayerInfo.MyHeros[1].IsMale);
            rnd.Next();
            Assert.AreEqual( rnd.Next(2) == 0, ctx.PlayerInfo.MyHeros[2].IsMale);
            rnd.Next();
            Assert.AreEqual( rnd.Next(2) == 0, ctx.PlayerInfo.MyHeros[3].IsMale);
            rnd.Next();
            Assert.AreEqual( rnd.Next(2) == 0, ctx.PlayerInfo.MyHeros[4].IsMale);
            rnd.Next();
            Assert.AreEqual( rnd.Next(2) == 0, ctx.PlayerInfo.MyHeros[5].IsMale);
            rnd.Next();
            Assert.AreEqual( rnd.Next(2) == 0, ctx.PlayerInfo.MyHeros[6].IsMale);
            rnd.Next();
            Assert.AreEqual( rnd.Next(2) == 0, ctx.PlayerInfo.MyHeros[7].IsMale);
            rnd.Next();
            Assert.AreEqual( rnd.Next(2) == 0, ctx.PlayerInfo.MyHeros[8].IsMale);
            rnd.Next();
            Assert.AreEqual( rnd.Next(2) == 0, ctx.PlayerInfo.MyHeros[9].IsMale);
            rnd.Next();
            Assert.AreEqual( rnd.Next(2) == 0, ctx.PlayerInfo.MyHeros[10].IsMale);
            rnd.Next();
            Assert.AreEqual( rnd.Next(2) == 0, ctx.PlayerInfo.MyHeros[11].IsMale);
            rnd.Next();
            Assert.AreEqual( rnd.Next(2) == 0, ctx.PlayerInfo.MyHeros[12].IsMale);
            rnd.Next();
            Assert.AreEqual( rnd.Next(2) == 0, ctx.PlayerInfo.MyHeros[13].IsMale);
            rnd.Next();
            Assert.AreEqual( rnd.Next(2) == 0, ctx.PlayerInfo.MyHeros[14].IsMale);
            rnd.Next();
            Assert.AreEqual( rnd.Next(2) == 0, ctx.PlayerInfo.MyHeros[15].IsMale);
        }

        private void FullList(HerosManager heroManager)
        {
            heroManager.Find(HerosEnum.Warrior.ToString()).CreateHero();
            heroManager.Find( HerosEnum.Mage.ToString() ).CreateHero();
            heroManager.Find( HerosEnum.Paladin.ToString() ).CreateHero();
            heroManager.Find( HerosEnum.Priest.ToString() ).CreateHero();
            heroManager.Find(HerosEnum.Warrior.ToString()).CreateHero();
            heroManager.Find( HerosEnum.Mage.ToString() ).CreateHero();
            heroManager.Find( HerosEnum.Paladin.ToString() ).CreateHero();
            heroManager.Find( HerosEnum.Priest.ToString() ).CreateHero();
            heroManager.Find(HerosEnum.Warrior.ToString()).CreateHero();
            heroManager.Find( HerosEnum.Mage.ToString() ).CreateHero();
            heroManager.Find( HerosEnum.Paladin.ToString() ).CreateHero();
            heroManager.Find( HerosEnum.Priest.ToString() ).CreateHero();
            heroManager.Find(HerosEnum.Warrior.ToString()).CreateHero();
            heroManager.Find( HerosEnum.Mage.ToString() ).CreateHero();
            heroManager.Find( HerosEnum.Paladin.ToString() ).CreateHero();
            heroManager.Find( HerosEnum.Priest.ToString() ).CreateHero();
        }



    }
}
