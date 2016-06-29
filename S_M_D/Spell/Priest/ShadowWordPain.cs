using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Spell
{
    [Serializable]
    public class ShadowWordPain : Spells
    {
        Priest _priest;
        float[] _damageRatioByLvl = new float[4] { 6, 12f, 18f, 24f };

        public ShadowWordPain( Priest priest )
            : base( "ShadowWordPain", 1000, "Mot diabolique qui fait souffrir les ennemis", 10, 0, false, false)
        {
            _priest = priest;
            CooldownManager = new CooldownManager( 1 );
            TargetManager = new TargetManager( 1, new bool[4] { false, false, true, true }, new bool[4] { true, true, false, false } );
            KindOfEffect = new KindOfEffect( priest.EffectivDamage, DamageTypeEnum.Magical, 0, 0, _damageRatioByLvl[Lvl] );
        }

        public override void UpdateSpell()
        {
            KindOfEffect.Damage = Convert.ToInt32( Priest.EffectivDamage * _damageRatioByLvl[Lvl] );
        }

        public override KindOfEffect OnLaunchSpell()
        {
            return new KindOfEffect( Priest.EffectivDamage, DamageTypeEnum.Magical, 0, 0, _damageRatioByLvl[Lvl] );
        }

        public Priest Priest
        {
            get
            {
                return _priest;
            }
        }
    }
}
