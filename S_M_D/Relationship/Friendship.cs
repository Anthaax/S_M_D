using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Character
{
    public class Friendship : Relationship
    {
        public Friendship(BaseHeros first, BaseHeros second)
        {
            Name = "Desir";
            HeroDuo = new BaseHeros[2];
            HeroDuo[0] = first;
            HeroDuo[1] = second;
        }

        override
            public void Effect(BaseHeros heros)
        {
            heros.EffectivDamage += 2;
        }

        public override void EffectOnDeath()
        {
            throw new NotImplementedException();
        }
    }
}
