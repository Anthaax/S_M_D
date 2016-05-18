using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Spell;
using S_M_D.Character;

namespace S_M_D.Battle
{
    public class BattleManager
    {
        GameContext _ctx;
        public BattleManager(GameContext ctx)
        {
            _ctx = ctx;
        }

        public void LaunchSpell(BaseHeros hero, BaseMonster target, Spells spell)
        {
            
        }
        public void LaunchSpell( BaseHeros hero, BaseMonster target, BaseMonster target2, Spells spell )
        {

        }
    }
}
