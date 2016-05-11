using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Spell
{
    class FireOnTime
    {
        int _damage;
        int _damagePerTurn;
        int _turn;

        public FireOnTime(int damage, int rate, int damagePerTurn, int turn)
        {
            Damage = damage * rate;
            DamagePerTurn = damagePerTurn;
            Turn = turn;
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
    }
}
