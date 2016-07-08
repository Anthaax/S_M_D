using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Dungeon;
using S_M_D.Character;
using S_M_D.Combat;

namespace S_M_D
{
    [Serializable]
    public class DungeonManager
    {
        readonly GameContext _ctx;
        readonly List<Map> _mapCatalogue;
        Map _curentDungeon;
        BaseHeros[] _heros;
        CombatManager _cbtManager;
        Reward _reward;
        public DungeonManager( GameContext ctx)
        {
            _ctx = ctx;
            _mapCatalogue = new List<Map>();
            _reward = new Reward( _ctx );
        }

        public GameContext Ctx
        {
            get { return _ctx; }
        }

        public Map CurentDungeon
        {
            get { return _curentDungeon; }
        }
        public BaseHeros[] Heros
        {
            get { return _heros; }
        }

        public List<Map> MapCatalogue
        {
            get
            {
                return _mapCatalogue;
            }
        }

        public CombatManager CbtManager
        {
            get
            {
                return _cbtManager;
            }
        }

        public Reward Reward
        {
            get
            {
                return _reward;
            }
        }

        public void InitializedCatalogue()
        {
            _mapCatalogue.Clear();
            _mapCatalogue.Add( new Map(Ctx) );
        }
        public void CreateDungeon(BaseHeros[] heros, Map dungeon)
        {
            _curentDungeon = dungeon;
            _heros = heros;
        }
        public void LaunchCombat()
        {
            if (_curentDungeon == null) throw new InvalidOperationException( "Impossible to launch CombatWithout a Map" );
            _cbtManager = new CombatManager( Heros, Ctx );
        }
        public void EndOfTheDuengon()
        {
            int numbersHeros = _heros.Count( h => h.IsDead == false );
            if(numbersHeros != 0 || _reward.Items.Count == 0)
            {
                _ctx.PlayerInfo.MyItems.AddRange( _reward.Items );
                _ctx.MoneyManager.ReciveMoney( _reward.Money );
            }
            _heros.Where( h => h.IsDead == false ).ToList().ForEach( h =>
                                                                     {
                                                                         h.HP = h.EffectivHPMax;
                                                                         h.Mana = h.EffectivManaMax;
                                                                         h.Xp += _reward.Xp / numbersHeros;
                                                                     }
                                                                    );
            _heros.Where( h => h.IsDead == true ).ToList().ForEach( h => h.Die() );
            ChangeHeroMind();
            _ctx.PlayerInfo.NewWeek();
            List<BaseHeros> dead = _ctx.PlayerInfo.DeadHero.Distinct( ).ToList();
            _ctx.PlayerInfo.DeadHero.Clear( );
            _ctx.PlayerInfo.DeadHero.AddRange( dead );
        }
        private void ChangeHeroMind()
        {
            BaseHeros hero = _heros[_ctx.Rnd.Next( _heros.Length )];
            while (hero.IsDead == true)
            {
                hero = _heros[_ctx.Rnd.Next( _heros.Length )];
            }
            if (_ctx.Rnd.Next()%2 == 0)
            {
                GetSickness( hero );
            }
            else
            {
                GetPsyco( hero );
            }
            
        }
        private void GetSickness(BaseHeros hero)
        {
            Array sicknessArray = Enum.GetValues( typeof( SicknessEnum ) );
            SicknessEnum sickness = (SicknessEnum)sicknessArray.GetValue( _ctx.Rnd.Next( sicknessArray.Length ) );
            switch (sickness)
            {
                case SicknessEnum.Cancer:
                    Cancer cancer = new Cancer();
                    if(hero.Sicknesses.Count(c => c.Name == cancer.Name) == 0)
                        hero.GetSickness( cancer );
                    break;
                case SicknessEnum.Diarrhea:
                    Diarrhea diarrhea = new Diarrhea();
                    if (hero.Sicknesses.Count( c => c.Name == diarrhea.Name ) == 0)
                        hero.GetSickness( diarrhea );
                    break;
                case SicknessEnum.Fever:
                    Fever fever = new Fever();
                    if (hero.Sicknesses.Count( c => c.Name == fever.Name ) == 0)
                        hero.GetSickness( fever );
                    break;
                case SicknessEnum.Staphyloccocus:
                    Staphyloccocus staphyloccocus = new Staphyloccocus();
                    if (hero.Sicknesses.Count( c => c.Name == staphyloccocus.Name ) == 0)
                        hero.GetSickness( staphyloccocus );
                    break;
                default:
                    break;
            }
        }
        private void GetPsyco( BaseHeros hero )
        {
            Array PsycoArray = Enum.GetValues( typeof( PsycologyEnum ) );
            PsycologyEnum psyco = (PsycologyEnum)PsycoArray.GetValue( _ctx.Rnd.Next( PsycoArray.Length ) );
            switch (psyco)
            {
                case PsycologyEnum.Agressivity:
                    Agressivity agressivity = new Agressivity();
                    if (hero.Psycho.Count( c => c.Name == agressivity.Name ) == 0)
                        hero.GetPsycho( agressivity );
                    break;
                case PsycologyEnum.Arrogant:
                    Arrogant arrogant = new Arrogant();
                    if (hero.Psycho.Count( c => c.Name == arrogant.Name ) == 0)
                        hero.GetPsycho( arrogant );
                    break;
                case PsycologyEnum.Crazyness:
                    Crazyness crazyness = new Crazyness();
                    if (hero.Psycho.Count( c => c.Name == crazyness.Name ) == 0)
                        hero.GetPsycho( crazyness );
                    break;
                case PsycologyEnum.Fragil:
                    Fragil fragil = new Fragil();
                    if (hero.Psycho.Count( c => c.Name == fragil.Name ) == 0)
                        hero.GetPsycho( fragil );
                    break;
                default:
                    break;
            }

        }
    }
}
