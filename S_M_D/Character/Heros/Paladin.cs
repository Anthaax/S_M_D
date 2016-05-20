using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Spell;

namespace S_M_D.Character
{
    public class Paladin : BaseHeros
    {
        public Paladin(PaladinConfiguration PaladinConfig)
            : base( PaladinConfig.CharacterClassName, PaladinConfig.Price, PaladinConfig.IsMale, PaladinConfig.Evilness, PaladinConfig.Sickness, PaladinConfig.Psycho,
                 PaladinConfig.Relation, PaladinConfig.Equipement, PaladinConfig.Xp, PaladinConfig.XpMax, PaladinConfig.CharacterName, 0, PaladinConfig.HPmax, PaladinConfig.ManaMax,
                 PaladinConfig.Damage, PaladinConfig.CritChance, PaladinConfig.HitChance, PaladinConfig.Speed, PaladinConfig.AffectRes, PaladinConfig.BleedingRes,
                 PaladinConfig.MagicRes, PaladinConfig.FireRes, PaladinConfig.PoisonRes, PaladinConfig.WaterRes, PaladinConfig.Defense, PaladinConfig.DodgeChance, PaladinConfig.Spells )
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
            ManaMax += 10;
            Damage += 2;
            HitChance += 30;
            DodgeChance += 3;
        }
    }
}
