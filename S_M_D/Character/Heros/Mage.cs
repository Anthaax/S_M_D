using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Character
{
    [Serializable]
    public class Mage : BaseHeros
    {
        public Mage(MageConfiguration MageConfig)
            : base(MageConfig.GameContext, MageConfig.CharacterClassName, MageConfig.Price, MageConfig.IsMale, MageConfig.Evilness, MageConfig.Sickness, MageConfig.Psycho,
                 MageConfig.Relation, MageConfig.Equipement, MageConfig.Xp, MageConfig.XpMax, MageConfig.CharacterName, 0, MageConfig.HPmax, MageConfig.ManaMax,
                 MageConfig.Damage, MageConfig.CritChance, MageConfig.HitChance, MageConfig.Speed, MageConfig.AffectRes, MageConfig.BleedingRes,
                 MageConfig.MagicRes, MageConfig.FireRes, MageConfig.PoisonRes, MageConfig.WaterRes, MageConfig.Defense, MageConfig.DodgeChance, MageConfig.Spells)
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
