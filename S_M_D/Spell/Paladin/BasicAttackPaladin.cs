using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;


namespace S_M_D.Spell
{
    public class BasicAttackPaladin : Spells
    {
        readonly Paladin _paladin;

        int[] _damageRatioByLvl = new int[4] { 1, 2, 3, 4 };
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paladin"></param>
        public BasicAttackPaladin(Paladin paladin)
            :base("BasicAttack", 400, "Attaque basique du paladin", 0, 0, true, true)
        {
            _paladin = paladin;
            CooldownManager = new CooldownManager( 1 );
            TargetManager = new TargetManager( 1, new bool[4] { true, true, false, false }, new bool[4] { true, true, false, false } );
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
