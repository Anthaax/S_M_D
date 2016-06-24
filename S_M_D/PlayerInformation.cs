using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;
using S_M_D.Camp;
using S_M_D.Camp.ClassConfig;
using S_M_D.Camp.Class;

namespace S_M_D
{
    [Serializable]
    public class PlayerInformation
    {
        readonly GameContext _ctx;
        readonly List<BaseHeros> _myHeros;
        readonly List<BaseBuilding> _myBuildings;
        readonly List<BaseItem> _myItems;
        readonly List<BaseHeros> _deadHero;
        readonly List<BaseHeros> _onlineDude;
        int _numberOfWeek;
        public PlayerInformation( GameContext ctx )
        {
            _ctx = ctx;
            _myHeros = new List<BaseHeros>();
            _deadHero = new List<BaseHeros>();
            _myBuildings = new List<BaseBuilding>();
            _myItems = new List<BaseItem>();
            _onlineDude = new List<BaseHeros>();
            _numberOfWeek = 0;
        }

        public GameContext Ctx
        {
            get
            {
                return _ctx;
            }
        }

        public List<BaseHeros> MyHeros
        {
            get
            {
                return _myHeros;
            }
        }
        public List<BaseBuilding> MyBuildings
        {
            get
            {
                return _myBuildings;

            }
        }

        public List<BaseItem> MyItems
        {
            get
            {
                return _myItems;
            }
        }

        public List<BaseHeros> DeadHero
        {
            get
            {
                return _deadHero;
            }
        }

        public int NumberOfWeek
        {
            get
            {
                return _numberOfWeek;
            }
        }

        public List<BaseHeros> OnlineDude
        {
            get
            {
                return _onlineDude;
            }
        }

        public void NewWeek()
        {
            _numberOfWeek++;
            _myHeros.ForEach( h => h.InBuilding = null );
            RemoveAllHeroInBuildings();
        }

        public BaseBuilding GetBuilding( BuildingNameEnum name )
        {
            return _myBuildings.Find( t => t.Name == name );
        }
        public BaseHeros GetHeros( string name )
        {
            return _myHeros.Find( t => t.CharacterName == name );
        }
        public void InitializedBuilding()
        {
            _ctx.BuildingManager.Find( BuildingNameEnum.Townhall ).CreateBuilding();
            _ctx.BuildingManager.Find( BuildingNameEnum.Armory ).CreateBuilding();
            _ctx.BuildingManager.Find( BuildingNameEnum.Bar ).CreateBuilding();
            _ctx.BuildingManager.Find( BuildingNameEnum.Caravan ).CreateBuilding();
            _ctx.BuildingManager.Find( BuildingNameEnum.Casern ).CreateBuilding();
            _ctx.BuildingManager.Find( BuildingNameEnum.Cemetery ).CreateBuilding();
            _ctx.BuildingManager.Find( BuildingNameEnum.Hospital ).CreateBuilding();
            _ctx.BuildingManager.Find( BuildingNameEnum.Hotel ).CreateBuilding();
            _ctx.BuildingManager.Find( BuildingNameEnum.MentalHospital ).CreateBuilding();
        }
        public void InitializedHeros()
        {
            _ctx.HeroManager.Find( HerosEnum.Mage.ToString() ).CreateHero();
            _ctx.HeroManager.Find( HerosEnum.Paladin.ToString() ).CreateHero();
            _ctx.HeroManager.Find( HerosEnum.Priest.ToString() ).CreateHero();
            _ctx.HeroManager.Find( HerosEnum.Warrior.ToString() ).CreateHero();
        }
        private void RemoveAllHeroInBuildings()
        {
            foreach (var building in _myBuildings)
            {
                var SingleHero = building as ISingleHero;
                var MultipleHeros = building as IMultipleHero;

                if (SingleHero != null)
                    SingleHero.DeleteHero();
                else if (MultipleHeros != null)
                    MultipleHeros.DeleteHeros();
            }
        }
        public void CreateHeroForMulti( string className, string name, int isMale, int iDWeapon0, int iDWeapon1, int iDWeapon2, int iDWeapon3, int level )
        {
            List<int> ID = new List<int>();
            ID.Add( iDWeapon0 );
            ID.Add( iDWeapon1 );
            ID.Add( iDWeapon2 );
            ID.Add( iDWeapon3 );
            BaseHeros hero = _ctx.HeroManager.Find( className ).CreateHeroWithLeve( level, isMale == 0, name, ID.ToArray() );
            _onlineDude.Add( hero );
        }
    }
}
