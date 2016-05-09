using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ItemCreator
{
    [Serializable]
    public class BasePotion : BaseStatItem 
    {
        public enum PotionTypes
        {
            HP,
            Mana
        }
        PotionTypes potiontype;
        int effect;


        public PotionTypes Potiontype
        {
            get
            {
                return potiontype;
            }

            set
            {
                potiontype = value;
            }
        }

        public int Effect
        {
            get
            {
                return effect;
            }

            set
            {
                effect = value;
            }
        }
    }
}
