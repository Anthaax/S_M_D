using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S_M_D.Character;

namespace S_M_D.Spell
{
    public class BasicAttackWarrior : Spell
    {
        readonly Warrior _warrior;
        public BasicAttackWarrior( Warrior warrior )
            :base("BasicAttack", 400, "Attaque basique du paladin", 0, 0, DamageTypeEnum.Physical)
        {
            _warrior = warrior;
        }

        public Warrior Paladin
        {
            get
            {
                return _warrior;
            }
        }

        protected override void UseSpell( BaseMonster target )
        {
            Random rnd = new Random();
            if (rnd.Next( 100 ) <= Paladin.HitChance)
            {
                target.HP -= Paladin.Damage;
            }
        }
    }
}
}
