using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Character
{
    public class Warrior : BaseHeros, ILevel
    {

        public Warrior(WarriorConfiguration WarriorConfig)
            :base(WarriorConfig.CharacterClassName, WarriorConfig.Price, WarriorConfig.IsMale, WarriorConfig.Evilness, WarriorConfig.Sickness, WarriorConfig.Psycho, 
                 WarriorConfig.Relation, WarriorConfig.Equipement, WarriorConfig.Xp, WarriorConfig.XpMax, WarriorConfig.CharacterName, 0, WarriorConfig.HPmax, WarriorConfig.ManaMax, 
                 WarriorConfig.Damage, WarriorConfig.CritChance, WarriorConfig.HitChance, WarriorConfig.Speed, WarriorConfig.AffectRes, WarriorConfig.BleedingRes, 
                 WarriorConfig.MagicRes, WarriorConfig.FireRes, WarriorConfig.PoisonRes, WarriorConfig.WaterRes, WarriorConfig.Defense, WarriorConfig.DodgeChance, WarriorConfig.Spells)
        {

        }
        /// <summary>
        /// Level up a warrior if is xpMax > Xp an exeption was throw
        /// </summary>
        public void LevelUp()
        {
            if (XpMax > Xp)
                throw new ArgumentException("Hero can't level up don't use this function when XpMax > Xp");
            Lvl++;
            Xp = Xp - XpMax;
            XpMax = XpMax * 2;

            HPmax += 15;
            ManaMax += 6;
            Damage += 4;
            HitChance += 20;
            DodgeChance += 5;
        }
    }

}
