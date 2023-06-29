using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BoMbErMaN.Manager
{
    public class Bomb_Manager
    {
        public int ExplosionTime = 2000;    // 1000당 1초
        public PlayerClass Player = default;
        public Monster_Manager Monster = default;
        public Map_Manager Map = default;
        public UI_Manager UI = default;
        public List<BombClass> List = new List<BombClass>();

        public Bomb_Manager(PlayerClass player_, Map_Manager map_, UI_Manager ui_)
        {
            Player = player_;
            Map = map_;
            UI = ui_;
            Monster = Player.Monster;
        }

        public void Set_RemoveList(int i)
        {
            List.RemoveAt(i);
        }

        public void Get_FindBomb(int x, int y)
        {
            for (int i = 0; i < List.Count; i++)
            {
                if (x == List[i].Dir_X && List[i].Dir_Y == y)
                {
                    List[i].Set_Explosion(x, y, 0, List[0].cancellationToken);
                    List[i].Set_RemoveTask();
                    List[i].index = i;
                    return;
                }
            }
        }

        public void Set_CreateBomb()
        {
            int x = Player.Dir_X;
            int y = Player.Dir_Y;
            string pattern = Map.Tile.Board[y, x];
            if (Player.BombCount == 0 || "※" == pattern || pattern == "δ")
            {
                return;
            }
            BombClass bomb = new BombClass(x, y, Map, Player, Monster, this);
            List.Add(bomb);  
        }
    }
}
