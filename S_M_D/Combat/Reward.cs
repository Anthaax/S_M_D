using System.Collections.Generic;
using S_M_D.Character;
using S_M_D;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using System;

namespace S_M_D.Combat
{
    [Serializable]
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
            int rand = _gameContext.Rnd.Next(30);
            BaseItem result = null;
            if (_gameContext.Rnd.Next(20) > 9)
            {
                if (rand > 19)
                {
                    int nbMatchItem = _gameContext.AllItemInGame
                                .Where( c => c.Itemtype == BaseItem.ItemTypes.Armor )
                                .Count();
                    result = _gameContext.AllItemInGame
                                .Where( c => c.Itemtype == BaseItem.ItemTypes.Armor )
                                .ToList()[_gameContext.Rnd.Next( nbMatchItem )];
                }
                else if (rand > 9)
                {
                    int nbMatchItem = _gameContext.AllItemInGame
                                .Where( c => c.Itemtype == BaseItem.ItemTypes.Weapon )
                                .Count();
                    result = _gameContext.AllItemInGame
                                .Where( c => c.Itemtype == BaseItem.ItemTypes.Weapon )
                                .ToList()[_gameContext.Rnd.Next( nbMatchItem )];
                }
                else
                {
                    int nbMatchItem = _gameContext.AllItemInGame
                                .Where( c => c.Itemtype == BaseItem.ItemTypes.Trinket )
                                .Count();
                    result = _gameContext.AllItemInGame
                                .Where( c => c.Itemtype == BaseItem.ItemTypes.Trinket )
                                .ToList()[_gameContext.Rnd.Next( nbMatchItem )];
                }
            }
                

             
            return result;
        }

        private int getXP(BaseMonster[] monsters)
        {
            int result = 0;
            monsters.ToList().ForEach( m => result += m.GiveXp );
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
