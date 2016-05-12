using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Spell
{
    public class FireOnTime
    {
        int _damage;
        int _damagePerTurn;
        int _turn;
        bool _canBeStop;

        public FireOnTime(int damage, int rate, int damagePerTurn, int turn, bool canBestop)
        {
            Damage = damage * rate;
            DamagePerTurn = damagePerTurn;
            Turn = turn;
            CanBeStop = canBestop;
        }

        public int Damage
        {
            get
            {
                return _damage;
            }

            set
            {
                _damage = value;
            }
        }

        public int DamagePerTurn
        {
            get
            {
                return _damagePerTurn;
            }

            set
            {
                _damagePerTurn = value;
            }
        }

        public int Turn
        {
            get
            {
                return _turn;
            }

            set
            {
                _turn = value;
            }
        }

        public bool CanBeStop
        {
            get
            {
                return _canBeStop;
            }

            set
            {
                _canBeStop = value;
            }
        }
    }
}
