using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_M_D.Character.Heros
{
    class PaladinClass : BaseHero
    {
        public PaladinClass()
        {
            CharacterName = "George";
            CharacterClassName = "Paladin";
            Lvl = 0;
            HP = 40;
            HPmax = 40;
            Mana = 30;
            ManaMax = 30;
            Damage = 7;
            CritChance = 12;
            Speed = 8;
            HitChance = 50;
            AffectRes = 50;
            BleedingRes = 40;
            MagicRes = 30;
            FireRes = 20;
            PoisonRes = 40;
            WaterRes = 20;
            Defense = 34;
            DodgeChance = 20;
            Evilness = 0;
            Xp = 0;
            XpMax = 100;
            Sickness = "";
            Relation = "";
            Psycho = "";
            Equipement[0] = "UNE GROSSE BITE";
            Equipement[1] = "UN BON GROS STRING MA GUEULE";
        }
        public override void LevelUp()
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
