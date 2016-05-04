using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_M_D.Character
{
    public abstract class BaseHero : BaseCharacter
    {
        string _characterClassName;
        int _evilness;
        string _sickness;
        string _psycho;
        string _relation;
        string[] _equipement = new string[4];
        int _xp;
        int _xpMax;

        public int Evilness
        {
            get
            {
                return _evilness;
            }

            set
            {
                _evilness = value;
            }
        }

        public string Sickness
        {
            get
            {
                return _sickness;
            }

            set
            {
                _sickness = value;
            }
        }

        public string Psycho
        {
            get
            {
                return _psycho;
            }

            set
            {
                _psycho = value;
            }
        }

        public string Relation
        {
            get
            {
                return _relation;
            }

            set
            {
                _relation = value;
            }
        }

        public string[] Equipement
        {
            get
            {
                return _equipement;
            }

            set
            {
                _equipement = value;
            }
        }

        public int Xp
        {
            get
            {
                return _xp;
            }

            set
            {
                _xp = value;
            }
        }

        public int XpMax
        {
            get
            {
                return _xpMax;
            }

            set
            {
                _xpMax = value;
            }
        }

        public string CharacterClassName
        {
            get
            {
                return _characterClassName;
            }

            set
            {
                _characterClassName = value;
            }
        }
    }
}
