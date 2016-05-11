using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Spell
{
    class BasicDamageMagical
    {
        int _damage;
        DamageTypeEnum _type;
        public BasicDamageMagical(int damage, int rate)
        {
            Damage = damage * rate;
            Type = DamageTypeEnum.Magical;
        }

        public int Damage
        {
            get
            {
                return _damage;
            }

            set
            {
                _damage = value;
            }
        }

        public DamageTypeEnum Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }
    }
}
