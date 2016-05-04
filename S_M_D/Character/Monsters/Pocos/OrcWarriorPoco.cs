using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S_M_D.Character;

namespace S_M_D.Character.Monsters.Pocos
{
    public class OrcWarriorPoco : BaseMonster
    {
        public OrcWarriorPoco()
        {
            HPmax = 20;
            HP = 20;
            ManaMax = 20;
            Mana = 20;
            Damage = 3;
            CritChance = 0;
            HitChance = 50;
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
            Type = MonsterType.ORC;
        }
        
    }
}
