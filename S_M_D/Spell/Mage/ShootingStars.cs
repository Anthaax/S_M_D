using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;

namespace S_M_D.Spell
{
    [Serializable]
    public class ShootingStars : Spells
    {
        float[] _damageRatioByLvl = new float[4] { 3, 4.5f, 6f, 7.5f };
        readonly Mage _mage;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paladin"></param>
        public ShootingStars( Mage mage)
            : base( "Shooting-Star", 600, "Une pluie d'étoiles filantes", 5, 0, false, false)
        {
            _mage = mage;
            CooldownManager = new CooldownManager( 1 );
            TargetManager = new TargetManager( 1, new bool[4] { false, false, true, true }, new bool[4] { false, true, true, true } );
            KindOfEffect = new KindOfEffect( mage.EffectivDamage, DamageTypeEnum.Physical, 0, 0, _damageRatioByLvl[Lvl] );
        }

        public override void UpdateSpell()
        {
            KindOfEffect.Damage = Convert.ToInt32(Mage.EffectivDamage * _damageRatioByLvl[Lvl]);

        }

        public override KindOfEffect OnLaunchSpell()
        {
            return new KindOfEffect( Mage.EffectivDamage, DamageTypeEnum.Fire, 0, 0, _damageRatioByLvl[Lvl] );
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