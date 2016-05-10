using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_M_D.Character
{
    public abstract class Psychology
    {
        abstract public void effect(BaseHeros heros);

        string name;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
    }
}
