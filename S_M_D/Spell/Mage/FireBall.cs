using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;

namespace S_M_D.Spell
{
    public class FireBall : Spells
    {
        readonly Mage _mage;
        readonly SpellEffect spellEffect;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paladin"></param>
        public FireBall(Mage mage)
            : base("FireBall", 400, "Boule de feu", 5, 0, DamageTypeEnum.Magical, 1)
        {
            _mage = mage;
            SpellEffect spellEffect = new SpellEffect();
            spellEffect.Damage = mage.Damage*2;
            spellEffect.CritChance = mage.CritChance;
            spellEffect.HitChance = mage.HitChance;
            spellEffect.Fireing = true;
            spellEffect.FireValue = 2;
            spellEffect.FireTime = 2;
        }

        public override void levelUp()
        {
            spellEffect.Damage = Convert.ToInt32(mage.Damage * 2.5);
            Lvl += 1;
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
