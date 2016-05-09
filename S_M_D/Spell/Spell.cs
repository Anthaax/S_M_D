using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_M_D.Character
{
    public abstract class Spell
    {
        string _name;
        int _price;
        string _description;
        int _manaCost;
        int _baseCooldown;
        bool _isOnCooldown;
        int _cooldown;

    }
}
