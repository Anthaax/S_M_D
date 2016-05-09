﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_M_D.Character
{
    public abstract class BaseCharacter
    {
        //Info Character
        readonly string _characterName;
        // Character stats
        int _lvl;

        // Stat HP and Mana 
        int _HPmax;
        int _HP;
        int _manaMax;
        int _mana;

        // Attacks stats
        int _damage;
        int _critChance;
        int _hitChance;
        int _speed;

        // Resistances stats
        int _affectRes;
        int _bleedingRes;
        int _magicRes;
        int _fireRes;
        int _poisonRes;
        int _waterRes;

        //Defense stats
        int _defense;
        int _dodgeChance;
        public BaseCharacter( string characterName, int lvl, int hpMax, int manaMax, int damage, int critChance, int hitChance, int speed, int affectRes, int bleedingRes,
            int magicRes, int fireRes, int poisonRes, int waterRes, int defense, int dodgeChance )
        {
            _affectRes = affectRes;
            _bleedingRes = bleedingRes;
            _characterName = characterName;
            _critChance = critChance;
            _damage = damage;
            _defense = defense;
            _dodgeChance = dodgeChance;
            _fireRes = fireRes;
            _hitChance = hitChance;
            _HP = hpMax;
            _HPmax = hpMax;
            _lvl = lvl;
            _magicRes = magicRes;
            _mana = manaMax;
            _manaMax = manaMax;
            _poisonRes = poisonRes;
            _speed = speed;
            _waterRes = waterRes;
        }
        public string CharacterName
        {
            get
            {
                return _characterName;
            }

        }

        public int Lvl
        {
            get
            {
                return _lvl;
            }

            set
            {
                _lvl = value;
            }
        }

        public int HPmax
        {
            get
            {
                return _HPmax;
            }

            set
            {
                _HPmax = value;
            }
        }

        public int HP
        {
            get
            {
                return _HP;
            }

            set
            {
                _HP = value;
            }
        }

        public int ManaMax
        {
            get
            {
                return _manaMax;
            }

            set
            {
                _manaMax = value;
            }
        }

        public int Mana
        {
            get
            {
                return _mana;
            }

            set
            {
                _mana = value;
            }
        }

        public int Damage
        {
            get
            {
                return _damage;
            }

            set
            {
                _damage = value;
            }
        }

        public int CritChance
        {
            get
            {
                return _critChance;
            }

            set
            {
                _critChance = value;
            }
        }

        public int HitChance
        {
            get
            {
                return _hitChance;
            }

            set
            {
                _hitChance = value;
            }
        }

        public int AffectRes
        {
            get
            {
                return _affectRes;
            }

            set
            {
                _affectRes = value;
            }
        }

        public int BleedingRes
        {
            get
            {
                return _bleedingRes;
            }

            set
            {
                _bleedingRes = value;
            }
        }

        public int MagicRes
        {
            get
            {
                return _magicRes;
            }

            set
            {
                _magicRes = value;
            }
        }

        public int FireRes
        {
            get
            {
                return _fireRes;
            }

            set
            {
                _fireRes = value;
            }
        }

        public int PoisonRes
        {
            get
            {
                return _poisonRes;
            }

            set
            {
                _poisonRes = value;
            }
        }

        public int WaterRes
        {
            get
            {
                return _waterRes;
            }

            set
            {
                _waterRes = value;
            }
        }

        public int Defense
        {
            get
            {
                return _defense;
            }

            set
            {
                _defense = value;
            }
        }

        public int DodgeChance
        {
            get
            {
                return _dodgeChance;
            }

            set
            {
                _dodgeChance = value;
            }
        }

        public int Speed
        {
            get
            {
                return _speed;
            }

            set
            {
                _speed = value;
            }
        }
    }
}

