using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Spell;

namespace S_M_D.Character
{
    [Serializable]
    public abstract class BaseCharacter
    {
        //Info Character
        string _characterName;
        bool _isDead;
        // Character stats
        int _lvl;

        // Stat HP and Mana 
        int _HPmax;
        int _HP;
        int _manaMax;
        int _mana;
        int _effectivHPMax;
        int _effectivManaMax;

        // Attacks stats
        int _damage;
        int _critChance;
        int _hitChance;
        int _speed;
        int _effectivDamage;
        int _effectCritChance;
        int _effectivHitChance;
        int _effectivSpeed;

        // Resistances stats
        int _affectRes;
        int _bleedingRes;
        int _magicRes;
        int _fireRes;
        int _poisonRes;
        int _waterRes;
        int _effectivAffectRes;
        int _effectivBleedingRes;
        int _effectivMagicRes;
        int _effectivFireRes;
        int _effectivPoisonRes;
        int _effectivWaterRes;

        //Defense stats
        int _defense;
        int _dodgeChance;
        int _effectivDefense;
        int _effectivDodgeChance;
        /// <summary>
        /// Choose resitance for one kind damageTymeEnum
        /// </summary>
        /// <param name="damageType">DamageTypeEnum from the spell</param>
        /// <returns></returns>
        public int Resist(DamageTypeEnum damageType)
        {
            int resitChance;
            switch (damageType)
            {
                case DamageTypeEnum.Magical:
                    resitChance = _effectivMagicRes;
                    return resitChance;
                case DamageTypeEnum.Bleeding:
                    resitChance = _effectivBleedingRes;
                    return resitChance;
                case DamageTypeEnum.Poison:
                    resitChance = _effectivPoisonRes;
                    return resitChance;
                case DamageTypeEnum.Fire:
                    resitChance = _effectivFireRes;
                    return resitChance;
                case DamageTypeEnum.Affect:
                    resitChance = _effectivAffectRes;
                    return resitChance;
                case DamageTypeEnum.Water:
                    resitChance = _effectivWaterRes;
                    return resitChance;
                default:
                    return 0;
            }
        }
        /// <summary>
        /// Initialize all effectife stats
        /// </summary>
        public void InitializedEffectiveStats()
        {
            HP = HPmax;
            EffectivHPMax = HPmax;
            Mana = ManaMax;
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
        } 
        public string CharacterName
        {
            get
            {
                return _characterName;
            }
            set { _characterName = value; }
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

        public int EffectivHPMax
        {
            get
            {
                return _effectivHPMax;
            }

            set
            {
                _effectivHPMax = value;
            }
        }

        public int EffectivManaMax
        {
            get
            {
                return _effectivManaMax;
            }

            set
            {
                _effectivManaMax = value;
            }
        }

        public int EffectivDamage
        {
            get
            {
                return _effectivDamage;
            }

            set
            {
                _effectivDamage = value;
            }
        }

        public int EffectCritChance
        {
            get
            {
                return _effectCritChance;
            }

            set
            {
                _effectCritChance = value;
            }
        }

        public int EffectivSpeed
        {
            get
            {
                return _effectivSpeed;
            }

            set
            {
                _effectivSpeed = value;
            }
        }

        public int EffectivAffectRes
        {
            get
            {
                return _effectivAffectRes;
            }

            set
            {
                _effectivAffectRes = value;
            }
        }

        public int EffectivBleedingRes
        {
            get
            {
                return _effectivBleedingRes;
            }

            set
            {
                _effectivBleedingRes = value;
            }
        }

        public int EffectivMagicRes
        {
            get
            {
                return _effectivMagicRes;
            }

            set
            {
                _effectivMagicRes = value;
            }
        }

        public int EffectivFireRes
        {
            get
            {
                return _effectivFireRes;
            }

            set
            {
                _effectivFireRes = value;
            }
        }

        public int EffectivPoisonRes
        {
            get
            {
                return _effectivPoisonRes;
            }

            set
            {
                _effectivPoisonRes = value;
            }
        }

        public int EffectivWaterRes
        {
            get
            {
                return _effectivWaterRes;
            }

            set
            {
                _effectivWaterRes = value;
            }
        }

        public int EffectivDefense
        {
            get
            {
                return _effectivDefense;
            }

            set
            {
                _effectivDefense = value;
            }
        }

        public int EffectivDodgeChance
        {
            get
            {
                return _effectivDodgeChance;
            }

            set
            {
                _effectivDodgeChance = value;
            }
        }

        public int EffectivHitChance
        {
            get
            {
                return _effectivHitChance;
            }

            set
            {
                _effectivHitChance = value;
            }
        }

        public bool IsDead
        {
            get
            {
                return _isDead;
            }

            set
            {
                _isDead = value;
            }
        }
    }
}

