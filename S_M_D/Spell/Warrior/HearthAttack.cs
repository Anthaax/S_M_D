﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;

namespace S_M_D.Spell
{
    [Serializable]
    public class HearthAttack : Spells
    {
        float[] _damageRatioByLvl = new float[4] { 1.5f, 2f, 2.5f, 3f };
        int[] _poisonValueByLvl = new int[4] { 3, 6, 9, 12 };
        readonly Warrior _warrior;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="warrior"></param>
        public HearthAttack( Warrior warrior )
            : base( "HearthAttack", 400, "Inflige un assaut sur le coeur de l'ennemi et le fait saigner", 5, 0, true, true)
        {
            _warrior = warrior;
            CooldownManager = new CooldownManager( 2 );
            TargetManager = new TargetManager( 1, new bool[4] { true, true, false, false }, new bool[4] { true, true, false, false } );
            KindOfEffect = new KindOfEffect( warrior.EffectivDamage, DamageTypeEnum.Bleeding, _poisonValueByLvl[0], 4, _damageRatioByLvl[Lvl] );
        }

        public override void UpdateSpell()
        {
            KindOfEffect.Damage = Convert.ToInt32(Warrior.EffectivDamage * _damageRatioByLvl[Lvl]);
            KindOfEffect.DamagePerTurn = Convert.ToInt32( _poisonValueByLvl[Lvl] );
        }

        public override KindOfEffect OnLaunchSpell()
        {
            return new KindOfEffect( Warrior.EffectivDamage, DamageTypeEnum.Bleeding, _poisonValueByLvl[Lvl], 4, _damageRatioByLvl[Lvl] );
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