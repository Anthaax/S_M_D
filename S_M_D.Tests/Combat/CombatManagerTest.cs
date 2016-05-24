using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using S_M_D.Combat;
using S_M_D.Character.Monsters;
using S_M_D.Character;
using S_M_D.Spell;

namespace S_M_D.Tests.Combat
{
    [TestFixture]
    public class CombatManagerTest
    {
        [Test]
        public void CombatManagerMonsterInitializationTest()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
            CombatManager cbt = new CombatManager( ctx.PlayerInfo.MyHeros.ToArray(), ctx );
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
        public void WhoCanBeTargetable()
        {
            GameContext ctx = GameContext.CreateNewGame( 1 );
            CombatManager cbt = new CombatManager( ctx.PlayerInfo.MyHeros.ToArray(), ctx );
            BaseHeros hero = cbt.CharacterOrderAttack.First() as BaseHeros;
            bool[] target =  cbt.SpellManager.WhoCanBeTargetable( hero.Spells.First(), 0 );
            Assert.AreEqual( hero.Spells.First().TargetManager.CanBeTargetable, target );
            target = cbt.SpellManager.WhoCanBeTargetable( hero.Spells.First(), 3 );
            Assert.AreEqual( new bool[4] { false, false, false, false }, target );
        }
        [Test]
        public void LauchSpellTest()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
            CombatManager cbt = new CombatManager( ctx.PlayerInfo.MyHeros.ToArray(), ctx);
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First(), cbt.CharacterOrderAttack.First() );
            cbt.SpellManager.HeroLaunchSpell( ctx.PlayerInfo.MyHeros.First().Spells.First(), 0 );
            Assert.AreEqual( cbt.Monsters.First().HPmax - ctx.PlayerInfo.MyHeros.First().Spells.First().KindOfEffect.Damage, cbt.Monsters.First().HP );
            Assert.AreEqual( true, ctx.PlayerInfo.MyHeros.First().Spells.First().CooldownManager.IsOnCooldown );
            Assert.Throws<ArgumentException>( () => cbt.SpellManager.HeroLaunchSpell( ctx.PlayerInfo.MyHeros.First().Spells[1], 0) );
            cbt.SpellManager.HeroLaunchSpell( ctx.PlayerInfo.MyHeros.First().Spells[1], 1 );
            Assert.AreEqual( cbt.Monsters.First().HPmax - ctx.PlayerInfo.MyHeros.First().Spells[1].KindOfEffect.Damage, cbt.Monsters[1].HP );
            Assert.AreEqual( DamageTypeEnum.Fire, cbt.DamageOnTime[cbt.Monsters[1]].DamageType );
        }
        [Test]
        public void MultipleEffectOnOneMonster()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
            CombatManager cbt = new CombatManager( ctx.PlayerInfo.MyHeros.ToArray(), ctx );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First(), cbt.CharacterOrderAttack.First() );
            cbt.SpellManager.HeroLaunchSpell( ctx.PlayerInfo.MyHeros.First().Spells[1], 1 );
            cbt.SpellManager.HeroLaunchSpell( ctx.PlayerInfo.MyHeros.First().Spells[1], 1 );
            Assert.AreEqual( cbt.Monsters.First().HPmax - ctx.PlayerInfo.MyHeros.First().Spells[1].KindOfEffect.Damage*2, cbt.Monsters[1].HP );
            Assert.AreEqual( DamageTypeEnum.Fire, cbt.DamageOnTime[cbt.Monsters[1]].DamageType );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells[1].KindOfEffect.DamagePerTurn * 2, cbt.DamageOnTime[cbt.Monsters[1]].EffectiveDamagePerTurn );
            cbt.SpellManager.HeroLaunchSpell( ctx.PlayerInfo.MyHeros.First().Spells[1], 2 );
            Assert.AreEqual( cbt.Monsters.First().HPmax - ctx.PlayerInfo.MyHeros.First().Spells[1].KindOfEffect.Damage, cbt.Monsters[2].HP );
            Assert.AreEqual( DamageTypeEnum.Fire, cbt.DamageOnTime[cbt.Monsters[1]].DamageType );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells[1].KindOfEffect.DamagePerTurn, cbt.DamageOnTime[cbt.Monsters[2]].EffectiveDamagePerTurn );
        }
        [Test]
        public void HealHeroOrMonster()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
            CombatManager cbt = new CombatManager( ctx.PlayerInfo.MyHeros.ToArray(), ctx);
            ctx.PlayerInfo.MyHeros[1].HP -= 5;
            Assert.Throws<ArgumentException>( () => cbt.SpellManager.HeroLaunchSpell( ctx.PlayerInfo.MyHeros.First().Spells[1], 0) );
            cbt.SpellManager.HeroLaunchSpell( ctx.PlayerInfo.MyHeros[1].Spells[2], 1 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[1].EffectivHPMax, cbt.Heros[1].HP );
            ctx.PlayerInfo.MyHeros[1].HP = 1;
            cbt.SpellManager.HeroLaunchSpell( ctx.PlayerInfo.MyHeros[1].Spells[2], 1 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[1].Spells[2].KindOfEffect.Damage + 1, cbt.Heros[1].HP );
            cbt.Monsters[0].HP = 1;
            cbt.Monsters[0].EffectivHPMax = 32;
            cbt.SpellManager.MonsterLaunchSpell( ctx.PlayerInfo.MyHeros[1].Spells[2], 0 );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[1].Spells[2].KindOfEffect.Damage + 1, cbt.Monsters[0].HP );
            cbt.SpellManager.MonsterLaunchSpell( ctx.PlayerInfo.MyHeros[1].Spells[2], 0 );
            Assert.AreEqual( cbt.Monsters[0].EffectivHPMax, cbt.Monsters[0].HP );


        }
        [Test]
        public void ChangeTurn()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
            CombatManager cbt = new CombatManager( ctx.PlayerInfo.MyHeros.ToArray(), ctx);
            Assert.AreEqual(cbt.CharacterOrderAttack[0], cbt.GetCharacterTurn());
            Assert.AreEqual(cbt.CharacterOrderAttack[1], cbt.NextTurn());
            Assert.AreEqual(cbt.CharacterOrderAttack[2], cbt.NextTurn());
            Assert.AreEqual(cbt.CharacterOrderAttack[3], cbt.NextTurn());
            Assert.AreEqual(cbt.CharacterOrderAttack[4], cbt.NextTurn());
            Assert.AreEqual(cbt.CharacterOrderAttack[5], cbt.NextTurn());
            Assert.AreEqual(cbt.CharacterOrderAttack[6], cbt.NextTurn());
            Assert.AreEqual(cbt.CharacterOrderAttack[7], cbt.NextTurn());
            Assert.AreEqual(cbt.CharacterOrderAttack[0], cbt.NextTurn());
            Assert.AreEqual(cbt.CharacterOrderAttack[1], cbt.NextTurn());
            Assert.AreEqual(cbt.CharacterOrderAttack[2], cbt.NextTurn());
            Assert.AreEqual(cbt.CharacterOrderAttack[3], cbt.NextTurn());
            Assert.AreEqual(cbt.CharacterOrderAttack[4], cbt.NextTurn());
            Assert.AreEqual(cbt.CharacterOrderAttack[5], cbt.NextTurn());
            Assert.AreEqual(cbt.CharacterOrderAttack[6], cbt.NextTurn());
            Assert.AreEqual(cbt.CharacterOrderAttack[7], cbt.NextTurn());
            Assert.AreEqual(cbt.CharacterOrderAttack[0], cbt.NextTurn());
            Assert.AreEqual(cbt.CharacterOrderAttack[1], cbt.NextTurn());
            Assert.AreEqual(cbt.CharacterOrderAttack[2], cbt.NextTurn());
        }
        [Test]
        public void EndOfCombat()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
            CombatManager cbt = new CombatManager( ctx.PlayerInfo.MyHeros.ToArray(), ctx);
            Assert.AreEqual( false, cbt.CheckIfTheCombatWasOver() );
            ctx.PlayerInfo.MyHeros.Where( c => c.CharacterClassName != HerosEnum.Mage.ToString() ).ToList().ForEach( c => c.HP = 0 );
            cbt.SpellManager.MonsterLaunchSpell( ctx.PlayerInfo.MyHeros.First().Spells[3], 1 );
            ctx.PlayerInfo.MyHeros.ForEach( c => c.HP = 0 );
            cbt.SpellManager.MonsterLaunchSpell( ctx.PlayerInfo.MyHeros.First().Spells[0], 0 );
            Assert.AreEqual( true, cbt.CheckIfTheCombatWasOver() );

        }
        [Test]
        public void RemoveDieHero()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
            CombatManager cbt = new CombatManager( ctx.PlayerInfo.MyHeros.ToArray(), ctx);
            ctx.PlayerInfo.MyHeros.Where( c => c.CharacterClassName != HerosEnum.Mage.ToString() ).ToList().ForEach(c => c.HP = 0);
            cbt.SpellManager.MonsterLaunchSpell( ctx.PlayerInfo.MyHeros.First().Spells[3], 1 );
            Assert.AreEqual( 5, cbt.CharacterOrderAttack.Count );
            Assert.AreEqual( 1, ctx.PlayerInfo.MyHeros.Count );
            Assert.AreEqual( null, cbt.Heros[1] );
            Assert.AreEqual( null, cbt.Heros[2] );
            Assert.AreEqual( null, cbt.Heros[3] );
        }

        [Test]
        public void RewardTest()
        {
            GameContext ctx = GameContext.CreateNewGame( 1 );
            CombatManager cbt = new CombatManager( ctx.PlayerInfo.MyHeros.ToArray(), ctx);
            Random rnd = new Random(1);
            cbt.ApplyRewward();
            UseRndMultipleTime( rnd, 29);
            int i = rnd.Next( 30 );
            int nbMatchItem = ctx.AllItemInGame
                                .Where( c => c.Itemtype == BaseItem.ItemTypes.Armor )
                                .Count();
            BaseItem result = ctx.AllItemInGame
                        .Where( c => c.Itemtype == BaseItem.ItemTypes.Armor )
                        .ToList()[rnd.Next( nbMatchItem )];
            Assert.AreEqual( ctx.PlayerInfo.MyHeros[0].Xp, cbt.Reward.Xp / 4 );
            Assert.AreEqual( result, cbt.Reward.Item );
            Assert.AreEqual( ctx.PlayerInfo.MyItems.First(), cbt.Reward.Item );
            Assert.AreEqual( ctx.MoneyManager.Money, cbt.Reward.Money + 10000 );
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
