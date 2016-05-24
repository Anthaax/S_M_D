using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Spell;
using S_M_D.Character;

namespace S_M_D.Combat
{
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
            if (spell.KindOfEffect.DamageType == DamageTypeEnum.Heal)
                LaunchHealOnHero( spell, position );
            else
                LaunchDamageSpellOnMonster( spell, position );
        }
        public void MonsterLaunchSpell( Spells spell, int position )
        {
            if (spell.KindOfEffect.DamageType == DamageTypeEnum.Heal)
                LaunchHealOnMonster( spell, position );
            else
                LaunchDamageSpellOnHero( spell, position );
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
            while (i < spell.TargetManager.Radius & i + position <= _combatManager.Heros.Count())
            {
                character = GetTheCharacter( typeOfT, position + i );
                if( character != null)
                {
                    character.HP -= spellEffect.Damage;
                    if (spell.KindOfEffect.CanBeBlock && _combatManager.GameContext.Rnd.Next( 100 ) >= character.Resist( spell.KindOfEffect.DamageType ))
                    {
                        KindOfEffect existentSpellEffect = null;
                        _combatManager.DamageOnTime.TryGetValue( character, out existentSpellEffect );
                        if (existentSpellEffect == null)
                            _combatManager.DamageOnTime[character] = spellEffect;
                        else if (spellEffect.DamageType == existentSpellEffect.DamageType)
                            existentSpellEffect.EffectiveDamagePerTurn += spellEffect.DamagePerTurn;
                        else
                            _combatManager.DamageOnTime[character] = spellEffect;
                    }
                    else if (spell.KindOfEffect.CanBeBlock)
                        character.HP += spellEffect.Damage;
                    suppresDeadCharacter<T>( i + position );
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
        private BaseCharacter GetTheCharacter(Type t, int position)
        {
            BaseCharacter character;
            if (t == typeof( BaseHeros ))
                character = _combatManager.Heros[position];
            else
                character = _combatManager.Monsters[position];
            return character;
        }
        private void suppresDeadCharacter<T>(int position)
        {
            Type typeOfT = typeof( T );
            BaseCharacter charac = GetTheCharacter(typeOfT,position);
            if(charac.HP <= 0)
            {
                if (typeOfT == typeof( BaseHeros ))
                    _combatManager.Heros[position] = null;
                else
                    _combatManager.Monsters[position] = null;
            }
            _combatManager.CharacterOrderAttack.RemoveAll( c => c.HP <= 0 );
            _combatManager.GameContext.PlayerInfo.MyHeros.RemoveAll( c => c.HP <= 0 );
        }
    }
}
