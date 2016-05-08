using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_M_D.Character
{
    public abstract class HerosType
    {
        readonly List<BaseHeros> _heroes;
        readonly string _characterClassName;
        readonly string _characterName;
        readonly int _price;
        readonly bool _isMale;

        protected HerosType( List<BaseHeros> heroes, string characterClassName, int price, bool isMale, string characterName )
        {
            _heroes = heroes;
            _characterClassName = characterClassName;
            _characterName = characterName;
            _isMale = isMale;
            _price = price;
        }

        public string CharacterClassName { get { return _characterClassName; } }
        public string CharacterName { get { return _characterName; } }
        public int Price { get { return _price; } }
        public bool IsMale { get { return _isMale; } }

        public List<BaseHeros> Heroes
        {
            get
            {
                return _heroes;
            }
        }

        public BaseHeros CreateHero()
        {
            if (Heroes.Count > 16) throw new InvalidOperationException("You have already 16 hero");
            BaseHeros Hero = DoCreateHero();
            Heroes.Add( Hero );
            //Enlever Argent
            return Hero;
        }
        protected abstract BaseHeros DoCreateHero();
    }
}
