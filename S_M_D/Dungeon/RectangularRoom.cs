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

            this.events = new List<string>( );

            this.chest = new List<Character.BaseItem>( );
        }

        public RectangularRoom( List<Point> pts )
        {
            this.Path = new List<Point>( pts );
            this.IsCorridor = false;
            this.Neighbor = new List<MapItem>( );

            this.events = new List<string>( );

            this.chest = new List<Character.BaseItem>( );
        }

        public override bool Init( int roomWidth, int roomHeight )
        {
            Path.Clear( );

            Random rand = new Random( );

            width = rand.Next( 4, 8 );
            height = rand.Next( 4, 8 );

            Point begin = new Point( rand.Next(0, roomWidth - width ), rand.Next(0, roomHeight-height) );

            Point p1 = new Point( begin.X + width, begin.Y );
            Point p2 = new Point( begin.X + width, begin.Y + height );
            Point p3 = new Point( begin.X, begin.Y + height );

            Path.Add( begin );
            Path.Add( p1 );
            Path.Add( p2 );
            Path.Add( p3 );

            this.Center = new Point( begin.X + width / 2, begin.Y + height / 2 );

            return true;
        }

        public override string ToString( )
        {
            string s = "RectangularRoom" + '\n' + Center.X.ToString() + " " + Center.Y.ToString() + '\n';
            for ( int i = 0; i < Path.Count; i++ )
            {
                s += Path[ i ].X.ToString( ) + ' ' + Path[ i ].Y.ToString( ) + '\n';
            }
            return s;
        }

    }
}
