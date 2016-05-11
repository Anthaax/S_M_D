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
    public class TownCreationTests
    {
        [Test]
        public void CreationTownHallTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            TownHallConfig townHallConfig = new TownHallConfig( ctx );
            TownHall townHall = new TownHall( townHallConfig );
            Assert.AreEqual( 500, townHall.BuildingCost );
            Assert.AreEqual( 1, townHall.Level );
            Assert.AreEqual( "Townhall", townHall.Name.ToString() );
        }
        [Test]
        public void CreationArmoryTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ArmoryConfig townHallConfig = new ArmoryConfig( ctx );
            Armory bat = new Armory( townHallConfig );
            Assert.AreEqual( 600, bat.BuildingCost );
            Assert.AreEqual( 0, bat.Level );
            Assert.AreEqual( "Armory", bat.Name.ToString() );
        }
        [Test]
        public void CreationBarTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            BarConfig Config = new BarConfig( ctx );
            Bar bat = new Bar( Config );
            Assert.AreEqual( 900, bat.BuildingCost );
            Assert.AreEqual( 0, bat.Level );
            Assert.AreEqual( "Bar", bat.Name.ToString() );
        }
        [Test]
        public void CreationCaravanTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            CaravanConfig Config = new CaravanConfig( ctx );
            Caravan bat = new Caravan( Config );
            Assert.AreEqual( 500, bat.BuildingCost );
            Assert.AreEqual( 0, bat.Level );
            Assert.AreEqual( "Caravan", bat.Name.ToString() );
        }
        [Test]
        public void CreationCasernTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            CasernConfig Config = new CasernConfig( ctx );
            Casern bat = new Casern( Config );
            Assert.AreEqual( 400, bat.BuildingCost );
            Assert.AreEqual( 0, bat.Level );
            Assert.AreEqual( "Casern", bat.Name.ToString() );
        }
        [Test]
        public void CreationCemeteryTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            CemeteryConfig Config = new CemeteryConfig( ctx );
            Cemetery bat = new Cemetery( Config );
            Assert.AreEqual( 0, bat.BuildingCost );
            Assert.AreEqual( 1, bat.Level );
            Assert.AreEqual( "Cemetery", bat.Name.ToString() );
        }
        [Test]
        public void CreationHospitalTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            HospitalConfig Config = new HospitalConfig( ctx );
            Hospital bat = new Hospital( Config );
            Assert.AreEqual( 1500, bat.BuildingCost );
            Assert.AreEqual( 0, bat.Level );
            Assert.AreEqual( "Hospital", bat.Name.ToString() );
        }
        [Test]
        public void CreationHotelTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            HotelConfig Config = new HotelConfig( ctx );
            Hotel bat = new Hotel( Config );
            Assert.AreEqual( 1000, bat.BuildingCost );
            Assert.AreEqual( 0, bat.Level );
            Assert.AreEqual( "Hotel", bat.Name.ToString() );
        }
        [Test]
        public void CreationMentalHospitalTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            MentalHospitalConfig Config = new MentalHospitalConfig( ctx );
            MentalHospital bat = new MentalHospital( Config );
            Assert.AreEqual( 500, bat.BuildingCost );
            Assert.AreEqual( 0, bat.Level );
            Assert.AreEqual( "MentalHospital", bat.Name.ToString() );
        }
    }
}
