using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;

namespace S_M_D.Spell
{
    public class FireBall : Spells
    {
        int[] fireValueByLvl = new int[4] { 2, 4, 8, 10 };
        int[] damageRatioByLvl = new int[4] { 2, 3, 4, 5 };
        readonly Mage _mage;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paladin"></param>
        public FireBall(Mage mage)
            : base("FireBall", 400, "Boule de feu", 5, 0, DamageTypeEnum.Magical, 1, new bool[4] { false, false, true, true }, new bool[4] { false, true, true, true })
        {
            _mage = mage;
            FireOnTime = new FireOnTime(mage.EffectivDamage, damageRatioByLvl[Lvl], fireValueByLvl[Lvl], 2,true);

        }

        public override void  updateSpell()
        {
            FireOnTime = new FireOnTime(mage.EffectivDamage, damageRatioByLvl[Lvl], fireValueByLvl[Lvl], 2,true);
        }



        public Mage mage
        {
            get
            {
                return _mage;
            }
        }

    }
}
