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
        string _sickness;
        string _psycho;
        string _relation;
        readonly List<Spells> _spells;
        string[] _equipement = new string[4];
        int _xp;
        int _xpMax;

        public BaseHeros( string characterClassName, int price, bool isMale, int evilness, string sickness, string psycho, string relation, string[] equipement, int xp, int xpMax,
            string characterName, int lvl, int hpMax, int manaMax, int damage, int critChance, int hitChance, int speed, int affectRes, int bleedingRes, int magicRes, int fireRes, 
            int poisonRes, int waterRes, int defense, int dodgeChance, List<Spells> spells )
        {
            _characterClassName = characterClassName;
            _price = price;
            _isMale = isMale;
            _evilness = evilness;
            _sickness = sickness;
            _psycho = psycho;
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

        public string Sickness
        {
            get
            {
                return _sickness;
            }

            set
            {
                _sickness = value;
            }
        }

        public string Psycho
        {
            get
            {
                return _psycho;
            }

            set
            {
                _psycho = value;
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
