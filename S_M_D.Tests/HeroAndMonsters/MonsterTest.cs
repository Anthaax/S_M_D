using NUnit.Framework;
using S_M_D.Character;
using S_M_D.Character.Monsters;
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
            BaseMonster orcMonster = config.CreateMonster( MonsterType.ORC, 1 );

            Assert.AreEqual( 105, orcMonster.HPmax );
            Assert.AreEqual( 105, orcMonster.HP );
            Assert.AreEqual( 25, orcMonster.ManaMax );
            Assert.AreEqual( 25, orcMonster.Mana );
            Assert.AreEqual( 10, orcMonster.Damage );
            Assert.AreEqual( 50, orcMonster.CritChance );
            Assert.AreEqual( 1000, orcMonster.HitChance );
            Assert.AreEqual( 5, orcMonster.Speed );
            Assert.AreEqual( 0, orcMonster.AffectRes );
            Assert.AreEqual( 0, orcMonster.BleedingRes );
            Assert.AreEqual( 0, orcMonster.MagicRes );
            Assert.AreEqual( 0, orcMonster.FireRes );
            Assert.AreEqual( 0, orcMonster.PoisonRes );
            Assert.AreEqual( 0, orcMonster.WaterRes );
            Assert.AreEqual( 0, orcMonster.Defense );
            Assert.AreEqual( 0, orcMonster.DodgeChance );
            Assert.AreEqual( 2, orcMonster.GiveXp );
            Assert.AreEqual( MonsterType.ORC, orcMonster.Type );
        }
        [Test]
        public void CreationElfTest()
        {
            MonsterConfiguration config = new MonsterConfiguration();
            BaseMonster orcMonster = config.CreateMonster(MonsterType.ELF, 2);

            Assert.AreEqual(104, orcMonster.HPmax);
            Assert.AreEqual(104, orcMonster.HP);
            Assert.AreEqual(50, orcMonster.ManaMax);
            Assert.AreEqual(50, orcMonster.Mana);
            Assert.AreEqual(15, orcMonster.Damage);
            Assert.AreEqual(0, orcMonster.CritChance);
            Assert.AreEqual(1000, orcMonster.HitChance);
            Assert.AreEqual(9, orcMonster.Speed);
            Assert.AreEqual(0, orcMonster.AffectRes);
            Assert.AreEqual(0, orcMonster.BleedingRes);
            Assert.AreEqual(0, orcMonster.MagicRes);
            Assert.AreEqual(0, orcMonster.FireRes);
            Assert.AreEqual(0, orcMonster.PoisonRes);
            Assert.AreEqual(0, orcMonster.WaterRes);
            Assert.AreEqual(0, orcMonster.Defense);
            Assert.AreEqual(40, orcMonster.DodgeChance);
            Assert.AreEqual(2, orcMonster.GiveXp);
            Assert.AreEqual(MonsterType.ELF, orcMonster.Type);
        }
        [Test]
        public void CreationTrollTest()
        {
            MonsterConfiguration config = new MonsterConfiguration();
            BaseMonster orcMonster = config.CreateMonster(MonsterType.TROLL, 1);

            Assert.AreEqual(108, orcMonster.HPmax);
            Assert.AreEqual(108, orcMonster.HP);
            Assert.AreEqual(43, orcMonster.ManaMax);
            Assert.AreEqual(43, orcMonster.Mana);
            Assert.AreEqual(15, orcMonster.Damage);
            Assert.AreEqual(30, orcMonster.CritChance);
            Assert.AreEqual(1000, orcMonster.HitChance);
            Assert.AreEqual(5, orcMonster.Speed);
            Assert.AreEqual(0, orcMonster.AffectRes);
            Assert.AreEqual(0, orcMonster.BleedingRes);
            Assert.AreEqual(0, orcMonster.MagicRes);
            Assert.AreEqual(0, orcMonster.FireRes);
            Assert.AreEqual(0, orcMonster.PoisonRes);
            Assert.AreEqual(0, orcMonster.WaterRes);
            Assert.AreEqual(0, orcMonster.Defense);
            Assert.AreEqual(10, orcMonster.DodgeChance);
            Assert.AreEqual(8, orcMonster.GiveXp);
            Assert.AreEqual(MonsterType.TROLL, orcMonster.Type);
        }
        [Test]
        public void DeadMonsterTest()
        {
            MonsterConfiguration config = new MonsterConfiguration();
            MonsterManager manager = new MonsterManager();
            BaseMonster orcMonster = config.CreateMonster( MonsterType.ORC, 1 );
            BaseMonster elfMonster = config.CreateMonster( MonsterType.ELF, 1 );
            List<BaseMonster> monsters = new List<BaseMonster>();

            orcMonster.HP = 0;
            monsters.Add( orcMonster );
            monsters.Add( elfMonster );

            manager.printList( monsters );
            manager.DeleteDeadMonster( monsters );
            manager.printList( monsters );

            Assert.AreEqual( 1, monsters.Count );
            Assert.AreEqual( MonsterType.ELF, monsters[0].Type );
        }
    }
}
