using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Spell
{
    [Serializable]
    public class Toxic : Spells
    {
        Mage _mage;
        int[] _poisonValueByLvl = new int[4] { 5, 10, 15, 20 };
        float[] _damageRatioByLvl = new float[4] { 1.5f, 2.5f, 3.5f, 5f };

        public Toxic( Mage mage )
            : base( "Toxic", 1000, "Empoisone violament l'ennemi", 12, 0, false, false)
        {

            _mage = mage;
            CooldownManager = new CooldownManager( 1 );
            TargetManager = new TargetManager( 1, new bool[4] { false, false, true, true }, new bool[4] { false, true, true, true } );
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
