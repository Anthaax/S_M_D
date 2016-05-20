using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Spell;

namespace S_M_D.Character
{
    public class PriestConfiguration : HerosType
    {
        readonly int _HPmax;
        readonly int _HP;
        readonly int _manaMax;
        readonly int _mana;

        // Attacks stats
        readonly int _damage;
        readonly int _critChance;
        readonly int _hitChance;
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
        readonly int _dodgeChance;
        readonly int _evilness;
        readonly string _sickness;
        readonly string _psycho;
        readonly string _relation;
        readonly BaseItem[] _equipement;
        readonly Spells[] _spells;
        readonly int _xp;
        readonly int _xpMax;

        /// <summary>
        /// Priest configuration for create a mage with the good configuration
        /// </summary>
        /// <param name="HerosList"> Need a hero list to add the new priest in this list</param>
        public PriestConfiguration (GameContext ctx)
            : base(ctx, HerosEnum.Priest.ToString(), 400, "Jojo")
        {
            _HPmax = 30;
            _HP = 30;
            _manaMax = 40;
            _mana = 40;
            _damage = 5;
            _critChance = 10;
            _hitChance = 60;
            _speed = 8;
            _affectRes = 30;
            _bleedingRes = 30;
            _magicRes = 30;
            _fireRes = 30;
            _poisonRes = 30;
            _waterRes = 30;
            _defense = 20;
            _dodgeChance = 10;
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
        /// Create a Priest and return this one with the good configuration 
        /// </summary>
        /// <returns></returns>
        protected override BaseHeros DoCreateHero()
        {
            return new Priest(this);
        }
        /// <summary>
        /// Initialize all spell of a priest
        /// </summary>
        /// <param name="hero"> A priest to initialize spell</param>
        protected override void InitilizedSpell(BaseHeros hero)
        {
            Priest priest = hero as Priest;
            hero.Spells[0] = new BasicAttackPriest(priest);
            hero.Spells[1] = new ChurchSanction( priest );
            hero.Spells[2] = new DarknessEradication( priest );
            hero.Spells[3] = new HeartPurification( priest );
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

