using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemCreator;
using System.IO;
using System.Xml.Serialization;
using S_M_D.Character;

namespace S_M_D.Dungeon
{
    public class EventGenerator : IEventGenerator
    {

        private string[] eventName = { "Chest", "Combat", "NoEvent", "Trap" };

        private string SelectEvent()
        {
            Random rand = new Random( );

            string selection = eventName[ rand.Next( 0, eventName.Length ) ];

            return selection;
        }

        private void FillChest( )
        {
            Random rand = new Random( );
            int item = rand.Next( 200 );
            string path;
            Character.BaseItem result;

            int selection = rand.Next( 1, 2 );

            if(selection == 1)
            {
                path = "Items/Armors.xml";
                using ( FileStream myFileStream = new FileStream( path, FileMode.Open ) )
                {
                    XmlSerializer reader = new XmlSerializer( typeof( List<Character.BaseArmor> ) );
                    List<Character.BaseArmor> overview = ( List<Character.BaseArmor> ) reader.Deserialize( myFileStream );
                    result = overview[ item ];

                }
            }
            else
            {
                path = "Items/Weapons.xml";
                using ( FileStream myFileStream = new FileStream( path, FileMode.Open ) )
                {
                    XmlSerializer reader = new XmlSerializer( typeof( List<Character.BaseWeapon> ) );
                    List<Character.BaseWeapon> overview = ( List<Character.BaseWeapon> ) reader.Deserialize( myFileStream );
                    result = overview[ item ];

                }
            }
        }

        public void Generate(Map map)
        {
            foreach(Room r in map.Rooms)
            {
                AttachEvent( r );
            }
        }

        public void AttachEvent( Room selectedRoom )
        {
            selectedRoom.events.Add( SelectEvent( ) );
        }

    }
}
