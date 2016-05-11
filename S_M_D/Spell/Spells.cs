using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;

namespace S_M_D.Spell
{
    public abstract class Spells
    {
        readonly string _name;
        readonly int _price;
        readonly string _description;
        readonly int _manaCost;
        readonly int _baseCooldown;
        int _lvl;
        readonly DamageTypeEnum _damageType;
        bool _isOnCooldown;
        int _cooldown;
        int _radius;
        bool [] _positionToAttack = new bool [4];
        bool[] _PositionTakingAttack = new bool[4];
        public Spells(string name, int price, string descrpition, int manaCost, int baseCooldown, DamageTypeEnum damageType, int lvl, bool[] positionToAttack, bool[] positionTakingAttack)
        {
            _name = name;
            _price = price;
            _description = descrpition;
            _manaCost = manaCost;
            _baseCooldown = baseCooldown;
            _damageType = damageType;
            _lvl = lvl;
            _positionToAttack = positionToAttack;
            _PositionTakingAttack = positionTakingAttack;
        }

        public abstract void updateSpell();
        public abstract void levelUp();
        /// <summary>
        /// Use effect of the spell 
        /// </summary>
        public abstract SpellEffect UseSpell();

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public int Price
        {
            get
            {
                return _price;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
        }

        public int ManaCost
        {
            get
            {
                return _manaCost;
            }
        }

        public int BaseCooldown
        {
            get
            {
                return _baseCooldown;
            }
        }

        public bool IsOnCooldown
        {
            get
            {
                return _isOnCooldown;
            }

            set
            {
                _isOnCooldown = value;
            }
        }

        public int Cooldown
        {
            get
            {
                return _cooldown;
            }

            set
            {
                _cooldown = value;
            }
        }

        public DamageTypeEnum DamageType
        {
            get
            {
                return _damageType;
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
        
    }
}
