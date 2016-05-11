using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp
{
    public abstract class BuildingType
    {
        readonly string _name;
        readonly int _buildingCost;
        readonly int _level;
        readonly List<BaseBuilding> _buildings;

        protected BuildingType(string name, int buildingCost,int level, List<BaseBuilding> buildings)
        {
            _name = name;
            _buildingCost = buildingCost;
            _buildings = buildings;
            _level = level;
        }

        public int BuildingCost
        {
            get { return _buildingCost; }
        }
        public int Level
        {
            get { return _level; }
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
