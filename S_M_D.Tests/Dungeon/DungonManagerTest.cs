using NUnit.Framework;
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
    }
}
