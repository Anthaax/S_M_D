﻿using S_M_D.Camp.ClassConfig;
using S_M_D.Character;
using S_M_D.Spell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.Class
{
    [Serializable]
    public class Casern : BaseBuilding, ILevelUP, ISingleHero
    {
        private BaseHeros _hero;
        int _actionPrice;
        public Casern(CasernConfig b) : base(b)
        {
            _hero = b.Hero;
            _actionPrice = b.ActionPrice;
        }
        /// <summary>
        /// Set an hero in the building
        /// </summary>
        /// <param name="h"></param>
        public void SetHero(BaseHeros h)
        {
            _hero = h;
            _hero.InBuilding = this;
        }
        /// <summary>
        /// Delete the hero in the building
        /// </summary>
        public void DeleteHero()
        {
            if(_hero != null)
                _hero.InBuilding = null;
            _hero = null;
        }
        public void BuySpellToHero(Spells spell)
        {
            if (_hero == null) throw new ArgumentException( "You need an hero" );
            if (spell.IsBuy) throw new ArgumentException( "Can't buy this spell he was already buy" );
            if (Ctx.MoneyManager.CanBuy( spell.Price )) Ctx.MoneyManager.Buy( spell.Price );
            else throw new ArgumentException( "You Can't buy this thing" );
            spell.IsBuy = true;
        }
        public void UpgradeSpellToHero( Spells spell )
        {
            if (_hero == null) throw new ArgumentException( "You need an hero" );
            if (!spell.IsBuy) throw new ArgumentException( "Can't upgrate this spell he wasn't buy" );
            if (Ctx.MoneyManager.CanBuy( _actionPrice )) Ctx.MoneyManager.Buy( _actionPrice );
            else throw new ArgumentException( "You Can't buy this thing" );
            spell.LevelUp();
        }
        public void LevelUP()
        {
            Level++;
            _actionPrice = _actionPrice / Level;
        }

        public int ActionPrice
        {
            get
            {
                return _actionPrice;
            }
        }

        public BaseHeros Hero
        {
            get
            {
                return _hero;
            }
        }
    }
}
