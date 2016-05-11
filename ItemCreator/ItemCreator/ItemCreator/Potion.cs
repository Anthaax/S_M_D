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
    public class Potion
    {
        Random rnd = new Random();
        BasePotion newPotion;

        public Potion()
        {
            createPotion();
        }

                   public void createPotion()
        {
            List<BasePotion> listOfPot = new List<BasePotion>();
            for (int x = 0; x < 200; x++)
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

    }

}   
