using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Character
{
    [Serializable]
    public class Fragil : Psychology
    {
        public Fragil()
        {
            Name = "Fragil";
        }
                    override
            public void effect(BaseHeros heros)
        {
            heros.EffectivDefense -= 10;
        }
    }
}
