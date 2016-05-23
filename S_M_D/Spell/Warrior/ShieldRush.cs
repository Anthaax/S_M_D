using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Spell
{
    class ShieldRush : Spells
    {
        readonly Warrior _warrior;
        float[] _damageRatioByLvl = new float[4] { 1.2f, 1.5f, 1.8f, 2.1f };

        public ShieldRush(Warrior warrior)
            :base("ShieldRush", 400, "Donne un coup de bouclier", 0, 0, true, true)
        {
            _warrior = warrior;
            CooldownManager = new CooldownManager( 1 );
            TargetManager = new TargetManager( 1, new bool[4] { true, true, false, false }, new bool[4] { true, true, false, false });
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
