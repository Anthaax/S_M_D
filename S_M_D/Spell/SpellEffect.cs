using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Spell
{
    public class SpellEffect
    {

        int _damage;
        int _hitChance;
        int _critChance;
        bool _effect;
        int _effectValue;
        bool _poisoning;
        int _poisoningValue;
        int _poisoningTime;
        bool _bleeding;
        int _bleedingValue;
        int _bleedingTime;
        bool _watering;
        int _waterValue;
        int _waterTime;
        bool _fireing;
        int _fireValue;
        int _fireTime;

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

        public int HitChance
        {
            get
            {
                return _hitChance;
            }

            set
            {
                _hitChance = value;
            }
        }

        public int CritChance
        {
            get
            {
                return _critChance;
            }

            set
            {
                _critChance = value;
            }
        }

        public bool Effect
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

        public int EffectValue
        {
            get
            {
                return _effectValue;
            }

            set
            {
                _effectValue = value;
            }
        }

        public bool Poisoning
        {
            get
            {
                return _poisoning;
            }

            set
            {
                _poisoning = value;
            }
        }

        public int PoisoningValue
        {
            get
            {
                return _poisoningValue;
            }

            set
            {
                _poisoningValue = value;
            }
        }

        public int PoisoningTime
        {
            get
            {
                return _poisoningTime;
            }

            set
            {
                _poisoningTime = value;
            }
        }

        public bool Bleeding
        {
            get
            {
                return _bleeding;
            }

            set
            {
                _bleeding = value;
            }
        }

        public int BleedingValue
        {
            get
            {
                return _bleedingValue;
            }

            set
            {
                _bleedingValue = value;
            }
        }

        public int BleedingTime
        {
            get
            {
                return _bleedingTime;
            }

            set
            {
                _bleedingTime = value;
            }
        }

        public bool Watering
        {
            get
            {
                return _watering;
            }

            set
            {
                _watering = value;
            }
        }

        public int WaterValue
        {
            get
            {
                return _waterValue;
            }

            set
            {
                _waterValue = value;
            }
        }

        public int WaterTime
        {
            get
            {
                return _waterTime;
            }

            set
            {
                _waterTime = value;
            }
        }

        public bool Fireing
        {
            get
            {
                return _fireing;
            }

            set
            {
                _fireing = value;
            }
        }

        public int FireValue
        {
            get
            {
                return _fireValue;
            }

            set
            {
                _fireValue = value;
            }
        }

        public int FireTime
        {
            get
            {
                return _fireTime;
            }

            set
            {
                _fireTime = value;
            }
        }
    }
}
