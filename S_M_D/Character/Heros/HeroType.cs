using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Character
{
    [Serializable]
    public abstract class HerosType
    {
        readonly GameContext _ctx;
        readonly string _characterClassName;
        string _characterName;
        readonly int _price;
        bool _isMale;
        /// <summary>
        /// Type of a Hero with all of is information and methode for the creation of him
        /// </summary>
        /// <param name="heroes"></param>
        /// <param name="characterClassName"></param>
        /// <param name="price"></param>
        /// <param name="characterName"></param>
        protected HerosType( GameContext ctx, string characterClassName, int price, string characterName )
        {
            _ctx = ctx;
            _characterClassName = characterClassName;
            _price = price;
        }

        private string ChooseCharacterName()
        {

            string name;
            Array valuesM = Enum.GetValues(typeof(HerosMaleNameEnum));
            Array valuesF = Enum.GetValues(typeof(HerosFemaleNameEnum));

            if (_isMale == true) name = valuesM.GetValue(_ctx.Rnd.Next(valuesM.Length)).ToString();
            else name = valuesF.GetValue(_ctx.Rnd.Next(valuesF.Length)).ToString();

            return name;
        }

        public string CharacterClassName { get { return _characterClassName; } }
        public string CharacterName { get { return _characterName; } }
        public int Price { get { return _price; } }
        public bool IsMale { get { return _isMale; } }
        public GameContext GameContext { get { return _ctx; } }
        /// <summary>
        /// CHoose randomly if the hero is a male or a female
        /// </summary>
        /// <returns> Return a bool </returns>
        private bool ChooseSex()
        {
            return _ctx.Rnd.Next(2) == 0;

        }
        /// <summary>
        /// Create an hero with is good configuration
        /// </summary>
        /// <returns> the new hero </returns>
        public BaseHeros CreateHero()
        {
            if (_ctx.PlayerInfo.MyHeros.Count >= 16) throw new InvalidOperationException("You have already 16 hero");
            if (!_ctx.MoneyManager.CanBuy(Price)) throw new InvalidOperationException("Pls check money before buy an hero");
            _isMale = ChooseSex();
            _characterName = ChooseCharacterName();
            BaseHeros Hero = DoCreateHero();
            InitializedEquipment( Hero );
            InitilizedSpell( Hero );
            _ctx.PlayerInfo.MyHeros.Add( Hero );
            return Hero;
        }
        public BaseHeros CreateHeroWithLeve(int level, bool isMale, string characterName, int[] IDItem)
        {
            _isMale = isMale;
            _characterName = characterName;
            BaseHeros Hero = ApplyLevelAndCreateHero( level );
            Hero.Lvl = level;
            InitilizedSpell(Hero);
            EquipedItemWithID( IDItem, Hero );
            return Hero;
        }
        /// <summary>
        /// Create an hero with is good configuration
        /// </summary>
        /// <returns> the new hero </returns>
        public BaseHeros CreateHeroToBuy()
        {
            if (_ctx.PlayerInfo.MyHeros.Count >= 16) throw new InvalidOperationException("You have already 16 hero");
            _isMale = ChooseSex();
            _characterName = ChooseCharacterName();
            BaseHeros Hero = DoCreateHero();
            InitializedEquipment( Hero );
            InitilizedSpell(Hero);
            return Hero;
        }
        /// <summary>
        /// Create a hero and return this one with the good configuration 
        /// </summary>
        /// <returns> Return the new hero </returns>
        protected abstract BaseHeros DoCreateHero();
        protected abstract BaseHeros ApplyLevelAndCreateHero( int level );
        /// <summary>
        /// Initialize all spell of an paladin
        /// </summary>
        /// <param name="hero"> A paladin to initialize spell</param>
        protected abstract void InitilizedSpell( BaseHeros hero );
        private void InitializedEquipment( BaseHeros hero )
        {
            int nbMatchItem = GameContext.AllItemInGame
                                .Where( c => c.Quality == BaseStatItem.quality.common && c.Itemtype == BaseItem.ItemTypes.Armor )
                                .Count();
            BaseItem item = GameContext.AllItemInGame
                                .Where( c => c.Quality == BaseStatItem.quality.common && c.Itemtype == BaseItem.ItemTypes.Armor )
                                .ToList()[GameContext.Rnd.Next( nbMatchItem )];
            AddItem( item, hero );
            nbMatchItem = GameContext.AllItemInGame
                                .Where( c => c.Quality == BaseStatItem.quality.common && c.Itemtype == BaseItem.ItemTypes.Weapon )
                                .Count();
            item = GameContext.AllItemInGame
                                .Where( c => c.Quality == BaseStatItem.quality.common && c.Itemtype == BaseItem.ItemTypes.Weapon )
                                .ToList()[GameContext.Rnd.Next( nbMatchItem )];
            AddItem( item, hero );
            nbMatchItem = GameContext.AllItemInGame
                                .Where( c => c.Quality == BaseStatItem.quality.common && c.Itemtype == BaseItem.ItemTypes.Trinket )
                                .Count();
            item = GameContext.AllItemInGame
                                .Where( c => c.Quality == BaseStatItem.quality.common && c.Itemtype == BaseItem.ItemTypes.Trinket )
                                .ToList()[GameContext.Rnd.Next( nbMatchItem )];
            AddItem( item, hero );
            nbMatchItem = GameContext.AllItemInGame
                                .Where( c => c.Quality == BaseStatItem.quality.common && c.Itemtype == BaseItem.ItemTypes.Trinket )
                                .Count();
            item = GameContext.AllItemInGame
                                .Where( c => c.Quality == BaseStatItem.quality.common && c.Itemtype == BaseItem.ItemTypes.Trinket )
                                .ToList()[GameContext.Rnd.Next( nbMatchItem )];
            AddItem( item, hero );
        }
        private void AddItem(BaseItem itemToAdd, BaseHeros hero)
        {
            _ctx.PlayerInfo.MyItems.Add( itemToAdd );
            hero.GetNewItem( itemToAdd );
        }
        private void EquipedItemWithID(int[] ID, BaseHeros hero)
        {
            int count = 0;
            foreach (var id in ID)
            {
                if(id != 0 && count == 0)
                {
                    BaseItem item = GameContext.AllItemInGame
                                .First( c => c.ItemId == id && c.Itemtype == BaseItem.ItemTypes.Armor);
                    AddItem( item, hero );
                }
                else if (id != 0 && count == 1)
                {
                    BaseItem item = GameContext.AllItemInGame
                                .First( c => c.ItemId == id && c.Itemtype == BaseItem.ItemTypes.Weapon );
                    AddItem( item, hero );
                }
                else if(id != 0)
                {
                    BaseItem item = GameContext.AllItemInGame
                                .First( c => c.ItemId == id && c.Itemtype == BaseItem.ItemTypes.Trinket );
                    AddItem( item, hero );
                }
                count++;
            }
        }
    }
}
