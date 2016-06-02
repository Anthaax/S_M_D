using S_M_D.Character;
using S_M_D.Character.Monsters;
using S_M_D;
using S_M_D.Spell;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;

namespace S_M_D.Combat
{
    [Serializable]
    public class CombatManager
    {
        readonly BaseMonster[] _monsters;
        readonly BaseHeros[] _heros;
        readonly List<BaseCharacter> _characterOrderAttack;
        readonly Dictionary<BaseCharacter, KindOfEffect> _damageOnTime;
        readonly SpellManager _spellManager;
        readonly GameContext _gameContext;
        readonly IAMonster _iaMonster;
        readonly Reward _reward;
        int _turn;
        public CombatManager(BaseHeros[] heros, GameContext gameContext)
        {
            _gameContext = gameContext;
            _heros = heros;
            //Initialization of monsters
            _monsters = new BaseMonster[4];
            MonsterConfiguration monsterCreation = new MonsterConfiguration();
            createMonster(monsterCreation);
            //Initialization of character order of attack
            _characterOrderAttack = new List<BaseCharacter>();
            InitializedOderAttack();

            _damageOnTime = new Dictionary<BaseCharacter, KindOfEffect>();
            InitiliazedDictionary();
            _spellManager = new SpellManager( this );
            _reward = new Reward(_monsters, _gameContext);
            _iaMonster = new IAMonster( this );
            _turn = 0;
        }
        private void createMonster(MonsterConfiguration monsterCreation)
        {
            for (int x = 0; x < 4; x++)
            {
                Monsters[x] = monsterCreation.CreateMonster((MonsterType)GameContext.Rnd.Next(1,5), Heros.Max(s => s.Lvl));
                Monsters[x].Position = x;
            }
        }

        public void InitializedOderAttack()
        {
            BaseCharacter[] allCharacter = new BaseCharacter[8];
            _heros.CopyTo( allCharacter, 0 );
            _monsters.CopyTo( allCharacter, _heros.Length );
            CharacterOrderAttack.AddRange(allCharacter.ToList());
            BaseCharacterComparer comparer = new BaseCharacterComparer();
            CharacterOrderAttack.Sort( comparer );
        }

        public void InitiliazedDictionary()
        {
            for (int i = 0; i < _heros.Length; i++)
            {
                if(_heros[i] != null)
               _damageOnTime.Add( _heros[i], null );
            }
            for (int i = 0; i < _monsters.Length; i++)
            {
                if(_monsters[i] != null)
                _damageOnTime.Add( _monsters[i], null );
            }
        }

        public BaseCharacter NextTurn()
        {
            _turn++;
            BaseCharacter b = GetCharacterTurn();
            Type bType = b.GetType();
            if (!CheckIfTheCombatWasOver())
            {
                while (typeof(BaseMonster) == bType)
                {
                    BaseMonster monster = b as BaseMonster;
                    BaseCharacter NextCharacter;
                    if (monster != null)
                    {
                        NextCharacter = _iaMonster.MonsterTurnAndDoNextTurn(monster);
                        BaseHeros hero = NextCharacter as BaseHeros;
                        if (hero != null)
                            hero.Spells.Where(c => c != null).ToList().ForEach(c => c.CooldownManager.NewTurn());
                        return NextCharacter;
                    }
                }
            }
            return b;
        }

        public bool CheckIfTheCombatWasOver()
        {
            return _heros.Where(c => c == null).Count() == 4 || _monsters.Where(c => c == null).Count() == 4;
        }

        public BaseCharacter GetCharacterTurn()
        {
            return CharacterOrderAttack[_turn % _characterOrderAttack.Count];
        }
        public void ApplyRewward()
        {
            foreach (var hero in Heros)
            {
                hero.Xp += Reward.Xp / Heros.Where( c => c.HP > 0 ).Count();
            }
            _gameContext.MoneyManager.ReciveMoney( Reward.Money );
            _gameContext.PlayerInfo.MyItems.Add( _reward.Item );
        }

        public Reward Reward
        {
            get { return _reward; }
        }

        public BaseHeros[] Heros
        {
            get { return _heros; }
        }

        public BaseMonster[] Monsters
        {
            get { return _monsters; }
        }
        public GameContext GameContext
        {
            get { return _gameContext; }
        }

        public Dictionary<BaseCharacter, KindOfEffect> DamageOnTime
        {
            get { return _damageOnTime; }
        }

        public SpellManager SpellManager
        {
            get { return _spellManager; }
        }

        public List<BaseCharacter> CharacterOrderAttack
        {
            get { return _characterOrderAttack; }
        }
    }
}
