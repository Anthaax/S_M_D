using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;

namespace S_M_D.Spell
{
    [Serializable]
    public class Tourbillon : Spells
    {
        readonly Warrior _warrior;
        int[] _damageRatioByLvl = new int[4] { 2, 3, 4, 5 };

        public Tourbillon( Warrior warrior )
            :base( "Tourbillon", 500, "Attaque avancé du warrior", 1, 0, false, false)
        {
            _warrior = warrior;
            CooldownManager = new CooldownManager( 1 );
            TargetManager = new TargetManager( 1, new bool[4] { true, true, false, false }, new bool[4] { true, true, false, false } );
            KindOfEffect = new KindOfEffect( warrior.EffectivDamage, DamageTypeEnum.Physical, 0, 0, _damageRatioByLvl[Lvl] );
        }

        public override void UpdateSpell()
        {
            KindOfEffect.Damage = Convert.ToInt32( Warrior.EffectivDamage * _damageRatioByLvl[Lvl] );
        }

        public override KindOfEffect OnLaunchSpell()
        {
            return new KindOfEffect( Warrior.EffectivDamage, DamageTypeEnum.Physical, 0, 0, _damageRatioByLvl[Lvl] );
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
