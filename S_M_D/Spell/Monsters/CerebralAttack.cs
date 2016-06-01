using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Spell.Monsters
{
    public class CerebralAttack : Spells
    {
        readonly BaseMonster _monster;
        float _rate;
        public CerebralAttack( BaseMonster monster )
            : base( "BasicAttack", 0, "BasicAttackMonster", 0, 0, true, true )
        {
            _monster = monster;
            _rate = Lvl / 10;
            CooldownManager = new CooldownManager( 1 );
            TargetManager = new TargetManager( 1, new bool[4] { false, false, true, true }, new bool[4] { true, true, true, true } );
            KindOfEffect = new KindOfEffect( Monster.EffectivDamage, DamageTypeEnum.Physical, 0, 0, _rate );
        }

        public BaseMonster Monster
        {
            get
            {
                return _monster;
            }
        }

        public override KindOfEffect OnLaunchSpell()
        {
            return new KindOfEffect( _monster.EffectivDamage, DamageTypeEnum.Physical, 0, 0, _rate );
        }

        public override void UpdateSpell()
        {

        }
    }
}
