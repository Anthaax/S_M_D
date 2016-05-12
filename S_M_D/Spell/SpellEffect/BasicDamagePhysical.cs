using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Spell
{
    public class BasicDamagePhysical
    {
        int _damage;
        DamageTypeEnum _type;
        public BasicDamagePhysical(int damage, int rate)
        {
            Damage = damage * rate;
            Type = DamageTypeEnum.Physical;
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
