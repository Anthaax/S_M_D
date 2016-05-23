using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Dungeon
{
    public class RectangularRoom : PolygonRoom
    {

        public int width { get; set; }
        public int height { get; set; }

        public RectangularRoom()
        {
            this.Path = new List<Point>( );
            this.IsCorridor = false;
            this.Neighbor = new List<MapItem>( );
        }


        public override bool Init( int roomWidth, int roomHeight )
        {
            path.Clear( );

            Random rand = new Random( );

            width = rand.Next( 4, 8 );
            height = rand.Next( 4, 8 );

            Point begin = new Point( rand.Next(0, roomWidth - width ), rand.Next(0, roomHeight-height) );

            Point p1 = new Point( begin.X + width, begin.Y );
            Point p2 = new Point( begin.X + width, begin.Y + height );
            Point p3 = new Point( begin.X, begin.Y + height );

            path.Add( begin );
            path.Add( p1 );
            path.Add( p2 );
            path.Add( p3 );

            this.center = new Point( begin.X + width / 2, begin.Y + height / 2 );

            return true;
        }

    }
}
