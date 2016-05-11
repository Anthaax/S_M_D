﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;


namespace S_M_D.Spell
{
    public class BasicAttackMage : Spells
    {
        readonly Mage _mage;
        readonly SpellEffect _spellEffect;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paladin"></param>
        public BasicAttackMage(Mage mage)
            : base("BasicAttack", 400, "Attaque basique du priest", 0, 0, DamageTypeEnum.Physical, 1,new bool[4] { true, true, false, false } , new bool[4] { true, true, false, false } )
        {
            
            _mage = mage;
            
            _spellEffect = new SpellEffect();
            updateSpell();
        }

        public override void updateSpell()
        {
            _spellEffect.Damage = _mage.Damage;
            _spellEffect.CritChance = _mage.CritChance;
            _spellEffect.HitChance = _mage.HitChance;
        }

        public override void levelUp()
        {
            _spellEffect.Damage = Convert.ToInt32(mage.Damage * 1.1);
            Lvl += 1;
        }


        public Mage mage
        {
            get
            {
                return _mage;
            }
        }

        public override SpellEffect UseSpell()
        {
            return _spellEffect;
        }
    }
}