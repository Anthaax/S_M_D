﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Spell
{
    [Serializable]
    public class KindOfEffect
    {
        int _damage;
        readonly DamageTypeEnum _damageType;
        int _damagePerTurn;
        int _effectiveDamagePerTurn;
        int _effectiveTurn;
        readonly int _turn;
        readonly bool _canBeBlock;
        public KindOfEffect(int damage, DamageTypeEnum damageType, int damagePerTurn, int turn, float rate)
        {
            _damage = Convert.ToInt32(damage * rate);
            _damageType = damageType;
            _damagePerTurn = damagePerTurn;
            _effectiveDamagePerTurn = DamagePerTurn;
            _turn = turn;
            EffectiveTurn = turn;
            if (_damageType == (DamageTypeEnum)1 || _damageType == (DamageTypeEnum)8) _canBeBlock = false;
            else _canBeBlock = true;
        }
        public int Damage
        {
            get
            {
                return _damage;
            }
            set { _damage = value; }
        }

        public DamageTypeEnum DamageType
        {
            get
            {
                return _damageType;
            }
        }

        public int DamagePerTurn
        {
            get
            {
                return _damagePerTurn;
            }
            set { _damagePerTurn = value; }

        }

        public int Turn
        {
            get
            {
                return _turn;
            }
        }

        public bool CanBeBlock
        {
            get
            {
                return _canBeBlock;
            }
        }

        public int EffectiveDamagePerTurn
        {
            get
            {
                return _effectiveDamagePerTurn;
            }

            set
            {
                _effectiveDamagePerTurn = value;
            }
        }

        public int EffectiveTurn
        {
            get
            {
                return _effectiveTurn;
            }

            set
            {
                _effectiveTurn = value;
            }
        }
    }
}
