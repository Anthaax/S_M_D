using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;

namespace S_M_D.Spell
{
    [Serializable]
    public class VampireTouch : Spells
    {
        int[] _healRatioByLvl = new int[4] { 3, 5, 7, 9 };
        int[] _poisonDamage = new int[4] { 3, 5, 7, 9 };
        readonly Priest _priset;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="priest"></param>
        public VampireTouch( Priest priest)
            : base( "VampireTouch", 400, "Touché vampirique", 5, 0, false, false)
        {
            _priset = priest;
            CooldownManager = new CooldownManager( 1 );
            TargetManager = new TargetManager( 1, new bool[4] { true, true, true, true }, new bool[4] { true, true, true, true } );
            KindOfEffect = new KindOfEffect( priest.EffectivDamage, DamageTypeEnum.Poison, _poisonDamage[0], 0, _healRatioByLvl[Lvl] );

        }
        public override void  UpdateSpell()
        {
            KindOfEffect.Damage = Convert.ToInt32( Priest.EffectivDamage * _healRatioByLvl[Lvl] );
            KindOfEffect.DamagePerTurn = _poisonDamage[Lvl];
        }

        public override KindOfEffect OnLaunchSpell()
        {
            return new KindOfEffect( Priest.EffectivDamage, DamageTypeEnum.Poison, _poisonDamage[Lvl], 0, _healRatioByLvl[Lvl] );
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
