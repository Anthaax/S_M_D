﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Spell;


namespace S_M_D.Character
{
    public abstract class BaseHeros : BaseCharacter
    {
        readonly string _characterClassName;
        int _price;
        bool _isMale;
        int _evilness;
        readonly Spells[] _spells;
        readonly List<Sickness> _sicknesses;
        readonly List<Psychology> _psycho;
        readonly List<Relationship> _relationship;
        BaseItem[] _equipement;
        int _xp;
        int _xpMax;

        public BaseHeros( string characterClassName, int price, bool isMale, int evilness, string sickness, string psycho, string relation, BaseItem[] equipement, int xp, int xpMax,
            string characterName, int lvl, int hpMax, int manaMax, int damage, int critChance, int hitChance, int speed, int affectRes, int bleedingRes, int magicRes, int fireRes, 
            int poisonRes, int waterRes, int defense, int dodgeChance, Spells[] spells)
        {
            _characterClassName = characterClassName;
            _price = price;
            _isMale = isMale;
            _evilness = evilness;
            _xp = xp;
            _xpMax = xpMax;
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
            _spells = new Spells[8];
            Equipement = new BaseItem[4];
            _sicknesses = new List<Sickness>();
            _psycho = new List<Psychology>();
            _relationship = new List<Relationship>();
        }

        public void GetNewItem (BaseItem item)
        {
            if (item.Itemtype == BaseItem.ItemTypes.Weapon)
            {
                if (Equipement[0] == null) Equipement[0] = item;
                else throw new ArgumentException("You already have an armor!");
            }
            else if (item.Itemtype == BaseItem.ItemTypes.Armor)
            {
                if (Equipement[1] == null) Equipement[1] = item;
                else throw new ArgumentException("You already have a weapon!");
            }
            else if (item.Itemtype == BaseItem.ItemTypes.Trinket)
            {
                if (Equipement[2] == null) Equipement[2] = item;
                else throw new ArgumentException("You already have a Trinket!");
            }
            else throw new ArgumentException("Type of item non reconize!");
            UpdateHeroStats();
        }

        public void RemoveItem(BaseItem item)
        {

            int x = 0;
            foreach (BaseItem equip in Equipement)
            {
                if (equip == item) Equipement[x] = null;
            }
        }

        public void AddItemStats(BaseItem item)
        {
            EffectivHPMax += item.HP;
            EffectivManaMax += item.Mana;
            EffectCritChance += item.CritChance;
            EffectivAffectRes += item.AffectRes;
            EffectivBleedingRes += item.BleedingRes;
            EffectivDamage += item.Damage;
            EffectivDefense += item.Defense;
            EffectivDodgeChance += item.DodgeChance;
            EffectivFireRes += item.FireRes;
            EffectivHitChance += item.HitChance;
            EffectivMagicRes += item.MagicRes;
            EffectivPoisonRes += item.PoisonRes;
            EffectivSpeed += item.Speed;
            EffectivWaterRes += item.WaterRes;
        }

        

        public void GetRelationship(Relationship relation)
        {
            BaseHeros heros1 = relation.HeroDuo[0];
            BaseHeros heros2 = relation.HeroDuo[1];

            foreach (Relationship relations in _relationship)
            {
                if (heros1 == relations.HeroDuo[0] && heros2 == relations.HeroDuo[1]) throw new ArgumentException("dude, they cant have two relation at the same time");
                if (heros1 == relations.HeroDuo[1] && heros2 == relations.HeroDuo[2]) throw new ArgumentException("dude, they cant have two relation at the same time"); 
            }

            _relationship.Add(relation);
            UpdateHeroStats();
        }

        public void DeleteRelationship(Relationship relation)
        {
            _relationship.Remove(relation);
            UpdateHeroStats();
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

            foreach (Relationship rel in _relationship)
            {
                rel.Effect(this);
            }

            foreach (Spells spellToUpdate in _spells)
            {
                if (spellToUpdate != null)
                {
                    spellToUpdate.UpdateSpell();
                }

            }

            foreach (BaseItem item in Equipement)
            {
                if (item != null)
                {
                    AddItemStats(item);
                }
            }

        }
        public abstract void LevelUp();
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

        public Spells[] Spells
        {
            get
            {
                return _spells;
            }
        }

        public List<Relationship> Relationship
        {
            get
            {
                return _relationship;
            }
        }

        public BaseItem[] Equipement
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

        public List<Sickness> Sicknesses
        {
            get
            {
                return _sicknesses;
            }
        }

        public List<Psychology> Psycho
        {
            get
            {
                return _psycho;
            }
        }
    }
}
