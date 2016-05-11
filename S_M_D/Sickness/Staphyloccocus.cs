using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Character
{
    public class Staphyloccocus : Sickness
    {
        public Staphyloccocus()
        {
            Name = "Staphyloccocus";
        }

        override
        public void effect(BaseHeros heros)
        {
            heros.EffectivSpeed -= Convert.ToInt32(heros.Speed * 0.5);
        }
    }
}