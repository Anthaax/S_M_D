﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Character
{
    [Serializable]
    public class Cancer : Sickness
    {
        public Cancer()
        {
            Name = "Cancer";
        }

        override
        public void effect(BaseHeros heros)
        {
            heros.EffectivHPMax -= 8;
        }
    }
}