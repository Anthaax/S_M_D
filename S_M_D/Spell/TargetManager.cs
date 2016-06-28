using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Spell
{
    [Serializable]
    public class TargetManager
    {
        readonly bool[] _heroPosition;
        readonly bool[] _canBeTargetable;
        readonly int _radius;

        public TargetManager(int radius, bool[] heroPosition, bool[] canBeTargetable )
        {
            _radius = radius;
            _canBeTargetable = canBeTargetable;
            _heroPosition = heroPosition;
        }
        public bool[] CanBeTargetable
        {
            get
            {
                return _canBeTargetable;
            }
        }

        public int Radius
        {
            get
            {
                return _radius;
            }
        }

        public bool[] HeroPosition
        {
            get
            {
                return _heroPosition;
            }
        }

        public bool[] WhoCanBeTargetable(int Position)
        {
            if(HeroPosition[Position])
            {
                return CanBeTargetable;
            }
            return new bool[4] { false, false, false, false };
        }
    }
}
