using S_M_D.Camp.ClassConfig;
using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.Class
{
    public class Bar : BaseBuilding
    {
        private BaseHeros _hero1;
        private BaseHeros _hero2;
        GameContext _ctx;
        public Bar(BarConfig b) : base(b)
        {
            _hero1 = b.Hero1;
            _hero2 = b.Hero2;
            _ctx = b.Ctx;
        }
        public void setHeros1(BaseHeros hero1)
        {
            _hero1 = hero1;
            _hero1.InBuilding = this;
        }
        public void setHeros2(BaseHeros hero2)
        {
            _hero1 = hero2;
            _hero1.InBuilding = this;
        }
        public void deleteHeros()
        {
            _hero1 = null;
            _hero2 = null;
        }
        public void CreateRelationHero()
        {
            RelationEnum relation =  (RelationEnum)_ctx.Rnd.Next(1, 5);
            switch (relation)
            {
                case RelationEnum.Desir:
                    Desir desir = new Desir(_hero1, _hero2);
                    desir.Effect(_hero1);
                    desir.Effect( _hero2 );
                    break;
                case RelationEnum.Friendship:
                    Friendship friend = new Friendship(_hero1, _hero2);
                    friend.Effect(_hero1);
                    friend.Effect( _hero2 );
                    break;
                case RelationEnum.Hate:
                    Hate hate = new Hate(_hero1, _hero2);
                    hate.Effect(_hero1);
                    hate.Effect( _hero2 );
                    break;
                case RelationEnum.Love:
                    Love love = new Love(_hero1, _hero2);
                    love.Effect(_hero1);
                    love.Effect( _hero2 );
                    break;
                default:
                    break;
            }
        }
        public BaseHeros Hero1
        {
            get
            {
                return _hero1;
            }
        }

        public BaseHeros Hero2
        {
            get
            {
                return _hero2;
            }
        }
    }
}
