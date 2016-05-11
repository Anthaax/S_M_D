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
        readonly SpellEffect _spellEffect;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paladin"></param>
        public BasicAttackPaladin(Paladin paladin)
            :base("BasicAttack", 400, "Attaque basique du paladin", 0, 0, DamageTypeEnum.Physical, 1, new bool[4] { true, true, false, false }, new bool[4] { true, true, false, false })
        {
            _paladin = paladin;
            _spellEffect = new SpellEffect();
            updateSpell();
        }

        public override void updateSpell()
        {
            _spellEffect.Damage = _paladin.Damage;
            _spellEffect.CritChance = _paladin.CritChance;
            _spellEffect.HitChance = _paladin.HitChance;
        }
        public override void levelUp()
        {
            _spellEffect.Damage = Convert.ToInt32(Paladin.Damage * 1.1);
            Lvl += 1;
        }

        public Paladin Paladin
        {
            get
            {
                return _paladin;
            }
        }

        public override SpellEffect UseSpell()
        {
            return _spellEffect;
        }
    }
}
