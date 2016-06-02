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
        public DungeonManager( GameContext ctx)
        {
            _ctx = ctx;
            _mapCatalogue = new List<Map>();
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

            set
            {
                _cbtManager = value;
            }
        }

        public void InitializedCatalogue()
        {
            _mapCatalogue.Clear();
            for (int i = 0; i < 4; i++)
            {
                _mapCatalogue.Add( new Map() );
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
    }
}
