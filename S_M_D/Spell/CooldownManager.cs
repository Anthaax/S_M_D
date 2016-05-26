using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Spell
{
    public class CooldownManager
    {
        bool _isOnCooldown;
        readonly int _baseCooldown;
        int _cooldown;
        public CooldownManager(int baseCooldown)
        {
            _baseCooldown = baseCooldown;
            _cooldown = 0;
            _isOnCooldown = false;
        }

        public void SpellsWasUsed()
        {
            IsOnCooldown = true;
            Cooldown = _baseCooldown;
        }

        public void NewTurn()
        {
            Cooldown--;
            if (Cooldown < 0)
                Cooldown = 0;
            if (Cooldown == 0)
                IsOnCooldown = false;
        }
        public bool IsOnCooldown
        {
            get
            {
                return _isOnCooldown;
            }

            set
            {
                _isOnCooldown = value;
            }
        }

        public int BaseCooldown
        {
            get
            {
                return _baseCooldown;
            }
        }

        public int Cooldown
        {
            get
            {
                return _cooldown;
            }

            set
            {
                _cooldown = value;
            }
        }
    }
}
