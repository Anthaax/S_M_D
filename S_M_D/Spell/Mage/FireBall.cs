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
        readonly SpellEffect _spellEffect;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paladin"></param>
        public FireBall(Mage mage)
            : base("FireBall", 400, "Boule de feu", 5, 0, DamageTypeEnum.Magical, 1, new bool[4] { false, false, true, true }, new bool[4] { false, true, true, true })
        {
            _mage = mage;
            _spellEffect = new SpellEffect();
            updateSpell();
            
        }

        public override void  updateSpell()
        {
            _spellEffect.Damage = _mage.Damage * damageRatioByLvl[Lvl];
            _spellEffect.CritChance = _mage.CritChance;
            _spellEffect.HitChance = _mage.HitChance;
            _spellEffect.Fireing = true;
            _spellEffect.FireValue = fireValueByLvl[Lvl];
            _spellEffect.FireTime = 2;
        }
        public override void levelUp()
        {
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
