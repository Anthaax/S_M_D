using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Character.Monsters
{
    public class MonsterConfiguration
    {
        public BaseMonster CreateMonster(BaseMonster Poco, int level)
        {
            switch(Poco.Type)
            {
                case MonsterType.ORC:
                    Poco.HPmax = 20+5*level;
                    Poco.HP = 20 + 5 * level;
                    Poco.ManaMax = 20 + 5 * level;
                    Poco.Mana = 20 + 5 * level;
                    Poco.Damage = 3 + 5 * level;
                    Poco.CritChance = 50;
                    Poco.HitChance = 50;
                    Poco.Speed = 5;
                    Poco.AffectRes = 0;
                    Poco.BleedingRes = 0;
                    Poco.MagicRes = 0;
                    Poco.FireRes = 0;
                    Poco.PoisonRes = 0;
                    Poco.WaterRes = 0;
                    Poco.Defense = 0;
                    Poco.DodgeChance = 0;
                    Poco.GiveXp = 2;
                    Poco.Type = MonsterType.ORC;
                    return Poco;

                case MonsterType.ELF:
                    Poco.HPmax = 20 + 2 * level;
                    Poco.HP = 20 + 2 * level;
                    Poco.ManaMax = 40 + 5 * level;
                    Poco.Mana = 40 + 5 * level;
                    Poco.Damage = 2 + 5 * level;
                    Poco.CritChance = 0;
                    Poco.HitChance = 80;
                    Poco.Speed = 10;
                    Poco.AffectRes = 0;
                    Poco.BleedingRes = 0;
                    Poco.MagicRes = 0;
                    Poco.FireRes = 0;
                    Poco.PoisonRes = 0;
                    Poco.WaterRes = 0;
                    Poco.Defense = 0;
                    Poco.DodgeChance = 40;
                    Poco.GiveXp = 2;
                    Poco.Type = MonsterType.ELF;
                    return Poco;

                default:
                    throw new Exception("Not poco detected!");
            }
            
        }
    }
}
