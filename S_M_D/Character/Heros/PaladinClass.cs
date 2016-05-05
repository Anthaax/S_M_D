using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_M_D.Character
{
    public class PaladinClassConfiguration : HerosType
    {
        readonly BaseHero _baseHero;
        public PaladinClassConfiguration( List<BaseHero> HerosList )
            : base( HerosList, HerosEnum.Paladin.ToString(), 400, true, "George" )
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
            BaseHero.HP = 40;
            BaseHero.HPmax = 40;
            BaseHero.Mana = 30;
            BaseHero.ManaMax = 30;
            BaseHero.Damage = 7;
            BaseHero.CritChance = 12;
            BaseHero.Speed = 8;
            BaseHero.HitChance = 50;
            BaseHero.AffectRes = 50;
            BaseHero.BleedingRes = 40;
            BaseHero.MagicRes = 30;
            BaseHero.FireRes = 20;
            BaseHero.PoisonRes = 40;
            BaseHero.WaterRes = 20;
            BaseHero.Defense = 34;
            BaseHero.DodgeChance = 20;
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
            return new PaladinClass( BaseHero );
        }
    }
    public class PaladinClass : BaseHero, ILevel
    {
        public PaladinClass(BaseHero PaladinConfig)
        {
            CharacterName = PaladinConfig.CharacterName;
            CharacterClassName = PaladinConfig.CharacterClassName;
            Lvl = PaladinConfig.Lvl;
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
