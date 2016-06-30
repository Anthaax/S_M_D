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
        int _xp = 0;
        readonly List<BaseItem> _items;
        int _money = 0;
        readonly GameContext _gameContext;

        public Reward( GameContext gameContext)
        {
            _gameContext = gameContext;
            _items = new List<BaseItem>();
        }
        private BaseItem GetItem()
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

        public void AddXpCombat(BaseMonster[] monsters)
        {
            monsters.ToList().ForEach( m => _xp += m.GiveXp );
        }

        public void AddItemToLoot()
        {
            _items.Add( GetItem());
        }

        public void AddGold()
        {
            _money += 100;
        }

        public int Money
        {
            get
            {
                return _money;
            }
        }

        public List<BaseItem> Items
        {
            get
            {
                return _items;
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
