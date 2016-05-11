using NUnit.Framework;
using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_M_D.Tests
{
    [TestFixture]
    public class Spells
    {
        [Test]
        public void SpellWarriorTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find(HerosEnum.Warrior.ToString()).CreateHero();
            Assert.IsNotEmpty(ctx.PlayerInfo.MyHeros.First().Spells);
            Assert.AreEqual("BasicAttack", ctx.PlayerInfo.MyHeros.First().Spells.First().Name);
        }

        [Test]
        public void SpellPaladinTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find(HerosEnum.Paladin.ToString()).CreateHero();
            Assert.IsNotEmpty(ctx.PlayerInfo.MyHeros.First().Spells);
            Assert.AreEqual("BasicAttack", ctx.PlayerInfo.MyHeros.First().Spells.First().Name);
        }

        [Test]
        public void SpellPMageTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find(HerosEnum.Mage.ToString()).CreateHero();
            Assert.IsNotEmpty(ctx.PlayerInfo.MyHeros.First().Spells);
            Assert.AreEqual("BasicAttack", ctx.PlayerInfo.MyHeros.First().Spells.First().Name);
            Assert.AreEqual("FireBall", ctx.PlayerInfo.MyHeros.First().Spells[1].Name);
            Assert.AreEqual("ChaosBolt", ctx.PlayerInfo.MyHeros.First().Spells[2].Name);
        }


        [Test]
        public void SpellPriestTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find(HerosEnum.Priest.ToString()).CreateHero();
            Assert.IsNotEmpty(ctx.PlayerInfo.MyHeros.First().Spells);
            Assert.AreEqual("BasicAttack", ctx.PlayerInfo.MyHeros.First().Spells.First().Name);
        }
    }
}
