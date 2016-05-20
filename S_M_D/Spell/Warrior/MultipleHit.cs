using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;

namespace S_M_D.Spell
{
    public class MultipleHit : Spells
    {
        float[] _damageRatioByLvl = new float[4] { 2.5f, 5f, 7.5f, 10f };
        readonly Warrior _warrior;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="warrior"></param>
        public MultipleHit( Warrior warrior)
            : base( "MultipleHit", 400, "Frappe avec le marteau de la justice", 5, 0, true, true)
        {
            _warrior = warrior;
            CooldownManager = new CooldownManager( 1 );
            TargetManager = new TargetManager( 1, new bool[4] { true, true, false, false }, new bool[4] { true, false, false, false } );
            KindOfEffect = new KindOfEffect( warrior.EffectivDamage, DamageTypeEnum.Physical, 0, 0, _damageRatioByLvl[Lvl] );
        }

        public override void UpdateSpell()
        {
            KindOfEffect.Damage = Convert.ToInt32(Warrior.EffectivDamage * _damageRatioByLvl[Lvl]);
        }
        public Warrior Warrior
        {
            get
            {
                return _warrior;
            }
        }
    }
}