using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoMbErMaN
{
    public class Slime : MonsterClass
    {
        public Slime(int hp_, int atk_, int def_, int dir_X_, int dir_Y_)
        {
            Hp = hp_;
            Atk = atk_;
            Def = def_;
            Dir_X = dir_X_;
            Dir_Y = dir_Y_;
        }
    }
}
