﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Character
{
    public class Mage : BaseHeros, ILevel
    {
        public Mage(MageConfiguration MageConfig)
            : base(MageConfig.CharacterClassName, MageConfig.Price, MageConfig.IsMale, MageConfig.Evilness, MageConfig.Sickness, MageConfig.Psycho,
                 MageConfig.Relation, MageConfig.Equipement, MageConfig.Xp, MageConfig.XpMax, MageConfig.CharacterName, 0, MageConfig.HPmax, MageConfig.ManaMax,
                 MageConfig.Damage, MageConfig.CritChance, MageConfig.HitChance, MageConfig.Speed, MageConfig.AffectRes, MageConfig.BleedingRes,
                 MageConfig.MagicRes, MageConfig.FireRes, MageConfig.PoisonRes, MageConfig.WaterRes, MageConfig.Defense, MageConfig.DodgeChance, MageConfig.Spells)
        {

        }
        /// <summary>
        /// Level up a paladin if is xpMax > Xp an exeption was throw
        /// </summary>
        public void LevelUp()
        {
            if (XpMax > Xp)
                throw new ArgumentException("Hero can't level up don't use this function when XpMax > Xp");
            Lvl++;
            Xp = Xp - XpMax;
            XpMax = XpMax * 2;

            HPmax += 10;
            ManaMax += 10;
            Damage += 2;
            HitChance += 30;
            DodgeChance += 3;
        }
    }
}