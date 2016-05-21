using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;

namespace S_M_D.Spell
{
    public class FireBall : Spells
    {
        int[] _fireValueByLvl = new int[4] { 2, 4, 8, 10 };
        int[] _damageRatioByLvl = new int[4] { 2, 3, 4, 5 };
        readonly Mage _mage;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paladin"></param>
        public FireBall(Mage mage)
            : base("FireBall", 400, "Boule de feu", 5, 0, true, false)
        {
            _mage = mage;
            CooldownManager = new CooldownManager( 1 );
            TargetManager = new TargetManager( 1, new bool[4] { true, false, true, true }, new bool[4] { false, true, true, true } );
            KindOfEffect = new KindOfEffect( mage.EffectivDamage, DamageTypeEnum.Fire, _fireValueByLvl[0], 2, _damageRatioByLvl[Lvl] );

        }
        public override void  UpdateSpell()
        {
            KindOfEffect.Damage = Convert.ToInt32( Mage.EffectivDamage * _damageRatioByLvl[Lvl] );
            KindOfEffect.DamagePerTurn = Convert.ToInt32( _fireValueByLvl[Lvl] );
        }

        public override KindOfEffect OnLaunchSpell()
        {
            return new KindOfEffect( Mage.EffectivDamage, DamageTypeEnum.Fire, _fireValueByLvl[Lvl], 2, _damageRatioByLvl[Lvl] );

        }

        public Mage Mage
        {
            get
            {
                return _mage;
            }
        }

    }
}
