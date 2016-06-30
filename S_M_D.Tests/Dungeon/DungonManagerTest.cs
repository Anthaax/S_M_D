using NUnit.Framework;
using S_M_D.Camp.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_M_D.Dungeon.Tests
{
    [TestFixture]
    class DungonManagerTest
    {
        [Test]
        public void CreateDungeonManger()
        {
            GameContext ctx = GameContext.CreateNewGame( 1 );
            Assert.IsNotNull( ctx.DungeonManager );
            ctx.DungeonManager.InitializedCatalogue();
            Assert.IsNotEmpty( ctx.DungeonManager.MapCatalogue );
            ctx.DungeonManager.CreateDungeon( ctx.PlayerInfo.MyHeros.ToArray(), ctx.DungeonManager.MapCatalogue[ctx.Rnd.Next( ctx.DungeonManager.MapCatalogue.Count )] );
            Assert.IsNotNull( ctx.DungeonManager.CurentDungeon );
            ctx.DungeonManager.LaunchCombat();
            Assert.IsNotNull( ctx.DungeonManager.CbtManager );

        }
        [Test]
        public void EndOfTheDuengon()
        {
            GameContext ctx = GameContext.CreateNewGame( 1 );
            ctx.DungeonManager.InitializedCatalogue();
            ctx.DungeonManager.CreateDungeon( ctx.PlayerInfo.MyHeros.ToArray(), ctx.DungeonManager.MapCatalogue[ctx.Rnd.Next( ctx.DungeonManager.MapCatalogue.Count )] );
            ctx.DungeonManager.LaunchCombat();
            ctx.DungeonManager.CbtManager.ApplyRewward();

            Armory armory = ctx.PlayerInfo.GetBuilding( BuildingNameEnum.Armory ) as Armory;
            armory.SetHero( ctx.PlayerInfo.MyHeros.First() );
            int xp = 0;
            ctx.DungeonManager.CbtManager.Monsters.ToList().ForEach( h => xp += h.GiveXp );
            ctx.DungeonManager.EndOfTheDuengon();

            Assert.AreEqual( ctx.DungeonManager.Reward.Xp / 4, ctx.PlayerInfo.MyHeros.First().Xp );
            Assert.AreEqual( 1, ctx.PlayerInfo.MyItems.Count );
            Assert.AreEqual( 10100, ctx.MoneyManager.Money );
            Assert.AreEqual( 1, ctx.PlayerInfo.NumberOfWeek );
            Assert.AreEqual( null, armory.Hero );
        }
        [Test]
        public void EndOfTheDuengonWithoutCombat()
        {
            GameContext ctx = GameContext.CreateNewGame( 1 );
            ctx.DungeonManager.InitializedCatalogue();
            ctx.DungeonManager.CreateDungeon( ctx.PlayerInfo.MyHeros.ToArray(), ctx.DungeonManager.MapCatalogue[ctx.Rnd.Next( ctx.DungeonManager.MapCatalogue.Count )] );

            Armory armory = ctx.PlayerInfo.GetBuilding( BuildingNameEnum.Armory ) as Armory;
            armory.SetHero( ctx.PlayerInfo.MyHeros.First() );
            MutipleEndOfDuengon( ctx, 40 );

            Assert.AreEqual( 40, ctx.PlayerInfo.NumberOfWeek );

            Assert.AreEqual( null, armory.Hero );
        }
        private void MutipleEndOfDuengon(GameContext ctx ,int number)
        {
            for (int i = 0; i < number; i++)
            {
                ctx.DungeonManager.EndOfTheDuengon();
            }
        }
    }
}
