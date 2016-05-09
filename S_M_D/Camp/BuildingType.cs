using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_M_D.Camp
{
    public abstract class BuildingType
    {
        readonly string _name;
        readonly int _buildingCost;
        readonly List<BaseBuilding> _buildings;

        protected BuildingType(string name, int buildingCost, List<BaseBuilding> buildings)
        {
            _name = name;
            _buildingCost = buildingCost;
            _buildings = buildings;
        }

        public int BuildingCost
        {
            get { return _buildingCost; }
        }

        public string Name
        {
            get { return _name; }
        }
        public List<BaseBuilding> Buildings
        {
            get { return _buildings; }
        }
    }
}
