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
        readonly SpellEffect _spellEffect;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paladin"></param>
        public BasicAttackPriest(Priest priest)
            : base("BasicAttack", 400, "Attaque basique du priest", 0, 0, DamageTypeEnum.Physical, 1, new bool[4] { true, true, false, false }, new bool[4] { true, true, false, false })
        {
            _priest = priest;
            _spellEffect = new SpellEffect();
            updateSpell();
        }

        public override void updateSpell()
        {
            _spellEffect.Damage = _priest.Damage;
            _spellEffect.CritChance = _priest.CritChance;
            _spellEffect.HitChance = _priest.HitChance;
        }
        public override void levelUp()
        {
            _spellEffect.Damage = Convert.ToInt32(priest.Damage * 1.1);
            Lvl += 1;
        }

        public Priest priest
        {
            get
            {
                return _priest;
            }
        }

        public override SpellEffect UseSpell()
        {
            return _spellEffect;
        }
    }
}