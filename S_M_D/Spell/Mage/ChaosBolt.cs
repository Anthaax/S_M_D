using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;

namespace S_M_D.Spell
{
    [Serializable]
    public class ChaosBolt : Spells
    {
        int[] _fireValueByLvl = new int[4] { 2, 4, 8, 10 };
        float[] _damageRatioByLvl = new float[4] { 3, 4.5f, 6f, 7.5f };
        readonly Mage _mage;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paladin"></param>
        public ChaosBolt(Mage mage)
            : base("ChaosBolt", 400, "Une tempête de foudre s'abat violemment sur deux ennemis", 20, 0, true, true)
        {
            _mage = mage;
            CooldownManager = new CooldownManager( 3 );
            TargetManager = new TargetManager( 2, new bool[4] { false, false, true, true }, new bool[4] { false, true, true, true } );
            KindOfEffect = new KindOfEffect( mage.EffectivDamage, DamageTypeEnum.Fire, _fireValueByLvl[0], 3, _damageRatioByLvl[Lvl] );
        }

        public override void UpdateSpell()
        {
            KindOfEffect.Damage = Convert.ToInt32(Mage.EffectivDamage * _damageRatioByLvl[Lvl]);
            KindOfEffect.DamagePerTurn = Convert.ToInt32( _fireValueByLvl[Lvl] ); 

        }

        public override KindOfEffect OnLaunchSpell()
        {
            return new KindOfEffect( Mage.EffectivDamage, DamageTypeEnum.Fire, _fireValueByLvl[Lvl], 3, _damageRatioByLvl[Lvl] );
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