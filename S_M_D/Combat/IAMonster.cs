using S_M_D.Character;
using S_M_D.Spell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Combat
{
    public class IAMonster
    {
        CombatManager _cbt;
        public IAMonster(CombatManager cbt)
        {
            _cbt = cbt;
        }
        public BaseCharacter MonsterTurnAndDoNextTurn(BaseMonster monster)
        {
            List<Spells> canLauncSpell = monster.Spells
                                    .Where( c => c.TargetManager.WhoCanBeTargetable( monster.Position ) != new bool[4] { false, false, false, false } )
                                    .ToList();
            Spells spellToLaunch = canLauncSpell[_cbt.GameContext.Rnd.Next( canLauncSpell.Count )];
            int position = _cbt.GameContext.Rnd.Next( 4 );
            if (canLauncSpell.Count > 0)
                _cbt.SpellManager.MonsterLaunchSpell( spellToLaunch, position );
            return _cbt.NextTurn();
        }
    }
}
