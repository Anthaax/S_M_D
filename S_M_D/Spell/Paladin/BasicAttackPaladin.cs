﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S_M_D.Character;


namespace S_M_D.Spell
{
    public class BasicAttackPaladin : Spells
    {
        readonly Paladin _paladin;
        public BasicAttackPaladin(Paladin paladin)
            :base("BasicAttack", 400, "Attaque basique du paladin", 0, 0, DamageTypeEnum.Physical, 1)
        {
            _paladin = paladin;
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
