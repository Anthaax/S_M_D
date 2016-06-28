using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;


namespace S_M_D.Spell
{
    [Serializable]
    public class DivineStorm : Spells
    {
        readonly Paladin _paladin;

        float[] _damageRatioByLvl = new float[4] { 1.5f, 3, 4.5f, 6 };
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paladin"></param>
        public DivineStorm( Paladin paladin)
            :base( "DivineStorm", 800, "Une tempete divine", 5, 0, false, false)
        {
            _paladin = paladin;
            CooldownManager = new CooldownManager( 1 );
            TargetManager = new TargetManager( 1, new bool[4] { false, true, true, false }, new bool[4] { true, true, true, false } );
            KindOfEffect = new KindOfEffect( Paladin.EffectivDamage, DamageTypeEnum.Physical, 0, 0, _damageRatioByLvl[Lvl] );
        }

        public override void UpdateSpell()
        {
            KindOfEffect.Damage = Convert.ToInt32( Paladin.EffectivDamage * _damageRatioByLvl[Lvl] );
        }

        public override KindOfEffect OnLaunchSpell()
        {
            return new KindOfEffect( Paladin.EffectivDamage, DamageTypeEnum.Physical, 0, 0, _damageRatioByLvl[Lvl] );
        }

        public Paladin Paladin
        {
            get
            {
                return _paladin;
            }
        }

    }
}
