using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;
using System.Reflection;

namespace ItemCreator
{
    class Weapon
    {
        Random rnd = new Random();
        BaseWeapon newWeapon;

        public Weapon()
        {
            createWeapon();
        }
        public void createWeapon()
        {
            List<BaseWeapon> listOfWeapon = new List<BaseWeapon>();
            for (int x = 0; x < 200; x++)
            {
                newWeapon = new BaseWeapon();
                newWeapon.Itemtype = BaseItem.ItemTypes.Weapon;
                newWeapon.ItemName = "A" + rnd.Next(1, 1000);
                newWeapon.ItemId = rnd.Next(1, 1000000);
                newWeapon.ItemDescription = "my new armor";
                ChooseWeaponType();
                ChooseWeaponQuality();
                ChooseWeaponBonus();
                ChooseWeaponName(newWeapon.Quality);
                newWeapon.Stats = BaseStatItem.stats.hp;
                listOfWeapon.Add(newWeapon);
            }

            WriteXMLWeapon(listOfWeapon);

        }

        private void ChooseWeaponType()
        {
            int randomTemp = rnd.Next(1, 4);
            if (randomTemp == 1) newWeapon.WeaponType1 = BaseWeapon.WeaponType.Arc;
            if (randomTemp == 2) newWeapon.WeaponType1 = BaseWeapon.WeaponType.Sword;
            if (randomTemp == 3) newWeapon.WeaponType1 = BaseWeapon.WeaponType.Staff;
        }

        private void ChooseWeaponName(BaseStatItem.quality quality)
        {
            if (quality == BaseStatItem.quality.legendary)
            {
                using (StreamReader myFileStream = new StreamReader("../../Items/Weapons/WeaponsName/LegendaryWeaponName.txt"))
                {
                    string test = myFileStream.ReadToEnd();
                    var tab = Regex.Split(test, ",");
                    int x = rnd.Next(0, tab.Length);
                    newWeapon.ItemName = tab[x];
                }
            }
            else if (quality == BaseStatItem.quality.epic)
            {
                using (StreamReader myFileStream = new StreamReader("../../Items/Weapons/WeaponsName/EpicWeaponName.txt"))
                {
                    string test = myFileStream.ReadToEnd();
                    var tab = Regex.Split(test, ",");
                    int x = rnd.Next(0, tab.Length);
                    newWeapon.ItemName = tab[x];
                }
            }
            else
            {
                using (StreamReader myFileStream = new StreamReader("../../Items/Weapons/WeaponsName/BaseWeaponName.txt"))
                {
                    string test = myFileStream.ReadToEnd();
                    var tab = Regex.Split(test, ",");
                    int x = rnd.Next(0, tab.Length);
                    newWeapon.ItemName = tab[x];
                }
            }
        }

        private void ChooseWeaponQuality()
        {
            int randomTemp = rnd.Next(1, 101);
            if (randomTemp <= 30) newWeapon.Quality = BaseStatItem.quality.useless;
            if (randomTemp > 30 && randomTemp <= 60) newWeapon.Quality = BaseStatItem.quality.common;
            if (randomTemp > 60 && randomTemp <= 85) newWeapon.Quality = BaseStatItem.quality.rare;
            if (randomTemp > 85 && randomTemp <= 95) newWeapon.Quality = BaseStatItem.quality.epic;
            if (randomTemp > 95) newWeapon.Quality = BaseStatItem.quality.legendary;
        }

        private void ChooseWeaponBonus()
        {
            int y = 0;
            List<int> L = new List<int>();
            for (int x = 1; x <= 8; x++)
            {
                int result = rnd.Next(1, 15);
                while (L.Contains(result))
                {
                    result = rnd.Next(1, 15);
                }
                L.Add(result);
            }

            foreach (int number in L)
            {
                y++;
                switch (number)
                {
                    case 1:
                        newWeapon.HP += (AddBonusStatsA(y));
                        break;
                    case 2:
                        newWeapon.Mana += (AddBonusStatsA(y));
                        break;
                    case 3:
                        newWeapon.Damage += (AddBonusStatsA(y));
                        break;
                    case 4:
                        newWeapon.CritChance += (AddBonusStatsA(y));
                        break;
                    case 5:
                        newWeapon.HitChance += (AddBonusStatsA(y));
                        break;
                    case 6:
                        newWeapon.Speed += (AddBonusStatsA(y));
                        break;
                    case 7:
                        newWeapon.AffectRes += (AddBonusStatsA(y));
                        break;
                    case 8:
                        newWeapon.BleedingRes += (AddBonusStatsA(y));
                        break;
                    case 9:
                        newWeapon.FireRes += (AddBonusStatsA(y));
                        break;
                    case 10:
                        newWeapon.PoisonRes += (AddBonusStatsA(y));
                        break;
                    case 11:
                        newWeapon.WaterRes += (AddBonusStatsA(y));
                        break;
                    case 12:
                        newWeapon.Defense += (AddBonusStatsA(y));
                        break;
                    case 13:
                        newWeapon.MagicRes += (AddBonusStatsA(y));
                        break;
                    case 14:
                        newWeapon.DodgeChance += (AddBonusStatsA(y));
                        break;
                }
            }
        }

        private int AddBonusStatsA(int y)
        {
            int result = 0;
            if (newWeapon.Quality == BaseStatItem.quality.useless)
            {
                if (y < 5)
                {
                    result -= rnd.Next(1, 9);
                }
                else if (y > 4 && y < 9)
                {
                    result += rnd.Next(1, 9);
                }
            }
            else if (newWeapon.Quality == BaseStatItem.quality.common)
            {
                if (y < 4)
                {
                    result -= rnd.Next(1, 9);
                }
                else if (y > 3 && y < 9)
                {
                    result += rnd.Next(4, 13);
                }
            }
            else if (newWeapon.Quality == BaseStatItem.quality.rare)
            {
                if (y < 3)
                {
                    result -= rnd.Next(1, 9);
                }
                else if (y > 2 && y < 9)
                {
                    result += rnd.Next(6, 16);
                }
            }
            else if (newWeapon.Quality == BaseStatItem.quality.epic)
            {
                if (y < 2)
                {
                    result -= rnd.Next(1, 9);
                }
                else if (y > 1 && y < 9)
                {
                    result += rnd.Next(9, 19);
                }
            }
            if (newWeapon.Quality == BaseStatItem.quality.legendary)
            {
                result += rnd.Next(20, 40);
            }

            return result;
        }

        public static void WriteXMLWeapon(List<BaseWeapon> weapon)
        {
            string path = Path.GetDirectoryName( Path.GetDirectoryName( Path.GetDirectoryName( Path.GetDirectoryName( Path.GetDirectoryName( Assembly.GetExecutingAssembly().CodeBase ) ) ) ) );
            var realPath = new Uri (path + @"/S_M_D.Tests/bin/Debug/Weapons.xml" );
            using (FileStream myFileStream = new FileStream(realPath.LocalPath, FileMode.Create))
            {

                XmlSerializer serialiser = new XmlSerializer(typeof(List<BaseWeapon>));
                serialiser.Serialize(myFileStream, weapon);
            }
            realPath = new Uri( path + @"/CodeCakeBuilder/bin/Debug/Weapons.xml" );
            using (FileStream myFileStream = new FileStream( realPath.LocalPath, FileMode.Create ))
            {

                XmlSerializer serialiser = new XmlSerializer( typeof( List<BaseWeapon> ) );
                serialiser.Serialize( myFileStream, weapon );
            }
        }

        public void ReadXMLArmor()
        {
            using (FileStream myFileStream = new FileStream("../../../../S_M_D/Items/Weapons.xml", FileMode.Open))
            {
                XmlSerializer reader = new XmlSerializer(typeof(List<BaseWeapon>));
                List<BaseWeapon> overview = (List<BaseWeapon>)reader.Deserialize(myFileStream);

            }
        }
    }
}

