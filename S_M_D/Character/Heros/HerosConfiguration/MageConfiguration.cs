﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Spell;

namespace S_M_D.Character
{
    [Serializable]
    public class MageConfiguration : HerosType
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
        /// Mage configuration for create a mage with the good configuration
        /// </summary>
        /// <param name="HerosList"> Need a hero list to add the new mage in this list</param>
        public MageConfiguration(GameContext ctx)
            : base( ctx, HerosEnum.Mage.ToString(), 400, "Ginette" )
        {
            _HPmax = 25;
            _HP = 25;
            _manaMax = 50;
            _mana = 50;
            _damage = 4;
            _critChance = 6;
            _hitChance = 80;
            _speed = 10;
            _affectRes = 20;
            _bleedingRes = 20;
            _magicRes = 60;
            _fireRes = 20;
            _poisonRes = 20;
            _waterRes = 20;
            _defense = 10;
            _dodgeChance = 8;
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
        /// Create a Mage and return this one with the good configuration 
        /// </summary>
        /// <returns></returns>
        protected override BaseHeros DoCreateHero()
        {
            return new Mage(this);
        }
        /// <summary>
        /// Initialize all spell of a mage
        /// </summary>
        /// <param name="hero"> A mage to initialize spell</param>
        protected override void InitilizedSpell(BaseHeros hero)
        {
            Mage mage = hero as Mage;
            hero.Spells[0] = new BasicAttackMage(mage);
            hero.Spells[1] = new FireBall(mage);
            hero.Spells[2] = new ChaosBolt(mage);
            hero.Spells[3] = new CockStorm( mage );
            hero.Spells[4] = new Toxic( mage );
            hero.Spells[5] = new ShootingStars( mage );
            hero.Spells[6] = new Hydrobast( mage );
            hero.Spells[7] = new ThunderBolt( mage );
        }
        protected override BaseHeros ApplyLevelAndCreateHero(int level)
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
