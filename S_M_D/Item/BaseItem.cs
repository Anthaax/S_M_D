using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Character
{
    [Serializable]
    public abstract class BaseItem 
    {
        string _itemName;
        string _itemDescription;
        int _itemId;
        int _lvl;
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

        public enum ItemTypes
        {
            Trinket,
            Potion,
            Armor,
            Weapon
        }
        ItemTypes itemtype;

        public abstract void LevelUp();

        public string ItemName
        {
            get
            {
                return _itemName;
            }

            set
            {
                _itemName = value;
            }
        }

        public string ItemDescription
        {
            get
            {
                return _itemDescription;
            }

            set
            {
                _itemDescription = value;
            }
        }

        public int ItemId
        {
            get
            {
                return _itemId;
            }

            set
            {
                _itemId = value;
            }
        }

        public ItemTypes Itemtype
        {
            get
            {
                return itemtype;
            }

            set
            {
                itemtype = value;
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
