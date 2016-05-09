using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace ItemCreator
{
    class ItemManager
    {
        Random rnd = new Random();
        BasePotion newPotion;
        BaseTrinket newTrinket;
        public void createPotion()
        {
            List<BasePotion> listOfPot = new List<BasePotion>();
            for (int x=0;x<200;x++)
            {
                newPotion = new BasePotion();
                newPotion.Itemtype = BaseItem.ItemTypes.Potion;
                newPotion.ItemName = "P" + rnd.Next(1, 1000);
                newPotion.ItemId = rnd.Next(1, 1000000);
                newPotion.ItemDescription = "my new potion";
                ChoosePotionType();
                ChoosePotionQuality();
                ChoosePotionBonus();
                newPotion.Stats = BaseStatItem.stats.hp;
                listOfPot.Add(newPotion);
            }

            WriteXMLPotion(listOfPot);

        }

        private void ChoosePotionType()
        {
            int randomTemp = rnd.Next(1, 2);
            if (randomTemp == 1) newPotion.Potiontype = BasePotion.PotionTypes.HP;
            if (randomTemp == 2) newPotion.Potiontype = BasePotion.PotionTypes.Mana;
        }

        private void ChoosePotionQuality()
        {
            int randomTemp = rnd.Next(1, 101);
            if (randomTemp <= 30) newPotion.Quality = BaseStatItem.quality.useless;
            if (randomTemp > 30 && randomTemp <= 60) newPotion.Quality = BaseStatItem.quality.common;
            if (randomTemp > 60 && randomTemp <= 85) newPotion.Quality = BaseStatItem.quality.rare;
            if (randomTemp < 85 && randomTemp >= 95) newPotion.Quality = BaseStatItem.quality.epic;
            if (randomTemp > 95) newPotion.Quality = BaseStatItem.quality.legendary;
        }

        private void ChoosePotionBonus()
        {
            if (newPotion.Quality == BaseStatItem.quality.useless) newPotion.Effect = rnd.Next(1, 3);
            if (newPotion.Quality == BaseStatItem.quality.common) newPotion.Effect = rnd.Next(3, 9);
            if (newPotion.Quality == BaseStatItem.quality.rare) newPotion.Effect = rnd.Next(9, 18);
            if (newPotion.Quality == BaseStatItem.quality.epic) newPotion.Effect = rnd.Next(18, 32);
            if (newPotion.Quality == BaseStatItem.quality.legendary) newPotion.Effect = rnd.Next(32, 64);
        }

        public static void WriteXMLPotion(List<BasePotion> potions)
        {
            using (FileStream myFileStream = new FileStream("Potions.xml", FileMode.Create))
            {
               
                XmlSerializer serialiser = new XmlSerializer(typeof(List<BasePotion>));
                serialiser.Serialize(myFileStream, potions);
            }
        }

        public void ReadXMLPotion()
        {
            using (FileStream myFileStream = new FileStream("Potions.xml", FileMode.Open))
            {
                XmlSerializer reader = new XmlSerializer(typeof(List<BasePotion>));
                List<BasePotion> overview = (List<BasePotion>)reader.Deserialize(myFileStream);

            }
        }

        public void createTrinket()
        {
            List<BaseTrinket> listOfTrinket = new List<BaseTrinket>();
            for(int x=0;x<200;x++)
            {
                newTrinket = new BaseTrinket();
                newTrinket.Itemtype = BaseItem.ItemTypes.Trinket;
                newTrinket.ItemName = "p" + rnd.Next(1, 1000);
                newTrinket.ItemId = rnd.Next(1, 100000);
                newTrinket.ItemDescription = "my new trinket";
                ChooseTrinketType();
                ChooseTrinketQuality();
                ChooseTrinketBonus();
                newTrinket.Stats = BaseStatItem.stats.hp;
                listOfTrinket.Add(newTrinket);
            }
            WriteXMLTrinket(listOfTrinket);
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
            for (int x = 1; x<= 8; x++)
            {
                int result = rnd.Next(1, 15);
                while (L.Contains(result))
                {
                    result = rnd.Next(1, 15);
                }
                L.Add(result);
            }

            foreach(int number in L)
            {
                y++;
                switch(number)
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

        private int AddBonusStats( int y)
        {
            int result = 0;
            if (newTrinket.Quality == BaseStatItem.quality.useless)
            {
                if (y<5)
                {
                    result -= rnd.Next(1, 9);
                }
                else if (y>4 && y<9)
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
            using (FileStream myFileStream = new FileStream("Trinket.xml", FileMode.Create))
            {

                XmlSerializer serialiser = new XmlSerializer(typeof(List<BaseTrinket>));
                serialiser.Serialize(myFileStream, trinket);
            }
        }

        public void ReadXMLTrinket()
        {
            using (FileStream myFileStream = new FileStream("Trinket.xml", FileMode.Open))
            {
                XmlSerializer reader = new XmlSerializer(typeof(List<BaseTrinket>));
                List<BaseTrinket> overview = (List<BaseTrinket>)reader.Deserialize(myFileStream);

            }
        }

    }
}
