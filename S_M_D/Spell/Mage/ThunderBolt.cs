using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;


namespace S_M_D.Spell
{
    [Serializable]
    public class ThunderBolt : Spells
    {
        readonly Mage _mage;
        float[] _damageRatioByLvl = new float[4] { 1.25f, 1.75f, 2.5f, 3f };
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paladin"></param>
        public ThunderBolt( Mage mage)
            : base( "ThunderBolt", 500, "Eclair s'abattant sur un ennemi", 0, 0, false, false)
        {
            
            _mage = mage;
            CooldownManager = new CooldownManager( 2 );
            TargetManager = new TargetManager( 1, new bool[4] { false, true, true, false }, new bool[4] { false, true, true, false } );
            KindOfEffect = new KindOfEffect( mage.EffectivDamage, DamageTypeEnum.Magical, 0, 0, _damageRatioByLvl[Lvl] );
        }

        public override void UpdateSpell()
        {
            KindOfEffect.Damage = Convert.ToInt32(_mage.EffectivDamage * _damageRatioByLvl[Lvl]);
        }

        public override KindOfEffect OnLaunchSpell()
        {
            return KindOfEffect = new KindOfEffect( Mage.EffectivDamage, DamageTypeEnum.Physical, 0, 0, _damageRatioByLvl[Lvl] );
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