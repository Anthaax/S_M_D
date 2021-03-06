﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Character;

namespace S_M_D.Spell
{
    [Serializable]
    public class GodHelp : Spells
    {
        int[] _healRatioByLvl = new int[4] { 3, 5, 7, 9 };
        readonly Paladin _paladin;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paladin"></param>
        public GodHelp( Paladin paladin)
            : base( "GodHelp", 800, "Invoque l'aide de dieux pour chatier les monstres pendant 2 tours", 5, 0, true, true)
        {
            _paladin = paladin;
            CooldownManager = new CooldownManager( 2 );
            TargetManager = new TargetManager( 1, new bool[4] { true, true, true, true }, new bool[4] { true, true, true, true } );
            KindOfEffect = new KindOfEffect( paladin.EffectivDamage, DamageTypeEnum.Physical, 0, 2, _healRatioByLvl[Lvl] );

        }
        public override void  UpdateSpell()
        {
            KindOfEffect.Damage = Convert.ToInt32( Paladin.EffectivDamage * _healRatioByLvl[Lvl] );
        }

        public override KindOfEffect OnLaunchSpell()
        {
            return new KindOfEffect( Paladin.EffectivDamage, DamageTypeEnum.Physical, 0, 2, _healRatioByLvl[Lvl] );
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
