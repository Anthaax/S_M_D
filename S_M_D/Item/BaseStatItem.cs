using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace S_M_D.Character
{

    public abstract class BaseStatItem : BaseItem
    {   
        public enum quality
        {
            useless,
            common,
            rare,
            epic,
            legendary
        }

        public enum stats
        {
            hp = 1,
            mana = 2,
            damage = 3,
            critChance = 4,
            hitChance = 5,
            speed = 6,
            affectRes = 7,
            bleedingRes = 8,
            magicRes = 9,
            fireRes = 10,
            poisonRes = 11,
            waterRes = 12,
            defense = 13,
            dodgeChance = 14,
        }


    }
}
