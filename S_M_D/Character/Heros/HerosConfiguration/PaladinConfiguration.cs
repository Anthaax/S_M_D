﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Spell;

namespace S_M_D.Character
{
    [Serializable]
    public class PaladinConfiguration : HerosType
    {
        int _HPmax;
        int _HP;
        int _manaMax;
        int _mana;

        // Attacks stats
        int _damage;
        readonly int _critChance;
        int _hitChance;
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
        int _dodgeChance;
        readonly int _evilness;
        readonly string _sickness;
        readonly string _psycho;
        readonly string _relation;
        readonly BaseItem[] _equipement;
        readonly Spells[] _spells;
        readonly int _xp;
        readonly int _xpMax;

        /// <summary>
        /// Paladin configuration for create a paladin with the good configuration
        /// </summary>
        /// <param name="HerosList"> Need a hero list to add the new paladin in this list</param>
        public PaladinConfiguration( GameContext ctx)
            : base( ctx, HerosEnum.Paladin.ToString(), 400, "George" )
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
            _spells = new Spells[8];
            _equipement = new BaseItem[4];
        }
        /// <summary>
        /// Create a paladin and return this one with the good configuration 
        /// </summary>
        /// <returns></returns>
        protected override BaseHeros DoCreateHero()
        {
            return new Paladin( this );
        }
        /// <summary>
        /// Initialize all spell of an paladin
        /// </summary>
        /// <param name="hero"> A paladin to initialize spell</param>
        protected override void InitilizedSpell( BaseHeros hero )
        {
            Paladin paladin = hero as Paladin;
            hero.Spells[0]= new BasicAttackPaladin( paladin );
            hero.Spells[1] = new GodDivination( paladin );
            hero.Spells[2] = new GodHelp( paladin );
            hero.Spells[3] = new JusticeHammer( paladin );
            hero.Spells[4] = new DivineStorm( paladin );
            hero.Spells[5] = new DivineWrath( paladin );
            hero.Spells[6] = new SealOfWrath( paladin );
            hero.Spells[7] = new WrathHammer( paladin );
        }
        protected override BaseHeros ApplyLevelAndCreateHero( int level )
        {
            _HPmax += 10 * level;
            _manaMax += 10 * level;
            _damage += 2 * level;
            _hitChance += 30 * level;
            _dodgeChance += 3 * level;
            return DoCreateHero();
        }
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

        public Spells[] Spells
        {
            get
            {
                return _spells;
            }
        }

        public BaseItem[] Equipement
        {
            get
            {
                return _equipement;
            }
        }
    }
}
