using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Character
{
    /// <summary>
    /// Manage hero creation
    /// </summary>
    public class HerosManager
    {
        readonly Dictionary<string, HerosType> _types;
        readonly GameContext _ctx;
        public HerosManager( GameContext ctx)
        {
            _types = new Dictionary<string, HerosType>();
            _ctx = ctx;
            Initialize();
        }
        /// <summary>
        /// Initiliaze the dictionary of herosType with all type of hero
        /// </summary>
        void Initialize()
        {
            RegisterType( new WarriorConfiguration( _ctx ) );
            RegisterType( new PaladinConfiguration( _ctx ) );
            RegisterType( new MageConfiguration( _ctx ) );
            RegisterType( new PriestConfiguration( _ctx ) );
        }
        /// <summary>
        /// Add in the dictionary the good name for hero type
        /// </summary>
        /// <param name="h"></param>
        void RegisterType( HerosType h )
        {
            _types.Add( h.CharacterClassName , h );
        }
        /// <summary>
        /// Find a Type with is Type name
        /// </summary>
        /// <param name="name"> to minimise fail chance use HerosEnum an chose your class</param>
        /// <returns>The hero types</returns>
        public HerosType Find( string name )
        {
            HerosType t;
            _types.TryGetValue( name, out t );
            return t;
        }
        /// <summary>
        /// Get an IEnumarable of all HerosType in the heros manager
        /// </summary>
        public IEnumerable<HerosType> AllTypes
        {
            get { return _types.Values; }
        }
    }
}
