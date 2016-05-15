using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D
{
    public class MoneyManager
    {
        private GameContext _gameContext;
        private int _money;

        public MoneyManager(GameContext gameContext)
        {
            _gameContext = gameContext;
            _money = 10000;
        }
        public bool CanBuy(int costItem)
        {
            return costItem <= _money;
        }
        public void Buy(int cost)
        {
            if (cost <= _money)
                _money -= cost;
        }
        public int Money
        {
            get
            {
                return _money;
            }
        }
    }
}
