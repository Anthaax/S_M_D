using S_M_D.Camp.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp
{
    public abstract class BaseBuilding
    {
        private BuildingName _name;
        private int _buildingCost;
        private int _level;
        readonly int _levelMax;

        public BaseBuilding(BuildingType b)
        {
            _name = b.Name;
            _buildingCost = b.BuildingCost;
            _level = b.Level;
            _levelMax = 4;
        }


        public BuildingName Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
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
    }
}
