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

        public void LaunchDamageSpellOnMonster(Spells spell, int postition)
        {
            if (!spell.TargetManager.CanBeTargetable[postition]) throw new ArgumentException( "Imposible to have this taget" );
            int i = 0;
            spell.CooldownManager.SpellsWasUsed();
            while (i < spell.TargetManager.Radius & i+postition < _combatManager.Monsters.Count())
            {
                BaseMonster monster = _combatManager.Monsters[postition];
                if (spell.KindOfEffect.CanBeBlock && _combatManager.GameContext.Rnd.Next( 100 ) >= monster.Resist( spell.KindOfEffect.DamageType ))
                {
                    monster.HP -= spell.KindOfEffect.Damage;
                    Spells damageOnTimeSpell = null;
                    _combatManager.DamageOnTime.TryGetValue( monster, out damageOnTimeSpell );
                    if (spell.KindOfEffect.DamageType == damageOnTimeSpell.KindOfEffect.DamageType)
                        spell.KindOfEffect.DamagePerTurn += damageOnTimeSpell.KindOfEffect.DamagePerTurn;
                    _combatManager.DamageOnTime[monster] = spell;
                }
                else if (!spell.KindOfEffect.CanBeBlock)
                    monster.HP -= spell.KindOfEffect.Damage;
                else
                    monster.HP += spell.KindOfEffect.Damage;
                i++;
            }
        }
        public void LaunchDamageSpellOnHero( Spells spell, int postition )
        {
            if (!spell.TargetManager.CanBeTargetable[postition]) throw new ArgumentException( "Imposible to have this taget" );
            int i = 0;
            spell.CooldownManager.SpellsWasUsed();
            while (i < spell.TargetManager.Radius & i + postition < _combatManager.Heros.Count())
            {
                BaseHeros hero = _combatManager.Heros[postition];
                hero.HP -= spell.KindOfEffect.Damage;
                if (spell.KindOfEffect.CanBeBlock && _combatManager.GameContext.Rnd.Next( 100 ) >= hero.Resist( spell.KindOfEffect.DamageType ))
                {
                    Spells damageOnTimeSpell = null;
                    _combatManager.DamageOnTime.TryGetValue( hero, out damageOnTimeSpell );
                    if (spell.KindOfEffect.DamageType == damageOnTimeSpell.KindOfEffect.DamageType)
                        spell.KindOfEffect.DamagePerTurn += damageOnTimeSpell.KindOfEffect.DamagePerTurn;
                    _combatManager.DamageOnTime[hero] = spell;
                }
                else if (!spell.KindOfEffect.CanBeBlock)
                    hero.HP -= spell.KindOfEffect.Damage;
                else
                    hero.HP += spell.KindOfEffect.Damage;
                i++;
            }
        }
    }
}
