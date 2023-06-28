using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoMbErMaN.Manager
{
    public class Wall_Manager
    {
        public List<WallClass> List = new List<WallClass>();

        public Wall_Manager(int size)
        {
            for (int i = 0; i < size; i++)
            {
                WallClass wall = new WallClass(0,0, "■");
                List.Add(wall);
            }
        }

        public void Set_Dir_X(params int[] x)
        {
            for (int i = 0; i < List.Count; i++)
            {
                List[i].Dir_X = x[i];
            }
        }

        public void Set_Dir_Y(params int[] y)
        {
            for (int i = 0; i < List.Count; i++)
            {
                List[i].Dir_Y = y[i];
            }
        }

        public void Set_Patterns(params string[] pattern_)
        {
            for (int i = 0; i < List.Count; i++)
            {
                List[i].Pattern = pattern_[i];
            }
        }
    }
}
