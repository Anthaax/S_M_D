using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Character
{
    [Serializable]
    public class Love : Relationship
    {
        public Love(BaseHeros first, BaseHeros second)
        {
            Name = "love";
            HeroDuo = new BaseHeros[2];
            HeroDuo[0] = first;
            HeroDuo[1] = second;
            first.GetRelationship(this);
            second.GetRelationship(this);
        }

        override
            public void Effect(BaseHeros heros)
        {
            heros.EffectivDamage += Convert.ToInt32(heros.Damage * 0.1);
            heros.EffectivDefense += Convert.ToInt32(heros.Defense * 0.1);
        }

        public override void EffectOnDeath()
        {
            HeroDuo[0].DeleteRelationship( this );
            HeroDuo[1].DeleteRelationship( this );
        }
    }
}
