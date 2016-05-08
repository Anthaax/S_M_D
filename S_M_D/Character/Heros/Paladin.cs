using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_M_D.Character
{
    public class PaladinClass : BaseHeros, ILevel
    {
        public PaladinClass(PaladinConfiguration PaladinConfig)
        {
            CharacterName = PaladinConfig.CharacterName;
            CharacterClassName = PaladinConfig.CharacterClassName;
            Lvl = 0;
            HP = PaladinConfig.HP;
            HPmax = PaladinConfig.HPmax;
            Mana = PaladinConfig.Mana;
            ManaMax = PaladinConfig.ManaMax;
            Damage = PaladinConfig.Damage;
            CritChance = PaladinConfig.CritChance;
            Speed = PaladinConfig.Speed;
            HitChance = PaladinConfig.HitChance;
            AffectRes = PaladinConfig.AffectRes;
            BleedingRes = PaladinConfig.BleedingRes;
            MagicRes = PaladinConfig.MagicRes;
            FireRes = PaladinConfig.FireRes;
            PoisonRes = PaladinConfig.PoisonRes;
            WaterRes = PaladinConfig.WaterRes;
            Defense = PaladinConfig.Defense;
            DodgeChance = PaladinConfig.DodgeChance;
            Evilness = PaladinConfig.Evilness;
            Xp = PaladinConfig.Xp;
            XpMax = PaladinConfig.XpMax;
            Sickness = PaladinConfig.Sickness;
            Relation = PaladinConfig.Relation;
            Psycho = PaladinConfig.Psycho;
            Equipement[0] = PaladinConfig.Equipement[0];
            Equipement[1] = PaladinConfig.Equipement[1];
        }
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
