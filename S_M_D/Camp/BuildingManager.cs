using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Camp.ClassConfig;
using S_M_D.Camp.Class;

namespace S_M_D.Camp
{
    [Serializable]
    public class BuildingManager
    {
        readonly GameContext _ctx;
        readonly Dictionary<BuildingNameEnum, BuildingType> _buildingTypes;

        public BuildingManager( GameContext ctx)
        {
            _ctx = ctx;
            _buildingTypes = new Dictionary<BuildingNameEnum, BuildingType>();
            Initialized();
        }

        private void Initialized()
        {
            RegisterTypes(new TownHallConfig(Ctx));
            RegisterTypes(new ArmoryConfig(Ctx));
            RegisterTypes(new BarConfig(Ctx));
            RegisterTypes(new CaravanConfig(Ctx));
            RegisterTypes(new CasernConfig(Ctx));
            RegisterTypes(new CemeteryConfig(Ctx));
            RegisterTypes(new HospitalConfig(Ctx));
            RegisterTypes(new HotelConfig(Ctx));
            RegisterTypes(new MentalHospitalConfig(Ctx));
        }

        private void RegisterTypes(BuildingType building)
        {
            _buildingTypes.Add(building.Name, building);
        }

        public BuildingType Find(BuildingNameEnum name)
        {
            BuildingType b;
            _buildingTypes.TryGetValue(name, out b);
            return b;
        }

        public IEnumerable<BuildingType> AllTypes
        {
            get { return _buildingTypes.Values; }
        }

        public GameContext Ctx
        {
            get
            {
                return _ctx;
            }
        }
    }
}
