using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;

namespace S_M_D.Spell
{
    [Serializable]
    public class ShadowWordDeath : Spells
    {
        float[] _damageRatioByLvl = new float[4] { 1.5f, 2f, 2.5f, 3f };
        readonly Priest _priest;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="priest"></param>
        public ShadowWordDeath( Priest priest)
            : base( "ShadowWordDeath", 400, "Mot diabolique qui detruit les ennemis", 20, 0, false, false)
        {
            _priest = priest;
            CooldownManager = new CooldownManager( 2 );
            TargetManager = new TargetManager( 3, new bool[4] { false, false, true, true }, new bool[4] { true, true, false, false } );
            KindOfEffect = new KindOfEffect( priest.EffectivDamage, DamageTypeEnum.Magical,0, 0, _damageRatioByLvl[Lvl] );
        }

        public override void UpdateSpell()
        {
            KindOfEffect.Damage = Convert.ToInt32(Priest.EffectivDamage * _damageRatioByLvl[Lvl]);
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