using NUnit.Framework;
using S_M_D.Character;
using S_M_D.Character.Monsters;
using S_M_D.Character.Monsters.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_M_D.Tests
{
    [TestFixture]
    public class MonstersTest
    {
        [Test]
        public void CreationOrcTest()
        {
            MonsterConfiguration config = new MonsterConfiguration();
            BaseMonster orcMonster = config.CreateMonster(MonsterType.ORC, 1);

            Assert.AreEqual(25, orcMonster.HPmax);
            Assert.AreEqual(25, orcMonster.HP);
            Assert.AreEqual(25, orcMonster.ManaMax);
            Assert.AreEqual(25, orcMonster.Mana);
            Assert.AreEqual(8, orcMonster.Damage);
            Assert.AreEqual(50, orcMonster.CritChance);
            Assert.AreEqual(50, orcMonster.HitChance);
            Assert.AreEqual(5, orcMonster.Speed);
            Assert.AreEqual(0, orcMonster.AffectRes);
            Assert.AreEqual(0, orcMonster.BleedingRes);
            Assert.AreEqual(0, orcMonster.MagicRes);
            Assert.AreEqual(0, orcMonster.FireRes);
            Assert.AreEqual(0, orcMonster.PoisonRes);
            Assert.AreEqual(0, orcMonster.WaterRes);
            Assert.AreEqual(0, orcMonster.Defense);
            Assert.AreEqual(0, orcMonster.DodgeChance);
            Assert.AreEqual(2, orcMonster.GiveXp);
            Assert.AreEqual(MonsterType.ORC, orcMonster.Type);
        }

        [Test]
        public void DeadMonsterTest()
        {
            MonsterConfiguration config = new MonsterConfiguration();
            MonsterManager manager = new MonsterManager();
            BaseMonster orcMonster = config.CreateMonster(MonsterType.ORC, 1);
            BaseMonster elfMonster = config.CreateMonster(MonsterType.ELF, 1);
            List<BaseMonster> monsters = new List<BaseMonster>();

            orcMonster.HP = 0;
            monsters.Add(orcMonster);
            monsters.Add(elfMonster);

            manager.printList(monsters);
            manager.DeleteDeadMonster(monsters);
            manager.printList(monsters);

            Assert.AreEqual(1, monsters.Count);
            Assert.AreEqual(MonsterType.ELF, monsters[0].Type);

        }
    }
}
