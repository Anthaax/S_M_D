using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Character
{
    public class BaseCharacterComparer : IComparer<BaseCharacter>
    {
        public int Compare( BaseCharacter x, BaseCharacter y )
        {
            if (x.Speed > y.Speed)
                return -1;
            if (x.Speed < y.Speed)
                return 1;
            return 0;
        }
    }
}
