using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D
{
    public class MoneyManager
    {
        private GameContext _gameContext;

        public MoneyManager( GameContext gameContext )
        {
            _gameContext = gameContext;
        }
    }
}
