using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.Class
{
    public interface ISingleHero
    {
        void SetHero( BaseHeros hero );
        void DeleteHero();
    }
}
