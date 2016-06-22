using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;

namespace S_M_D.Spell
{
    [Serializable]
    public class Hydrobast : Spells
    {
        int[] _waterDamage = new int[4] { 2, 4, 8, 10 };
        float[] _damageRatioByLvl = new float[4] { 2.5f, 5, 7.5f, 9 };
        readonly Mage _mage;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paladin"></param>
        public Hydrobast( Mage mage)
            : base( "Hydrobast", 600, "Attaque ultime eau", 10, 0, false, false)
        {
            _mage = mage;
            CooldownManager = new CooldownManager( 2 );
            TargetManager = new TargetManager( 1, new bool[4] { false, false, true, true }, new bool[4] { false, true, true, true } );
            KindOfEffect = new KindOfEffect( mage.EffectivDamage, DamageTypeEnum.Fire, _waterDamage[0], 2, _damageRatioByLvl[Lvl] );

        }
        public override void  UpdateSpell()
        {
            KindOfEffect.Damage = Convert.ToInt32( Mage.EffectivDamage * _damageRatioByLvl[Lvl] );
            KindOfEffect.DamagePerTurn = Convert.ToInt32( _waterDamage[Lvl] );
        }

        public override KindOfEffect OnLaunchSpell()
        {
            return new KindOfEffect( Mage.EffectivDamage, DamageTypeEnum.Fire, WaterDamage[Lvl], 2, _damageRatioByLvl[Lvl] );

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
