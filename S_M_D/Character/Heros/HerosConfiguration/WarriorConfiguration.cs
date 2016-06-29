using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Spell;

namespace S_M_D.Character
{
    [Serializable]
    public class WarriorConfiguration : HerosType
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
        /// Warrior configuration for create a paladin with the good configuration
        /// </summary>
        /// <param name="HerosList"> Need a hero list to add the new paladin in this list </param>
        public WarriorConfiguration( GameContext ctx )
            : base( ctx, HerosEnum.Warrior.ToString(), 400, "George" )
        {
            _HPmax = 50;
            _HP = 50;
            _manaMax = 20;
            _mana = 20;
            _damage = 11;
            _critChance = 20;
            _hitChance = 60;
            _speed = 5;
            _affectRes = 30;
            _bleedingRes = 45;
            _magicRes = 20;
            _fireRes = 20;
            _poisonRes = 20;
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
        /// Create a warrior and return this one with the good configuration 
        /// </summary>
        /// <returns></returns>
        protected override BaseHeros DoCreateHero()
        {
            return new Warrior( this );
        }
        /// <summary>
        /// Initialize all spell of an warrior
        /// </summary>
        /// <param name="hero"> A warrior to initialize spell</param>
        protected override void InitilizedSpell( BaseHeros hero )
        {
            Warrior warrior = hero as Warrior;
            hero.Spells[0] = new BasicAttackWarrior( warrior );
            hero.Spells[1] = new ShieldRush(warrior);
            hero.Spells[2] = new HearthAttack( warrior );
            hero.Spells[3] = new MultipleHit( warrior );
            hero.Spells[4] = new Brawl( warrior );
            hero.Spells[5] = new Devastate( warrior );
            hero.Spells[6] = new HeroicRush( warrior );
            hero.Spells[7] = new Tourbillon( warrior );
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