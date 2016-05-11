﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Spell;
using ItemCreator;

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
        BaseItem[] _equipement = new BaseItem[4];
        int _xp;
        int _xpMax;

        public BaseHeros( string characterClassName, int price, bool isMale, int evilness, string sickness, string psycho, string relation, string[] equipement, int xp, int xpMax,
            string characterName, int lvl, int hpMax, int manaMax, int damage, int critChance, int hitChance, int speed, int affectRes, int bleedingRes, int magicRes, int fireRes, 
            int poisonRes, int waterRes, int defense, int dodgeChance, Spells[] spells)
        {
            _characterClassName = characterClassName;
            _price = price;
            _isMale = isMale;
            _evilness = evilness;
            _equipement = equipement;
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
            _sicknesses = new List<Sickness>();
            _psycho = new List<Psychology>();
            _relationship = new List<Relationship>();
        }

        public void GetNewItem (BaseItem item)
        {
            if (item.Itemtype == BaseItem.ItemTypes.Weapon)
            {
                if (_equipement[0] != null) _equipement[0] = item;
                else throw new ArgumentException("You already have an armor!");
            }
            if (item.Itemtype == BaseItem.ItemTypes.Armor)
            {
                if (_equipement[1] != null) _equipement[1] = item;
                else throw new ArgumentException("You already have a weapon!");
            }
            if (item.Itemtype == BaseItem.ItemTypes.Trinket)
            {
                if (_equipement[2] != null) _equipement[2] = item;
                else throw new ArgumentException("You already have a Trinket!");
            }
            if (item.Itemtype == BaseItem.ItemTypes.Potion)
            {
                if (_equipement[3] != null) _equipement[3] = item;
                else throw new ArgumentException("You already have a Potion!");
            }
            else throw new ArgumentException("Type of item non reconize!");
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
                    spellToUpdate.updateSpell();
                }

            }

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
    }
}
