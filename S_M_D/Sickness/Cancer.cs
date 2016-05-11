using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Character
{
    public class Cancer : Sickness
    {
        public Cancer()
        {
            Name = "Cancer";
        }

        override
        public void effect(BaseHeros heros)
        {
            heros.EffectivHPMax -= Convert.ToInt32(heros.HPmax * 0.1);
        }
    }
}