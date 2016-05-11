using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace S_M_D.Character
{

    public class BaseStatItem : BaseItem
    {

        // Stat HP and Mana 
        int _HP;
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

        public enum quality
        {
            useless,
            common,
            rare,
            epic,
            legendary
        }
        quality _quality;

        public enum stats
        {
            hp = 1,
            mana = 2,
            damage = 3,
            critChance = 4,
            hitChance = 5,
            speed = 6,
            affectRes = 7,
            bleedingRes = 8,
            magicRes = 9,
            fireRes = 10,
            poisonRes = 11,
            waterRes = 12,
            defense = 13,
            dodgeChance = 14,
        }
        private stats stats1;

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

        public quality Quality
        {
            get
            {
                return _quality;
            }

            set
            {
                _quality = value;
            }
        }

        public stats Stats
        {
            get
            {
                return stats1;
            }

            set
            {
                stats1 = value;
            }
        }
    }
}
