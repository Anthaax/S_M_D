using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;

namespace S_M_D.Spell
{
    [Serializable]
    public class WrathHammer : Spells
    {
        float[] _damageRatioByLvl = new float[4] { 1.5f, 2f, 2.5f, 3f };
        readonly Paladin _paladin;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paladin"></param>
        public WrathHammer( Paladin paladin)
            : base( "WrathHammer", 500, "Courroux du marteau punissant les ennemis", 15, 0, false, false)
        {
            _paladin = paladin;
            CooldownManager = new CooldownManager( 1 );
            TargetManager = new TargetManager( 2, new bool[4] { true, true, false, false }, new bool[4] { true, true, true, false } );
            KindOfEffect = new KindOfEffect( paladin.EffectivDamage, DamageTypeEnum.Physical, 0, 0, _damageRatioByLvl[Lvl] );
        }

        public override void UpdateSpell()
        {
            KindOfEffect.Damage = Convert.ToInt32(Paladin.EffectivDamage * _damageRatioByLvl[Lvl]);
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