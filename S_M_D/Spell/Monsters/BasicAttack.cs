using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;

namespace S_M_D.Spell
{
    [Serializable]
    public class BasicAttack : Spells
    {
        readonly BaseMonster _monster;
        float _rate;
        public BasicAttack(BaseMonster monster)
            :base("BasicAttack", 0, "BasicAttackMonster", 0, 0, true, true)
        {
            _monster = monster;
            _rate = (10+Monster.Lvl) / 10;
            CooldownManager = new CooldownManager( 1 );
            TargetManager = new TargetManager( 1, new bool[4] { true, true, false, false }, new bool[4] { true, true, true, true } );
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
