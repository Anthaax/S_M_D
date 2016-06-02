using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;

namespace S_M_D.Tests
{
    [TestFixture]
    public class GameContextTest
    {
        [Test]
        public void SaveAndLoadGameContext()
        {
            GameContext ctx = GameContext.CreateNewGame();
            string folderName = @"C:\SauvegardeS_M_D";
            string nameSave = ctx.SaveName;
            ctx.Save(folderName);
            GameContext.LoadResult load = GameContext.LoadGame(Path.Combine(folderName, nameSave));
            GameContext ctx2 = load.LoadedGame;
            Assert.AreEqual(ctx.SaveName, ctx2.SaveName);
        }
    }
}
