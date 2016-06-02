using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace S_M_D.Character
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

        public override void LevelUp()
        {
            Lvl++;
        }
    }
}
