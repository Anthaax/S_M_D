using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S_M_D.Character;
using S_M_D.Character.Monsters;
using S_M_D;


namespace Combat
{
    public class CombatManager
    {
        readonly BaseMonster[] _monsters;
        readonly BaseHeros[] _heros;
        readonly GameContext _gameContext;
        readonly Reward _reward;


        public CombatManager(BaseHeros[] heros, GameContext gameContext)
        {
            _gameContext = gameContext;
            MonsterConfiguration monsterCreation = new MonsterConfiguration();
            _heros = heros;
            createMonster(monsterCreation);
            _reward = new Reward(_monsters, _gameContext);

        }

        private void createMonster(MonsterConfiguration monsterCreation)
        {

            for (int x = 0; x < 4; x++)
            {
                _monsters[x] = monsterCreation.CreateMonster((MonsterType)_gameContext.Rnd.Next(1,5), _heros[x].Lvl);
            }

        }

        public Reward Reward
        {
            get
            {
                return _reward;
            }
        }
    }
}
