using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;
using S_M_D.Camp;
using System.Reflection;
using System.IO;
using System.Xml.Serialization;

namespace S_M_D
{
    public class GameContext
    {
        readonly Random _rnd;
        readonly PlayerInformation _playerInfo;
        readonly HerosManager _herosManager;
        readonly BuildingManager _buildingManager;
        readonly MoneyManager _moneyManager;
        readonly List<BaseStatItem> _allItemInGame;
        readonly DungeonManager _dungeonManager;

        public GameContext(GameContext gameContext)
            :this()
        {
            _rnd = gameContext.Rnd;
            _allItemInGame = gameContext.AllItemInGame;
            _herosManager = gameContext.HeroManager;
            _moneyManager = gameContext.MoneyManager;
            _buildingManager = gameContext.BuildingManager;
            _dungeonManager = gameContext.DungeonManager;
            _playerInfo = gameContext.PlayerInfo;
        }

        public GameContext()
        {
            _rnd = new Random();
            _herosManager = new HerosManager(this);
            _moneyManager = new MoneyManager( this );
            _playerInfo = new PlayerInformation( this );
            _buildingManager = new BuildingManager(this);
            _dungeonManager = new DungeonManager( this );
            _allItemInGame = new List<BaseStatItem>();
            InitializedItems();
            _playerInfo.InitializedBuilding();
            _playerInfo.InitializedHeros();

        }

        public GameContext( int rndSeed )
        {
            _rnd = new Random( rndSeed );
            _herosManager = new HerosManager( this );
            _moneyManager = new MoneyManager( this );
            _playerInfo = new PlayerInformation( this );
            _buildingManager = new BuildingManager( this );
            _dungeonManager = new DungeonManager( this );
            _allItemInGame = new List<BaseStatItem>();
            InitializedItems();
            _playerInfo.InitializedBuilding();
            _playerInfo.InitializedHeros();
        }

        /// <summary>
        /// Create a new game context
        /// </summary>
        /// <returns> Retur the new game context </returns>
        public static GameContext CreateNewGame()
        {
            return new GameContext();
        }
        public static GameContext CreateNewGame(int rndSeed)
        {
            return new GameContext(rndSeed);
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

        public MoneyManager MoneyManager
        {
            get
            {
                return _moneyManager;
            }
        }

        public List<BaseStatItem> AllItemInGame
        {
            get
            {
                return _allItemInGame;
            }
        }

        public DungeonManager DungeonManager
        {
            get
            {
                return _dungeonManager;
            }
        }

        private void InitializedItems()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            var uri = new Uri( path + @"\Armors.xml" );
            using (FileStream myFileStream = new FileStream( uri.LocalPath, FileMode.Open ))
            {
                XmlSerializer reader = new XmlSerializer( typeof( List<BaseArmor> ) );
                List<BaseArmor> overview = (List<BaseArmor>)reader.Deserialize( myFileStream );
                overview.ForEach( c => AllItemInGame.Add( c ) );
            }
            uri = new Uri( path + @"\Weapons.xml" );
            using (FileStream myFileStream = new FileStream( uri.LocalPath, FileMode.Open ))
            {
                XmlSerializer reader = new XmlSerializer( typeof( List<BaseWeapon> ) );
                List<BaseWeapon> overview = (List<BaseWeapon>)reader.Deserialize( myFileStream );
                overview.ForEach( c => AllItemInGame.Add( c ) );
            }
            uri = new Uri( path + @"\Trinket.xml" );
            using (FileStream myFileStream = new FileStream( uri.LocalPath, FileMode.Open ))
            {
                XmlSerializer reader = new XmlSerializer( typeof( List<BaseTrinket> ) );
                List<BaseTrinket> overview = (List<BaseTrinket>)reader.Deserialize( myFileStream );
                overview.ForEach( c => AllItemInGame.Add( c ) );
            }
        }
    }
}
