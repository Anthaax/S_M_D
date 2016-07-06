using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Spell
{
    [Serializable]
    public class FlameThrower : Spells
    {
        readonly BaseMonster _monster;
        float _rate;
        public FlameThrower( BaseMonster monster ) 
            : base( "FlameThrower", 0, "FlameThrower", 0, 0, true, true )
        {
            _monster = monster;
            _rate = (20 + Lvl) / 10;
            CooldownManager = new CooldownManager( 1 );
            TargetManager = new TargetManager( 1, new bool[4] { true, true, true, true }, new bool[4] { true, true, true, true } );
            KindOfEffect = new KindOfEffect( monster.EffectivDamage, DamageTypeEnum.Poison, Lvl+2, 3, _rate );
        }

        public override KindOfEffect OnLaunchSpell()
        {
            return KindOfEffect = new KindOfEffect( _monster.EffectivDamage, DamageTypeEnum.Poison, Lvl + 2, 3, _rate );
        }

        public override void UpdateSpell()
        {
        }
    }
}
