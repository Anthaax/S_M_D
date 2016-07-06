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
            Armor,
            Weapon
        }
        ItemTypes itemtype;

        public void LevelUp()
        {
            Lvl++;
            for (int i = 1; i < 15; i++)
            {
                ChangeStat(i);
            }
        }
        private void ChangeStat(int indice)
        {
            BaseStatItem.stats stats = (BaseStatItem.stats)indice;
            switch (stats)
            {
                case BaseStatItem.stats.hp:
                    if (HP < 0)
                    {
                        HP--;
                    }
                    else if (HP > 0)
                    {
                        HP++;
                    }
                    break;
                case BaseStatItem.stats.mana:
                    if (Mana < 0)
                    {
                        Mana--;
                    }
                    else if (Mana > 0)
                    {
                        Mana++;
                    }
                    break;
                case BaseStatItem.stats.damage:
                    if (Damage < 0)
                    {
                        Damage--;
                    }
                    else if (Damage > 0)
                    {
                        Damage++;
                    }
                    break;
                case BaseStatItem.stats.critChance:
                    if (CritChance < 0)
                    {
                        CritChance--;
                    }
                    else if (CritChance > 0)
                    {
                        CritChance++;
                    }
                    break;
                case BaseStatItem.stats.hitChance:
                    if (HitChance < 0)
                    {
                        HitChance--;
                    }
                    else if (HitChance > 0)
                    {
                        HitChance++;
                    }
                    break;
                case BaseStatItem.stats.speed:
                    if (Speed < 0)
                    {
                        Speed--;
                    }
                    else if (Speed > 0)
                    {
                        Speed++;
                    }
                    break;
                case BaseStatItem.stats.affectRes:
                    if (AffectRes < 0)
                    {
                        AffectRes--;
                    }
                    else if (AffectRes > 0)
                    {
                        AffectRes++;
                    }
                    break;
                case BaseStatItem.stats.bleedingRes:
                    if (BleedingRes < 0)
                    {
                        BleedingRes--;
                    }
                    else if (BleedingRes > 0)
                    {
                        BleedingRes++;
                    }
                    break;
                case BaseStatItem.stats.magicRes:
                    if (MagicRes < 0)
                    {
                        MagicRes--;
                    }
                    else if (MagicRes > 0)
                    {
                        MagicRes++;
                    }
                    break;
                case BaseStatItem.stats.fireRes:
                    if (FireRes < 0)
                    {
                        FireRes--;
                    }
                    else if (FireRes > 0)
                    {
                        FireRes++;
                    }
                    break;
                case BaseStatItem.stats.poisonRes:
                    if (PoisonRes < 0)
                    {
                        PoisonRes--;
                    }
                    else if (PoisonRes > 0)
                    {
                        PoisonRes++;
                    }
                    break;
                case BaseStatItem.stats.waterRes:
                    if (WaterRes < 0)
                    {
                        WaterRes--;
                    }
                    else if (WaterRes > 0)
                    {
                        WaterRes++;
                    }
                    break;
                case BaseStatItem.stats.defense:
                    if (Defense < 0)
                    {
                        Defense--;
                    }
                    else if (Defense > 0)
                    {
                        Defense++;
                    }
                    break;
                case BaseStatItem.stats.dodgeChance:
                    if (DodgeChance < 0)
                    {
                        DodgeChance--;
                    }
                    else if (DodgeChance > 0)
                    {
                        DodgeChance++;
                    }
                    break;
                default:
                    break;
            }
        }
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
