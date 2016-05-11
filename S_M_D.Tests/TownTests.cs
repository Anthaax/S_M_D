using NUnit.Framework;
using S_M_D.Camp;
using S_M_D.Camp.Class;
using S_M_D.Camp.ClassConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_M_D.Tests
{
    [TestFixture]
    public class TownTests
    {
        [Test]
        public void CreationTownHallTest()
        {
            TownHallConfig townHallConfig = new TownHallConfig("TownHall", 200, 1, new List<BaseBuilding>());
            TownHall townHall = new TownHall(townHallConfig);
            Assert.AreEqual(200, townHall.BuildingCost);
            Assert.AreEqual(1, townHall.Level);
            Assert.AreEqual("TownHall", townHall.Name);
        }
    }
}
