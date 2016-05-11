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
        readonly SpellEffect spellEffect;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paladin"></param>
        public BasicAttackMage(Mage mage)
            : base("BasicAttack", 400, "Attaque basique du priest", 0, 0, DamageTypeEnum.Physical, 1)
        {
            _mage = mage;
            SpellEffect spellEffect = new SpellEffect();
            spellEffect.Damage = mage.Damage;
            spellEffect.CritChance = mage.CritChance;
            spellEffect.HitChance = mage.HitChance;
        }

        public override void levelUp()
        {
            spellEffect.Damage = Convert.ToInt32(mage.Damage * 1.1);
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