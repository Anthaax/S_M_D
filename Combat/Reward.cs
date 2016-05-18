using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S_M_D.Character;
using S_M_D;
using System.IO;
using System.Xml.Serialization;

namespace Combat
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
            _item = getItem();
            _money = _gameContext.Rnd.Next(10000);

        }

        private BaseItem getItem()
        {
            string path;
            int rand = _gameContext.Rnd.Next(30);
            int item = _gameContext.Rnd.Next(200);
            BaseItem result = null;
            if (rand > 19) path = "../../../S_M_D/Items/Weapons.xml";
            else if (rand > 9) path = "../../../S_M_D/Items/Armors.xml";
            else path = "../../../S_M_D/Items/Trinkets.xml";

            if (_gameContext.Rnd.Next(20)>9)
            {
                using (FileStream myFileStream = new FileStream(path, FileMode.Open))
                {
                    XmlSerializer reader = new XmlSerializer(typeof(List<BaseItem>));
                    List<BaseItem> overview = (List<BaseItem>)reader.Deserialize(myFileStream);
                    result = overview[item];

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
