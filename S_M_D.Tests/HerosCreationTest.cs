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


        [Test]
        public void SpellWarriorTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find( HerosEnum.Warrior.ToString() ).CreateHero();
            Assert.IsNotEmpty( ctx.PlayerInfo.MyHeros.First().Spells );
            Assert.AreEqual( "BasicAttack", ctx.PlayerInfo.MyHeros.First().Spells.First().Name );
        }

        [Test]
        public void SpellPaladinTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find( HerosEnum.Paladin.ToString()).CreateHero();
            Assert.IsNotEmpty( ctx.PlayerInfo.MyHeros.First().Spells);
            Assert.AreEqual("BasicAttack", ctx.PlayerInfo.MyHeros.First().Spells.First().Name);
        }

        [Test]
        public void SpellPMageTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find(HerosEnum.Mage.ToString()).CreateHero();
            Assert.IsNotEmpty( ctx.PlayerInfo.MyHeros.First().Spells);
            Assert.AreEqual("BasicAttack", ctx.PlayerInfo.MyHeros.First().Spells.First().Name);
            Assert.AreEqual("FireBall", ctx.PlayerInfo.MyHeros.First().Spells[1].Name);
        }

        [Test]
        public void SpellPriestTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find( HerosEnum.Priest.ToString() ).CreateHero();
            Assert.IsNotEmpty( ctx.PlayerInfo.MyHeros.First().Spells);
            Assert.AreEqual("BasicAttack", ctx.PlayerInfo.MyHeros.First().Spells.First().Name);
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

        [Test]
        public void DiarrheaWariorTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find( HerosEnum.Warrior.ToString() ).CreateHero();
            Warrior warrior = ctx.PlayerInfo.MyHeros.First() as Warrior;
            Diarrhea test = new Diarrhea();
            warrior.GetSickness(test);
            Assert.AreEqual(warrior.EffectivDamage, 10);
            warrior.DeleteSickness(test);
            Assert.AreEqual(warrior.EffectivDamage, warrior.Damage);

        }

        [Test]
        public void FeverWariorTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find( HerosEnum.Warrior.ToString() ).CreateHero();
            Warrior warrior = ctx.PlayerInfo.MyHeros.First() as Warrior;
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
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find( HerosEnum.Warrior.ToString() ).CreateHero();
            Warrior warrior = ctx.PlayerInfo.MyHeros.First() as Warrior;
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
        public void LoveBetweenWarriorAndMageTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find( HerosEnum.Warrior.ToString() ).CreateHero();
            ctx.HeroManager.Find(HerosEnum.Mage.ToString()).CreateHero();

            Warrior warrior = ctx.PlayerInfo.MyHeros.First() as Warrior;
            Mage mage = ctx.PlayerInfo.MyHeros[1] as Mage;
            Love love = new Love(warrior, mage);
            warrior.GetRelationship(love);
            mage.GetRelationship(love);
            Assert.AreEqual(warrior.EffectivDamage, 12);
            Assert.AreEqual(warrior.EffectivDefense, 44);
            Assert.AreEqual(mage.EffectivDamage, 4);
            Assert.AreEqual(mage.EffectivDefense, 11);
            mage.DeleteRelationship(love);
            warrior.DeleteRelationship(love);
            Assert.AreEqual(warrior.EffectivDamage, warrior.Damage);
            Assert.AreEqual(warrior.EffectivDefense, warrior.Defense);
            Assert.AreEqual(mage.EffectivDamage, mage.Damage);
            Assert.AreEqual(mage.EffectivDefense, mage.Defense);
        }

        [Test]
        public void WarriorUpdate()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find( HerosEnum.Warrior.ToString() ).CreateHero();
            ctx.HeroManager.Find( HerosEnum.Mage.ToString() ).CreateHero();
            Warrior warrior = ctx.PlayerInfo.MyHeros.First() as Warrior;
            Mage mage = ctx.PlayerInfo.MyHeros[1] as Mage;
            Fever testF = new Fever();
            Diarrhea testD = new Diarrhea();
            Crazyness testC = new Crazyness();
            Love love = new Love(warrior, mage);
            warrior.GetPsycho(testC);
            warrior.GetSickness(testF);
            warrior.GetSickness(testD);
            warrior.GetRelationship(love);
            mage.GetRelationship(love);
            Assert.AreEqual(warrior.EffectivDamage, 19);
            Assert.AreEqual(warrior.EffectivDefense, 36);
            Assert.AreEqual(warrior.EffectCritChance, 30);
            Assert.AreEqual(warrior.EffectivHitChance, 30);
            warrior.DeleteSickness(testF);
            warrior.DeleteSickness(testD);
            warrior.DeletePsycho(testC);
            warrior.DeleteRelationship(love);
            mage.DeleteRelationship(love);
            Assert.AreEqual(warrior.EffectivDamage, warrior.Damage);
            Assert.AreEqual(warrior.EffectivDefense, warrior.Defense);
        }

        [Test]
        public void GetItemWeaponTest()
        {

            using (FileStream myFileStream = new FileStream("Weapons.xml", FileMode.Open))
            {
                XmlSerializer reader = new XmlSerializer(typeof(List<BaseWeapon>));
                List<BaseWeapon> overview = (List<BaseWeapon>)reader.Deserialize(myFileStream);
            }
            

        }
    }
}
