using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S_M_D.Spell;

namespace S_M_D.Character
{
    public abstract class BaseHeros : BaseCharacter
    {
        readonly string _characterClassName;
        int _price;
        bool _isMale;
        int _evilness;
        string _relation;
        readonly List<Spells> _spells;
        readonly List<Sickness> _sicknesses;
        readonly List<Psychology> _psycho;
        string[] _equipement = new string[4];
        int _xp;
        int _xpMax;

        public BaseHeros( string characterClassName, int price, bool isMale, int evilness, string sickness, string psycho, string relation, string[] equipement, int xp, int xpMax,
            string characterName, int lvl, int hpMax, int manaMax, int damage, int critChance, int hitChance, int speed, int affectRes, int bleedingRes, int magicRes, int fireRes, 
            int poisonRes, int waterRes, int defense, int dodgeChance, List<Spells> spells)
        {
            _characterClassName = characterClassName;
            _price = price;
            _isMale = isMale;
            _evilness = evilness;
            _relation = relation;
            _equipement = equipement;
            _xp = xp;
            _xpMax = xpMax;
            _spells = spells;
            AffectRes = affectRes;
            BleedingRes = bleedingRes;
            CharacterName = characterName;
            CritChance = critChance;
            Damage = damage;
            Defense = defense;
            DodgeChance = dodgeChance;
            FireRes = fireRes;
            HitChance = hitChance;
            HP = hpMax;
            HPmax = hpMax;
            Lvl = lvl;
            MagicRes = magicRes;
            Mana = manaMax;
            ManaMax = manaMax;
            PoisonRes = poisonRes;
            Speed = speed;
            WaterRes = waterRes;
            _sicknesses = new List<Sickness>();
            _psycho = new List<Psychology>();
        }

        public void GetSickness(Sickness sickness)
        {
            foreach (Sickness sick in _sicknesses)
            {
                if (sick.Name == sickness.Name)
                {
                    throw new ArgumentException("dude, u cant get 2 times the same sickness");
                }
            }
            _sicknesses.Add(sickness);
            UpdateHeroStats();
        }

        public void DeleteSickness(Sickness sickness)
        {
               _sicknesses.Remove(sickness);
            UpdateHeroStats();
        }

        public void GetPsycho(Psychology psycho)
        {
            foreach (Psychology psy in _psycho)
            {
                if (psy.Name == psycho.Name)
                {
                    throw new ArgumentException("dude, u cant get 2 times the same psycho");
                }
            }
            _psycho.Add(psycho);
            UpdateHeroStats();
        }

        public void DeletePsycho(Psychology psycho)
        {
            _psycho.Remove(psycho);
            UpdateHeroStats();
        }

        public void UpdateHeroStats()
        {
            EffectivHPMax = HPmax;
            EffectivManaMax = ManaMax;
            EffectCritChance = CritChance;
            EffectivAffectRes = AffectRes;
            EffectivBleedingRes = BleedingRes;
            EffectivDamage = Damage;
            EffectivDefense = Defense;
            EffectivDodgeChance = DodgeChance;
            EffectivFireRes = FireRes;
            EffectivHitChance = HitChance;
            EffectivMagicRes = MagicRes;
            EffectivPoisonRes = PoisonRes;
            EffectivSpeed = Speed;
            EffectivWaterRes = WaterRes;

            foreach (Sickness sick in _sicknesses)
            {
                sick.effect(this);
            }

            foreach (Psychology psy in _psycho)
            {
                psy.effect(this);
            }
        }

        public int Evilness
        {
            get
            {
                return _evilness;
            }

            set
            {
                _evilness = value;
            }
        }

        public string Relation
        {
            get
            {
                return _relation;
            }

            set
            {
                _relation = value;
            }
        }

        public string[] Equipement
        {
            get
            {
                return _equipement;
            }

            set
            {
                _equipement = value;
            }
        }

        public int Xp
        {
            get
            {
                return _xp;
            }

            set
            {
                _xp = value;
            }
        }

        public int XpMax
        {
            get
            {
                return _xpMax;
            }

            set
            {
                _xpMax = value;
            }
        }

        public string CharacterClassName
        {
            get
            {
                return _characterClassName;
            }
        }

        public bool IsMale
        {
            get
            {
                return _isMale;
            }

            set
            {
                _isMale = value;
            }
        }

        public int Price
        {
            get
            {
                return _price;
            }

            set
            {
                _price = value;
            }
        }

        public List<Spells> Spells
        {
            get
            {
                return _spells;
            }
        }
    }
}
