using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Character
{
    [Serializable]
    public class Priest : BaseHeros
    {
        public Priest(PriestConfiguration PriestConfig)
            : base(PriestConfig.GameContext, PriestConfig.CharacterClassName, PriestConfig.Price, PriestConfig.IsMale, PriestConfig.Evilness, PriestConfig.Sickness, PriestConfig.Psycho,
                 PriestConfig.Relation, PriestConfig.Equipement, PriestConfig.Xp, PriestConfig.XpMax, PriestConfig.CharacterName, 0, PriestConfig.HPmax, PriestConfig.ManaMax,
                 PriestConfig.Damage, PriestConfig.CritChance, PriestConfig.HitChance, PriestConfig.Speed, PriestConfig.AffectRes, PriestConfig.BleedingRes,
                 PriestConfig.MagicRes, PriestConfig.FireRes, PriestConfig.PoisonRes, PriestConfig.WaterRes, PriestConfig.Defense, PriestConfig.DodgeChance, PriestConfig.Spells)
        {
            UpdateHeroStats();
        }
        /// <summary>
        /// Level up a paladin if is xpMax > Xp an exeption was throw
        /// </summary>
        public override void LevelUp()
        {
            if (XpMax > Xp)
                throw new ArgumentException( "Hero can't level up don't use this function when XpMax > Xp" );
            Lvl++;
            Xp = Xp - XpMax;
            XpMax = XpMax * 2;

            HPmax += 10;
            EffectivHPMax += 10;
            HP += 10;
            ManaMax += 10;
            EffectivManaMax += 10;
            Mana += 10;
            Damage += 2;
            HitChance += 30;
            DodgeChance += 3;
        }
    }
}