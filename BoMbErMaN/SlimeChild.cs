using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoMbErMaN
{
    public class SlimeChild : MonsterClass
    {

        public SlimeChild(int dir_X_, int dir_Y_)
        {
            Hp = 30;
            Atk = 10;
            Def = 3;
            Dir_X = dir_X_;
            Dir_Y = dir_Y_;
            Pattern = "ⓢ";
        }
    }
}
