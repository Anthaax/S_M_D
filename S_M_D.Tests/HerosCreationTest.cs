using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using S_M_D.Character;

namespace S_M_D.Tests
{
    [TestFixture]
    public class HerosCreationTest
    {
        [Test]
        public void CreationHeroAddIntoListTest()
        {
            List<BaseHeros> b = new List<BaseHeros>();
            HerosManager h = new HerosManager( b );
            h.Find( HerosEnum.Warrior.ToString() ).CreateHero();
            Assert.IsNotEmpty( b );
            h.Find( HerosEnum.Paladin.ToString() ).CreateHero();
            Assert.AreEqual( 2, b.Count );
        }
        [Test]
        public void CreationHeroClassNameTest()
        {
            List<BaseHeros> b = new List<BaseHeros>();
            HerosManager h = new HerosManager( b );
            string name = h.Find( HerosEnum.Warrior.ToString() ).CharacterClassName;
            Assert.AreEqual( HerosEnum.Warrior.ToString(), name );
            name = h.Find( HerosEnum.Paladin.ToString() ).CharacterClassName;
            Assert.AreEqual( HerosEnum.Paladin.ToString(), name );
        }
    }
}
