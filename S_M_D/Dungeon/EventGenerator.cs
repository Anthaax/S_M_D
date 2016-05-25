using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using ItemCreator;
using System.IO;
using System.Xml.Serialization;
using S_M_D.Character;

namespace S_M_D.Dungeon
{
    public class EventGenerator : IEventGenerator
    {

        private string[] eventName = { "Trap", "Combat", "NoEvent", "Chest" };

        Random rand = new Random( );

        private string SelectEvent()
        {
            string selection = eventName[ rand.Next( 0, eventName.Length ) ];

            return selection;
        }

        private BaseItem FillChest( )
        {
            int item = rand.Next( 200 );
            string path;
            Character.BaseItem result = null;

            int selection = rand.Next( 1, 3 );

            switch(selection)
            {
                case 1 :
                    path = "Items/Armors.xml";
                    using ( FileStream myFileStream = new FileStream( path, FileMode.Open ) )
                    {
                        XmlSerializer reader = new XmlSerializer( typeof( List<Character.BaseArmor> ) );
                        List<Character.BaseArmor> overview = ( List<Character.BaseArmor> ) reader.Deserialize( myFileStream );
                        result = overview[ item ];
                    }
                    break;

                case 2 :
                    path = "Items/Weapons.xml";
                    using ( FileStream myFileStream = new FileStream( path, FileMode.Open ) )
                    {
                        XmlSerializer reader = new XmlSerializer( typeof( List<Character.BaseWeapon> ) );
                        List<Character.BaseWeapon> overview = ( List<Character.BaseWeapon> ) reader.Deserialize( myFileStream );
                        result = overview[ item ];
                    }
                    break;

                case 3 :
                    path = "Items/Trinkets.xml";
                    using ( FileStream myFileStream = new FileStream( path, FileMode.Open ) )
                    {
                        XmlSerializer reader = new XmlSerializer( typeof( List<Character.BaseTrinket> ) );
                        List<Character.BaseTrinket> overview = ( List<Character.BaseTrinket> ) reader.Deserialize( myFileStream );
                        result = overview[ item ];
                    }
                    break;
            }

            return result;
        }

        public void Generate(Map map)
        {
            foreach(Room r in map.Rooms)
            {
                AttachEvent( r );
                if(r.events.Contains("Chest"))
                {
                    r.chest.Add( FillChest( ) );
                }
            }
        }

        public void AttachEvent( Room selectedRoom )
        {
            selectedRoom.events.Add( SelectEvent( ) );
        }

        public void AttachChestEvent(Room selectedRoom)
        {
            selectedRoom.events.Add( eventName[ 0 ] );
        }

    }
}
