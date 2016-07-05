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

            AdjustManaAndHp( cbt, ctx.PlayerInfo.MyHeros.First().Spells.First(), 1 );

            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First(), cbt.CharacterOrderAttack.First() );
            cbt.SpellManager.HeroLaunchSpell( ctx.PlayerInfo.MyHeros.First().Spells.First(), 0 );
            Assert.AreEqual( 1, ctx.PlayerInfo.MyHeros.First().Mana );
            Assert.AreEqual( 20, cbt.Monsters.First().HP );
            Assert.AreEqual( true, ctx.PlayerInfo.MyHeros.First().Spells.First().CooldownManager.IsOnCooldown );
            Assert.Throws<ArgumentException>( () => cbt.SpellManager.HeroLaunchSpell( ctx.PlayerInfo.MyHeros.First().Spells[1], 0) );
            SetIsOnCooldownFasle( ctx.PlayerInfo.MyHeros.First().Spells.First() );
            Assert.Throws<ArgumentException>( () => cbt.SpellManager.HeroLaunchSpell( ctx.PlayerInfo.MyHeros.First().Spells[1], 0 ) );
            cbt.SpellManager.HeroLaunchSpell( ctx.PlayerInfo.MyHeros.First().Spells[0], 1 );
            Assert.AreEqual( 20, cbt.Monsters[1].HP );
        }
        [Test]
        public void ManaUtilisationTest()
        {
            GameContext ctx = GameContext.CreateNewGame( 1 );
            CombatManager cbt = new CombatManager( ctx.PlayerInfo.MyHeros.ToArray(), ctx );

            AdjustManaAndHp( cbt, ctx.PlayerInfo.MyHeros.First().Spells[1], 1 );
            cbt.SpellManager.HeroLaunchSpell( ctx.PlayerInfo.MyHeros.First().Spells[1], 1 );
            Assert.Throws<ArgumentException>( () => cbt.SpellManager.HeroLaunchSpell( ctx.PlayerInfo.MyHeros.First().Spells[1], 1 ));
        }
        [Test]
        public void MultipleEffectOnOneMonster()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
            CombatManager cbt = new CombatManager( ctx.PlayerInfo.MyHeros.ToArray(), ctx );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First(), cbt.CharacterOrderAttack.First() );

            AdjustManaAndHp( cbt, ctx.PlayerInfo.MyHeros.First().Spells[1], 2 );
            
            cbt.SpellManager.HeroLaunchSpell( ctx.PlayerInfo.MyHeros.First().Spells[1], 1 );
            SetIsOnCooldownFasle( ctx.PlayerInfo.MyHeros.First().Spells[1] );

            cbt.SpellManager.HeroLaunchSpell( ctx.PlayerInfo.MyHeros.First().Spells[1], 1 );
            SetIsOnCooldownFasle( ctx.PlayerInfo.MyHeros.First().Spells[1] );

            Assert.AreEqual( 20 + ctx.PlayerInfo.MyHeros.First().Spells[1].KindOfEffect.DamagePerTurn * 2, cbt.Monsters[1].HP );
            Assert.AreEqual( DamageTypeEnum.Fire, cbt.DamageOnTime[cbt.Monsters[1]].DamageType );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells[1].KindOfEffect.DamagePerTurn * 2, cbt.DamageOnTime[cbt.Monsters[1]].EffectiveDamagePerTurn );

            AdjustManaAndHp( cbt, ctx.PlayerInfo.MyHeros.First().Spells[1], 1 );
            cbt.SpellManager.HeroLaunchSpell( ctx.PlayerInfo.MyHeros.First().Spells[1], 2 );

            Assert.AreEqual( 20 + ctx.PlayerInfo.MyHeros.First().Spells[1].KindOfEffect.DamagePerTurn , cbt.Monsters[2].HP );
            Assert.AreEqual( DamageTypeEnum.Fire, cbt.DamageOnTime[cbt.Monsters[1]].DamageType );
            Assert.AreEqual( ctx.PlayerInfo.MyHeros.First().Spells[1].KindOfEffect.DamagePerTurn, cbt.DamageOnTime[cbt.Monsters[2]].EffectiveDamagePerTurn );
        }
        [Test]
        public void ApplyDammageOnTime()
        {
            GameContext ctx = GameContext.CreateNewGame( 1 );
            CombatManager cbt = new CombatManager( ctx.PlayerInfo.MyHeros.ToArray(), ctx );
            cbt.SpellManager.MoveCharacter<BaseHeros>( 0, 3 );
            S_M_D.Spell.Spells spell = cbt.Heros[0].Spells[2];
            AdjustManaAndHp( cbt, spell, 1 );

            cbt.SpellManager.HeroLaunchSpell( spell, 0 );
            for (int i = 0; i < 8; i++)
            {
                cbt.NextTurn();
            }
            Assert.AreEqual( 20, cbt.Monsters[0].HP );
            KindOfEffect effect;
            cbt.DamageOnTime.TryGetValue( cbt.Monsters[0], out effect );
            Assert.AreEqual( spell.KindOfEffect.Turn - 1, effect.EffectiveTurn );
            Assert.AreEqual( spell.KindOfEffect.Turn, effect.Turn );
            for (int i = 0; i < 3*8; i++)
            {
                cbt.NextTurn();
            }
            cbt.DamageOnTime.TryGetValue( cbt.Monsters[0], out effect );
            Assert.IsNull( effect );
        }
        [Test]
        public void ChangeTurn()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
            CombatManager cbt = new CombatManager( ctx.PlayerInfo.MyHeros.ToArray(), ctx);
            Assert.AreEqual(cbt.CharacterOrderAttack[0], cbt.GetCharacterTurn());
            Assert.AreEqual(cbt.CharacterOrderAttack[1], cbt.AutomaticNextTurn());
            Assert.AreEqual(cbt.CharacterOrderAttack[2], cbt.AutomaticNextTurn());
            Assert.AreEqual(cbt.CharacterOrderAttack[6], cbt.AutomaticNextTurn());
            Assert.AreEqual( cbt.CharacterOrderAttack[0], cbt.AutomaticNextTurn() );
            Assert.AreEqual(cbt.CharacterOrderAttack[1], cbt.AutomaticNextTurn());
            Assert.AreEqual(cbt.CharacterOrderAttack[2], cbt.AutomaticNextTurn());
            Assert.AreEqual(cbt.CharacterOrderAttack[6], cbt.AutomaticNextTurn());
            Assert.AreEqual( cbt.CharacterOrderAttack[0], cbt.AutomaticNextTurn() );
            Assert.AreEqual(cbt.CharacterOrderAttack[1], cbt.AutomaticNextTurn());
            Assert.AreEqual(cbt.CharacterOrderAttack[2], cbt.AutomaticNextTurn());
            Assert.AreEqual(cbt.CharacterOrderAttack[6], cbt.AutomaticNextTurn());
            Assert.AreEqual( cbt.CharacterOrderAttack[0], cbt.AutomaticNextTurn() );
            Assert.AreEqual(cbt.CharacterOrderAttack[1], cbt.AutomaticNextTurn());
            Assert.AreEqual(cbt.CharacterOrderAttack[2], cbt.AutomaticNextTurn());
            Assert.AreEqual(cbt.CharacterOrderAttack[6], cbt.AutomaticNextTurn());
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
            UseRndMultipleTime( rnd, 41);
            int i = rnd.Next( 30 );
            int nbMatchItem = ctx.AllItemInGame
                                .Where( c => c.Itemtype == BaseItem.ItemTypes.Armor )
                                .Count();
            BaseItem result = ctx.AllItemInGame
                        .Where( c => c.Itemtype == BaseItem.ItemTypes.Armor )
                        .ToList()[rnd.Next( nbMatchItem )];
            int xp = 0;
            cbt.Monsters.ToList().ForEach( h => xp += h.GiveXp );
            Assert.AreEqual( xp, ctx.DungeonManager.Reward.Xp);
            //Assert.AreEqual( result, ctx.DungeonManager.Reward.Items.First() );
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
        [Test]
        public void UpdateCooldown()
        {
            GameContext ctx = GameContext.CreateNewGame( 1 );
            CombatManager cbt = new CombatManager( ctx.PlayerInfo.MyHeros.ToArray(), ctx );
            BaseHeros heros = cbt.GetCharacterTurn() as BaseHeros;
            cbt.SpellManager.HeroLaunchSpell( heros.Spells.First(), 0 );
            cbt.AutomaticNextTurn();
            cbt.AutomaticNextTurn();
            cbt.AutomaticNextTurn();
            cbt.AutomaticNextTurn();
            cbt.AutomaticNextTurn();
            Assert.AreEqual( false, heros.Spells.First().CooldownManager.IsOnCooldown );
            cbt.SpellManager.HeroLaunchSpell( heros.Spells[1], 1 );
            cbt.AutomaticNextTurn();
            cbt.AutomaticNextTurn();
            cbt.AutomaticNextTurn();
            cbt.AutomaticNextTurn();
            cbt.AutomaticNextTurn();
            Assert.AreEqual( false, heros.Spells[1].CooldownManager.IsOnCooldown );
        }
        [Test]
        public void PositionAsTrue()
        {
            GameContext ctx = GameContext.CreateNewGame( 1 );
            CombatManager cbt = new CombatManager( ctx.PlayerInfo.MyHeros.ToArray(), ctx );
            Assert.AreEqual( 0, cbt.GetCharacterTurnPosition() );
        }
        [Test]
        public void LaunchSpellWithMultipleMethod()
        {
            GameContext ctx = GameContext.CreateNewGame( 1 );
            CombatManager cbt = new CombatManager( ctx.PlayerInfo.MyHeros.ToArray(), ctx );
            List<Spell.Spells> spells = cbt.IaMonster.SpellsToLaunch( cbt.Monsters.First() );
            Spell.Spells spell = null;
            if (spells.Count != 0)
            {
                spell = spells.First();
                int[] position = cbt.IaMonster.GetPositionsHeros();
                cbt.IaMonster.LauchSpell( spell, position[0] );
                Assert.AreEqual( cbt.Heros[position[0]].EffectivHPMax - cbt.Heros[position[0]].HP, spell.KindOfEffect.Damage );
            }            
        }
        private void UseRndMultipleTime( Random rnd, int nbTime )
        {
            for (int i = 0; i < nbTime; i++)
            {
                rnd.Next();
            }
        }
        private void AdjustManaAndHp(CombatManager cbt, S_M_D.Spell.Spells spell, int numberTimeUseSpell)
        {
            cbt.CharacterOrderAttack.ForEach( m =>
                                        {
                                            m.Mana = 1 + spell.ManaCost * numberTimeUseSpell;
                                            m.EffectivHPMax = 1 + spell.ManaCost * numberTimeUseSpell;
                                            m.HP = 20 + spell.KindOfEffect.Damage*numberTimeUseSpell + spell.KindOfEffect.DamagePerTurn * numberTimeUseSpell ;
                                            m.EffectivHPMax = 20 + spell.KindOfEffect.Damage * numberTimeUseSpell + spell.KindOfEffect.DamagePerTurn * numberTimeUseSpell;
                                        } );
        }
        private void SetIsOnCooldownFasle(Spell.Spells spell)
        {
            spell.CooldownManager.IsOnCooldown = false;
        }
    }
}
