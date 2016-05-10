using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using S_M_D.Character;

namespace S_M_D.Tests
{
    [TestFixture]
    public class HerosCreationTest
    {
        [Test]
        public void CreationHeroAddIntoListTest()
        {
            List<BaseHeros> allHeros = new List<BaseHeros>();
            HerosManager h = new HerosManager( allHeros );
            h.Find( HerosEnum.Warrior.ToString() ).CreateHero();
            Assert.IsNotEmpty( allHeros );
            h.Find( HerosEnum.Paladin.ToString() ).CreateHero();
            Assert.AreEqual( 2, allHeros.Count );
        }
        [Test]
        public void CantCreateHerosWhen16HerosInHerosList()
        {
            List<BaseHeros> allHeros = new List<BaseHeros>();
            HerosManager heroManager = new HerosManager( allHeros );
            FullList( heroManager );
            Assert.Throws<InvalidOperationException>( () => heroManager.Find( HerosEnum.Warrior.ToString() ).CreateHero());
            Assert.IsNotEmpty( allHeros.First().Spells );
            Assert.AreEqual( "BasicAttack", allHeros.First().Spells.First().Name );
        }
        [Test]
        public void CreationHeroClassNameTest()
        {
            List<BaseHeros> allHeros = new List<BaseHeros>();
            HerosManager h = new HerosManager( allHeros );
            string name = h.Find( HerosEnum.Warrior.ToString() ).CreateHero().CharacterClassName;
            Assert.AreEqual( HerosEnum.Warrior.ToString(), name );
            name = h.Find( HerosEnum.Paladin.ToString() ).CreateHero().CharacterClassName;
            Assert.AreEqual( HerosEnum.Paladin.ToString(), name );
        }
        [Test]
        public void CreationHeroClassPrimaryInformationStatTest()
        {
            List<BaseHeros> allHeros = new List<BaseHeros>();
            HerosManager h = new HerosManager( allHeros );
            string name = h.Find( HerosEnum.Warrior.ToString() ).CharacterName;
            Assert.AreEqual( "George", name );
            name = h.Find( HerosEnum.Paladin.ToString() ).CharacterName;
            Assert.AreEqual( "George", name );
            int price = h.Find( HerosEnum.Paladin.ToString() ).Price;
            Assert.AreEqual( 400, price );
            price = h.Find( HerosEnum.Warrior.ToString() ).Price;
            Assert.AreEqual( 400, price );
        }
        [Test]
        public void CreationPaladinStatTest()
        {
            List<BaseHeros> allHeros = new List<BaseHeros>();
            HerosManager h = new HerosManager( allHeros );
            h.Find( HerosEnum.Paladin.ToString() ).CreateHero();
            Assert.AreEqual( allHeros.First().CharacterClassName, "Paladin" );
            Assert.AreEqual( allHeros.First().CharacterName, "George" );
            Assert.AreEqual( allHeros.First().Price, 400 );
            Assert.AreEqual( allHeros.First().AffectRes, 50 );
            Assert.AreEqual( allHeros.First().BleedingRes, 40 );
            Assert.AreEqual( allHeros.First().CritChance, 12 );
            Assert.AreEqual( allHeros.First().Damage, 7 );
            Assert.AreEqual( allHeros.First().Defense, 40 );
            Assert.AreEqual( allHeros.First().DodgeChance, 15 );
            Assert.AreEqual( allHeros.First().Evilness, 0 );
            Assert.AreEqual( allHeros.First().FireRes, 20 );
            Assert.AreEqual( allHeros.First().HitChance, 50 );
            Assert.AreEqual( allHeros.First().HP, 40 );
            Assert.AreEqual( allHeros.First().HPmax, 40 );
            Assert.AreEqual( allHeros.First().Lvl, 0 );
            Assert.AreEqual( allHeros.First().MagicRes, 30 );
            Assert.AreEqual( allHeros.First().Mana, 30 );
            Assert.AreEqual( allHeros.First().ManaMax, 30 );
            Assert.AreEqual( allHeros.First().PoisonRes, 40 );
            Assert.AreEqual( allHeros.First().Speed, 8 );
            Assert.AreEqual( allHeros.First().WaterRes, 20 );
            Assert.AreEqual( allHeros.First().Xp, 0 );
            Assert.AreEqual( allHeros.First().XpMax, 100 );
        }
        [Test]
        public void CreationWarriorStatTest()
        {
            List<BaseHeros> allHeros = new List<BaseHeros>();
            HerosManager h = new HerosManager( allHeros );
            h.Find( HerosEnum.Warrior.ToString() ).CreateHero();
            Assert.AreEqual( allHeros.First().CharacterClassName, "Warrior" );
            Assert.AreEqual( allHeros.First().CharacterName, "George" );
            Assert.AreEqual( allHeros.First().Price, 400 );
            Assert.AreEqual( allHeros.First().AffectRes, 30 );
            Assert.AreEqual( allHeros.First().BleedingRes, 45 );
            Assert.AreEqual( allHeros.First().CritChance, 20 );
            Assert.AreEqual( allHeros.First().Damage, 11 );
            Assert.AreEqual( allHeros.First().Defense, 40 );
            Assert.AreEqual( allHeros.First().DodgeChance, 15 );
            Assert.AreEqual( allHeros.First().Evilness, 0 );
            Assert.AreEqual( allHeros.First().FireRes, 20 );
            Assert.AreEqual( allHeros.First().HitChance, 60 );
            Assert.AreEqual( allHeros.First().HP, 50 );
            Assert.AreEqual( allHeros.First().HPmax, 50 );
            Assert.AreEqual( allHeros.First().Lvl, 0 );
            Assert.AreEqual( allHeros.First().MagicRes, 20 );
            Assert.AreEqual( allHeros.First().Mana, 20 );
            Assert.AreEqual( allHeros.First().ManaMax, 20 );
            Assert.AreEqual( allHeros.First().PoisonRes, 20 );
            Assert.AreEqual( allHeros.First().Speed, 5 );
            Assert.AreEqual( allHeros.First().WaterRes, 20 );
            Assert.AreEqual( allHeros.First().Xp, 0 );
            Assert.AreEqual( allHeros.First().XpMax, 100 );
        }
        [Test]
        public void HerosWarriorSexTest()
        {
            List<BaseHeros> allHeros = new List<BaseHeros>();
            HerosManager h = new HerosManager( allHeros );
            Random rnd = new Random( 1 );
            h.Find( HerosEnum.Warrior.ToString() ).CreateHero();
            Assert.AreEqual( allHeros.First().IsMale, rnd.Next( 2 ) == 0 );
        }
        [Test]
        public void HerosPaladinSexTest()
        {
            List<BaseHeros> allHeros = new List<BaseHeros>();
            HerosManager h = new HerosManager( allHeros );
            Random rnd = new Random( 1 );
            h.Find( HerosEnum.Paladin.ToString() ).CreateHero();
            Assert.AreEqual( allHeros.First().IsMale, rnd.Next( 2 ) == 0 );
        }
        [Test]
        public void SpellWarriorTest()
        {
            List<BaseHeros> allHeros = new List<BaseHeros>();
            HerosManager heroManager = new HerosManager( allHeros );
            heroManager.Find( HerosEnum.Warrior.ToString() ).CreateHero();
            Assert.IsNotEmpty( allHeros.First().Spells );
            Assert.AreEqual( "BasicAttack", allHeros.First().Spells.First().Name );
        }

        private void FullList(HerosManager heroManager)
        {
            heroManager.Find( HerosEnum.Warrior.ToString() ).CreateHero();
            heroManager.Find( HerosEnum.Warrior.ToString() ).CreateHero();
            heroManager.Find( HerosEnum.Warrior.ToString() ).CreateHero();
            heroManager.Find( HerosEnum.Warrior.ToString() ).CreateHero();
            heroManager.Find( HerosEnum.Warrior.ToString() ).CreateHero();
            heroManager.Find( HerosEnum.Warrior.ToString() ).CreateHero();
            heroManager.Find( HerosEnum.Warrior.ToString() ).CreateHero();
            heroManager.Find( HerosEnum.Warrior.ToString() ).CreateHero();
            heroManager.Find( HerosEnum.Warrior.ToString() ).CreateHero();
            heroManager.Find( HerosEnum.Warrior.ToString() ).CreateHero();
            heroManager.Find( HerosEnum.Warrior.ToString() ).CreateHero();
            heroManager.Find( HerosEnum.Warrior.ToString() ).CreateHero();
            heroManager.Find( HerosEnum.Warrior.ToString() ).CreateHero();
            heroManager.Find( HerosEnum.Warrior.ToString() ).CreateHero();
            heroManager.Find( HerosEnum.Warrior.ToString() ).CreateHero();
            heroManager.Find( HerosEnum.Warrior.ToString() ).CreateHero();
        }
    }
}
