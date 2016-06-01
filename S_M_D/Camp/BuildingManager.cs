using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Camp.ClassConfig;
using S_M_D.Camp.Class;

namespace S_M_D.Camp
{
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
            RegisterTypes(new TownHallConfig(_ctx));
            RegisterTypes(new ArmoryConfig(_ctx));
            RegisterTypes(new BarConfig(_ctx));
            RegisterTypes(new CaravanConfig(_ctx));
            RegisterTypes(new CasernConfig(_ctx));
            RegisterTypes(new CemeteryConfig(_ctx));
            RegisterTypes(new HospitalConfig(_ctx));
            RegisterTypes(new HotelConfig(_ctx));
            RegisterTypes(new MentalHospitalConfig(_ctx));
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
    }
}
