using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Spell;
using S_M_D.Character;

namespace S_M_D.Combat
{
    [Serializable]
    public class SpellManager
    {
        readonly CombatManager _combatManager;
        public SpellManager(CombatManager combatManager )
        {
            _combatManager = combatManager;
        }
        public bool[] WhoCanBeTargetable(Spells spell, int position)
        {
            return spell.TargetManager.WhoCanBeTargetable( position );
        }
        public void HeroLaunchSpell( Spells spell, int position )
        {
            if (spell.ManaCost > _combatManager.GetCharacterTurn().Mana) throw new ArgumentException( "Spell can't be launch hero haven't enought mana", "Mana" );
            if (spell.CooldownManager.IsOnCooldown) throw new ArgumentException( "Spell can't be launch he is on cooldown", "Cooldow" );
            _combatManager.GetCharacterTurn().Mana -= spell.ManaCost;
            if (spell.KindOfEffect.DamageType == DamageTypeEnum.Heal)
                LaunchHealOnHero( spell, position );
            else
                LaunchDamageSpellOnMonster( spell, position );
        }
        public void MonsterLaunchSpell( Spells spell, int position )
        {
            _combatManager.GetCharacterTurn().Mana -= spell.ManaCost;
            if (spell.KindOfEffect.DamageType == DamageTypeEnum.Heal)
                LaunchHealOnMonster( spell, position );
            else
                LaunchDamageSpellOnHero( spell, position );
        }
        public void ApplyDamageOnTime()
        {
            BaseCharacter charac = _combatManager.GetCharacterTurn();
            KindOfEffect effect;
            _combatManager.DamageOnTime.TryGetValue( charac, out effect );
            if(effect != null)
            {
                charac.HP -= effect.EffectiveDamagePerTurn;
                effect.EffectiveTurn--;
                if (effect.EffectiveTurn == 0)
                    _combatManager.DamageOnTime[charac] = null;
            }
        }
        private void LaunchDamageSpellOnMonster(Spells spell, int position)
        {
            ApplyDamage<BaseMonster>( spell, position );
        }
        private void LaunchDamageSpellOnHero( Spells spell, int postition )
        {
            ApplyDamage<BaseHeros>( spell, postition );
        }
        private void LaunchHealOnHero( Spells spell, int position)
        {
            if (spell.KindOfEffect.DamageType != DamageTypeEnum.Heal) throw new ArgumentException( "Impossible Heal with damageSpell" );
            ApplyHeal<BaseHeros>( spell, position );
        }
        private void LaunchHealOnMonster( Spells spell, int position )
        {
            if (spell.KindOfEffect.DamageType != DamageTypeEnum.Heal) throw new ArgumentException( "Impossible Heal with damageSpell" );
            ApplyHeal<BaseMonster>( spell, position );
        }
        private void ApplyDamage<T>( Spells spell , int position)
        {
            BaseCharacter character;
            Type typeOfT = typeof( T );
            if (!spell.TargetManager.CanBeTargetable[position]) throw new ArgumentException( "Imposible to have this taget" );
            int i = 0;
            spell.CooldownManager.SpellsWasUsed();
            KindOfEffect spellEffect = spell.OnLaunchSpell();
            while (i < spell.TargetManager.Radius & i + position < _combatManager.Heros.Count())
            {
                if (position + i < 4)
                    character = GetTheCharacter( typeOfT, position + i );
                else
                    character = GetTheCharacter( typeOfT, 3 );
                if( character != null)
                {
                    character.HP -= spellEffect.Damage;
                    if (spell.KindOfEffect.CanBeBlock && _combatManager.GameContext.Rnd.Next( 100,200 ) >= character.Resist( spell.KindOfEffect.DamageType ))
                    {
                        KindOfEffect existentSpellEffect = null;
                        _combatManager.DamageOnTime.TryGetValue( character, out existentSpellEffect );
                        if (existentSpellEffect == null)
                            _combatManager.DamageOnTime[character] = spellEffect;
                        else if (spellEffect.DamageType == existentSpellEffect.DamageType)
                        {
                            existentSpellEffect.EffectiveDamagePerTurn += spellEffect.DamagePerTurn;
                            existentSpellEffect.EffectiveTurn = Math.Max( spellEffect.Turn, existentSpellEffect.EffectiveTurn);
                        }
                        else
                            _combatManager.DamageOnTime[character] = spellEffect;
                    }
                    else if (spell.KindOfEffect.CanBeBlock)
                        character.HP += spellEffect.Damage;
                    SuppresDeadCharacter<T>( i + position );
                }
                i++;
            }
        }
        private void ApplyHeal<T>( Spells spell, int position )
        {
            BaseCharacter character;
            Type typeOfT = typeof( T );
            if (!spell.TargetManager.CanBeTargetable[position]) throw new ArgumentException( "Imposible to have this taget" );
            int i = 0;
            spell.CooldownManager.SpellsWasUsed();
            KindOfEffect spellEffect = spell.OnLaunchSpell();
            while (i < spell.TargetManager.Radius & i + position < _combatManager.Heros.Count())
            {
                character = GetTheCharacter( typeOfT, position );
                if (character.HP + spellEffect.Damage >= character.EffectivHPMax)
                    character.HP = character.EffectivHPMax;
                else
                    character.HP += spellEffect.Damage;
                i++;
            }
        }
        public void MoveCharacter<T>( int initialPosition, int newPosition)
        {
            BaseCharacter character;
            Type typeOfT = typeof( T );
            if (typeOfT == typeof(BaseHeros))
            {
                character = _combatManager.Heros[initialPosition];
                _combatManager.Heros[initialPosition] = _combatManager.Heros[newPosition];
                _combatManager.Heros[newPosition] = character as BaseHeros;
            }
            else
            {
                character = _combatManager.Monsters[initialPosition];
                _combatManager.Monsters[initialPosition] = _combatManager.Monsters[newPosition];
                _combatManager.Monsters[newPosition] = character as BaseMonster;
            }
        }
        private BaseCharacter GetTheCharacter(Type t, int position)
        {
            BaseCharacter character;
            if (t == typeof( BaseHeros ))
                character = _combatManager.Heros[position];
            else
                character = _combatManager.Monsters[position];
            return character;
        }
        private void SuppresDeadCharacter<T>(int position)
        {
            Type typeOfT = typeof( T );
            BaseCharacter charac = GetTheCharacter(typeOfT,position);
            if(charac.HP <= 0)
            {
                charac.IsDead = true;
            }
            _combatManager.CharacterOrderAttack.RemoveAll( c => c.HP <= 0 );
            _combatManager.GameContext.PlayerInfo.MyHeros.Where(c => c.HP <= 0).ToList().ForEach( c => c.Die() );
            _combatManager.GameContext.PlayerInfo.MyHeros.RemoveAll( c => c.HP <= 0 );
        }
        private bool CriticalHit()
        {
            return _combatManager.GameContext.Rnd.Next( 100 ) < _combatManager.GetCharacterTurn().EffectCritChance;
        }
    }
}
