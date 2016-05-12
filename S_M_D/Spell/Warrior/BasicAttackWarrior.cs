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
        BasicDamagePhysical _spellEffect;
        
        int[] damageRatioByLvl = new int[4] { 1, 1, 1, 1 };
        public BasicAttackWarrior( Warrior warrior )
            :base("BasicAttack", 400, "Attaque basique du warrior : inflige " + warrior.Damage + " dégat à un ennemi", 0, 0, DamageTypeEnum.Physical, 1, new bool[4] { true, true, false, false }, new bool[4] { true, true, false, false })
        {
            _warrior = warrior;
            SpellEffect = new BasicDamagePhysical(_warrior.EffectivDamage, damageRatioByLvl[Lvl]);
        }

        public override void updateSpell()
        {
            SpellEffect = new BasicDamagePhysical(_warrior.EffectivDamage, damageRatioByLvl[Lvl]);
        }

        public Warrior Warrior
        {
            get
            {
                return _warrior;
            }
        }

        internal BasicDamagePhysical SpellEffect
        {
            get
            {
                return _spellEffect;
            }

            set
            {
                _spellEffect = value;
            }
        }
    }
}
