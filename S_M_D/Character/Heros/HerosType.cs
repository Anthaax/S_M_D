using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_M_D.Character
{
    public abstract class HerosType
    {
        readonly string _characterClassName;
        readonly string _characterName;
        readonly int _price;
        readonly bool _isMale;

        protected HerosType(string characterClassName, int price, bool isMale, string characterName)
        {
            _characterClassName = characterClassName;
            _characterName = characterName;
            _isMale = isMale;
            _price = price;
        }

        public string CharacterClassName { get { return _characterClassName; } }
        public string CharacterName { get { return _characterClassName; } }
        public int Price { get { return _price; } }
        public bool IsMale { get { return _isMale; } }

        public void CreateHero( List<BaseHero> HerosList )
        {
          
        }
    }
}
