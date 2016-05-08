using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_M_D.Character
{
    public class HerosManager
    {
        readonly Dictionary<string, HerosType> _types;
        readonly List<BaseHeros> _heros;
        public HerosManager( List<BaseHeros> heros)
        {
            _types = new Dictionary<string, HerosType>();
            _heros = heros;
            Initialize();
        }

        void Initialize()
        {
            RegisterType( new WarriorConfiguration( Heros ) );
            RegisterType( new PaladinConfiguration( Heros ) );
        }
        void RegisterType( HerosType h )
        {
            _types.Add( h.CharacterName , h );
        }
        public HerosType Find( string name )
        {
            HerosType t;
            _types.TryGetValue( name, out t );
            return t;
        }
        public IEnumerable<HerosType> AllTypes
        {
            get { return _types.Values; }
        }
        public List<BaseHeros> Heros
        {
            get{ return _heros; }
        }
    }
}
