using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;


namespace S_M_D.Spell
{
    public class BasicAttackPriest : Spells
    {
        readonly Priest _priest;
        readonly SpellEffect spellEffect;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paladin"></param>
        public BasicAttackPriest(Priest priest)
            : base("BasicAttack", 400, "Attaque basique du priest", 0, 0, DamageTypeEnum.Physical, 1)
        {
            _priest = priest;
            SpellEffect spellEffect = new SpellEffect();
            spellEffect.Damage = priest.Damage;
            spellEffect.CritChance = priest.CritChance;
            spellEffect.HitChance = priest.HitChance;
        }

        public override void levelUp()
        {
            spellEffect.Damage = Convert.ToInt32(priest.Damage * 1.1);
            Lvl += 1;
        }

        public Priest priest
        {
            get
            {
                return _priest;
            }
        }

        protected override void UseSpell()
        {

        }
    }
}