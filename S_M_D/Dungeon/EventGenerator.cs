using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
