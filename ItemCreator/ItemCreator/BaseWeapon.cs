using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemCreator
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
    }
}