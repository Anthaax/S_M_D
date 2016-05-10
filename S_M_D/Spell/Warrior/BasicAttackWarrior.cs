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
        readonly SpellEffect spellEffect;
        public BasicAttackWarrior( Warrior warrior )
            :base("BasicAttack", 400, "Attaque basique du paladin : inflige " + warrior.Damage + " dégat à un ennemi", 0, 0, DamageTypeEnum.Physical, 1)
        {
            _warrior = warrior;
            SpellEffect spellEffect = new SpellEffect();
            spellEffect.Damage = Warrior.Damage;
            spellEffect.CritChance = Warrior.CritChance;
            spellEffect.HitChance = Warrior.HitChance;
        }

        public override void levelUp()
        {
            spellEffect.Damage = Convert.ToInt32(Warrior.Damage * 1.1);
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
                return spellEffect;
            }
        }

        /// <summary>
        /// Use effect of the spell 
        /// </summary>
        protected override void UseSpell(  )
        {
            
        }
    }
}
