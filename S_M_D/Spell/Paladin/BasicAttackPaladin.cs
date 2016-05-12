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

        int[] damageRatioByLvl = new int[4] { 1, 2, 3, 4 };
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paladin"></param>
        public BasicAttackPaladin(Paladin paladin)
            :base("BasicAttack", 400, "Attaque basique du paladin", 0, 0, DamageTypeEnum.Physical, 1, new bool[4] { true, true, false, false }, new bool[4] { true, true, false, false })
        {
            _paladin = paladin;
            BasicDamagePhysical = new BasicDamagePhysical(paladin.EffectivDamage, damageRatioByLvl[Lvl]);
        }

        public override void updateSpell()
        {
            BasicDamagePhysical = new BasicDamagePhysical(_paladin.EffectivDamage, damageRatioByLvl[Lvl]);
        }


        public Paladin Paladin
        {
            get
            {
                return _paladin;
            }
        }

    }
}
