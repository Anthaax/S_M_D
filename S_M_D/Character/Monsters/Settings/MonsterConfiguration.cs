using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Spell;
using S_M_D.Spell.Monsters;

namespace S_M_D.Character.Monsters
{
    [Serializable]
    public class MonsterConfiguration
    {
        /// <summary>
        /// Create a Monster and return this monster
        /// </summary>
        /// <param name="type">Need and monster type return exeption if null</param>
        /// <param name="level">Need a level for create a monster with the good stats</param>
        /// <returns></returns>
        public BaseMonster CreateMonster(MonsterType type, int level)
        {
            BaseMonster Poco = new BaseMonster();
            switch(type)
            {
                case MonsterType.ORC:
                    Poco.HPmax = 20+5*level;
                    Poco.HP = 20 + 5 * level;
                    Poco.ManaMax = 20 + 5 * level;
                    Poco.Mana = 20 + 5 * level;
                    Poco.Damage = 3 + 5 * level;
                    Poco.CritChance = 50;
                    Poco.Lvl = level;
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
                    Poco.InitializedEffectiveStats();
                    Poco.Spells = new List<Spells>();
                    Poco.Spells.Add( new CerebralAttack( Poco ) );
                    Poco.Spells.Add( new BasicAttack( Poco ) );
                    Poco.Spells.Add( new BlackPlague( Poco ) );
                    Poco.Spells.Add( new FlameThrower( Poco ) );
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
                    Poco.Speed = 9;
                    Poco.Lvl = level;
                    Poco.AffectRes = 0;
                    Poco.BleedingRes = 0;
                    Poco.MagicRes = 0;
                    Poco.FireRes = 0;
                    Poco.PoisonRes = 0;
                    Poco.WaterRes = 0;
                    Poco.Defense = 0;
                    Poco.DodgeChance = 40;
                    Poco.GiveXp = 2;
                    Poco.InitializedEffectiveStats();
                    Poco.Type = MonsterType.ELF;
                    Poco.Spells = new List<Spells>();
                    Poco.Spells.Add( new CerebralAttack( Poco ) );
                    Poco.Spells.Add( new BasicAttack( Poco ) );
                    Poco.Spells.Add( new BlackPlague( Poco ) );
                    Poco.Spells.Add( new FlameThrower( Poco ) );
                    return Poco;
                
                case MonsterType.TROLL:
                    Poco.HPmax = 20 + 8 * level;
                    Poco.HP = 20 + 8 * level;
                    Poco.ManaMax = 40 + 3 * level;
                    Poco.Mana = 40 +3 * level;
                    Poco.Damage = 2 + 10 * level;
                    Poco.CritChance = 30;
                    Poco.HitChance = 70;
                    Poco.Speed = 5;
                    Poco.AffectRes = 0;
                    Poco.BleedingRes = 0;
                    Poco.MagicRes = 0;
                    Poco.Lvl = level;
                    Poco.FireRes = 0;
                    Poco.PoisonRes = 0;
                    Poco.WaterRes = 0;
                    Poco.Defense = 0;
                    Poco.DodgeChance = 10;
                    Poco.GiveXp = 8;
                    Poco.InitializedEffectiveStats();
                    Poco.Type = MonsterType.TROLL;
                    Poco.Spells = new List<Spells>();
                    Poco.Spells.Add( new BasicAttack( Poco ) );
                    Poco.Spells.Add( new CerebralAttack( Poco ) );
                    Poco.Spells.Add( new BlackPlague( Poco ) );
                    Poco.Spells.Add( new FlameThrower( Poco ) );
                    return Poco;

                default:
                    throw new Exception("Not poco detected!");
            }
            
        }
    }
}
