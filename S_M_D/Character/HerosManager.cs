using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_M_D.Character
{
    public class HerosManager
    {
        readonly public Dictionary<string, BaseHero> _types;
        public HerosManager()
        {
            _types = new Dictionary<string, BaseHero>();
        }


    }
}
