using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Character
{
    [Serializable]
    public class Agressivity : Psychology
    {
        public Agressivity()
        {
            Name = "Agressivity";
        }
        override
            public void effect(BaseHeros heros)
        {
            heros.EffectivDamage += Convert.ToInt32(heros.Damage * 0.5);
            heros.EffectCritChance += Convert.ToInt32(heros.EffectCritChance * 0.5);
            heros.EffectivHitChance -= Convert.ToInt32(heros.EffectivHitChance * 0.5);
        }
    }
}