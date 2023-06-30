using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoMbErMaN
{
    public class GoblinChild : MonsterClass
    {
        public GoblinChild(int dir_X_, int dir_Y_)
        {
            Hp = 30;
            Atk = 35;
            Def = 5;
            Dir_X = dir_X_;
            Dir_Y = dir_Y_;
            Pattern = "ⓖ";
        }
    }
}
