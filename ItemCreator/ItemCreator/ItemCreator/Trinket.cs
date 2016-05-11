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

    public class Trinket
    {
        Random rnd = new Random();
        BaseTrinket newTrinket;

        public Trinket()
        {
            createTrinket();
        }
        public void createTrinket()
        {
            List<BaseTrinket> listOfTrinket = new List<BaseTrinket>();
            for (int x = 0; x < 200; x++)
            {
                newTrinket = new BaseTrinket();
                newTrinket.Itemtype = BaseItem.ItemTypes.Trinket;
                newTrinket.ItemId = rnd.Next(1, 100000);
                newTrinket.ItemDescription = "my new trinket";
                ChooseTrinketType();
                ChooseTrinketQuality();
                ChooseTrinketBonus();
                newTrinket.Stats = BaseStatItem.stats.hp;
                ChooseTrinketName(newTrinket.Quality);
                listOfTrinket.Add(newTrinket);
            }
            WriteXMLTrinket(listOfTrinket);
        }

        private void ChooseTrinketName(BaseStatItem.quality quality)
        {
            if (quality == BaseStatItem.quality.legendary)
            {
                using (StreamReader myFileStream = new StreamReader("Trinkets/TrinketsNames/LegendaryTrinketNames.txt"))
                {
                    string test = myFileStream.ReadToEnd();
                    var tab = Regex.Split(test, ",");
                    int x = rnd.Next(0, tab.Length);
                    newTrinket.ItemName = tab[x];
                }
            }
            else if (quality == BaseStatItem.quality.epic)
            {
                using (StreamReader myFileStream = new StreamReader("Trinkets/TrinketsNames/EpicTrinketNames.txt"))
                {
                    string test = myFileStream.ReadToEnd();
                    var tab = Regex.Split(test, ",");
                    int x = rnd.Next(0, tab.Length);
                    newTrinket.ItemName = tab[x];
                }
            }
            else
            {
                using (StreamReader myFileStream = new StreamReader("Trinkets/TrinketsNames/BaseTrinketNames.txt"))
                {
                    string test = myFileStream.ReadToEnd();
                    var tab = Regex.Split(test, ",");
                    int x = rnd.Next(0, tab.Length);
                    newTrinket.ItemName = tab[x];
                }
            }
        }
        private void ChooseTrinketType()
        {
            int randomTemp = rnd.Next(1, 2);
            if (randomTemp == 1) newTrinket.TrinketTYpe = BaseTrinket.trinketType.Bague;
            if (randomTemp == 2) newTrinket.TrinketTYpe = BaseTrinket.trinketType.Collier;

        }

        private void ChooseTrinketQuality()
        {
            int randomTemp = rnd.Next(1, 101);
            if (randomTemp <= 30) newTrinket.Quality = BaseStatItem.quality.useless;
            if (randomTemp > 30 && randomTemp <= 60) newTrinket.Quality = BaseStatItem.quality.common;
            if (randomTemp > 60 && randomTemp <= 85) newTrinket.Quality = BaseStatItem.quality.rare;
            if (randomTemp < 85 && randomTemp >= 95) newTrinket.Quality = BaseStatItem.quality.epic;
            if (randomTemp > 95) newTrinket.Quality = BaseStatItem.quality.legendary;
        }

        private void ChooseTrinketBonus()
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
                        newTrinket.HP += (AddBonusStats(y));
                        break;
                    case 2:
                        newTrinket.Mana += (AddBonusStats(y));
                        break;
                    case 3:
                        newTrinket.Damage += (AddBonusStats(y));
                        break;
                    case 4:
                        newTrinket.CritChance += (AddBonusStats(y));
                        break;
                    case 5:
                        newTrinket.HitChance += (AddBonusStats(y));
                        break;
                    case 6:
                        newTrinket.Speed += (AddBonusStats(y));
                        break;
                    case 7:
                        newTrinket.AffectRes += (AddBonusStats(y));
                        break;
                    case 8:
                        newTrinket.BleedingRes += (AddBonusStats(y));
                        break;
                    case 9:
                        newTrinket.FireRes += (AddBonusStats(y));
                        break;
                    case 10:
                        newTrinket.PoisonRes += (AddBonusStats(y));
                        break;
                    case 11:
                        newTrinket.WaterRes += (AddBonusStats(y));
                        break;
                    case 12:
                        newTrinket.Defense += (AddBonusStats(y));
                        break;
                    case 13:
                        newTrinket.MagicRes += (AddBonusStats(y));
                        break;
                    case 14:
                        newTrinket.DodgeChance += (AddBonusStats(y));
                        break;
                }
            }
        }

        private int AddBonusStats(int y)
        {
            int result = 0;
            if (newTrinket.Quality == BaseStatItem.quality.useless)
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
            else if (newTrinket.Quality == BaseStatItem.quality.common)
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
            else if (newTrinket.Quality == BaseStatItem.quality.rare)
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
            else if (newTrinket.Quality == BaseStatItem.quality.epic)
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
            if (newTrinket.Quality == BaseStatItem.quality.legendary)
            {
                result += rnd.Next(20, 40);
            }

            return result;
        }

        public static void WriteXMLTrinket(List<BaseTrinket> trinket)
        {
            using (FileStream myFileStream = new FileStream("../../../../S_M_D/bin/debug/Trinket.xml", FileMode.Create))
            {

                XmlSerializer serialiser = new XmlSerializer(typeof(List<BaseTrinket>));
                serialiser.Serialize(myFileStream, trinket);
            }
        }

        public void ReadXMLTrinket()
        {
            using (FileStream myFileStream = new FileStream("../../../../S_M_D/bin/debug/Trinket.xml", FileMode.Open))
            {
                XmlSerializer reader = new XmlSerializer(typeof(List<BaseTrinket>));
                List<BaseTrinket> overview = (List<BaseTrinket>)reader.Deserialize(myFileStream);

            }
        }
    }

}
    
