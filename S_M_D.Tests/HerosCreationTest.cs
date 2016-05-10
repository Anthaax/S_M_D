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
            List<BaseHeros> b = new List<BaseHeros>();
            HerosManager h = new HerosManager( b );
            h.Find( HerosEnum.Warrior.ToString() ).CreateHero();
            Assert.IsNotEmpty( b );
            h.Find( HerosEnum.Paladin.ToString() ).CreateHero();
            Assert.AreEqual( 2, b.Count );
        }
        [Test]
        public void CreationHeroClassNameTest()
        {
            List<BaseHeros> b = new List<BaseHeros>();
            HerosManager h = new HerosManager( b );
            string name = h.Find( HerosEnum.Warrior.ToString() ).CreateHero().CharacterClassName;
            Assert.AreEqual( HerosEnum.Warrior.ToString(), name );
            name = h.Find( HerosEnum.Paladin.ToString() ).CreateHero().CharacterClassName;
            Assert.AreEqual( HerosEnum.Paladin.ToString(), name );
        }
        [Test]
        public void CreationHeroClassPrimaryInformationStatTest()
        {
            List<BaseHeros> b = new List<BaseHeros>();
            HerosManager h = new HerosManager( b );
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
            List<BaseHeros> b = new List<BaseHeros>();
            HerosManager h = new HerosManager( b );
            h.Find( HerosEnum.Paladin.ToString() ).CreateHero();
            Assert.AreEqual( b.First().CharacterClassName, "Paladin" );
            Assert.AreEqual( b.First().CharacterName, "George" );
            Assert.AreEqual( b.First().Price, 400 );
            Assert.AreEqual( b.First().AffectRes, 50 );
            Assert.AreEqual( b.First().BleedingRes, 40 );
            Assert.AreEqual( b.First().CritChance, 12 );
            Assert.AreEqual( b.First().Damage, 7 );
            Assert.AreEqual( b.First().Defense, 40 );
            Assert.AreEqual( b.First().DodgeChance, 15 );
            Assert.AreEqual( b.First().Evilness, 0 );
            Assert.AreEqual( b.First().FireRes, 20 );
            Assert.AreEqual( b.First().HitChance, 50 );
            Assert.AreEqual( b.First().HP, 40 );
            Assert.AreEqual( b.First().HPmax, 40 );
            Assert.AreEqual( b.First().Lvl, 0 );
            Assert.AreEqual( b.First().MagicRes, 30 );
            Assert.AreEqual( b.First().Mana, 30 );
            Assert.AreEqual( b.First().ManaMax, 30 );
            Assert.AreEqual( b.First().PoisonRes, 40 );
            Assert.AreEqual( b.First().Speed, 8 );
            Assert.AreEqual( b.First().WaterRes, 20 );
            Assert.AreEqual( b.First().Xp, 0 );
            Assert.AreEqual( b.First().XpMax, 100 );
        }
        [Test]
        public void CreationWarriorStatTest()
        {
            List<BaseHeros> b = new List<BaseHeros>();
            HerosManager h = new HerosManager( b );
            h.Find( HerosEnum.Warrior.ToString() ).CreateHero();
            Assert.AreEqual( b.First().CharacterClassName, "Warrior" );
            Assert.AreEqual( b.First().CharacterName, "George" );
            Assert.AreEqual( b.First().Price, 400 );
            Assert.AreEqual( b.First().AffectRes, 30 );
            Assert.AreEqual( b.First().BleedingRes, 45 );
            Assert.AreEqual( b.First().CritChance, 20 );
            Assert.AreEqual( b.First().Damage, 11 );
            Assert.AreEqual( b.First().Defense, 40 );
            Assert.AreEqual( b.First().DodgeChance, 15 );
            Assert.AreEqual( b.First().Evilness, 0 );
            Assert.AreEqual( b.First().FireRes, 20 );
            Assert.AreEqual( b.First().HitChance, 60 );
            Assert.AreEqual( b.First().HP, 50 );
            Assert.AreEqual( b.First().HPmax, 50 );
            Assert.AreEqual( b.First().Lvl, 0 );
            Assert.AreEqual( b.First().MagicRes, 20 );
            Assert.AreEqual( b.First().Mana, 20 );
            Assert.AreEqual( b.First().ManaMax, 20 );
            Assert.AreEqual( b.First().PoisonRes, 20 );
            Assert.AreEqual( b.First().Speed, 5 );
            Assert.AreEqual( b.First().WaterRes, 20 );
            Assert.AreEqual( b.First().Xp, 0 );
            Assert.AreEqual( b.First().XpMax, 100 );
        }
        [Test]
        public void HerosWarriorSexTest()
        {
            List<BaseHeros> b = new List<BaseHeros>();
            HerosManager h = new HerosManager( b );
            Random rnd = new Random( 1 );
            h.Find( HerosEnum.Warrior.ToString() ).CreateHero();
            Assert.AreEqual( b.First().IsMale, rnd.Next( 2 ) == 0 );
        }
        [Test]
        public void HerosPaladinSexTest()
        {
            List<BaseHeros> b = new List<BaseHeros>();
            HerosManager h = new HerosManager( b );
            Random rnd = new Random( 1 );
            h.Find( HerosEnum.Paladin.ToString() ).CreateHero();
            Assert.AreEqual( b.First().IsMale, rnd.Next( 2 ) == 0 );
        }
        [Test]
        public void SpellWarriorTest()
        {
            List<BaseHeros> b = new List<BaseHeros>();
            HerosManager h = new HerosManager( b );
            h.Find( HerosEnum.Warrior.ToString() ).CreateHero();
            Assert.IsNotEmpty( b.First().Spells );
        }

        [Test]
        public void DiarrheaWariorTest()
        {
            List<BaseHeros> b = new List<BaseHeros>();
            HerosManager h = new HerosManager(b);
            h.Find(HerosEnum.Warrior.ToString()).CreateHero();
            Warrior warrior = b.First() as Warrior;
            Diarrhea test = new Diarrhea();
            warrior.GetSickness(test);
            Assert.AreEqual(warrior.EffectivDamage, 10);
            warrior.DeleteSickness(test);
            Assert.AreEqual(warrior.EffectivDamage, warrior.Damage);
            
        }

        [Test]
        public void FeverWariorTest()
        {
            List<BaseHeros> b = new List<BaseHeros>();
            HerosManager h = new HerosManager(b);
            h.Find(HerosEnum.Warrior.ToString()).CreateHero();
            Warrior warrior = b.First() as Warrior;
            Fever test = new Fever();
            warrior.GetSickness(test);
            Assert.AreEqual(warrior.EffectivDamage, 13);
            Assert.AreEqual(warrior.EffectivDefense, 32);
            Assert.Throws<ArgumentException>(() => warrior.GetSickness(test));
            warrior.DeleteSickness(test);
            Assert.AreEqual(warrior.EffectivDamage, warrior.Damage);
            Assert.AreEqual(warrior.EffectivDefense, warrior.Defense);

        }

        [Test]
        public void CrazynessWarriorTest()
        {
            List<BaseHeros> b = new List<BaseHeros>();
            HerosManager h = new HerosManager(b);
            h.Find(HerosEnum.Warrior.ToString()).CreateHero();
            Warrior warrior = b.First() as Warrior;
            Crazyness test = new Crazyness();
            warrior.GetPsycho(test);
            Assert.AreEqual(warrior.EffectivDamage, 17);
            Assert.AreEqual(warrior.EffectCritChance, 30);
            Assert.AreEqual(warrior.EffectivHitChance, 30);
            Assert.Throws<ArgumentException>(() => warrior.GetPsycho(test));
            warrior.DeletePsycho(test);
            Assert.AreEqual(warrior.EffectivDamage, warrior.Damage);
            Assert.AreEqual(warrior.EffectCritChance, warrior.CritChance);
            Assert.AreEqual(warrior.EffectivHitChance, warrior.HitChance);
        }
        [Test]
        public void WarriorUpdate()
        {
            List<BaseHeros> b = new List<BaseHeros>();
            HerosManager h = new HerosManager(b);
            h.Find(HerosEnum.Warrior.ToString()).CreateHero();
            Warrior warrior = b.First() as Warrior;
            Fever testF = new Fever();
            Diarrhea testD = new Diarrhea();
            Crazyness testC = new Crazyness();
            warrior.GetPsycho(testC);
            warrior.GetSickness(testF);
            warrior.GetSickness(testD);
            Assert.AreEqual(warrior.EffectivDamage, 18);
            Assert.AreEqual(warrior.EffectivDefense, 32);
            Assert.AreEqual(warrior.EffectCritChance, 30);
            Assert.AreEqual(warrior.EffectivHitChance, 30);
            warrior.DeleteSickness(testF);
            warrior.DeleteSickness(testD);
            warrior.DeletePsycho(testC);
            Assert.AreEqual(warrior.EffectivDamage, warrior.Damage);
            Assert.AreEqual(warrior.EffectivDefense, warrior.Defense);



        }
    }
}
