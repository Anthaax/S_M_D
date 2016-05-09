using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_M_D.Character.Monsters.Settings
{
    public class MonsterManager
    {
        public List<BaseMonster> DeleteDeadMonster(List<BaseMonster> list)
        {
            foreach(BaseMonster monster in list)
            {
                if (monster.HP <= 0) list.Remove(monster);
            }
            return list;
        }
    }
}
