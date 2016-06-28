using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Character
{
    [Serializable]
    public class Fever : Sickness
    {
        public Fever ()
        {
            base.Name = "Fever";
        }

        override
        public void effect(BaseHeros heros)
        {
            heros.EffectivDefense -= Convert.ToInt32(heros.Defense * 0.2);
            heros.EffectivDamage += Convert.ToInt32(heros.Damage * 0.2);
        }
    }
}
