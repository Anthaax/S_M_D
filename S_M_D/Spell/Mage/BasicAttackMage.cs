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
        BasicDamageMagical _spellEffect;
        int[] damageRatioByLvl = new int[4] { 1, 1, 1, 1 };
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paladin"></param>
        public BasicAttackMage(Mage mage)
            : base("BasicAttack", 400, "Attaque basique du priest", 0, 0, DamageTypeEnum.Physical, 1,new bool[4] { true, true, false, false } , new bool[4] { true, true, false, false } )
        {
            
            _mage = mage;
            
            SpellEffect = new BasicDamageMagical(mage.EffectivDamage, damageRatioByLvl[Lvl]);

        }

        public override void updateSpell()
        {
            SpellEffect = new BasicDamageMagical(mage.EffectivDamage, damageRatioByLvl[Lvl]);
        }


        public Mage mage
        {
            get
            {
                return _mage;
            }
        }

        internal BasicDamageMagical SpellEffect
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