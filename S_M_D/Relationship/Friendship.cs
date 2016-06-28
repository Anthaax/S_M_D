using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Character
{
    [Serializable]
    public class Friendship : Relationship
    {
        public Friendship(BaseHeros first, BaseHeros second)
        {
            Name = "Desir";
            HeroDuo = new BaseHeros[2];
            HeroDuo[0] = first;
            HeroDuo[1] = second;
            first.GetRelationship(this);
            second.GetRelationship(this);
        }

        override
            public void Effect(BaseHeros heros)
        {
            heros.EffectivDamage += 2;
        }

        public override void EffectOnDeath()
        {
            HeroDuo[0].DeleteRelationship( this );
            HeroDuo[1].DeleteRelationship( this );
        }
    }
}
