using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemCreator
{
    [Serializable]
    public class BaseArmor : BaseStatItem
    {
        public enum ArmorType
        {
            Dress,
            Badass,
            Latex
        }

        ArmorType armoType;

        public ArmorType ArmoType
        {
            get
            {
                return armoType;
            }

            set
            {
                armoType = value;
            }
        }
    }
}
