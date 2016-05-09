using S_M_D.Character.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_M_D.Character
{
    public class BaseMonster : BaseCharacter
    {
        protected int _giveXp;
        protected MonsterType _type;


        public int GiveXp
        {
            get
            {
                return _giveXp;
            }

            set
            {
                _giveXp = value;
            }
        }

        public MonsterType Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }
    }
}
