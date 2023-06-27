using System;
using System.Collections.Generic;
using System.Data.OleDb;
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

        public Bomb_Manager(PlayerClass player_, Map_Manager map_, UI_Manager ui_)
        {
            Player = player_;
            Map = map_;
            UI = ui_;
        }

        public void Set_LinkMonster(Monster_Manager monster_)
        {
            Monster = monster_;
        }

        public void Set_CreateBomb()
        {
            int x = Player.Dir_X;
            int y = Player.Dir_Y;
            if (Player.BombCount == 0 || ("※" == Map.Tile.Board[y, x] || Map.Tile.Board[y, x] == "δ"))
            {
                return;
            }
            Player.BombCount -= 1;
            Map.Tile.Board[y, x] = "δ";
            Map.Get_PrintMap();

            Task.Delay(ExplosionTime).ContinueWith(t =>
            {
                Map.Tile.Board[y, x] = "※";
                for (int i = 1; i < Player.BombPower; i++)
                {
                    Map.Tile.Board[y - i, x] = "※";
                    Map.Tile.Board[y + i, x] = "※";
                    Map.Tile.Board[y, x - i] = "※";
                    Map.Tile.Board[y, x + i] = "※";
                }
                if (Map.Tile.Board[Player.Dir_Y, Player.Dir_X] == "※")
                {
                    Player.Set_Damage(50);
                }

                for (int i = 0; i < Monster.List.Count; i++)
                {
                    if (Map.Tile.Board[Monster.List[i].Dir_Y, Monster.List[i].Dir_X] == "※")
                    {
                        Monster.List[1].Set_Damage(50);

                    }
                }

                Map.Get_PrintMap();
                Player.BombCount += 1;
                Task.Delay(ExplosionTime / 4).ContinueWith(t2 =>
                {
                    Map.Tile.Board[y, x] = "　";
                    for (int i = 1; i < Player.BombPower; i++)
                    {
                        Map.Tile.Board[y - i, x] = "　";
                        Map.Tile.Board[y + i, x] = "　";
                        Map.Tile.Board[y, x - i] = "　";
                        Map.Tile.Board[y, x + i] = "　";
                    }
                    Map.Get_PrintMap();
                });
                
            });
        }

    }
}
