using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;

namespace S_M_D.Spell
{
    public class HeartPurification : Spells
    {
        int[] _healRatioByLvl = new int[4] { 3, 5, 7, 9 };
        readonly Priest _priset;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="priest"></param>
        public HeartPurification( Priest priest)
            : base( "HeartPurification", 400, "Purifie le couer de votre allié", 5, 0, true, true)
        {
            _priset = priest;
            CooldownManager = new CooldownManager( 1 );
            TargetManager = new TargetManager( 1, new bool[4] { true, true, true, true }, new bool[4] { true, true, true, true } );
            KindOfEffect = new KindOfEffect( priest.EffectivDamage, DamageTypeEnum.Heal, 0, 0, _healRatioByLvl[Lvl] );

        }
        public override void  UpdateSpell()
        {
            KindOfEffect.Damage = Convert.ToInt32( Priest.EffectivDamage * _healRatioByLvl[Lvl] );
        }

        public override KindOfEffect OnLaunchSpell()
        {
            return new KindOfEffect( Priest.EffectivDamage, DamageTypeEnum.Heal, 0, 0, _healRatioByLvl[Lvl] );
        }

        public Priest Priest
        {
            get
            {
                return _priset;
            }
        }

    }
}
