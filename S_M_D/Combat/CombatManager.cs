using S_M_D.Character;
using S_M_D.Character.Monsters;
using S_M_D;


namespace S_M_D.Combat
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
            _monsters = new BaseMonster[4];
            MonsterConfiguration monsterCreation = new MonsterConfiguration();
            _heros = heros;
            createMonster(monsterCreation);
            _reward = new Reward(_monsters, _gameContext);

        }

        private void createMonster(MonsterConfiguration monsterCreation)
        {

            for (int x = 0; x < 4; x++)
            {
                Monsters[x] = monsterCreation.CreateMonster((MonsterType)_gameContext.Rnd.Next(1,5), Heros[x].Lvl);
            }

        }

        public Reward Reward
        {
            get
            {
                return _reward;
            }
        }

        public BaseHeros[] Heros
        {
            get
            {
                return _heros;
            }
        }

        public BaseMonster[] Monsters
        {
            get
            {
                return _monsters;
            }
        }
    }
}
