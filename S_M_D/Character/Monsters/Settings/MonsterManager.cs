using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Character.Monsters
{
    public class MonsterManager
    {
        /// <summary>
        /// Delete a monster from a list
        /// </summary>
        /// <param name="list"></param>
        public void DeleteDeadMonster(List<BaseMonster> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].HP <= 0)
                {
                    list.RemoveAt(i);
                }
            }
        }

        public void printList(List<BaseMonster> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].Type.ToString() + " : " + list[i].HP);
            }
        }
    }
}
