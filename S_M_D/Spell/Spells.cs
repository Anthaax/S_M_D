using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;

namespace S_M_D.Spell
{
    public abstract class Spells
    {
        readonly string _name;
        readonly int _price;
        readonly string _description;
        readonly int _manaCost;
        KindOfEffect _kindOfEffect;
        TargetManager _targetManager;
        CooldownManager _cooldownManager;
        int _lvl;
        bool _isBuy;
        bool _isEquiped;
        public Spells(string name, int price, string descrpition, int manaCost, int lvl, bool isBuy, bool isEquiped)
        {
            _name = name;
            _price = price;
            _description = descrpition;
            _manaCost = manaCost;
            _lvl = lvl;
            _isBuy = isBuy;
            _isEquiped = isEquiped;
        }
        public abstract void UpdateSpell();
        public void LevelUp()
        {
            if (Lvl <= 4) throw new InvalidOperationException( "The Spell cannot be upgrate more than 3 time" );
            Lvl++;
            UpdateSpell();
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public int Price
        {
            get
            {
                return _price;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
        }

        public int ManaCost
        {
            get
            {
                return _manaCost;
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
        public bool IsBuy
        {
            get
            {
                return _isBuy;
            }

            set
            {
                _isBuy = value;
            }
        }

        public bool IsEquiped
        {
            get
            {
                return _isEquiped;
            }

            set
            {
                _isEquiped = value;
            }
        }

        public KindOfEffect KindOfEffect
        {
            get
            {
                return _kindOfEffect;
            }

            set
            {
                _kindOfEffect = value;
            }
        }

        public CooldownManager CooldownManager
        {
            get
            {
                return _cooldownManager;
            }

            set
            {
                _cooldownManager = value;
            }
        }

        public TargetManager TargetManager
        {
            get
            {
                return _targetManager;
            }

            set
            {
                _targetManager = value;
            }
        }
    }
}
