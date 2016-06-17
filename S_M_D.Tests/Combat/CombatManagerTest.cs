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
            cbt.Monsters[0].EffectivHPMax = ctx.PlayerInfo.MyHeros[0].Spells[0].KindOfEffect.Damage + 5;
            cbt.Monsters[0].HP = ctx.PlayerInfo.MyHeros[0].Spells[0].KindOfEffect.Damage + 5;
            cbt.Monsters[1].EffectivHPMax = ctx.PlayerInfo.MyHeros[0].Spells[1].KindOfEffect.Damage + 5;
            cbt.Monsters[1].HP = ctx.PlayerInfo.MyHeros[0].Spells[1].KindOfEffect.Damage + 5;
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First(), cbt.CharacterOrderAttack.First() );
            cbt.SpellManager.HeroLaunchSpell( ctx.PlayerInfo.MyHeros.First().Spells.First(), 0 );
            Assert.AreEqual( 5, cbt.Monsters.First().HP );
            Assert.AreEqual( true, ctx.PlayerInfo.MyHeros.First().Spells.First().CooldownManager.IsOnCooldown );
            Assert.Throws<ArgumentException>( () => cbt.SpellManager.HeroLaunchSpell( ctx.PlayerInfo.MyHeros.First().Spells[1], 0) );
            cbt.SpellManager.HeroLaunchSpell( ctx.PlayerInfo.MyHeros.First().Spells[1], 1 );
            Assert.AreEqual( 5, cbt.Monsters[1].HP );
            Assert.AreEqual( DamageTypeEnum.Fire, cbt.DamageOnTime[cbt.Monsters[1]].DamageType );
        }
        [Test]
        public void MultipleEffectOnOneMonster()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
            CombatManager cbt = new CombatManager( ctx.PlayerInfo.MyHeros.ToArray(), ctx );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First(), cbt.CharacterOrderAttack.First() );

            cbt.Monsters[1].EffectivHPMax = ctx.PlayerInfo.MyHeros[1].Spells[2].KindOfEffect.Damage + 5;
            cbt.Monsters[1].HP = ctx.PlayerInfo.MyHeros[1].Spells[2].KindOfEffect.Damage + 5;
            cbt.Monsters[2].EffectivHPMax = ctx.PlayerInfo.MyHeros[1].Spells[2].KindOfEffect.Damage + 5;
            cbt.Monsters[2].HP = ctx.PlayerInfo.MyHeros[1].Spells[2].KindOfEffect.Damage + 5;
            cbt.Monsters[3].EffectivHPMax = ctx.PlayerInfo.MyHeros[1].Spells[2].KindOfEffect.Damage + 5;
            cbt.Monsters[3].HP = ctx.PlayerInfo.MyHeros[1].Spells[2].KindOfEffect.Damage + 5;

            cbt.SpellManager.HeroLaunchSpell( ctx.PlayerInfo.MyHeros.First().Spells[1], 1 );
            cbt.SpellManager.HeroLaunchSpell( ctx.PlayerInfo.MyHeros.First().Spells[1], 1 );

            Assert.AreEqual( cbt.Monsters[1].EffectivHPMax - (ctx.PlayerInfo.MyHeros[0].Spells[1].KindOfEffect.Damage*2), cbt.Monsters[1].HP );
            Assert.AreEqual( DamageTypeEnum.Fire, cbt.DamageOnTime[cbt.Monsters[1]].DamageType );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells[1].KindOfEffect.DamagePerTurn * 2, cbt.DamageOnTime[cbt.Monsters[1]].EffectiveDamagePerTurn );
            cbt.SpellManager.HeroLaunchSpell( ctx.PlayerInfo.MyHeros.First().Spells[1], 2 );
            Assert.AreEqual( cbt.Monsters[2].EffectivHPMax - (ctx.PlayerInfo.MyHeros[0].Spells[1].KindOfEffect.Damage), cbt.Monsters[2].HP );
            Assert.AreEqual( DamageTypeEnum.Fire, cbt.DamageOnTime[cbt.Monsters[1]].DamageType );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells[1].KindOfEffect.DamagePerTurn, cbt.DamageOnTime[cbt.Monsters[2]].EffectiveDamagePerTurn );
        }
        [Test]
        public void ApplyDammageOnTime()
        {
            GameContext ctx = GameContext.CreateNewGame( 1 );
            CombatManager cbt = new CombatManager( ctx.PlayerInfo.MyHeros.ToArray(), ctx );
            cbt.SpellManager.MoveCharacter<BaseHeros>( 0, 3 );
            S_M_D.Spell.Spells spell = cbt.Heros[0].Spells[3];
            cbt.Monsters.ToList().ForEach( m =>
                                             {
                                                 m.HP = spell.KindOfEffect.Damage + spell.KindOfEffect.DamagePerTurn + 5;
                                                 m.EffectivHPMax = spell.KindOfEffect.Damage + spell.KindOfEffect.DamagePerTurn + 5;
                                             } );
            cbt.SpellManager.HeroLaunchSpell( spell, 0 );
            for (int i = 0; i < 4; i++)
            {
                cbt.AutomaticNextTurn();
            }
            Assert.AreEqual( 5, cbt.Monsters[0].HP );
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
            ctx.PlayerInfo.MyHeros[1].HP -= ctx.PlayerInfo.MyHeros[1].Spells[2].KindOfEffect.Damage + 1;
            cbt.SpellManager.HeroLaunchSpell( ctx.PlayerInfo.MyHeros[1].Spells[2], 1 );
            Assert.AreEqual( cbt.Heros[1].EffectivHPMax - 1, cbt.Heros[1].HP );
            cbt.Monsters[0].HP = 1;
            cbt.Monsters[0].EffectivHPMax = ctx.PlayerInfo.MyHeros[1].Spells[2].KindOfEffect.Damage + 2;
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
            Assert.AreEqual(cbt.CharacterOrderAttack[3], cbt.AutomaticNextTurn());
            Assert.AreEqual(cbt.CharacterOrderAttack[4], cbt.AutomaticNextTurn());
            Assert.AreEqual(cbt.CharacterOrderAttack[5], cbt.AutomaticNextTurn());
            Assert.AreEqual( cbt.CharacterOrderAttack[0], cbt.AutomaticNextTurn() );
            Assert.AreEqual(cbt.CharacterOrderAttack[3], cbt.AutomaticNextTurn());
            Assert.AreEqual(cbt.CharacterOrderAttack[4], cbt.AutomaticNextTurn());
            Assert.AreEqual(cbt.CharacterOrderAttack[5], cbt.AutomaticNextTurn());
            Assert.AreEqual( cbt.CharacterOrderAttack[0], cbt.AutomaticNextTurn() );
            Assert.AreEqual(cbt.CharacterOrderAttack[3], cbt.AutomaticNextTurn());
            Assert.AreEqual(cbt.CharacterOrderAttack[4], cbt.AutomaticNextTurn());
            Assert.AreEqual(cbt.CharacterOrderAttack[5], cbt.AutomaticNextTurn());
            Assert.AreEqual( cbt.CharacterOrderAttack[0], cbt.AutomaticNextTurn() );
            Assert.AreEqual(cbt.CharacterOrderAttack[3], cbt.AutomaticNextTurn());
            Assert.AreEqual(cbt.CharacterOrderAttack[4], cbt.AutomaticNextTurn());
            Assert.AreEqual(cbt.CharacterOrderAttack[5], cbt.AutomaticNextTurn());
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
            Assert.AreEqual( 3, ctx.PlayerInfo.DeadHero.Count );
            Assert.AreEqual( true, cbt.Heros[1].IsDead );
            Assert.AreEqual( true, cbt.Heros[2].IsDead );
            Assert.AreEqual( true, cbt.Heros[3].IsDead );
        }

        [Test]
        public void RewardTest()
        {
            GameContext ctx = GameContext.CreateNewGame( 1 );
            ctx.DungeonManager.InitializedCatalogue();
            ctx.DungeonManager.CreateDungeon( ctx.PlayerInfo.MyHeros.ToArray(), ctx.DungeonManager.MapCatalogue.First() );
            ctx.DungeonManager.LaunchCombat();
            CombatManager cbt = ctx.DungeonManager.CbtManager;
            Random rnd = new Random(1);
            cbt.ApplyRewward();
            UseRndMultipleTime( rnd, 38);
            int i = rnd.Next( 30 );
            int nbMatchItem = ctx.AllItemInGame
                                .Where( c => c.Itemtype == BaseItem.ItemTypes.Trinket )
                                .Count();
            BaseItem result = ctx.AllItemInGame
                        .Where( c => c.Itemtype == BaseItem.ItemTypes.Trinket )
                        .ToList()[rnd.Next( nbMatchItem )];
            int xp = 0;
            cbt.Monsters.ToList().ForEach( h => xp += h.GiveXp );
            Assert.AreEqual( xp, ctx.DungeonManager.Reward.Xp);
            Assert.AreEqual( result, ctx.DungeonManager.Reward.Items.First() );
            Assert.AreEqual( 100, ctx.DungeonManager.Reward.Money );
        }
        [Test]
        public void MovePlayer()
        {
            GameContext ctx = GameContext.CreateNewGame( 1 );
            CombatManager cbt = new CombatManager( ctx.PlayerInfo.MyHeros.ToArray(), ctx );
            string herosName = ctx.PlayerInfo.MyHeros[0].CharacterName;
            string herosName1 = ctx.PlayerInfo.MyHeros[3].CharacterName;
            Assert.AreEqual( herosName, cbt.Heros[0].CharacterName );
            Assert.AreEqual( herosName1, cbt.Heros[3].CharacterName );
            cbt.SpellManager.MoveCharacter<BaseHeros>( 0, 3 );
            Assert.AreEqual( herosName, cbt.Heros[3].CharacterName );
            Assert.AreEqual( herosName1, cbt.Heros[0].CharacterName );
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
