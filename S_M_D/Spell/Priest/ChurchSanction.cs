using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;

namespace S_M_D.Spell
{
    public class ChurchSanction : Spells
    {
        float[] _damageRatioByLvl = new float[4] { 1.5f, 2f, 2.5f, 3f };
        int[] _poisonValueByLvl = new int[4] { 3, 6, 9, 12 };
        readonly Priest _priest;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="priest"></param>
        public ChurchSanction( Priest priest)
            : base( "JusticeHammer", 400, "Inflige un terrible poison venu de l'église", 10, 0, true, true)
        {
            _priest = priest;
            CooldownManager = new CooldownManager( 2 );
            TargetManager = new TargetManager( 1, new bool[4] { false, false, true, true }, new bool[4] { false, false, true, true } );
            KindOfEffect = new KindOfEffect( priest.EffectivDamage, DamageTypeEnum.Poison, _poisonValueByLvl[0], 3, _damageRatioByLvl[Lvl] );
        }

        public override void UpdateSpell()
        {
            KindOfEffect.Damage = Convert.ToInt32(Priest.EffectivDamage * _damageRatioByLvl[Lvl]);
            KindOfEffect.DamagePerTurn = Convert.ToInt32( _poisonValueByLvl[Lvl] );
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