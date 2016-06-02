using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Spell
{
    [Serializable]
    public class CockStorm : Spells
    {
        Mage _mage;
        int[] _poisonValueByLvl = new int[4] { 3, 6, 9, 12 };
        float[] _damageRatioByLvl = new float[4] { 4, 6f, 8f, 10f };

        public CockStorm( Mage mage )
            : base( "CockStorm", 1000, "Une tempête de bite", 20, 0, true, true)
        {

            _mage = mage;
            CooldownManager = new CooldownManager( 3 );
            TargetManager = new TargetManager( 3, new bool[4] { false, false, true, true }, new bool[4] { false, true, true, true } );
            KindOfEffect = new KindOfEffect( mage.EffectivDamage, DamageTypeEnum.Poison, _poisonValueByLvl[0], 3, _damageRatioByLvl[Lvl] );
        }

        public override void UpdateSpell()
        {
            KindOfEffect.Damage = Convert.ToInt32( Mage.EffectivDamage * _damageRatioByLvl[Lvl] );
            KindOfEffect.DamagePerTurn = Convert.ToInt32( _poisonValueByLvl[Lvl] );

        }

        public override KindOfEffect OnLaunchSpell()
        {
            return new KindOfEffect( Mage.EffectivDamage, DamageTypeEnum.Poison, _poisonValueByLvl[Lvl], 3, _damageRatioByLvl[Lvl] );
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
