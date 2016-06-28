using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Character
{
    [Serializable]
    public class Arrogant : Psychology
    {
        public Arrogant()
        {
            Name = "Arrogant";
        }
        override
            public void effect(BaseHeros heros)
        {
            heros.EffectCritChance += Convert.ToInt32(heros.EffectCritChance * 0.5);
        }
    }
}
