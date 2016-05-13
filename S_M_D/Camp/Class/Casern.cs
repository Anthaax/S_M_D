﻿using S_M_D.Camp.ClassConfig;
using S_M_D.Character;
using S_M_D.Spell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.Class
{
    public class Casern : BaseBuilding
    {
        private BaseHeros _hero;
        private Spells _spell;
        public Casern(CasernConfig b) : base(b)
        {
            _hero = b.Hero;
            _spell = b.Spell;
        }
        public void setHero(BaseHeros h)
        {
            _hero = h;
        }
        public void deleteHeros()
        {
            _hero = null;
        }
        public void buySpellToHero()
        {
            // ajoute le spell au héro
        }
    }
}