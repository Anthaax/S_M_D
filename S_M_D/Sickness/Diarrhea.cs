using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Character
{
    public class Diarrhea : Sickness
    {
        public Diarrhea()
        {
            base.Name = "Diarrhea";
        }
        override
        public void effect(BaseHeros heros)
        {
            heros.EffectivDamage -= Convert.ToInt32(heros.Damage * 0.1);
        }

        
    }
}
