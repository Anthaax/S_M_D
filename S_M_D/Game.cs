using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;
using S_M_D.Camp;
using System.Reflection;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace S_M_D
{
    [Serializable]
    public class GameContext
    {
        readonly Random _rnd;
        readonly PlayerInformation _playerInfo;
        readonly HerosManager _herosManager;
        readonly BuildingManager _buildingManager;
        readonly MoneyManager _moneyManager;
        readonly List<BaseStatItem> _allItemInGame;
        readonly DungeonManager _dungeonManager;
        readonly string _saveName;

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
            _saveName = gameContext.SaveName;
        }

        private GameContext()
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
            _saveName = Rnd.Next().ToString();

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
            _saveName = Rnd.Next().ToString();
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

        public void Save(string folderName)
        {
            if (!Directory.Exists(folderName)) Directory.CreateDirectory(folderName);
            string pathString = Path.Combine(folderName, SaveName);
            using (Stream fileStream = new FileStream(pathString, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, this);
            }
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

        public string SaveName
        {
            get
            {
                return _saveName;
            }
        }

        private void InitializedItems()
        {
            using (Stream Stream = GetType().Assembly.GetManifestResourceStream( "S_M_D.Resources.Armors.xml" ))
            {
                XmlSerializer reader = new XmlSerializer( typeof( List<BaseArmor> ) );
                List<BaseArmor> overview = (List<BaseArmor>)reader.Deserialize( Stream );
                overview.ForEach( c => AllItemInGame.Add( c ) );
            }
            using (Stream Stream = GetType().Assembly.GetManifestResourceStream( "S_M_D.Resources.Weapons.xml" ))
            {
                XmlSerializer reader = new XmlSerializer( typeof( List<BaseWeapon> ) );
                List<BaseWeapon> overview = (List<BaseWeapon>)reader.Deserialize( Stream );
                overview.ForEach( c => AllItemInGame.Add( c ) );
            }
            using (Stream Stream = GetType().Assembly.GetManifestResourceStream( "S_M_D.Resources.Trinket.xml" ))
            {
                XmlSerializer reader = new XmlSerializer( typeof( List<BaseTrinket> ) );
                List<BaseTrinket> overview = (List<BaseTrinket>)reader.Deserialize( Stream );
                overview.ForEach( c => AllItemInGame.Add( c ) );
            }
        }
        public class LoadResult
        {
            public GameContext LoadedGame { get; private set; }
            public string ErrorMessage { get; private set; }

            public LoadResult(GameContext c, string error)
            {
                Debug.Assert(c == null ^ error == null);
                LoadedGame = c;
                ErrorMessage = error;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Null on error.</returns>
        public static LoadResult LoadGame(string path)
        {
            GameContext g;
            Stream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                g = (GameContext)formatter.Deserialize(fileStream);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fileStream.Close();
            }
            return new LoadResult(new GameContext(g), null);
        }
    }
}
