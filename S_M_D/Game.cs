using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;
using S_M_D.Camp;

namespace S_M_D
{
    public class GameContext
    {
        readonly Random _rnd;
        readonly PlayerInformation _playerInfo;
        readonly HerosManager _herosManager;
        readonly BuildingManager _buildingManager;
        GameContext(GameContext gameContext)
            :this()
        {
            _rnd = gameContext.Rnd;
            _playerInfo = gameContext.PlayerInfo;
            _herosManager = gameContext.HeroManager;
        }

        GameContext()
        {
            _rnd = new Random( 1 );
            _playerInfo = new PlayerInformation( this );
            _herosManager = new HerosManager( this );
            _buildingManager = new BuildingManager(this);
        }
        public static GameContext CreateNewGame()
        {
            return new GameContext();
        }

        public Random Rnd { get { return _rnd; } } 
        public PlayerInformation PlayerInfo { get { return _playerInfo; } }
        public HerosManager HeroManager { get { return _herosManager; } }

        public BuildingManager BuildingManager
        {
            get
            {
                return _buildingManager;
            }
        }
    }
}
