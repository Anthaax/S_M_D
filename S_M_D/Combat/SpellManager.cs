﻿using System;
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
        public void LaunchDamageSpellOnMonster(Spells spell, int position)
        {
            ApplyDamage<BaseMonster>( spell, position );
        }
        public void LaunchDamageSpellOnHero( Spells spell, int postition )
        {
            ApplyDamage<BaseHeros>( spell, postition );
        }
        public void LaunchHealOnHero( Spells spell, int position)
        {
            ApplyHeal<BaseHeros>( spell, position );
        }
        public void LaunchHealOnMonster( Spells spell, int position )
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
                character = GetTheCharacter( typeOfT, position );
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
                else if(spell.KindOfEffect.CanBeBlock)
                character.HP += spellEffect.Damage;
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
    }
}
