using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            ItemManager createNewItem = new ItemManager();
            createNewItem.CreateWeapon();
            createNewItem.CreateTrinket();
            createNewItem.CreateArmor();

        }
    }
}
