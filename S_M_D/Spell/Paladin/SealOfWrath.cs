using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;

namespace S_M_D.Spell
{
    [Serializable]
    public class SealOfWrath : Spells
    {
        int[] _healPerTurn = new int[4] { 2, 4, 8, 10 };
        int[] _healRatioByLvl = new int[4] { 3, 5, 7, 9 };
        readonly Paladin _paladin;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paladin"></param>
        public SealOfWrath( Paladin paladin)
            : base( "SealOfWrath", 900, "Invoque la colere des dieux pour combatre les ténebres", 10, 0, false, false)
        {
            _paladin = paladin;
            CooldownManager = new CooldownManager( 2 );
            TargetManager = new TargetManager( 1, new bool[4] { true, true, true, true }, new bool[4] { true, true, true, true } );
            KindOfEffect = new KindOfEffect( paladin.EffectivDamage, DamageTypeEnum.Fire, _healPerTurn[0], 2, _healRatioByLvl[Lvl] );

        }
        public override void  UpdateSpell()
        {
            KindOfEffect.Damage = Convert.ToInt32( Paladin.EffectivDamage * _healRatioByLvl[Lvl] );
            KindOfEffect.DamagePerTurn = Convert.ToInt32( _healPerTurn[Lvl] );
        }

        public override KindOfEffect OnLaunchSpell()
        {
            return new KindOfEffect( Paladin.EffectivDamage, DamageTypeEnum.Heal, _healPerTurn[Lvl], 2, _healRatioByLvl[Lvl] );
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
