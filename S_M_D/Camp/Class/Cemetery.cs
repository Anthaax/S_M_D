﻿using S_M_D.Camp.ClassConfig;
using S_M_D.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Camp.Class
{
    public class Cemetery : BaseBuilding
    {
        private List<BaseHeros> _herosDispo;
        public Cemetery(CemeteryConfig b) : base(b)
        {
            _herosDispo = b.HerosDispo;
        }
        public void AddDeadHero(BaseHeros h)
        {
            _herosDispo.Add(h);
        }
        public List<BaseHeros> GetDeadHeros()
        {
            return _herosDispo;
        }
    }
}