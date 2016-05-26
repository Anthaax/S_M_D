using S_M_D.Character.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Spell;

namespace S_M_D.Character
{
    public class BaseMonster : BaseCharacter
    {
        protected int _giveXp;
        protected MonsterType _type;
        List<Spells> _spells;
        int _position;

        public int GiveXp
        {
            get
            {
                return _giveXp;
            }

            set
            {
                _giveXp = value;
            }
        }

        public List<Spells> Spells
        {
            get
            {
                return _spells;
            }

            set
            {
                _spells = value;
            }
        }

        public MonsterType Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }
        public int Position
        {
            get
            {
                return _position;
            }

            set
            {
                _position = value;
            }
        }
    }
}
