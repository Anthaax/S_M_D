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

        private BaseItem FillChest( GameContext ctx )
        {
            int item = rand.Next( 200 );
            string path;
            Character.BaseItem result = null;

            int selection = rand.Next( 1, 4 );

            switch(selection)
            {
                case 1 :
                    int nbMatchItem = ctx.AllItemInGame
                                .Where(c => c.Quality == BaseStatItem.quality.common && c.Itemtype == BaseItem.ItemTypes.Armor)
                                .Count();
                    result = ctx.AllItemInGame
                                .Where(c => c.Quality == BaseStatItem.quality.common && c.Itemtype == BaseItem.ItemTypes.Armor)
                                .ToList()[ctx.Rnd.Next(nbMatchItem)];
                    break;

                case 2 :
                    nbMatchItem = ctx.AllItemInGame
                                .Where(c => c.Quality == BaseStatItem.quality.common && c.Itemtype == BaseItem.ItemTypes.Weapon)
                                .Count();
                    result = ctx.AllItemInGame
                                .Where(c => c.Quality == BaseStatItem.quality.common && c.Itemtype == BaseItem.ItemTypes.Weapon)
                                .ToList()[ctx.Rnd.Next(nbMatchItem)];
                    break;

                case 3 :
                    nbMatchItem = ctx.AllItemInGame
                                .Where(c => c.Quality == BaseStatItem.quality.common && c.Itemtype == BaseItem.ItemTypes.Trinket)
                                .Count();
                    result = ctx.AllItemInGame
                                .Where(c => c.Quality == BaseStatItem.quality.common && c.Itemtype == BaseItem.ItemTypes.Trinket)
                                .ToList()[ctx.Rnd.Next(nbMatchItem)];
                    break;
            }

            return result;
        }

        public void Generate(Map map)
        {
            float monsterPercentage = 60f / 100f;
            float chestPercentage = 20f / 100f;
            float trapPercentage = 10f / 100f;
            //float noEventPercentage = 10 / 100;

            int monsterNb = (int)((float)map.Rooms.Count * monsterPercentage);
            int chestNb = ( int ) ( ( float ) map.Rooms.Count * chestPercentage );
            int trapNb = ( int ) ( ( float ) map.Rooms.Count * trapPercentage );
            //int noEventNb = ( int ) ( ( float ) map.Rooms.Count * noEventPercentage );

            for (int i = 1; i < monsterNb; i++ )
            {
                map.Rooms[ i ].events.Add( "Combat" );
            }
            for ( int j = 0; j < chestNb; j++)
            {
                map.Rooms[ monsterNb + j ].events.Add( "Chest" );
                map.Rooms[ monsterNb + j ].chest.Add( FillChest( map.Ctx) );
            }
            for ( int k = 0; k < trapNb; k++ )
            {
                map.Rooms[ monsterNb + chestNb + k ].events.Add( "Trap" );
            }

            /*
            foreach (Room r in map.Rooms)
            {
                AttachEvent( r );
                if(r.events.Contains("Chest"))
                {
                    r.chest.Add( FillChest( ) );
                }
            }
            */
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
