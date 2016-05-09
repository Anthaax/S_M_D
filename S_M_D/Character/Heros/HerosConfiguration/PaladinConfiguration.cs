using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_M_D.Character
{
    public class PaladinConfiguration : HerosType
    {
        readonly int _HPmax;
        readonly int _HP;
        readonly int _manaMax;
        readonly int _mana;

        // Attacks stats
        readonly int _damage;
        readonly int _critChance;
        readonly int _hitChance;
        readonly int _speed;

        // Resistances stats
        readonly int _affectRes;
        readonly int _bleedingRes;
        readonly int _magicRes;
        readonly int _fireRes;
        readonly int _poisonRes;
        readonly int _waterRes;

        //Defense stats
        readonly int _defense;
        readonly int _dodgeChance;
        readonly int _evilness;
        readonly string _sickness;
        readonly string _psycho;
        readonly string _relation;
        readonly string[] _equipement = new string[4];
        readonly int _xp;
        readonly int _xpMax;

        public int HPmax
        {
            get
            {
                return _HPmax;
            }
        }

        public int HP
        {
            get
            {
                return _HP;
            }
        }

        public int ManaMax
        {
            get
            {
                return _manaMax;
            }
        }

        public int Mana
        {
            get
            {
                return _mana;
            }
        }

        public int Damage
        {
            get
            {
                return _damage;
            }
        }

        public int CritChance
        {
            get
            {
                return _critChance;
            }
        }

        public int HitChance
        {
            get
            {
                return _hitChance;
            }
        }

        public int Speed
        {
            get
            {
                return _speed;
            }
        }

        public int AffectRes
        {
            get
            {
                return _affectRes;
            }
        }

        public int BleedingRes
        {
            get
            {
                return _bleedingRes;
            }
        }

        public int MagicRes
        {
            get
            {
                return _magicRes;
            }
        }

        public int PoisonRes
        {
            get
            {
                return _poisonRes;
            }
        }

        public int FireRes
        {
            get
            {
                return _fireRes;
            }
        }

        public int WaterRes
        {
            get
            {
                return _waterRes;
            }
        }

        public int Defense
        {
            get
            {
                return _defense;
            }
        }

        public int DodgeChance
        {
            get
            {
                return _dodgeChance;
            }
        }

        public int Evilness
        {
            get
            {
                return _evilness;
            }
        }

        public string Sickness
        {
            get
            {
                return _sickness;
            }
        }

        public string Psycho
        {
            get
            {
                return _psycho;
            }
        }

        public string Relation
        {
            get
            {
                return _relation;
            }
        }

        public string[] Equipement
        {
            get
            {
                return _equipement;
            }
        }

        public int Xp
        {
            get
            {
                return _xp;
            }
        }

        public int XpMax
        {
            get
            {
                return _xpMax;
            }
        }
        public PaladinConfiguration( List<BaseHeros> HerosList )
            : base( HerosList, HerosEnum.Paladin.ToString(), 400, "George" )
        {
            _HPmax = 40;
            _HP = 40;
            _manaMax = 30;
            _mana = 30;
            _damage = 7;
            _critChance = 12;
            _hitChance = 50;
            _speed = 8;
            _affectRes = 50;
            _bleedingRes = 40;
            _magicRes = 30;
            _fireRes = 20;
            _poisonRes = 40;
            _waterRes = 20;
            _defense = 40;
            _dodgeChance = 15;
            _evilness = 0;
            _xp = 0;
            _xpMax = 100;
            _sickness = "";
            _relation = "";
            _psycho = "";
            _equipement[0] = "UNE GROSSE BITE";
            _equipement[1] = "UN BON GROS STRING MA GUEULE";
        }
        protected override BaseHeros DoCreateHero()
        {
            return new PaladinClass( this );
        }
    }
}
