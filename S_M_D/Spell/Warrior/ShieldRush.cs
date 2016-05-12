using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Spell
{
    class ShieldRush : Spells
    {
        readonly Warrior _warrior;
        int[] _damageRatioByLvl = new int[4] { 1, 1, 1, 1 };

        public ShieldRush(Warrior warrior)
            :base("ShieldRush", 400, "Donne un coup de bouclier", 0, 0, DamageTypeEnum.Physical, 1, new bool[4] { true, true, false, false }, new bool[4] { true, true, false, false })
        {
            _warrior = warrior;
            DamageAndEffect = new DamageAndEffect(2,true, _warrior.EffectivDamage, _damageRatioByLvl[Lvl]);
        }

        public override void updateSpell()
        {
            DamageAndEffect = new DamageAndEffect(2,true,_warrior.EffectivDamage, _damageRatioByLvl[Lvl]);
        }

        public Warrior Warrior
        {
            get
            {
                return _warrior;
            }
        }

        public int[] DamageRatioByLvl
        {
            get
            {
                return _damageRatioByLvl;
            }

            set
            {
                _damageRatioByLvl = value;
            }
        }
    }
}
