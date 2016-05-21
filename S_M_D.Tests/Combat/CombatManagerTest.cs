using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using S_M_D.Combat;
using S_M_D.Character.Monsters;
using S_M_D.Spell;

namespace S_M_D.Tests.Combat
{
    [TestFixture]
    public class CombatManagerTest
    {
        [Test]
        public void CombatManagerMonsterInitializationTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            CombatManager cbt = new CombatManager( ctx.PlayerInfo.MyHeros.ToArray(), ctx , "../../../S_M_D/" );
            Assert.AreEqual( 4, cbt.Heros.Count() );
            Assert.AreEqual( 4, cbt.Monsters.Count() );
            Random rnd = new Random( 1 );
            UseRndMultipleTime(rnd , 4 );
            Assert.AreEqual( 4 + cbt.Monsters.Count(s => s != null) , cbt.CharacterOrderAttack.Count );
            rnd.Next();
            MonsterConfiguration monsters = new MonsterConfiguration();
            Assert.AreEqual( monsters.CreateMonster( (MonsterType)rnd.Next(1,5), cbt.Heros.Max( s => s.Lvl ) ).Lvl, cbt.Monsters.First().Lvl );
        }
        [Test]
        public void LauchSpellTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            CombatManager cbt = new CombatManager( ctx.PlayerInfo.MyHeros.ToArray(), ctx, "../../../S_M_D/" );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First(), cbt.CharacterOrderAttack.First() );
            cbt.SpellManager.LaunchDamageSpellOnMonster( ctx.PlayerInfo.MyHeros.First().Spells.First(), 0 );
            Assert.AreEqual( cbt.Monsters.First().HPmax - ctx.PlayerInfo.MyHeros.First().Spells.First().KindOfEffect.Damage, cbt.Monsters.First().HP );
            Assert.AreEqual( true, ctx.PlayerInfo.MyHeros.First().Spells.First().CooldownManager.IsOnCooldown );
            Assert.Throws<ArgumentException>( () => cbt.SpellManager.LaunchDamageSpellOnMonster( ctx.PlayerInfo.MyHeros.First().Spells[1], 0) );
            cbt.SpellManager.LaunchDamageSpellOnMonster( ctx.PlayerInfo.MyHeros.First().Spells[1], 1 );
            Assert.AreEqual( cbt.Monsters.First().HPmax - ctx.PlayerInfo.MyHeros.First().Spells[1].KindOfEffect.Damage, cbt.Monsters[1].HP );
            Assert.AreEqual( DamageTypeEnum.Fire, cbt.DamageOnTime[cbt.Monsters[1]].DamageType );
        }
        [Test]
        public void MultipleEffectOnOneMonster()
        {
            GameContext ctx = GameContext.CreateNewGame();
            CombatManager cbt = new CombatManager( ctx.PlayerInfo.MyHeros.ToArray(), ctx, "../../../S_M_D/" );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First(), cbt.CharacterOrderAttack.First() );
            cbt.SpellManager.LaunchDamageSpellOnMonster( ctx.PlayerInfo.MyHeros.First().Spells[1], 1 );
            cbt.SpellManager.LaunchDamageSpellOnMonster( ctx.PlayerInfo.MyHeros.First().Spells[1], 1 );
            Assert.AreEqual( cbt.Monsters.First().HPmax - ctx.PlayerInfo.MyHeros.First().Spells[1].KindOfEffect.Damage*2, cbt.Monsters[1].HP );
            Assert.AreEqual( DamageTypeEnum.Fire, cbt.DamageOnTime[cbt.Monsters[1]].DamageType );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells[1].KindOfEffect.DamagePerTurn * 2, cbt.DamageOnTime[cbt.Monsters[1]].EffectiveDamagePerTurn );
            cbt.SpellManager.LaunchDamageSpellOnMonster( ctx.PlayerInfo.MyHeros.First().Spells[1], 2 );
            Assert.AreEqual( cbt.Monsters.First().HPmax - ctx.PlayerInfo.MyHeros.First().Spells[1].KindOfEffect.Damage, cbt.Monsters[2].HP );
            Assert.AreEqual( DamageTypeEnum.Fire, cbt.DamageOnTime[cbt.Monsters[1]].DamageType );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells[1].KindOfEffect.DamagePerTurn, cbt.DamageOnTime[cbt.Monsters[2]].EffectiveDamagePerTurn );
        }
        [Test]
        public void HealHeroOrMonster()
        {
            GameContext ctx = GameContext.CreateNewGame();
            CombatManager cbt = new CombatManager( ctx.PlayerInfo.MyHeros.ToArray(), ctx, "../../../S_M_D/" );
            ctx.PlayerInfo.MyHeros[1].HP -= 5;
            Assert.Throws<ArgumentException>( () => cbt.SpellManager.LaunchHealOnHero( ctx.PlayerInfo.MyHeros.First().Spells[1], 0) );
            cbt.SpellManager.LaunchHealOnHero( ctx.PlayerInfo.MyHeros[1].Spells[2], 1 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[1].HPmax, cbt.Heros[1].HP );
            ctx.PlayerInfo.MyHeros[1].HP -= 22;
            cbt.SpellManager.LaunchHealOnHero( ctx.PlayerInfo.MyHeros[1].Spells[2], 1 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[1].HPmax -1, cbt.Heros[1].HP );
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
