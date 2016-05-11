using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;

namespace S_M_D.Spell
{
    public class BasicAttackWarrior : Spells
    {
        readonly Warrior _warrior;
        readonly SpellEffect _spellEffect;
        public BasicAttackWarrior( Warrior warrior )
            :base("BasicAttack", 400, "Attaque basique du warrior : inflige " + warrior.Damage + " dégat à un ennemi", 0, 0, DamageTypeEnum.Physical, 1, new bool[4] { true, true, false, false }, new bool[4] { true, true, false, false })
        {
            _warrior = warrior;
            _spellEffect = new SpellEffect();
            updateSpell();
        }

        public override void updateSpell()
        {
            _spellEffect.Damage = _warrior.Damage;
            _spellEffect.CritChance = _warrior.CritChance;
            _spellEffect.HitChance = _warrior.HitChance;
        }

        public override void levelUp()
        {
            _spellEffect.Damage = Convert.ToInt32(Warrior.Damage * 1.1);
            Lvl += 1;
        }

        public Warrior Warrior
        {
            get
            {
                return _warrior;
            }
        }

        public SpellEffect SpeelEffect
        {
            get
            {
                return _spellEffect;
            }
        }

        /// <summary>
        /// Use effect of the spell 
        /// </summary>
        public override SpellEffect UseSpell()
        {
            return _spellEffect;
        }
    }
}
