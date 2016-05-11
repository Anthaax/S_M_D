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
        BasicDamagePhysical _spellEffect;
        int[] damageRatioByLvl = new int[4] { 1, 1, 1, 1 };
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paladin"></param>
        public BasicAttackPriest(Priest priest)
            : base("BasicAttack", 400, "Attaque basique du priest", 0, 0, DamageTypeEnum.Physical, 1, new bool[4] { true, true, false, false }, new bool[4] { true, true, false, false })
        {
            _priest = priest;
            SpellEffect = new BasicDamagePhysical(_priest.EffectivDamage, damageRatioByLvl[Lvl]);
        }

        public override void updateSpell()
        {
            SpellEffect = new BasicDamagePhysical(_priest.EffectivDamage, damageRatioByLvl[Lvl]);
        }


        public Priest priest
        {
            get
            {
                return _priest;
            }
        }

        internal BasicDamagePhysical SpellEffect
        {
            get
            {
                return _spellEffect;
            }

            set
            {
                _spellEffect = value;
            }
        }
    }
}