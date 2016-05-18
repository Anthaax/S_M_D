using NUnit.Framework;
using S_M_D.Character;
using S_M_D.Spell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_M_D.Tests
{
    [TestFixture]
    public class Spells
    {
        [Test]
        public void SpellWarriorTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find(HerosEnum.Warrior.ToString()).CreateHero();
            Assert.IsNotEmpty(ctx.PlayerInfo.MyHeros.First().Spells);
            Assert.AreEqual("BasicAttack", ctx.PlayerInfo.MyHeros.First().Spells.First().Name);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Spells.First().CooldownManager.BaseCooldown, 1);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Spells.First().CooldownManager.Cooldown, 0);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Spells.First().CooldownManager.IsOnCooldown, false);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Spells.First().Description, "Attaque basique du warrior");
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Spells.First().Price, 400);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Spells.First().ManaCost, 0);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Spells.First().TargetManager.HeroPosition ,new bool[4] { true, true, false, false });
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Spells.First().TargetManager.CanBeTargetable, new bool[4] { true, true, false, false });
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Spells.First().TargetManager.Radius, 1);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Spells.First().KindOfEffect.Damage, 11);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Spells.First().KindOfEffect.CanBeBlock, false );
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Spells.First().KindOfEffect.DamagePerTurn, 0);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Spells.First().KindOfEffect.DamageType, DamageTypeEnum.Physical);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Spells.First().KindOfEffect.Turn, 0);


            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells[1].Name, "ShieldRush" );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells[1].CooldownManager.BaseCooldown, 1 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells[1].CooldownManager.Cooldown, 0 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells[1].CooldownManager.IsOnCooldown, false );
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Spells[1].Description, "Donne un coup de bouclier");
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells[1].Price, 400 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells[1].ManaCost, 0 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells[1].TargetManager.HeroPosition, new bool[4] { true, true, false, false } );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells[1].TargetManager.CanBeTargetable, new bool[4] { true, true, false, false } );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells[1].TargetManager.Radius, 1 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells[1].KindOfEffect.Damage, Convert.ToInt32(11*1.2f) );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells[1].KindOfEffect.CanBeBlock, false );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells[1].KindOfEffect.DamagePerTurn, 0 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells[1].KindOfEffect.DamageType, DamageTypeEnum.Physical );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells[1].KindOfEffect.Turn, 0 );

        }

        [Test]
        public void SpellPaladinTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find(HerosEnum.Paladin.ToString()).CreateHero();
            Assert.IsNotEmpty(ctx.PlayerInfo.MyHeros.First().Spells);
            Assert.AreEqual("BasicAttack", ctx.PlayerInfo.MyHeros.First().Spells.First().Name);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Spells.First().CooldownManager.BaseCooldown, 1);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Spells.First().CooldownManager.Cooldown, 0);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Spells.First().CooldownManager.IsOnCooldown, false);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Spells.First().Description, "Attaque basique du paladin");
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Spells.First().Price, 400);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Spells.First().ManaCost, 0);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Spells.First().TargetManager.HeroPosition ,new bool[4] { true, true, false, false });
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Spells.First().TargetManager.CanBeTargetable, new bool[4] { true, true, false, false });
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Spells.First().TargetManager.Radius, 1);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Spells.First().KindOfEffect.Damage, 7);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Spells.First().KindOfEffect.CanBeBlock, false );
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Spells.First().KindOfEffect.DamagePerTurn, 0);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Spells.First().KindOfEffect.DamageType, DamageTypeEnum.Physical);
            Assert.AreEqual(ctx.PlayerInfo.MyHeros.First().Spells.First().KindOfEffect.Turn, 0);
        }

        [Test]
        public void SpellPMageTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find(HerosEnum.Mage.ToString()).CreateHero();
            Assert.IsNotEmpty(ctx.PlayerInfo.MyHeros.First().Spells);
            Assert.AreEqual("BasicAttack", ctx.PlayerInfo.MyHeros.First().Spells.First().Name);
            Assert.AreEqual("FireBall", ctx.PlayerInfo.MyHeros.First().Spells[1].Name);
            Assert.AreEqual("ChaosBolt", ctx.PlayerInfo.MyHeros.First().Spells[2].Name);

            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells.First().CooldownManager.BaseCooldown, 1 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells.First().CooldownManager.Cooldown, 0 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells.First().CooldownManager.IsOnCooldown, false );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells.First().Description, "Attaque basique du mage" );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells.First().Price, 400 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells.First().ManaCost, 0 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells.First().TargetManager.HeroPosition, new bool[4] { true, true, false, false } );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells.First().TargetManager.CanBeTargetable, new bool[4] { true, true, false, false } );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells.First().TargetManager.Radius, 1 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells.First().KindOfEffect.Damage, 4 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells.First().KindOfEffect.CanBeBlock, false );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells.First().KindOfEffect.DamagePerTurn, 0 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells.First().KindOfEffect.DamageType, DamageTypeEnum.Physical );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells.First().KindOfEffect.Turn, 0 );
        }


        [Test]
        public void SpellPriestTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find(HerosEnum.Priest.ToString()).CreateHero();
            Assert.IsNotEmpty(ctx.PlayerInfo.MyHeros.First().Spells);
            Assert.AreEqual("BasicAttack", ctx.PlayerInfo.MyHeros.First().Spells.First().Name);
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells.First().CooldownManager.BaseCooldown, 1 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells.First().CooldownManager.Cooldown, 0 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells.First().CooldownManager.IsOnCooldown, false );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells.First().Description, "Attaque basique du priest" );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells.First().Price, 400 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells.First().ManaCost, 0 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells.First().TargetManager.HeroPosition, new bool[4] { true, true, false, false } );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells.First().TargetManager.CanBeTargetable, new bool[4] { true, true, false, false } );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells.First().TargetManager.Radius, 1 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells.First().KindOfEffect.Damage, 5 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells.First().KindOfEffect.CanBeBlock, false );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells.First().KindOfEffect.DamagePerTurn, 0 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells.First().KindOfEffect.DamageType, DamageTypeEnum.Physical );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells.First().KindOfEffect.Turn, 0 );
        }
    }
}
