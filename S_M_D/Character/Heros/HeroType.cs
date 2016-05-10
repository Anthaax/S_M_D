using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Character
{
    public abstract class HerosType
    {
        readonly List<BaseHeros> _heroes;
        readonly string _characterClassName;
        readonly string _characterName;
        readonly int _price;
        readonly bool _isMale;
        /// <summary>
        /// Type of a Hero with all of is information and methode for the creation of him
        /// </summary>
        /// <param name="heroes"></param>
        /// <param name="characterClassName"></param>
        /// <param name="price"></param>
        /// <param name="characterName"></param>
        protected HerosType( List<BaseHeros> heroes, string characterClassName, int price, string characterName )
        {
            _heroes = heroes;
            _characterClassName = characterClassName;
            _characterName = characterName;
            _isMale = ChooseSex();
            _price = price;
        }

        public string CharacterClassName { get { return _characterClassName; } }
        public string CharacterName { get { return _characterName; } }
        public int Price { get { return _price; } }
        public bool IsMale { get { return _isMale; } }
        public List<BaseHeros> Heroes { get { return _heroes; } }
        /// <summary>
        /// CHoose randomly if the hero is a male or a female
        /// </summary>
        /// <returns> Return a bool </returns>
        private bool ChooseSex()
        {
            Random rnd = new Random( 1 );
            return rnd.Next( 2 ) == 0;
        }
        /// <summary>
        /// Create an hero with is good configuration
        /// </summary>
        /// <returns> the new hero </returns>
        public BaseHeros CreateHero()
        {
            if (Heroes.Count >= 16) throw new InvalidOperationException("You have already 16 hero");
            BaseHeros Hero = DoCreateHero();
            InitilizedSpell( Hero );
            Heroes.Add( Hero );
            //Enlever Argent
            return Hero;
        }
        /// <summary>
        /// Create a hero and return this one with the good configuration 
        /// </summary>
        /// <returns> Return the new hero </returns>
        protected abstract BaseHeros DoCreateHero();
        /// <summary>
        /// Initialize all spell of an paladin
        /// </summary>
        /// <param name="hero"> A paladin to initialize spell</param>
        protected abstract void InitilizedSpell( BaseHeros hero );

    }
}
