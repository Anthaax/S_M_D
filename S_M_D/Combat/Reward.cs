using System.Collections.Generic;
using S_M_D.Character;
using S_M_D;
using System.IO;
using System.Xml.Serialization;

namespace S_M_D.Combat
{
    public class Reward
    {
        readonly int _xp;
        readonly BaseItem _item;
        readonly int _money;
        readonly GameContext _gameContext;

        public Reward(BaseMonster[] monsters, GameContext gameContext)
        {
            _gameContext = gameContext;
            _xp = getXP(monsters);
            _item = getItem("");
            _money = _gameContext.Rnd.Next(10000);

        }
        public Reward( BaseMonster[] monsters, GameContext gameContext , string path)
            :base()
        {
            _gameContext = gameContext;
            _xp = getXP( monsters );
            _item = getItem( path );
            _money = _gameContext.Rnd.Next( 10000 );
        }


        private BaseItem getItem(string prePath)
        {
            string path;
            int rand = _gameContext.Rnd.Next(30);
            int item = _gameContext.Rnd.Next(200);
            BaseItem result = null;
            if (_gameContext.Rnd.Next(20) > 9)
            {
                if (rand > 19)
                {
                    path = prePath + "Items/Weapons.xml";
                    using (FileStream myFileStream = new FileStream(path, FileMode.Open))
                    {
                        XmlSerializer reader = new XmlSerializer(typeof(List<BaseWeapon>));
                        List<BaseWeapon> overview = (List<BaseWeapon>)reader.Deserialize(myFileStream);
                        result = overview[item];

                    }
                }
                else if (rand > 9)
                {
                    path = prePath + "Items/Armors.xml";
                    using (FileStream myFileStream = new FileStream(path, FileMode.Open))
                    {
                        XmlSerializer reader = new XmlSerializer(typeof(List<BaseArmor>));
                        List<BaseArmor> overview = (List<BaseArmor>)reader.Deserialize(myFileStream);
                        result = overview[item];

                    }

                }
                else
                {
                    path = prePath + "Items/Trinket.xml";
                    using (FileStream myFileStream = new FileStream(path, FileMode.Open))
                    {
                        XmlSerializer reader = new XmlSerializer(typeof(List<BaseTrinket>));
                        List<BaseTrinket> overview = (List<BaseTrinket>)reader.Deserialize(myFileStream);
                        result = overview[item];

                    }
                }
            }
                

             
            return result;
        }

        private int getXP(BaseMonster[] monsters)
        {
            int result = 0;
            foreach(BaseMonster monster in monsters)
            {
                result += monster.GiveXp;
            }
            return result;
        }

        public int Money
        {
            get
            {
                return _money;
            }
        }

        public BaseItem Item
        {
            get
            {
                return _item;
            }
        }

        public int Xp
        {
            get
            {
                return _xp;
            }
        }

        
    }
}
