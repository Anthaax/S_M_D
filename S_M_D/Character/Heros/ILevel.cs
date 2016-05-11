using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S_M_D.Character
{
    public interface ILevel
    {
        /// <summary>
        /// Level up a hero if is xpMax > Xp an exeption was throw
        /// </summary>
        void LevelUp();
    }
}
