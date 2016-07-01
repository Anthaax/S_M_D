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
            _cbt.SpellManager.ApplyDamageOnTime();
            MonsterAlreadyAttack( monster );
            if (_cbt.GameContext.Rnd.Next( 4 ) != 0)
                LaunchSpell( monster );
            else
                MoveHero();
            return _cbt.NextTurn();
        }
        public List<Spells> SpellsToLaunch( BaseMonster monster )
        {
            List<Spells> canLauncSpell = monster.Spells
                                    .Where( c =>
                                              c.TargetManager.WhoCanBeTargetable( monster.Position ) != new bool[4] { false, false, false, false } &&
                                              c.CooldownManager.IsOnCooldown == false &&
                                              c.ManaCost <= monster.Mana
                                            )
                                   .ToList();
            return canLauncSpell;
        }
        public int[] GetPositionsHeros()
        {
            int[] tableau = new int[2];
            tableau[0] = _cbt.GameContext.Rnd.Next( 4 );
            tableau[1] = _cbt.GameContext.Rnd.Next( 4 );
            while (tableau[1] == tableau[0] || _cbt.Heros[tableau[1]].IsDead)
            {
                tableau[1] = _cbt.GameContext.Rnd.Next( 4 );
            }
            return tableau;
        }
        public void LauchSpell(Spells spell, int position)
        {
            _cbt.SpellManager.MonsterLaunchSpell( spell, position );
        }
        public void MonsterTurn(BaseMonster monster)
        {
            if (_mosterAction.Count == 4)
                _mosterAction.Clear();
        }
        private void LaunchSpell(BaseMonster monster)
        {
            List<Spells> canLauncSpell = monster.Spells
                                    .Where  ( c =>
                                                c.TargetManager.WhoCanBeTargetable( monster.Position ) != new bool[4] { false, false, false, false } &&
                                                c.CooldownManager.IsOnCooldown == false &&
                                                c.ManaCost <= monster.Mana
                                            )
                                   .ToList();
            if (canLauncSpell.Count > 0)
            {
                Spells spellToLaunch = canLauncSpell[_cbt.GameContext.Rnd.Next( canLauncSpell.Count )];
                int position = SelectHero();
                _cbt.SpellManager.MonsterLaunchSpell( spellToLaunch, position );
                MosterAction.Add( spellToLaunch, position );
            }
            else
            {
                MoveHero();
            }

        }
        private void MoveHero()
        {
            int first = _cbt.GameContext.Rnd.Next( 4 );
            int second = _cbt.GameContext.Rnd.Next( 4 );
            while (second == first || _cbt.Heros[second].IsDead)
            {
                second = _cbt.GameContext.Rnd.Next( 4 );
            }
            _cbt.SpellManager.MoveCharacter<BaseHeros>( first, second );
        }
        private void MonsterAlreadyAttack(BaseMonster monster)
        {
            foreach (var spell in monster.Spells)
            {
                if (_mosterAction.ContainsKey( spell ))
                    _mosterAction.Remove( spell );
            }
        }
        private int SelectHero()
        {
            int position = _cbt.GameContext.Rnd.Next( _cbt.Heros.Count() );
            while (_cbt.Heros[position].IsDead)
            {
                position = _cbt.GameContext.Rnd.Next( _cbt.Heros.Count() );
            }
            return position;
        }
    }
}
