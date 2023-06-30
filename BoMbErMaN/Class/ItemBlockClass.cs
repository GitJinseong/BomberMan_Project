using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoMbErMaN
{
    public class ItemBlockClass
    {
        public int Dir_X = default;
        public int Dir_Y = default;
        public string Pattern = default;
        public ItemBlockClass(int x, int y, string pattern_)
        {
            Dir_X = x;
            Dir_Y = y;
            Pattern = pattern_;
        }
    }
}
