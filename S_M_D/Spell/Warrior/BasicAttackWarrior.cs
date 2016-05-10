using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S_M_D.Character;

namespace S_M_D.Spell
{
    public class BasicAttackWarrior : Spells
    {
        readonly Warrior _warrior;
        public BasicAttackWarrior( Warrior warrior )
            :base("BasicAttack", 400, "Attaque basique du paladin : inflige " + warrior.Damage + " dégat à un ennemi", 0, 0, DamageTypeEnum.Physical, 1)
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

        protected override void UseSpell(  )
        {
            
        }
    }
}
