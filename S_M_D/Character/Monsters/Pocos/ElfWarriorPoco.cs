using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_M_D.Character.Monsters.Pocos
{
    public class ElfWarriorPoco : BaseMonster
    {
        public ElfWarriorPoco()
        {
            HPmax = 10;
            HP = 10;
            ManaMax = 40;
            Mana = 40;
            Damage = 2;
            CritChance = 20;
            HitChance = 70;
            Speed = 5;
            AffectRes = 0;
            BleedingRes = 0;
            MagicRes = 0;
            FireRes = 0;
            PoisonRes = 0;
            WaterRes = 0;
            Defense = 0;
            DodgeChance = 0;
            GiveXp = 2;
            Type = MonsterType.ELF;
        }
       
    }
}
