using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Character
{

    [Serializable]
    public class BaseWeapon : BaseStatItem
    {
        public enum WeaponType
        {
            Arc,
            Axe,
            Sword,
            Staff
        }

        WeaponType weaponType;

        public WeaponType WeaponType1
        {
            get
            {
                return weaponType;
            }

            set
            {
                weaponType = value;
            }
        }

        public override void LevelUp()
        {
            Lvl++;
        }
    }
}