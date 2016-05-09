using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_M_D.Camp
{
    public abstract class BaseBuilding
    {
        private string _name;
        private int _buildingCost;
        private int _level;

        public BaseBuilding(string name, int buildingCost, int level)
        {
            _name = name;
            _buildingCost = buildingCost;
            _level = level;
        }


        public string Name
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
