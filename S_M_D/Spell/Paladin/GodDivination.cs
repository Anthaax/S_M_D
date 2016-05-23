using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Spell
{
    public class GodDivination : Spells
    {
        Paladin _paladin;
        float[] _damageRatioByLvl = new float[4] { 6, 12f, 18f, 24f };

        public GodDivination( Paladin paladin )
            : base( "GodDivination", 1000, "Invoque la puissance divine pour sanctionner la fraude", 15, 0, true, true)
        {

            _paladin = paladin;
            CooldownManager = new CooldownManager( 3 );
            TargetManager = new TargetManager( 2, new bool[4] { false, false, true, true }, new bool[4] { false, true, true, true } );
            KindOfEffect = new KindOfEffect( paladin.EffectivDamage, DamageTypeEnum.Magical, 0, 0, _damageRatioByLvl[Lvl] );
        }

        public override void UpdateSpell()
        {
            KindOfEffect.Damage = Convert.ToInt32( Paladin.EffectivDamage * _damageRatioByLvl[Lvl] );
        }

        public override KindOfEffect OnLaunchSpell()
        {
            return new KindOfEffect( Paladin.EffectivDamage, DamageTypeEnum.Magical, 0, 0, _damageRatioByLvl[Lvl] );
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
