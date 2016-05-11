using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;


namespace S_M_D.Spell
{
    public class BasicAttackPaladin : Spells
    {
        readonly Paladin _paladin;
        readonly SpellEffect spellEffect;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paladin"></param>
        public BasicAttackPaladin(Paladin paladin)
            :base("BasicAttack", 400, "Attaque basique du paladin", 0, 0, DamageTypeEnum.Physical, 1)
        {
            _paladin = paladin;
            SpellEffect spellEffect = new SpellEffect();
            spellEffect.Damage = paladin.Damage;
            spellEffect.CritChance = paladin.CritChance;
            spellEffect.HitChance = paladin.HitChance;
        }

        public override void levelUp()
        {
            spellEffect.Damage = Convert.ToInt32(Paladin.Damage * 1.1);
            Lvl += 1;
        }

        public Paladin Paladin
        {
            get
            {
                return _paladin;
            }
        }

        protected override void UseSpell()
        {
             
        }
    }
}
