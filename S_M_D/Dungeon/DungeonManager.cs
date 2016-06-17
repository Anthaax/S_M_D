using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Dungeon;
using S_M_D.Character;
using S_M_D.Combat;

namespace S_M_D
{
    [Serializable]
    public class DungeonManager
    {
        readonly GameContext _ctx;
        readonly List<Map> _mapCatalogue;
        Map _curentDungeon;
        BaseHeros[] _heros;
        CombatManager _cbtManager;
        Reward _reward;
        public DungeonManager( GameContext ctx)
        {
            _ctx = ctx;
            _mapCatalogue = new List<Map>();
            _reward = new Reward( _ctx );
        }

        public GameContext Ctx
        {
            get { return _ctx; }
        }

        public Map CurentDungeon
        {
            get { return _curentDungeon; }
        }
        public BaseHeros[] Heros
        {
            get { return _heros; }
        }

        public List<Map> MapCatalogue
        {
            get
            {
                return _mapCatalogue;
            }
        }

        public CombatManager CbtManager
        {
            get
            {
                return _cbtManager;
            }
        }

        public Reward Reward
        {
            get
            {
                return _reward;
            }
        }

        public void InitializedCatalogue()
        {
            _mapCatalogue.Clear();
            for (int i = 0; i < 4; i++)
            {
                _mapCatalogue.Add( new Map(Ctx) );
            }
        }
        public void CreateDungeon(BaseHeros[] heros, Map dungeon)
        {
            _curentDungeon = dungeon;
            _heros = heros;
        }
        public void LaunchCombat()
        {
            if (_curentDungeon == null) throw new InvalidOperationException( "Impossible to launch CombatWithout a Map" );
            _cbtManager = new CombatManager( Heros, Ctx );
        }
        public void EndOfTheDuengon()
        {
            int numbersHeros = _heros.Count( h => h.IsDead == false );
            if(numbersHeros != 0)
            {
                _heros.Where( h => h.IsDead == false ).ToList().ForEach( h => h.Xp += _reward.Xp / numbersHeros );
                _ctx.PlayerInfo.MyItems.AddRange( _reward.Items );
                _ctx.MoneyManager.ReciveMoney( _reward.Money );
            }
            _ctx.PlayerInfo.NewWeek();
        }
    }
}
