using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.Class
{
    public interface IMultipleHero
    {
        void SetHeros( BaseHeros hero1, BaseHeros hero2 );
        void DeleteHeros();
    }
}
