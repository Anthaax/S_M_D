using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Character
{
    [Serializable]
    public class Warrior : BaseHeros
    {

        public Warrior(WarriorConfiguration WarriorConfig)
            :base(WarriorConfig.GameContext, WarriorConfig.CharacterClassName, WarriorConfig.Price, WarriorConfig.IsMale, WarriorConfig.Evilness, WarriorConfig.Sickness, WarriorConfig.Psycho, 
                 WarriorConfig.Relation, WarriorConfig.Equipement, WarriorConfig.Xp, WarriorConfig.XpMax, WarriorConfig.CharacterName, 0, WarriorConfig.HPmax, WarriorConfig.ManaMax, 
                 WarriorConfig.Damage, WarriorConfig.CritChance, WarriorConfig.HitChance, WarriorConfig.Speed, WarriorConfig.AffectRes, WarriorConfig.BleedingRes, 
                 WarriorConfig.MagicRes, WarriorConfig.FireRes, WarriorConfig.PoisonRes, WarriorConfig.WaterRes, WarriorConfig.Defense, WarriorConfig.DodgeChance, WarriorConfig.Spells)
        {
            UpdateHeroStats();
        }
        /// <summary>
        /// Level up a warrior if is xpMax > Xp an exeption was throw
        /// </summary>
        public override void LevelUp()
        {
            if (XpMax > Xp)
                throw new ArgumentException( "Hero can't level up don't use this function when XpMax > Xp" );
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
