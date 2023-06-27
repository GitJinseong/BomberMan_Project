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

        // 비동기 메서드
        public async Task Get_CheckBomb()
        {
           while (true)
            {
                int x = Player.Dir_X;
                int y = Player.Dir_Y;

                if (Map.Tile.Board[y, x] == "※")
                {
                    Player.Set_Damage(50);
                }

                for (int i = 0; i < Monster.List.Count; i++)
                {
                    int x2 = Monster.List[i].Dir_X;
                    int y2 = Monster.List[i].Dir_Y;
                    if (Map.Tile.Board[y2, x2] == "※")
                    {
                        Monster.List[i].Set_Damage(Player.Atk);
                    }
                }

                await Task.Delay(100);
            }
        }

        public void Set_CreateBomb()
        {
            int x = Player.Dir_X;
            int y = Player.Dir_Y;
            if (Player.BombCount == 0 || Map.Tile.Board[y, x] == "※")
            {
                return;
            }
            Player.BombCount -= 1;
            //BombClass bomb = new BombClass(x, y);
            Map.Tile.Board[y, x] = "δ";
            UI.Get_PrintPlayBox();
            Map.Get_PrintMap();

            Task.Delay(ExplosionTime).ContinueWith(t =>
            {
                //bomb = default;
                Map.Tile.Board[y, x] = "※";
                for (int i = 1; i < Player.BombPower; i++)
                {
                    Map.Tile.Board[y - i, x] = "※";
                    Map.Tile.Board[y + i, x] = "※";
                    Map.Tile.Board[y, x - i] = "※";
                    Map.Tile.Board[y, x + i] = "※";
                }
                UI.Get_PrintPlayBox();
                Map.Get_PrintMap();
                Player.BombCount += 1;
                Task.Delay(ExplosionTime / 2).ContinueWith(t2 =>
                {
                    Map.Tile.Board[y, x] = "　";
                    for (int i = 1; i < Player.BombPower; i++)
                    {
                        Map.Tile.Board[y - i, x] = "　";
                        Map.Tile.Board[y + i, x] = "　";
                        Map.Tile.Board[y, x - i] = "　";
                        Map.Tile.Board[y, x + i] = "　";
                    }
                    UI.Get_PrintPlayBox();
                    Map.Get_PrintMap();
                });
                
            });
        }

    }
}
