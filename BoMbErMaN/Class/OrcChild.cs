using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoMbErMaN
{
    public class OrcChild : MonsterClass
    {
        public OrcChild(int dir_X_, int dir_Y_)
        {
            Hp = 80;
            Atk = 50;
            Def = 5;
            Dir_X = dir_X_;
            Dir_Y = dir_Y_;
            Pattern = "ⓞ";
        }
    }
}
