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
    public class PlayerInformation
    {
        readonly GameContext _ctx;
        readonly List<BaseHeros> _myHeros;
        readonly List<BaseBuilding> _myBuildings;
        public PlayerInformation(GameContext ctx)
        {
            _ctx = ctx;
            _myHeros = new List<BaseHeros>();
            _myBuildings = new List<BaseBuilding>();
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
        public BaseBuilding GetBuilding(BuildingName name)
        {
            return _myBuildings.Find(t => t.Name == name);
        }
        public BaseHeros GetHeros( string name )
        {
            return _myHeros.Find( t => t.CharacterName == name );
        }
        public void InitializedBuilding()
        {
            _ctx.BuildingManager.Find(BuildingName.Townhall).CreateBuilding();
            _ctx.BuildingManager.Find(BuildingName.Armory).CreateBuilding();
            _ctx.BuildingManager.Find(BuildingName.Bar).CreateBuilding();
            _ctx.BuildingManager.Find(BuildingName.Caravan).CreateBuilding();
            _ctx.BuildingManager.Find(BuildingName.Casern).CreateBuilding();
            _ctx.BuildingManager.Find(BuildingName.Cemetery).CreateBuilding();
            _ctx.BuildingManager.Find(BuildingName.Hospital).CreateBuilding();
            _ctx.BuildingManager.Find(BuildingName.Hotel).CreateBuilding();
            _ctx.BuildingManager.Find(BuildingName.MentalHospital).CreateBuilding();
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
