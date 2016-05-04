using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_M_D.Character
{
    public class WarriorConfiguration : HerosType
    {
        BaseHero _baseHero;
        public WarriorConfiguration(List<BaseHero> HerosList )
            :base(HerosList, HerosEnum.Warrior.ToString(), 400, true, "George")
        {
            Initialized();
        }

        public void Initialized()
        {
            _baseHero.Lvl = 0;
            _baseHero.HP = 50;
            _baseHero.HPmax = 50;
            _baseHero.Mana = 20;
            _baseHero.ManaMax = 20;
            _baseHero.Damage = 11;
            _baseHero.CritChance = 22;
            _baseHero.Speed = 5;
            _baseHero.HitChance = 60;
            _baseHero.AffectRes = 30;
            _baseHero.BleedingRes = 45;
            _baseHero.MagicRes = 20;
            _baseHero.FireRes = 20;
            _baseHero.PoisonRes = 20;
            _baseHero.WaterRes = 20;
            _baseHero.Defense = 40;
            _baseHero.DodgeChance = 15;
            _baseHero.Evilness = 0;
            _baseHero.Xp = 0;
            _baseHero.XpMax = 100;
            _baseHero.Sickness = "";
            _baseHero.Relation = "";
            _baseHero.Psycho = "";
            _baseHero.Equipement[0] = "UNE GROSSE BITE";
            _baseHero.Equipement[1] = "UN BON GROS STRING MA GUEULE";
        }

        protected override BaseHero DoCreateHero( List<BaseHero> HerosList )
        {
            throw new NotImplementedException();
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
