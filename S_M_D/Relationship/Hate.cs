using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Character
{
    public class Hate : Relationship
    {
        public Hate(BaseHeros first, BaseHeros second)
        {
            Name = "hate";
            HeroDuo = new BaseHeros[2];
            HeroDuo[0] = first;
            HeroDuo[1] = second;
        }

        override
            public void Effect(BaseHeros heros)
        {
            heros.EffectivDamage += Convert.ToInt32(heros.Damage * 0.5);
            heros.EffectivDefense += Convert.ToInt32(heros.Defense * 0.5);
        }

        public override void EffectOnDeath()
        {
            throw new NotImplementedException();
        }
    }
}
