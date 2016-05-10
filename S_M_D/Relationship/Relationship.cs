using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace S_M_D.Character
{
   public abstract class Relationship
    {
        string _name;
        BaseHeros[] heroDuo;

        abstract public void Effect(BaseHeros heros);
        abstract public void EffectOnDeath();

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public BaseHeros[] HeroDuo
        {
            get
            {
                return heroDuo;
            }

            set
            {
                heroDuo = value;
            }
        }
    }
}
