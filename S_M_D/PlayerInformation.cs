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
        public PlayerInformation(GameContext ctx)
        {
            _ctx = ctx;
            _myHeros = new List<BaseHeros>();
            _deadHero = new List<BaseHeros>();
            _myBuildings = new List<BaseBuilding>();
            _myItems = new List<BaseItem>();
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

        public BaseBuilding GetBuilding(BuildingNameEnum name)
        {
            return _myBuildings.Find(t => t.Name == name);
        }
        public BaseHeros GetHeros( string name )
        {
            return _myHeros.Find( t => t.CharacterName == name );
        }
        public void InitializedBuilding()
        {
            _ctx.BuildingManager.Find(BuildingNameEnum.Townhall).CreateBuilding();
            _ctx.BuildingManager.Find(BuildingNameEnum.Armory).CreateBuilding();
            _ctx.BuildingManager.Find(BuildingNameEnum.Bar).CreateBuilding();
            _ctx.BuildingManager.Find(BuildingNameEnum.Caravan).CreateBuilding();
            _ctx.BuildingManager.Find(BuildingNameEnum.Casern).CreateBuilding();
            _ctx.BuildingManager.Find(BuildingNameEnum.Cemetery).CreateBuilding();
            _ctx.BuildingManager.Find(BuildingNameEnum.Hospital).CreateBuilding();
            _ctx.BuildingManager.Find(BuildingNameEnum.Hotel).CreateBuilding();
            _ctx.BuildingManager.Find(BuildingNameEnum.MentalHospital).CreateBuilding();
        }
        public void InitializedHeros()
        {
            _ctx.HeroManager.Find( HerosEnum.Mage.ToString() ).CreateHero();
            _ctx.HeroManager.Find( HerosEnum.Paladin.ToString() ).CreateHero();
            _ctx.HeroManager.Find( HerosEnum.Priest.ToString() ).CreateHero();
            _ctx.HeroManager.Find( HerosEnum.Warrior.ToString() ).CreateHero();
        }
    }
}
