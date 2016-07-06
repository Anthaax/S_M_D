using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace S_M_D.Character
{

    [Serializable]
    public class BaseTrinket : BaseStatItem
    {
        public enum trinketType
        {
            Bague,
            Collier,
            PorteCouille
        }
        trinketType trinketTYpe;

        public trinketType TrinketTYpe
        {
            get
            {
                return trinketTYpe;
            }

            set
            {
                trinketTYpe = value;
            }
        }
    }
}
