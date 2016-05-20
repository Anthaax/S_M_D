﻿using System;
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
            _isOnCooldown = true;
            _cooldown = _baseCooldown;
        }

        public void NewTurn()
        {
            _cooldown--;
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
