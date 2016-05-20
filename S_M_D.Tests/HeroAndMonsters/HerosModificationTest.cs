using NUnit.Framework;
using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace S_M_D.Tests
{
    [TestFixture]
    class HerosModificationTest
    {
        [Test]
        public void DiarrheaWariorTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find(HerosEnum.Warrior.ToString()).CreateHero();
            Warrior warrior = ctx.PlayerInfo.MyHeros[3] as Warrior;
            Diarrhea test = new Diarrhea();
            warrior.GetSickness(test);
            Assert.AreEqual(warrior.EffectivDamage, 10);
            warrior.DeleteSickness(test);
            Assert.AreEqual(warrior.EffectivDamage, warrior.Damage);

        }

        [Test]
        public void FeverWariorTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find(HerosEnum.Warrior.ToString()).CreateHero();
            Warrior warrior = ctx.PlayerInfo.MyHeros[3] as Warrior;
            Fever test = new Fever();
            warrior.GetSickness(test);
            Assert.AreEqual(warrior.EffectivDamage, 13);
            Assert.AreEqual(warrior.EffectivDefense, 32);
            Assert.Throws<ArgumentException>(() => warrior.GetSickness(test));
            warrior.DeleteSickness(test);
            Assert.AreEqual(warrior.EffectivDamage, warrior.Damage);
            Assert.AreEqual(warrior.EffectivDefense, warrior.Defense);

        }

        [Test]
        public void CancerWarriorTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find(HerosEnum.Warrior.ToString()).CreateHero();
            Warrior warrior = ctx.PlayerInfo.MyHeros[3] as Warrior;
            Cancer cancer = new Cancer();
            warrior.GetSickness(cancer);
            Assert.AreEqual(warrior.EffectivHPMax, 42);
            warrior.DeleteSickness(cancer);
            Assert.AreEqual(warrior.EffectivHPMax, warrior.HPmax);
        }

        [Test]
        public void WarriorStaphyloccocusTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find(HerosEnum.Warrior.ToString()).CreateHero();
            Warrior warrior = ctx.PlayerInfo.MyHeros[3] as Warrior;
            Staphyloccocus stap = new Staphyloccocus();
            warrior.GetSickness(stap);
            Assert.AreEqual(warrior.EffectivSpeed, 0);
            warrior.DeleteSickness(stap);
            Assert.AreEqual(warrior.EffectivSpeed, warrior.Speed);
        }

        [Test]
        public void CrazynessWarriorTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find(HerosEnum.Warrior.ToString()).CreateHero();
            Warrior warrior = ctx.PlayerInfo.MyHeros[3] as Warrior;
            Crazyness test = new Crazyness();
            warrior.GetPsycho(test);
            Assert.AreEqual(warrior.EffectivDamage, 17);
            Assert.AreEqual(warrior.EffectCritChance, 30);
            Assert.AreEqual(warrior.EffectivHitChance, 30);
            Assert.Throws<ArgumentException>(() => warrior.GetPsycho(test));
            warrior.DeletePsycho(test);
            Assert.AreEqual(warrior.EffectivDamage, warrior.Damage);
            Assert.AreEqual(warrior.EffectCritChance, warrior.CritChance);
            Assert.AreEqual(warrior.EffectivHitChance, warrior.HitChance);
        }

        [Test]
        public void FragilWarriorTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find(HerosEnum.Warrior.ToString()).CreateHero();
            Warrior warrior = ctx.PlayerInfo.MyHeros[3] as Warrior;
            Fragil fragil = new Fragil();
            warrior.GetPsycho(fragil);
            Assert.AreEqual(warrior.EffectivDefense, 30);
            warrior.DeletePsycho(fragil);
            Assert.AreEqual(warrior.EffectivDefense, warrior.Defense);
        }

        [Test]
        public void ArrogantWarriorTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find(HerosEnum.Warrior.ToString()).CreateHero();
            Warrior warrior = ctx.PlayerInfo.MyHeros[3] as Warrior;
            Arrogant arrogant = new Arrogant();
            warrior.GetPsycho(arrogant);
            Assert.AreEqual(warrior.EffectCritChance, 30);
            warrior.DeletePsycho(arrogant);
            Assert.AreEqual(warrior.EffectCritChance, warrior.CritChance);
        }

        [Test]
        public void AgressivityWarriorTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Warrior warrior = ctx.PlayerInfo.MyHeros[3] as Warrior;
            Agressivity agressivity = new Agressivity();
            warrior.GetPsycho(agressivity);
            Assert.AreEqual(warrior.EffectivDamage, 17);
            Assert.AreEqual(warrior.EffectCritChance, 30);
            warrior.DeletePsycho(agressivity);
            Assert.AreEqual(warrior.EffectivDamage, warrior.Damage);
        }
        [Test]
        public void LoveBetweenWarriorAndMageTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find(HerosEnum.Warrior.ToString()).CreateHero();
            Warrior warrior = ctx.PlayerInfo.MyHeros[3] as Warrior;
            Mage mage = ctx.PlayerInfo.MyHeros[0] as Mage;
            Love love = new Love(warrior, mage);
            Assert.AreEqual(warrior.EffectivDamage, 12);
            Assert.AreEqual(warrior.EffectivDefense, 44);
            Assert.AreEqual(mage.EffectivDamage, 4);
            Assert.AreEqual(mage.EffectivDefense, 11);
            mage.DeleteRelationship(love);
            warrior.DeleteRelationship(love);
            Assert.AreEqual(warrior.EffectivDamage, warrior.Damage);
            Assert.AreEqual(warrior.EffectivDefense, warrior.Defense);
            Assert.AreEqual(mage.EffectivDamage, mage.Damage);
            Assert.AreEqual(mage.EffectivDefense, mage.Defense);
        }
        [Test]
        public void HateBetweenTwoWarriorTest ()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find(HerosEnum.Warrior.ToString()).CreateHero();
            ctx.HeroManager.Find(HerosEnum.Mage.ToString()).CreateHero();

            Warrior warrior = ctx.PlayerInfo.MyHeros[3] as Warrior;
            Mage mage = ctx.PlayerInfo.MyHeros[0] as Mage;
            Hate hate = new Hate(warrior, mage);
            Assert.AreEqual(warrior.Damage += Convert.ToInt32(warrior.Damage * 0.5), warrior.EffectivDamage);
            Assert.AreEqual(warrior.Defense += Convert.ToInt32(warrior.Defense * 0.5), warrior.EffectivDefense);
            Assert.AreEqual(mage.Damage += Convert.ToInt32(mage.Damage * 0.5), mage.EffectivDamage);
            Assert.AreEqual(mage.Defense += Convert.ToInt32(mage.Defense * 0.5), mage.EffectivDefense);
        }

        [Test]
        public void DesirBetweenTwoWarriorTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find(HerosEnum.Warrior.ToString()).CreateHero();
            ctx.HeroManager.Find(HerosEnum.Mage.ToString()).CreateHero();

            Warrior warrior = ctx.PlayerInfo.MyHeros[3] as Warrior;
            Mage mage = ctx.PlayerInfo.MyHeros[0] as Mage;
            Desir desir = new Desir(warrior, mage);
            Assert.AreEqual(warrior.HitChance - 2, warrior.EffectivHitChance);
            Assert.AreEqual(mage.EffectivHitChance, mage.HitChance-2);
            desir.EffectOnDeath();
            Assert.IsEmpty( warrior.Relationship );
        }

        [Test]
        public void FriendshipBetweenTwooWarriorTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find(HerosEnum.Warrior.ToString()).CreateHero();
            ctx.HeroManager.Find(HerosEnum.Mage.ToString()).CreateHero();

            Warrior warrior = ctx.PlayerInfo.MyHeros[3] as Warrior;
            Mage mage = ctx.PlayerInfo.MyHeros[0] as Mage;
            Friendship friendship = new Friendship(warrior, mage);
            Assert.AreEqual(warrior.Damage + 2, warrior.EffectivDamage);
            Assert.AreEqual(mage.Damage + 2, mage.EffectivDamage);
        }
        [Test]
        public void GetItemWeaponTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find(HerosEnum.Warrior.ToString()).CreateHero();
            Warrior warrior = ctx.PlayerInfo.MyHeros[3] as Warrior;
            using (FileStream myFileStream = new FileStream("../../../S_M_D/Items/Weapons.xml", FileMode.Open))
            {
                XmlSerializer reader = new XmlSerializer(typeof(List<BaseWeapon>));
                List<BaseWeapon> overview = (List<BaseWeapon>)reader.Deserialize(myFileStream);
                warrior.GetNewItem(overview.First());
                Assert.AreEqual(overview.First(), warrior.Equipement[0]);
                Assert.AreEqual(warrior.EffectCritChance, warrior.CritChance += overview.First().CritChance);
                Assert.AreEqual(warrior.EffectivAffectRes, warrior.AffectRes += overview.First().AffectRes);
                Assert.AreEqual(warrior.EffectivBleedingRes, warrior.BleedingRes += overview.First().BleedingRes);
                Assert.AreEqual(warrior.EffectivDamage, warrior.Damage += overview.First().Damage);
                Assert.AreEqual(warrior.EffectivDefense, warrior.Defense += overview.First().Defense);
                Assert.AreEqual(warrior.EffectivDodgeChance, warrior.DodgeChance += overview.First().DodgeChance);
                Assert.AreEqual(warrior.EffectivFireRes, warrior.FireRes += overview.First().FireRes);
                Assert.AreEqual(warrior.EffectivHitChance, warrior.HitChance += overview.First().HitChance);
                Assert.AreEqual(warrior.EffectivHPMax, warrior.HPmax += overview.First().HP);
                Assert.AreEqual(warrior.EffectivMagicRes, warrior.MagicRes += overview.First().MagicRes);
                Assert.AreEqual(warrior.EffectivManaMax, warrior.ManaMax += overview.First().Mana);
                Assert.AreEqual(warrior.EffectivPoisonRes, warrior.PoisonRes += overview.First().PoisonRes);
                Assert.AreEqual(warrior.EffectivSpeed, warrior.Speed += overview.First().Speed);
                Assert.AreEqual(warrior.EffectivWaterRes, warrior.WaterRes += overview.First().WaterRes);
            }
        }

        [Test]
        public void RemoveItemTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find(HerosEnum.Warrior.ToString()).CreateHero();
            Warrior warrior = ctx.PlayerInfo.MyHeros[3] as Warrior;

            using (FileStream myFileStream = new FileStream("../../../S_M_D/Items/Weapons.xml", FileMode.Open))
            {
                XmlSerializer reader = new XmlSerializer(typeof(List<BaseWeapon>));
                List<BaseWeapon> overview = (List<BaseWeapon>)reader.Deserialize(myFileStream);
                warrior.GetNewItem(overview.First());
                warrior.RemoveItem(overview.First());
                warrior.GetNewItem(overview.Last());
                
            }

        }

        [Test]
        public void GetItemArmorTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find(HerosEnum.Warrior.ToString()).CreateHero();
            Warrior warrior = ctx.PlayerInfo.MyHeros[3] as Warrior;

            using (FileStream myFileStream = new FileStream("../../../S_M_D/Items/Armors.xml", FileMode.Open))
            {
                XmlSerializer reader = new XmlSerializer(typeof(List<BaseArmor>));
                List<BaseArmor> overview = (List<BaseArmor>)reader.Deserialize(myFileStream);
                warrior.GetNewItem(overview.First());
                Assert.AreEqual(overview.First(), warrior.Equipement[1]);
                Assert.AreEqual(warrior.EffectCritChance, warrior.CritChance += overview.First().CritChance);
                Assert.AreEqual(warrior.EffectivAffectRes, warrior.AffectRes += overview.First().AffectRes);
                Assert.AreEqual(warrior.EffectivBleedingRes, warrior.BleedingRes += overview.First().BleedingRes);
                Assert.AreEqual(warrior.EffectivDamage, warrior.Damage += overview.First().Damage);
                Assert.AreEqual(warrior.EffectivDefense, warrior.Defense += overview.First().Defense);
                Assert.AreEqual(warrior.EffectivDodgeChance, warrior.DodgeChance += overview.First().DodgeChance);
                Assert.AreEqual(warrior.EffectivFireRes, warrior.FireRes += overview.First().FireRes);
                Assert.AreEqual(warrior.EffectivHitChance, warrior.HitChance += overview.First().HitChance);
                Assert.AreEqual(warrior.EffectivHPMax, warrior.HPmax += overview.First().HP);
                Assert.AreEqual(warrior.EffectivMagicRes, warrior.MagicRes += overview.First().MagicRes);
                Assert.AreEqual(warrior.EffectivManaMax, warrior.ManaMax += overview.First().Mana);
                Assert.AreEqual(warrior.EffectivPoisonRes, warrior.PoisonRes += overview.First().PoisonRes);
                Assert.AreEqual(warrior.EffectivSpeed, warrior.Speed += overview.First().Speed);
                Assert.AreEqual(warrior.EffectivWaterRes, warrior.WaterRes += overview.First().WaterRes);
            }

        }

        [Test]
        public void GetItemTrinketTest()
        {
            GameContext ctx = GameContext.CreateNewGame();
            ctx.HeroManager.Find(HerosEnum.Warrior.ToString()).CreateHero();
            Warrior warrior = ctx.PlayerInfo.MyHeros[3] as Warrior;

            using (FileStream myFileStream = new FileStream("../../../S_M_D/Items/Trinket.xml", FileMode.Open))
            {
                XmlSerializer reader = new XmlSerializer(typeof(List<BaseTrinket>));
                List<BaseTrinket> overview = (List<BaseTrinket>)reader.Deserialize(myFileStream);
                warrior.GetNewItem(overview.First());
                Assert.AreEqual(overview.First(), warrior.Equipement[2]);
                Assert.AreEqual(warrior.EffectCritChance, warrior.CritChance += overview.First().CritChance);
                Assert.AreEqual(warrior.EffectivAffectRes, warrior.AffectRes += overview.First().AffectRes);
                Assert.AreEqual(warrior.EffectivBleedingRes, warrior.BleedingRes += overview.First().BleedingRes);
                Assert.AreEqual(warrior.EffectivDamage, warrior.Damage += overview.First().Damage);
                Assert.AreEqual(warrior.EffectivDefense, warrior.Defense += overview.First().Defense);
                Assert.AreEqual(warrior.EffectivDodgeChance, warrior.DodgeChance += overview.First().DodgeChance);
                Assert.AreEqual(warrior.EffectivFireRes, warrior.FireRes += overview.First().FireRes);
                Assert.AreEqual(warrior.EffectivHitChance, warrior.HitChance += overview.First().HitChance);
                Assert.AreEqual(warrior.EffectivHPMax, warrior.HPmax += overview.First().HP);
                Assert.AreEqual(warrior.EffectivMagicRes, warrior.MagicRes += overview.First().MagicRes);
                Assert.AreEqual(warrior.EffectivManaMax, warrior.ManaMax += overview.First().Mana);
                Assert.AreEqual(warrior.EffectivPoisonRes, warrior.PoisonRes += overview.First().PoisonRes);
                Assert.AreEqual(warrior.EffectivSpeed, warrior.Speed += overview.First().Speed);
                Assert.AreEqual(warrior.EffectivWaterRes, warrior.WaterRes += overview.First().WaterRes);
            }

        }

        [Test]
        public void WarriorUpdate()
        {
            GameContext ctx = GameContext.CreateNewGame();
            Warrior warrior = ctx.PlayerInfo.MyHeros[3] as Warrior;
            Priest priest = ctx.PlayerInfo.MyHeros[2] as Priest;
            Paladin paladin = ctx.PlayerInfo.MyHeros[1] as Paladin;
            Mage mage = ctx.PlayerInfo.MyHeros[0] as Mage;
            Fever testF = new Fever();
            Diarrhea testD = new Diarrhea();
            Crazyness testC = new Crazyness();
            Love love = new Love(warrior, mage);
            warrior.GetPsycho(testC);
            warrior.GetSickness(testF);
            warrior.GetSickness(testD);
            priest.UpdateHeroStats();
            paladin.UpdateHeroStats();
            mage.UpdateHeroStats();
            Assert.AreEqual(warrior.EffectivDamage, 19);
            Assert.AreEqual(warrior.EffectivDefense, 36);
            Assert.AreEqual(warrior.EffectCritChance, 30);
            Assert.AreEqual(warrior.EffectivHitChance, 30);
            warrior.DeleteSickness(testF);
            warrior.DeleteSickness(testD);
            warrior.DeletePsycho(testC);
            warrior.DeleteRelationship(love);
            mage.DeleteRelationship(love);
            Assert.AreEqual(warrior.EffectivDamage, warrior.Damage);
            Assert.AreEqual(warrior.EffectivDefense, warrior.Defense);
        }

    }
}
