using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;

namespace ItemCreator
{
    class Armor
    {
        Random rnd = new Random();
        BaseArmor newArmor;

        public Armor()
        {
            createArmor();
        }
        public void createArmor()
        {
            List<BaseArmor> listOfArmor = new List<BaseArmor>();
            for (int x = 0; x < 200; x++)
            {
                newArmor = new BaseArmor();
                newArmor.Itemtype = BaseItem.ItemTypes.Armor;
                newArmor.ItemId = rnd.Next(1, 1000000);
                newArmor.ItemDescription = "my new armor";
                ChooseArmorType();
                ChooseArmorQuality();
                ChooseArmorBonus();
                newArmor.Stats = BaseStatItem.stats.hp;
                ChooseArmorName(newArmor.Quality);
                listOfArmor.Add(newArmor);
            }

            WriteXMLArmor(listOfArmor);

        }

        private void ChooseArmorType()
        {
            int randomTemp = rnd.Next(1, 4);
            if (randomTemp == 1) newArmor.ArmoType = BaseArmor.ArmorType.Badass;
            if (randomTemp == 2) newArmor.ArmoType = BaseArmor.ArmorType.Dress;
            if (randomTemp == 3) newArmor.ArmoType = BaseArmor.ArmorType.Latex;
        }

        private void ChooseArmorQuality()
        {
            int randomTemp = rnd.Next(1, 101);
            if (randomTemp <= 30) newArmor.Quality = BaseStatItem.quality.useless;
            if (randomTemp > 30 && randomTemp <= 60) newArmor.Quality = BaseStatItem.quality.common;
            if (randomTemp > 60 && randomTemp <= 85) newArmor.Quality = BaseStatItem.quality.rare;
            if (randomTemp < 85 && randomTemp >= 95) newArmor.Quality = BaseStatItem.quality.epic;
            if (randomTemp > 95) newArmor.Quality = BaseStatItem.quality.legendary;
        }

        private void ChooseArmorBonus()
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
                        newArmor.HP += (AddBonusStatsA(y));
                        break;
                    case 2:
                        newArmor.Mana += (AddBonusStatsA(y));
                        break;
                    case 3:
                        newArmor.Damage += (AddBonusStatsA(y));
                        break;
                    case 4:
                        newArmor.CritChance += (AddBonusStatsA(y));
                        break;
                    case 5:
                        newArmor.HitChance += (AddBonusStatsA(y));
                        break;
                    case 6:
                        newArmor.Speed += (AddBonusStatsA(y));
                        break;
                    case 7:
                        newArmor.AffectRes += (AddBonusStatsA(y));
                        break;
                    case 8:
                        newArmor.BleedingRes += (AddBonusStatsA(y));
                        break;
                    case 9:
                        newArmor.FireRes += (AddBonusStatsA(y));
                        break;
                    case 10:
                        newArmor.PoisonRes += (AddBonusStatsA(y));
                        break;
                    case 11:
                        newArmor.WaterRes += (AddBonusStatsA(y));
                        break;
                    case 12:
                        newArmor.Defense += (AddBonusStatsA(y));
                        break;
                    case 13:
                        newArmor.MagicRes += (AddBonusStatsA(y));
                        break;
                    case 14:
                        newArmor.DodgeChance += (AddBonusStatsA(y));
                        break;
                }
            }
        }
        private void ChooseArmorName(BaseStatItem.quality quality)
        {
            if (quality == BaseStatItem.quality.legendary)
            {
                using (StreamReader myFileStream = new StreamReader("../../Items/Armors/ArmorsName/LegendaryArmor.txt"))
                {
                    string test = myFileStream.ReadToEnd();
                    var tab = Regex.Split(test, ",");
                    int x = rnd.Next(0, tab.Length);
                    newArmor.ItemName = tab[x];
                }
            }
            else if (quality == BaseStatItem.quality.epic)
            {
                using (StreamReader myFileStream = new StreamReader("../../Items/Armors/ArmorsName/EpicArmor.txt"))
                {
                    string test = myFileStream.ReadToEnd();
                    var tab = Regex.Split(test, ",");
                    int x = rnd.Next(0, tab.Length);
                    newArmor.ItemName = tab[x];
                }
            }
            else
            {
                using (StreamReader myFileStream = new StreamReader("../../Items/Armors/ArmorsName/BaseArmor.txt"))
                {
                    string test = myFileStream.ReadToEnd();
                    var tab = Regex.Split(test, ",");
                    int x = rnd.Next(0, tab.Length);
                    newArmor.ItemName = tab[x];
                }
            }
        }
        private int AddBonusStatsA(int y)
        {
            int result = 0;
            if (newArmor.Quality == BaseStatItem.quality.useless)
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
            else if (newArmor.Quality == BaseStatItem.quality.common)
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
            else if (newArmor.Quality == BaseStatItem.quality.rare)
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
            else if (newArmor.Quality == BaseStatItem.quality.epic)
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
            if (newArmor.Quality == BaseStatItem.quality.legendary)
            {
                result += rnd.Next(20, 40);
            }

            return result;
        }

        public static void WriteXMLArmor(List<BaseArmor> armor)
        {
            using (FileStream myFileStream = new FileStream("../../../../S_M_D/Items/Armors.xml", FileMode.Create))
            {

                XmlSerializer serialiser = new XmlSerializer(typeof(List<BaseArmor>));
                serialiser.Serialize(myFileStream, armor);
            }
        }

        public void ReadXMLArmor()
        {
            using (FileStream myFileStream = new FileStream("../../../../S_M_D/Items/Armors.xml", FileMode.Open))
            {
                XmlSerializer reader = new XmlSerializer(typeof(List<BaseArmor>));
                List<BaseArmor> overview = (List<BaseArmor>)reader.Deserialize(myFileStream);

            }
        }
    }
}
