using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;


namespace S_M_D.Spell
{
    public class BasicAttackMage : Spells
    {
        readonly Mage _mage;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paladin"></param>
        public BasicAttackMage(Mage mage)
            : base("BasicAttack", 400, "Attaque basique du paladin", 0, 0, DamageTypeEnum.Physical, 1)
        {
            _mage = mage;
        }

        public Mage mage
        {
            get
            {
                return _mage;
            }
        }

        protected override void UseSpell()
        {

        }
    }
}