using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Character
{
    public class BaseItem
    {
        string itemName;
        string itemDescription;
        int itemId;
        public enum ItemTypes
        {
            Trinket,
            Potion,
            Armor,
            Weapon
        }
        ItemTypes itemtype;

        public string ItemName
        {
            get
            {
                return itemName;
            }

            set
            {
                itemName = value;
            }
        }

        public string ItemDescription
        {
            get
            {
                return itemDescription;
            }

            set
            {
                itemDescription = value;
            }
        }

        public int ItemId
        {
            get
            {
                return itemId;
            }

            set
            {
                itemId = value;
            }
        }

        public ItemTypes Itemtype
        {
            get
            {
                return itemtype;
            }

            set
            {
                itemtype = value;
            }
        }
    }
}
