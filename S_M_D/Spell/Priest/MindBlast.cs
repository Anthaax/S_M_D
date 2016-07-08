using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;


namespace S_M_D.Spell
{
    [Serializable]
    public class MindBlast : Spells
    {
        readonly Priest _priest;
        int[] _damageRatioByLvl = new int[4] { 1, 2, 3, 4 };
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paladin"></param>
        public MindBlast( Priest priest)
            : base( "MindBlast", 800, "Controle l'esprit du monstre pour le faire souffrir", 10, 0, false, false)
        {
            _priest = priest;
            CooldownManager = new CooldownManager( 1 );
            TargetManager = new TargetManager( 1, new bool[4] { true, true, false, false }, new bool[4] { true, true, false, false } );
            KindOfEffect = new KindOfEffect( Priest.EffectivDamage, DamageTypeEnum.Physical, 0, 0, _damageRatioByLvl[Lvl] );
        }

        public override void UpdateSpell()
        {
            KindOfEffect.Damage = Convert.ToInt32( Priest.EffectivDamage * _damageRatioByLvl[Lvl] );
        }

        public override KindOfEffect OnLaunchSpell()
        {
            return new KindOfEffect( Priest.EffectivDamage, DamageTypeEnum.Physical, 0, 0, _damageRatioByLvl[Lvl] );
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