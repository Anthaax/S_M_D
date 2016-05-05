using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_M_D.Character
{
    public class WarriorClassConfiguration : HerosType
    {
        readonly BaseHero _baseHero;
        public WarriorClassConfiguration(List<BaseHero> HerosList )
            :base(HerosList, HerosEnum.Warrior.ToString(), 400, true, "George")
        {
            Initialized();
        }

        public BaseHero BaseHero
        {
            get { return _baseHero; }
        }

        public void Initialized()
        {
            BaseHero.Lvl = 0;
            BaseHero.HP = 50;
            BaseHero.HPmax = 50;
            BaseHero.Mana = 20;
            BaseHero.ManaMax = 20;
            BaseHero.Damage = 11;
            BaseHero.CritChance = 22;
            BaseHero.Speed = 5;
            BaseHero.HitChance = 60;
            BaseHero.AffectRes = 30;
            BaseHero.BleedingRes = 45;
            BaseHero.MagicRes = 20;
            BaseHero.FireRes = 20;
            BaseHero.PoisonRes = 20;
            BaseHero.WaterRes = 20;
            BaseHero.Defense = 40;
            BaseHero.DodgeChance = 15;
            BaseHero.Evilness = 0;
            BaseHero.Xp = 0;
            BaseHero.XpMax = 100;
            BaseHero.Sickness = "";
            BaseHero.Relation = "";
            BaseHero.Psycho = "";
            BaseHero.Equipement[0] = "UNE GROSSE BITE";
            BaseHero.Equipement[1] = "UN BON GROS STRING MA GUEULE";
        }

        protected override BaseHero DoCreateHero()
        {
            return new WarriorClass( BaseHero );
        }
    }
    public class WarriorClass : BaseHero, ILevel
    {

        public WarriorClass(BaseHero WarriorConfig)
        {
            CharacterName = WarriorConfig.CharacterName;
            CharacterClassName = WarriorConfig.CharacterClassName;
            Lvl = WarriorConfig.Lvl;
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
