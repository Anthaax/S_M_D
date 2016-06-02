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
            GameContext ctx = GameContext.CreateNewGame(1);
            Assert.AreEqual( 4, ctx.PlayerInfo.MyHeros.Count );
        }
        [Test]
        public void CantCreateHerosWhen16HerosInHerosList()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
            FullList( ctx.HeroManager );
            Assert.Throws<InvalidOperationException>( () => ctx.HeroManager.Find( HerosEnum.Warrior.ToString() ).CreateHero());
        }
        [Test]
        public void CreationHeroClassNameTest()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
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
            GameContext ctx = GameContext.CreateNewGame(1);
            int price = ctx.HeroManager.Find( HerosEnum.Paladin.ToString() ).Price;
            Assert.AreEqual(400, price);
            price = ctx.HeroManager.Find( HerosEnum.Warrior.ToString() ).Price;
            Assert.AreEqual( 400, price );
            price = ctx.HeroManager.Find( HerosEnum.Mage.ToString() ).Price;
            Assert.AreEqual( 400, price );
            price = ctx.HeroManager.Find( HerosEnum.Priest.ToString() ).Price;
            Assert.AreEqual(400, price);
        }
        [Test]
        public void CreationPaladinStatTest()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
            ctx.HeroManager.Find( HerosEnum.Paladin.ToString() ).CreateHero();
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].CharacterClassName, "Paladin" );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Price, 400 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].AffectRes, 50 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].BleedingRes, 40 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].CritChance, 12 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Damage, 7 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Defense, 40 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].DodgeChance, 15 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Evilness, 0 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].FireRes, 20 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].HitChance, 50 );
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].HP, ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count - 1].EffectivHPMax);
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].HPmax, 40 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Lvl, 0 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].MagicRes, 30 );
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Mana, ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count - 1].EffectivManaMax);
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].ManaMax, 30 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].PoisonRes, 40 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Speed, 8 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].WaterRes, 20 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Xp, 0 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].XpMax, 100 );
        }
        [Test]
        public void CreationWarriorStatTest()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
            ctx.HeroManager.Find( HerosEnum.Warrior.ToString() ).CreateHero();
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].CharacterClassName, "Warrior" );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Price, 400 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].AffectRes, 30 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].BleedingRes, 45 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].CritChance, 20 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Damage, 11 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Defense, 40 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].DodgeChance, 15 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Evilness, 0 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].FireRes, 20 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].HitChance, 60 );
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].HP, ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count - 1].EffectivHPMax);
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].HPmax, 50 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Lvl, 0 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].MagicRes, 20 );
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Mana, ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count - 1].EffectivManaMax);
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].ManaMax, 20 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].PoisonRes, 20 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Speed, 5 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].WaterRes, 20 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Xp, 0 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].XpMax, 100 );
        }

        [Test]
        public void CreationMageStatTest()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
            ctx.HeroManager.Find( HerosEnum.Mage.ToString() ).CreateHero();
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].CharacterClassName, "Mage");
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Price, 400);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].AffectRes, 20);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].BleedingRes, 20);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].CritChance, 6);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Damage, 4);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Defense, 10);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].DodgeChance, 8);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Evilness, 0);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].FireRes, 20);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].HitChance, 80);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].HP, ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count - 1].EffectivHPMax);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].HPmax, 25);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Lvl, 0);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].MagicRes, 60);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Mana, ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count - 1].EffectivManaMax);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].ManaMax, 50);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].PoisonRes, 20);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Speed, 10);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].WaterRes, 20);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Xp, 0);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].XpMax, 100);
        }

        [Test]
        public void CreationPriestStatTest()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
            ctx.HeroManager.Find(HerosEnum.Priest.ToString()).CreateHero();
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].CharacterClassName, "Priest");
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Price, 400);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].AffectRes, 30);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].BleedingRes, 30);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].CritChance, 10);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Damage, 5);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Defense, 20);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].DodgeChance, 10);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Evilness, 0);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].FireRes, 30);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].HitChance, 60);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].HP, ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count - 1].EffectivHPMax);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].HPmax, 30);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Lvl, 0);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].MagicRes, 30);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Mana, ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count - 1].EffectivManaMax);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].ManaMax, 40);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].PoisonRes, 30);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Speed, 8);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].WaterRes, 30);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Xp, 0);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].XpMax, 100);
        }
        public void HerosSexTest()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
            FullList(ctx.HeroManager);
            Random rnd = new Random(1);
            Assert.AreEqual(rnd.Next(2) == 0, ctx.PlayerInfo.MyHeros[0].IsMale);
            UseRndMultipleTime( rnd, 4 );
            Assert.AreEqual(rnd.Next(2) == 0, ctx.PlayerInfo.MyHeros[1].IsMale);
            UseRndMultipleTime( rnd, 4 );
            Assert.AreEqual( rnd.Next(2) == 0, ctx.PlayerInfo.MyHeros[2].IsMale);
            UseRndMultipleTime( rnd, 4 );
            Assert.AreEqual( rnd.Next(2) == 0, ctx.PlayerInfo.MyHeros[3].IsMale);
            UseRndMultipleTime( rnd, 4 );
            Assert.AreEqual( rnd.Next(2) == 0, ctx.PlayerInfo.MyHeros[4].IsMale);
            UseRndMultipleTime( rnd, 4 );
            Assert.AreEqual( rnd.Next(2) == 0, ctx.PlayerInfo.MyHeros[5].IsMale);
            UseRndMultipleTime( rnd, 4 );
            Assert.AreEqual( rnd.Next(2) == 0, ctx.PlayerInfo.MyHeros[6].IsMale);
            UseRndMultipleTime( rnd, 4 );
            Assert.AreEqual( rnd.Next(2) == 0, ctx.PlayerInfo.MyHeros[7].IsMale);
            UseRndMultipleTime( rnd, 5 );
            Assert.AreEqual( rnd.Next(2) == 0, ctx.PlayerInfo.MyHeros[8].IsMale);
            UseRndMultipleTime( rnd, 5 );
            Assert.AreEqual( rnd.Next(2) == 0, ctx.PlayerInfo.MyHeros[9].IsMale);
            UseRndMultipleTime( rnd, 5 );
            Assert.AreEqual( rnd.Next(2) == 0, ctx.PlayerInfo.MyHeros[10].IsMale);
            UseRndMultipleTime( rnd, 5 );
            Assert.AreEqual( rnd.Next(2) == 0, ctx.PlayerInfo.MyHeros[11].IsMale);
            UseRndMultipleTime( rnd, 5 );
            Assert.AreEqual( rnd.Next(2) == 0, ctx.PlayerInfo.MyHeros[12].IsMale);
            UseRndMultipleTime( rnd, 5 );
            Assert.AreEqual( rnd.Next(2) == 0, ctx.PlayerInfo.MyHeros[13].IsMale);
            UseRndMultipleTime( rnd, 5 );
            Assert.AreEqual( rnd.Next(2) == 0, ctx.PlayerInfo.MyHeros[14].IsMale);
            UseRndMultipleTime( rnd, 5 );
            Assert.AreEqual( rnd.Next(2) == 0, ctx.PlayerInfo.MyHeros[15].IsMale);
        }
        [Test]
        public void MageLevelUpTest()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
            ctx.HeroManager.Find( HerosEnum.Mage.ToString() ).CreateHero();
            Assert.Throws<ArgumentException>( () => ctx.PlayerInfo.MyHeros.First().LevelUp() );
            ctx.PlayerInfo.MyHeros.First().Xp = ctx.PlayerInfo.MyHeros.First().XpMax;
            ctx.PlayerInfo.MyHeros.First().LevelUp();
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count - 1].Lvl + 1, ctx.PlayerInfo.MyHeros.First().Lvl );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count - 1].HPmax + 10, ctx.PlayerInfo.MyHeros.First().HPmax );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count - 1].ManaMax + 10, ctx.PlayerInfo.MyHeros.First().ManaMax );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count - 1].Damage + 2, ctx.PlayerInfo.MyHeros.First().Damage );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count - 1].DodgeChance + 3, ctx.PlayerInfo.MyHeros.First().DodgeChance );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count - 1].HitChance + 30, ctx.PlayerInfo.MyHeros.First().HitChance );

        }
        [Test]
        public void WarriorLevelUpTest()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
            ctx.HeroManager.Find( HerosEnum.Warrior.ToString() ).CreateHero();
            Assert.Throws<ArgumentException>( () => ctx.PlayerInfo.MyHeros[3].LevelUp() );
            ctx.PlayerInfo.MyHeros[3].Xp = ctx.PlayerInfo.MyHeros[3].XpMax;
            ctx.PlayerInfo.MyHeros[3].LevelUp();
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Lvl + 1, ctx.PlayerInfo.MyHeros[3].Lvl );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].HPmax + 10, ctx.PlayerInfo.MyHeros[3].HPmax );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].ManaMax + 10, ctx.PlayerInfo.MyHeros[3].ManaMax );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Damage + 2, ctx.PlayerInfo.MyHeros[3].Damage );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].DodgeChance + 3, ctx.PlayerInfo.MyHeros[3].DodgeChance );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].HitChance + 30, ctx.PlayerInfo.MyHeros[3].HitChance );

        }

        [Test]
        public void PreistLevelUpTest()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
            ctx.HeroManager.Find( HerosEnum.Priest.ToString() ).CreateHero();
            ctx.HeroManager.Find( HerosEnum.Priest.ToString() ).CreateHero();
            Assert.Throws<ArgumentException>( () => ctx.PlayerInfo.MyHeros[2].LevelUp() );
            ctx.PlayerInfo.MyHeros[2].Xp = ctx.PlayerInfo.MyHeros[2].XpMax;
            ctx.PlayerInfo.MyHeros[2].LevelUp();
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Lvl + 1, ctx.PlayerInfo.MyHeros[2].Lvl );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].HPmax + 10, ctx.PlayerInfo.MyHeros[2].HPmax );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].ManaMax + 10, ctx.PlayerInfo.MyHeros[2].ManaMax );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Damage + 2, ctx.PlayerInfo.MyHeros[2].Damage );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].DodgeChance + 3, ctx.PlayerInfo.MyHeros[2].DodgeChance );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].HitChance + 30, ctx.PlayerInfo.MyHeros[2].HitChance );

        }

        [Test]
        public void PaladinLevelUpTest()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
            ctx.HeroManager.Find( HerosEnum.Paladin.ToString() ).CreateHero();
            ctx.HeroManager.Find( HerosEnum.Paladin.ToString() ).CreateHero();
            Assert.Throws<ArgumentException>( () => ctx.PlayerInfo.MyHeros[1].LevelUp() );
            ctx.PlayerInfo.MyHeros[1].Xp = ctx.PlayerInfo.MyHeros[1].XpMax;
            ctx.PlayerInfo.MyHeros[1].LevelUp();
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Lvl + 1, ctx.PlayerInfo.MyHeros[1].Lvl );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].HPmax + 10, ctx.PlayerInfo.MyHeros[1].HPmax );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].ManaMax + 10, ctx.PlayerInfo.MyHeros[1].ManaMax );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].Damage + 2, ctx.PlayerInfo.MyHeros[1].Damage );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].DodgeChance + 3, ctx.PlayerInfo.MyHeros[1].DodgeChance );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[ctx.PlayerInfo.MyHeros.Count-1].HitChance + 30, ctx.PlayerInfo.MyHeros[1].HitChance );

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
        }
        private void UseRndMultipleTime( Random rnd, int nbTime )
        {
            for (int i = 0; i < nbTime; i++)
            {
                rnd.Next();
            }
        }
    }
}
