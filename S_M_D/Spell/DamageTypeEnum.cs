using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;


namespace S_M_D.Spell
{
    [Serializable]
    public enum DamageTypeEnum
    {
        Physical = 1,
        Magical = 2,
        Bleeding = 3,
        Poison = 4,
        Fire = 5,
        Affect = 6,
        Water = 7,
        Heal = 8
    }
}