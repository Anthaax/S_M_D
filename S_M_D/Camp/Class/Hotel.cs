using S_M_D.Camp.ClassConfig;
using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.Class
{
    public class Hotel : BaseBuilding, ILevelUP
    {
        private BaseHeros _hero1;
        private BaseHeros _hero2;
        int _actionPrice;

        public Hotel(HotelConfig b) : base(b)
        {
            _hero1 = b.Hero1;
            _hero2 = b.Hero2;
            _actionPrice = b.ActionPrice;
        }
        public void SetHeros( BaseHeros hero1, BaseHeros hero2 )
        {
            _hero1 = hero1;
            _hero2 = hero2;
        }
        public void DeleteHeros()
        {
            _hero1 = null;
            _hero2 = null;
        }
        public void CreateRelationHeroHero()
        {
            if (_hero1 == null && _hero2 == null) throw new ArgumentException( "You need an hero" );
            foreach (Relationship relations in _hero1.Relationship)
            {
                if (_hero1 == relations.HeroDuo[0] && _hero2 == relations.HeroDuo[1]) throw new ArgumentException( "dude, they cant have two relation at the same time" );
                if (_hero1 == relations.HeroDuo[1] && _hero2 == relations.HeroDuo[0]) throw new ArgumentException( "dude, they cant have two relation at the same time" );
            }
            if (Ctx.MoneyManager.CanBuy( _actionPrice )) Ctx.MoneyManager.Buy( _actionPrice );
            else throw new ArgumentException( "You Can't buy this thing" );
            Array relationArray = Enum.GetValues( typeof( RelationEnum ) );
            RelationEnum relation = (RelationEnum)relationArray.GetValue( Ctx.Rnd.Next( relationArray.Length ) );
            switch (relation)
            {
                case RelationEnum.Desir:
                    Desir desir = new Desir( _hero1, _hero2 );
                    desir.Effect( _hero1 );
                    desir.Effect( _hero2 );
                    break;
                case RelationEnum.Friendship:
                    Friendship friend = new Friendship( _hero1, _hero2 );
                    friend.Effect( _hero1 );
                    friend.Effect( _hero2 );
                    break;
                case RelationEnum.Hate:
                    Hate hate = new Hate( _hero1, _hero2 );
                    hate.Effect( _hero1 );
                    hate.Effect( _hero2 );
                    break;
                case RelationEnum.Love:
                    Love love = new Love( _hero1, _hero2 );
                    love.Effect( _hero1 );
                    love.Effect( _hero2 );
                    break;
                default:
                    break;
            }
        }

        public void LevelUP()
        {
            Level++;
            _actionPrice = ActionPrice / Level;
        }
        public int ActionPrice
        {
            get
            {
                return _actionPrice;
            }
        }

        public BaseHeros Hero2
        {
            get
            {
                return _hero2;
            }
        }

        public BaseHeros Hero1
        {
            get
            {
                return _hero1;
            }
        }
    }
}
