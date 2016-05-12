using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Spell
{
    public class DamageAndEffect
    {
        int _effect;
        bool _canBeStop;
        int _damage;


        public DamageAndEffect(int effect, bool canBeStop,int damage, int rate)
        {
            Effect = effect;
            CanBeStop = canBeStop;
            Damage = damage * rate;
        }

        public int Effect
        {
            get
            {
                return _effect;
            }

            set
            {
                _effect = value;
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
    }
}
