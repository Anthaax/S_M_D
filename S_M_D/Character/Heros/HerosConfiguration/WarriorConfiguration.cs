using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_M_D.Character
{
    public class WarriorConfiguration : HerosType
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

        public WarriorConfiguration( List<BaseHeros> HerosList )
            : base( HerosList, HerosEnum.Warrior.ToString(), 400, true, "George" )
        {
             _HPmax = 50;
             _HP = 50;
             _manaMax = 20;
             _mana = 20;
             _damage = 11;
             _critChance = 20;
             _hitChance = 60;
             _speed = 5;
             _affectRes = 30;
             _bleedingRes = 45;
             _magicRes = 20;
             _fireRes = 20;
             _poisonRes = 20;
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
            return new Warrior( this );
        }
    }
}