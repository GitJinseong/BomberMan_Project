using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoMbErMaN.Manager
{
    public class ItemBlock_Manager
    {

        public string[] Patterns = new string[6] {"★", "♥", "＋", "★", "♥", "＋" };
        Random random = new Random();
        public PlayerClass Player = default;
        public List<ItemBlockClass> List = new List<ItemBlockClass>();

        public ItemBlock_Manager(int size, PlayerClass player_)
        {
            Player = player_;
            for (int i = 0; i < size; i++)
            {
                ItemBlockClass itemBlock = new ItemBlockClass(0, 0, "▧");
                List.Add(itemBlock);
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

        public void Set_DropItem(int index)
        {
            List[index].Pattern = Patterns[random.Next(0, 5)];
        }

        public void Set_RemoveBlock(int index)
        {
            if (random.Next(0,9) > 5)
            {
                switch (List[index].Pattern)
                {
                    case "★":
                        Player.Set_AddStat();
                        break;

                    case "♥":
                        Player.Set_Heal(50);
                        break;

                    case "＋":
                        Player.Set_AddBombStat();
                        break;
                }
            }          
            List.RemoveAt(index);
        }
    }
}
