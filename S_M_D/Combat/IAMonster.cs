using S_M_D.Character;
using S_M_D.Spell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Combat
{
    [Serializable]
    public class IAMonster
    {
        readonly CombatManager _cbt;
        readonly Dictionary<Spells, int> _mosterAction;
        public IAMonster(CombatManager cbt)
        {
            _cbt = cbt;
            _mosterAction = new Dictionary<Spells, int>();
        }

        public Dictionary<Spells, int> MosterAction
        {
            get
            {
                return _mosterAction;
            }
        }
        /// <summary>
        /// Do the trun of an lauch a spell on a hero do next turn
        /// </summary>
        /// <param name="monster">Monster turn</param>
        /// <returns></returns>
        public BaseCharacter MonsterTurnAndDoNextTurn(BaseMonster monster)
        {
            if (_mosterAction.Count == 4)
                _mosterAction.Clear();
            List<Spells> canLauncSpell = monster.Spells
                                    .Where(c => c.TargetManager.WhoCanBeTargetable(monster.Position) != new bool[4] { false, false, false, false })
                                    .Where(c => c.CooldownManager.IsOnCooldown == false)
                                    .ToList();
            Spells spellToLaunch = canLauncSpell[_cbt.GameContext.Rnd.Next( canLauncSpell.Count )];
            int position = _cbt.GameContext.Rnd.Next( 4 );
            if (canLauncSpell.Count > 0)
                _cbt.SpellManager.MonsterLaunchSpell( spellToLaunch, position );
            MosterAction.Add(spellToLaunch, position);
            spellToLaunch.CooldownManager.NewTurn();
            return _cbt.NextTurn();
        }
        public void MonsterTurn(BaseMonster monster)
        {
            if (_mosterAction.Count == 4)
                _mosterAction.Clear();
            List<Spells> canLauncSpell = monster.Spells
                                    .Where(c => c.TargetManager.WhoCanBeTargetable(monster.Position) != new bool[4] { false, false, false, false })
                                    .Where(c => c.CooldownManager.IsOnCooldown == false)
                                    .ToList();
            Spells spellToLaunch = canLauncSpell[_cbt.GameContext.Rnd.Next(canLauncSpell.Count)];
            int position = _cbt.GameContext.Rnd.Next(4);
            if (canLauncSpell.Count > 0)
                _cbt.SpellManager.MonsterLaunchSpell(spellToLaunch, position);
            MosterAction.Add(spellToLaunch, position);
            spellToLaunch.CooldownManager.NewTurn();
        }
    }
}
