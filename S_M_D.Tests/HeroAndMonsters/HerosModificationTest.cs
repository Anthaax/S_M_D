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
            GameContext ctx = GameContext.CreateNewGame(1);
            ctx.HeroManager.Find(HerosEnum.Warrior.ToString()).CreateHero();
            Warrior warrior = ctx.PlayerInfo.MyHeros[3] as Warrior;
            Diarrhea test = new Diarrhea();
            warrior.GetSickness(test);
            int equipementValueDmg = 0;
            warrior.Equipement.ToList().ForEach( c => equipementValueDmg += c.Damage );
            Assert.AreEqual(warrior.EffectivDamage, 10 + equipementValueDmg);
            warrior.DeleteSickness(test);
            Assert.AreEqual(warrior.EffectivDamage, warrior.Damage + equipementValueDmg);

        }

        [Test]
        public void FeverWariorTest()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
            ctx.HeroManager.Find(HerosEnum.Warrior.ToString()).CreateHero();
            Warrior warrior = ctx.PlayerInfo.MyHeros[3] as Warrior;
            Fever test = new Fever();
            warrior.GetSickness(test);
            int equipementValueDmg = 0;
            warrior.Equipement.ToList().ForEach( c => equipementValueDmg += c.Damage );
            Assert.AreEqual(warrior.EffectivDamage, 13 + equipementValueDmg);
            int equipementValueDef = 0;
            warrior.Equipement.ToList().ForEach( c => equipementValueDef += c.Defense );
            Assert.AreEqual(warrior.EffectivDefense, 32 + equipementValueDef );
            Assert.Throws<ArgumentException>(() => warrior.GetSickness(test));
            warrior.DeleteSickness(test);
            Assert.AreEqual(warrior.EffectivDamage, warrior.Damage + equipementValueDmg);
            Assert.AreEqual(warrior.EffectivDefense, warrior.Defense + equipementValueDef);

        }

        [Test]
        public void CancerWarriorTest()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
            ctx.HeroManager.Find(HerosEnum.Warrior.ToString()).CreateHero();
            Warrior warrior = ctx.PlayerInfo.MyHeros[3] as Warrior;
            Cancer cancer = new Cancer();
            warrior.GetSickness(cancer);
            int equipementValueHp = 0;
            warrior.Equipement.ToList().ForEach( c => equipementValueHp += c.HP );
            Assert.AreEqual(warrior.EffectivHPMax, 42 + equipementValueHp);
            warrior.DeleteSickness(cancer);
            Assert.AreEqual(warrior.EffectivHPMax, warrior.HPmax + equipementValueHp);
        }

        [Test]
        public void WarriorStaphyloccocusTest()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
            ctx.HeroManager.Find(HerosEnum.Warrior.ToString()).CreateHero();
            Warrior warrior = ctx.PlayerInfo.MyHeros[3] as Warrior;
            Staphyloccocus stap = new Staphyloccocus();
            warrior.GetSickness(stap);
            int equipementValueSpeed = 0;
            warrior.Equipement.ToList().ForEach( c => equipementValueSpeed += c.Speed );
            int newEquipementValueSpeed = equipementValueSpeed;
            if (warrior.Speed + equipementValueSpeed - 5 < 0) newEquipementValueSpeed = -warrior.Speed + 5;
            Assert.AreEqual(warrior.EffectivSpeed, warrior.Speed + newEquipementValueSpeed - 5 );
            warrior.DeleteSickness(stap);
            if (warrior.Speed + equipementValueSpeed < 0) newEquipementValueSpeed = -warrior.Speed;
            Assert.AreEqual(warrior.EffectivSpeed, warrior.Speed + newEquipementValueSpeed);
        }

        [Test]
        public void CrazynessWarriorTest()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
            Warrior warrior = ctx.PlayerInfo.MyHeros[3] as Warrior;
            Crazyness test = new Crazyness();
            warrior.GetPsycho(test);
            int equipementValueDmg = 0;
            warrior.Equipement.ToList().ForEach( c => equipementValueDmg += c.Damage );
            Assert.AreEqual(warrior.EffectivDamage, 17 + equipementValueDmg);
            int equipementValueCrit = 0;
            warrior.Equipement.ToList().ForEach( c => equipementValueCrit += c.CritChance );
            Assert.AreEqual(warrior.EffectCritChance, 30 + equipementValueCrit);
            int equipementValueHitChance = 0;
            warrior.Equipement.ToList().ForEach( c => equipementValueHitChance += c.HitChance );
            Assert.AreEqual(warrior.EffectivHitChance, 30 +equipementValueHitChance);
            Assert.Throws<ArgumentException>(() => warrior.GetPsycho(test));
            warrior.DeletePsycho(test);
            Assert.AreEqual(warrior.EffectivDamage, warrior.Damage + equipementValueDmg);
            Assert.AreEqual(warrior.EffectCritChance, warrior.CritChance + equipementValueCrit);
            Assert.AreEqual(warrior.EffectivHitChance, warrior.HitChance + equipementValueHitChance);
        }

        [Test]
        public void FragilWarriorTest()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
            Warrior warrior = ctx.PlayerInfo.MyHeros[3] as Warrior;
            Fragil fragil = new Fragil();
            warrior.GetPsycho(fragil);
            int equipementValueDefense = 0;
            warrior.Equipement.ToList().ForEach( c => equipementValueDefense += c.Defense );
            Assert.AreEqual(warrior.EffectivDefense, 30 + equipementValueDefense);
            warrior.DeletePsycho(fragil);
            Assert.AreEqual(warrior.EffectivDefense, warrior.Defense + equipementValueDefense);
        }

        [Test]
        public void ArrogantWarriorTest()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
            Warrior warrior = ctx.PlayerInfo.MyHeros[3] as Warrior;
            Arrogant arrogant = new Arrogant();
            warrior.GetPsycho(arrogant);
            int equipementValueCrit = 0;
            warrior.Equipement.ToList().ForEach( c => equipementValueCrit += c.CritChance );
            Assert.AreEqual(warrior.EffectCritChance, 30 + equipementValueCrit);
            warrior.DeletePsycho(arrogant);
            Assert.AreEqual(warrior.EffectCritChance, warrior.CritChance + equipementValueCrit);
        }

        [Test]
        public void AgressivityWarriorTest()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
            Warrior warrior = ctx.PlayerInfo.MyHeros[3] as Warrior;
            Agressivity agressivity = new Agressivity();
            warrior.GetPsycho(agressivity);
            int equipementValueDmg = 0;
            warrior.Equipement.ToList().ForEach( c => equipementValueDmg += c.Damage );
            int equipementValueCrit = 0;
            warrior.Equipement.ToList().ForEach( c => equipementValueCrit += c.CritChance );
            Assert.AreEqual(warrior.EffectivDamage, 17 + equipementValueDmg);
            Assert.AreEqual(warrior.EffectCritChance, 30 + equipementValueCrit);
            warrior.DeletePsycho(agressivity);
            Assert.AreEqual(warrior.EffectivDamage, warrior.Damage + equipementValueDmg);
            Assert.AreEqual(warrior.EffectCritChance, warrior.CritChance + equipementValueCrit);
        }
        [Test]
        public void LoveBetweenWarriorAndMageTest()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
            ctx.HeroManager.Find(HerosEnum.Warrior.ToString()).CreateHero();
            Warrior warrior = ctx.PlayerInfo.MyHeros[3] as Warrior;
            Mage mage = ctx.PlayerInfo.MyHeros[0] as Mage;
            Love love = new Love(warrior, mage);
            int equipementValueDmgWarrior = 0;
            warrior.Equipement.ToList().ForEach( c => equipementValueDmgWarrior += c.Damage );
            int equipementValueDefWarrior = 0;
            warrior.Equipement.ToList().ForEach( c => equipementValueDefWarrior += c.Defense );
            int equipementValueDmgMage = 0;
            mage.Equipement.ToList().ForEach( c => equipementValueDmgMage += c.Damage );
            int equipementValueDefMage = 0;
            mage.Equipement.ToList().ForEach( c => equipementValueDefMage += c.Defense );
            Assert.AreEqual(warrior.EffectivDamage, 12 + equipementValueDmgWarrior);
            Assert.AreEqual(warrior.EffectivDefense, 44 + equipementValueDefWarrior);
            Assert.AreEqual(mage.EffectivDamage, 4 + equipementValueDmgMage);
            Assert.AreEqual(mage.EffectivDefense, 11 + equipementValueDefMage);
            mage.DeleteRelationship(love);
            warrior.DeleteRelationship(love);
            Assert.AreEqual(warrior.EffectivDamage, warrior.Damage + equipementValueDmgWarrior);
            Assert.AreEqual(warrior.EffectivDefense, warrior.Defense+ equipementValueDefWarrior);
            Assert.AreEqual(mage.EffectivDamage, mage.Damage + equipementValueDmgMage);
            Assert.AreEqual(mage.EffectivDefense, mage.Defense + equipementValueDefMage);
        }
        [Test]
        public void HateBetweenWarriorAndMageTest ()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
            Warrior warrior = ctx.PlayerInfo.MyHeros[3] as Warrior;
            Mage mage = ctx.PlayerInfo.MyHeros[0] as Mage;
            Hate hate = new Hate(warrior, mage);
            int equipementValueDmgWarrior = 0;
            warrior.Equipement.ToList().ForEach( c => equipementValueDmgWarrior += c.Damage );
            int equipementValueDefWarrior = 0;
            warrior.Equipement.ToList().ForEach( c => equipementValueDefWarrior += c.Defense );
            int equipementValueDmgMage = 0;
            mage.Equipement.ToList().ForEach( c => equipementValueDmgMage += c.Damage );
            int equipementValueDefMage = 0;
            mage.Equipement.ToList().ForEach( c => equipementValueDefMage += c.Defense );
            int exepted = warrior.Damage += Convert.ToInt32( warrior.Damage * 0.5 );
            Assert.AreEqual(exepted + equipementValueDmgWarrior, warrior.EffectivDamage);
            exepted = warrior.Defense += Convert.ToInt32( warrior.Defense * 0.5 );
            Assert.AreEqual(exepted + equipementValueDefWarrior, warrior.EffectivDefense);
            exepted = mage.Damage += Convert.ToInt32( mage.Damage * 0.5 );
            Assert.AreEqual(exepted + equipementValueDmgMage, mage.EffectivDamage);
            exepted = mage.Defense += Convert.ToInt32( mage.Defense * 0.5 );
            Assert.AreEqual( exepted + equipementValueDefMage, mage.EffectivDefense);
        }

        [Test]
        public void DesirBetweenTwoWarriorTest()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
            Warrior warrior = ctx.PlayerInfo.MyHeros[3] as Warrior;
            Mage mage = ctx.PlayerInfo.MyHeros[0] as Mage;
            Desir desir = new Desir(warrior, mage);
            int equipementValueHitChanceWarrior = 0;
            warrior.Equipement.ToList().ForEach( c => equipementValueHitChanceWarrior += c.HitChance );
            int equipementValueHitChanceMage = 0;
            mage.Equipement.ToList().ForEach( c => equipementValueHitChanceMage += c.HitChance );
            Assert.AreEqual(warrior.HitChance - 2 + equipementValueHitChanceWarrior, warrior.EffectivHitChance);
            Assert.AreEqual(mage.EffectivHitChance, mage.HitChance-2 + equipementValueHitChanceMage);
            desir.EffectOnDeath();
            Assert.IsEmpty( warrior.Relationship );
        }

        [Test]
        public void FriendshipBetweenTwooWarriorTest()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
            Warrior warrior = ctx.PlayerInfo.MyHeros[3] as Warrior;
            Mage mage = ctx.PlayerInfo.MyHeros[0] as Mage;
            Friendship friendship = new Friendship(warrior, mage);
            int equipementValueHitChanceWarrior = 0;
            warrior.Equipement.ToList().ForEach( c => equipementValueHitChanceWarrior += c.Damage );
            int equipementValueHitChanceMage = 0;
            mage.Equipement.ToList().ForEach( c => equipementValueHitChanceMage += c.Damage );
            Assert.AreEqual(warrior.Damage + 2 + equipementValueHitChanceWarrior, warrior.EffectivDamage);
            Assert.AreEqual(mage.Damage + 2 + equipementValueHitChanceMage, mage.EffectivDamage);
        }
        [Test]
        public void GetArmorTest()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
            Warrior warrior = ctx.PlayerInfo.MyHeros[3] as Warrior;
            BaseStatItem item = ctx.AllItemInGame.First( c => c.Itemtype == BaseItem.ItemTypes.Armor);
            Assert.Throws<ArgumentException>(() => warrior.GetNewItem(item));
            Assert.AreEqual( 0, ctx.PlayerInfo.MyItems.Count );
            warrior.RemoveItem( warrior.Equipement[0] );
            warrior.RemoveItem( warrior.Equipement[1] );
            warrior.RemoveItem( warrior.Equipement[2] );
            warrior.RemoveItem( warrior.Equipement[3] );
            Assert.AreEqual( 4, ctx.PlayerInfo.MyItems.Count );
            ctx.PlayerInfo.MyItems.Add( item );
            warrior.GetNewItem( item );
            Assert.AreEqual(item, warrior.Equipement[0]);
            Assert.AreEqual(warrior.EffectCritChance, warrior.CritChance += item.CritChance);
            Assert.AreEqual(warrior.EffectivAffectRes, warrior.AffectRes += item.AffectRes);
            Assert.AreEqual(warrior.EffectivBleedingRes, warrior.BleedingRes += item.BleedingRes);
            Assert.AreEqual(warrior.EffectivDamage, warrior.Damage += item.Damage);
            Assert.AreEqual(warrior.EffectivDefense, warrior.Defense += item.Defense);
            Assert.AreEqual(warrior.EffectivDodgeChance, warrior.DodgeChance += item.DodgeChance);
            Assert.AreEqual(warrior.EffectivFireRes, warrior.FireRes += item.FireRes);
            Assert.AreEqual(warrior.EffectivHitChance, warrior.HitChance += item.HitChance);
            Assert.AreEqual(warrior.EffectivHPMax, warrior.HPmax += item.HP);
            Assert.AreEqual(warrior.EffectivMagicRes, warrior.MagicRes += item.MagicRes);
            Assert.AreEqual(warrior.EffectivManaMax, warrior.ManaMax += item.Mana);
            Assert.AreEqual(warrior.EffectivPoisonRes, warrior.PoisonRes += item.PoisonRes);
            Assert.AreEqual(warrior.EffectivSpeed, warrior.Speed += item.Speed);
            Assert.AreEqual(warrior.EffectivWaterRes, warrior.WaterRes += item.WaterRes);
        }

        [Test]
        public void RemoveItemTest()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
            ctx.HeroManager.Find(HerosEnum.Warrior.ToString()).CreateHero();
            Warrior warrior = ctx.PlayerInfo.MyHeros[3] as Warrior;
            BaseStatItem item = ctx.AllItemInGame.First( c => c.Itemtype == BaseItem.ItemTypes.Armor );
            Assert.Throws<ArgumentException>(() => warrior.GetNewItem(item));
            warrior.RemoveItem( warrior.Equipement[0] );
            Assert.AreEqual( null, warrior.Equipement[0] );
        }

        [Test]
        public void GetWeaponTest()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
            Warrior warrior = ctx.PlayerInfo.MyHeros[3] as Warrior;
            BaseStatItem item = ctx.AllItemInGame.First( c => c.Itemtype == BaseItem.ItemTypes.Weapon );
            Assert.Throws<ArgumentException>( () => warrior.GetNewItem( item ) );
            warrior.RemoveItem( warrior.Equipement[0] );
            warrior.RemoveItem( warrior.Equipement[1] );
            warrior.RemoveItem( warrior.Equipement[2] );
            warrior.RemoveItem( warrior.Equipement[3] );
            warrior.GetNewItem( item );
            Assert.AreEqual( item, warrior.Equipement[1] );
            Assert.AreEqual( warrior.EffectCritChance, warrior.CritChance += item.CritChance );
            Assert.AreEqual( warrior.EffectivAffectRes, warrior.AffectRes += item.AffectRes );
            Assert.AreEqual( warrior.EffectivBleedingRes, warrior.BleedingRes += item.BleedingRes );
            Assert.AreEqual( warrior.EffectivDamage, warrior.Damage += item.Damage );
            Assert.AreEqual( warrior.EffectivDefense, warrior.Defense += item.Defense );
            Assert.AreEqual( warrior.EffectivDodgeChance, warrior.DodgeChance += item.DodgeChance );
            Assert.AreEqual( warrior.EffectivFireRes, warrior.FireRes += item.FireRes );
            Assert.AreEqual( warrior.EffectivHitChance, warrior.HitChance += item.HitChance );
            Assert.AreEqual( warrior.EffectivHPMax, warrior.HPmax += item.HP );
            Assert.AreEqual( warrior.EffectivMagicRes, warrior.MagicRes += item.MagicRes );
            Assert.AreEqual( warrior.EffectivManaMax, warrior.ManaMax += item.Mana );
            Assert.AreEqual( warrior.EffectivPoisonRes, warrior.PoisonRes += item.PoisonRes );
            Assert.AreEqual( warrior.EffectivSpeed, warrior.Speed += item.Speed );
            Assert.AreEqual( warrior.EffectivWaterRes, warrior.WaterRes += item.WaterRes );

        }

        [Test]
        public void GetItemTrinketTest()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
            Warrior warrior = ctx.PlayerInfo.MyHeros[3] as Warrior;
            BaseStatItem item = ctx.AllItemInGame.First( c => c.Itemtype == BaseItem.ItemTypes.Trinket );
            Assert.Throws<ArgumentException>(() => warrior.GetNewItem(item));
            warrior.RemoveItem( warrior.Equipement[0] );
            warrior.RemoveItem( warrior.Equipement[1] );
            warrior.RemoveItem( warrior.Equipement[2] );
            warrior.RemoveItem( warrior.Equipement[3] );
            warrior.GetNewItem( item );
            Assert.AreEqual( item, warrior.Equipement[2] );
            Assert.AreEqual( warrior.EffectCritChance, warrior.CritChance += item.CritChance );
            Assert.AreEqual( warrior.EffectivAffectRes, warrior.AffectRes += item.AffectRes );
            Assert.AreEqual( warrior.EffectivBleedingRes, warrior.BleedingRes += item.BleedingRes );
            Assert.AreEqual( warrior.EffectivDamage, warrior.Damage += item.Damage );
            Assert.AreEqual( warrior.EffectivDefense, warrior.Defense += item.Defense );
            Assert.AreEqual( warrior.EffectivDodgeChance, warrior.DodgeChance += item.DodgeChance );
            Assert.AreEqual( warrior.EffectivFireRes, warrior.FireRes += item.FireRes );
            Assert.AreEqual( warrior.EffectivHitChance, warrior.HitChance += item.HitChance );
            Assert.AreEqual( warrior.EffectivHPMax, warrior.HPmax += item.HP );
            Assert.AreEqual( warrior.EffectivMagicRes, warrior.MagicRes += item.MagicRes );
            Assert.AreEqual( warrior.EffectivManaMax, warrior.ManaMax += item.Mana );
            Assert.AreEqual( warrior.EffectivPoisonRes, warrior.PoisonRes += item.PoisonRes );
            Assert.AreEqual( warrior.EffectivSpeed, warrior.Speed += item.Speed );
            Assert.AreEqual( warrior.EffectivWaterRes, warrior.WaterRes += item.WaterRes );

        }

        [Test]
        public void SwitchItems()
        {
            GameContext ctx = GameContext.CreateNewGame( 1 );
            BaseItem item = ctx.AllItemInGame.Where( c => c.Itemtype == BaseItem.ItemTypes.Armor ).First();
            ctx.PlayerInfo.MyItems.Add( item );
            BaseItem itemToChange = ctx.PlayerInfo.MyHeros[0].Equipement.Where( c => c.Itemtype == BaseItem.ItemTypes.Armor ).First();
            ctx.PlayerInfo.MyHeros.First().RemoveAndAddAnItem( itemToChange, item );
            Assert.AreEqual( true, ctx.PlayerInfo.MyItems.Contains( itemToChange ) );
            Assert.AreEqual( false, ctx.PlayerInfo.MyItems.Contains( item ) );
            Assert.AreEqual( true, ctx.PlayerInfo.MyHeros[0].Equipement.Contains( item ) );
            Assert.AreEqual( false, ctx.PlayerInfo.MyHeros[0].Equipement.Contains( itemToChange ) );
        }

        [Test]
        public void WarriorUpdate()
        {
            GameContext ctx = GameContext.CreateNewGame(1);
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
            int equipementValueHitChance = 0;
            warrior.Equipement.ToList().ForEach( c => equipementValueHitChance += c.HitChance );
            int equipementValueDmg = 0;
            warrior.Equipement.ToList().ForEach( c => equipementValueDmg += c.Damage );
            int equipementValueDef = 0;
            warrior.Equipement.ToList().ForEach( c => equipementValueDef += c.Defense );
            int equipementValueCrit = 0;
            warrior.Equipement.ToList().ForEach( c => equipementValueCrit += c.CritChance );
            priest.UpdateHeroStats();
            paladin.UpdateHeroStats();
            mage.UpdateHeroStats();
            Assert.AreEqual(warrior.EffectivDamage, 19 + equipementValueDmg);
            Assert.AreEqual(warrior.EffectivDefense, 36 + equipementValueDef);
            Assert.AreEqual(warrior.EffectCritChance, 30 + equipementValueCrit);
            Assert.AreEqual(warrior.EffectivHitChance, 30 + equipementValueHitChance);
            warrior.DeleteSickness(testF);
            warrior.DeleteSickness(testD);
            warrior.DeletePsycho(testC);
            warrior.DeleteRelationship(love);
            mage.DeleteRelationship(love);
            Assert.AreEqual(warrior.EffectivDamage, warrior.Damage + equipementValueDmg);
            Assert.AreEqual(warrior.EffectivDefense, warrior.Defense + equipementValueDef);
        }

    }
}
