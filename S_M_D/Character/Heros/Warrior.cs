using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_M_D.Character
{
    public class Warrior : BaseHeros, ILevel
    {

        public Warrior(WarriorConfiguration WarriorConfig)
        {
            CharacterName = WarriorConfig.CharacterName;
            CharacterClassName = WarriorConfig.CharacterClassName;
            Lvl = 0;
            HP = WarriorConfig.HP;
            HPmax = WarriorConfig.HPmax;
            Mana = WarriorConfig.Mana;
            ManaMax = WarriorConfig.ManaMax;
            Damage = WarriorConfig.Damage;
            CritChance = WarriorConfig.CritChance;
            Speed = WarriorConfig.Speed;
            HitChance = WarriorConfig.HitChance;
            AffectRes = WarriorConfig.AffectRes;
            BleedingRes = WarriorConfig.BleedingRes;
            MagicRes = WarriorConfig.MagicRes;
            FireRes = WarriorConfig.FireRes;
            PoisonRes = WarriorConfig.PoisonRes;
            WaterRes = WarriorConfig.WaterRes;
            Defense = WarriorConfig.Defense;
            DodgeChance = WarriorConfig.DodgeChance;
            Evilness = WarriorConfig.Evilness;
            Xp = WarriorConfig.Xp;
            XpMax = WarriorConfig.XpMax;
            Sickness = WarriorConfig.Sickness;
            Relation = WarriorConfig.Relation;
            Psycho = WarriorConfig.Psycho;
            Equipement[0] = WarriorConfig.Equipement[0];
            Equipement[1] = WarriorConfig.Equipement[1];
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
