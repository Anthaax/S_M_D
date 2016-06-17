using S_M_D.Camp.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp
{
    [Serializable]
    public abstract class BaseBuilding
    {
        readonly BuildingNameEnum _name;
        private int _buildingCost;
        private int _level;
        readonly int _levelMax;
        readonly GameContext _ctx;
        public BaseBuilding(BuildingType b)
        {
            _name = b.Name;
            _buildingCost = b.BuildingCost;
            _level = b.Level;
            _levelMax = 4;
            _ctx = b.Ctx;
        }

        public BuildingNameEnum Name
        {
            get
            {
                return _name;
            }
        }

        public int BuildingCost
        {
            get
            {
                return _buildingCost;
            }

            set
            {
                _buildingCost = value;
            }
        }

        public int Level
        {
            get
            {
                return _level;
            }

            set
            {
                _level = value;
            }
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
