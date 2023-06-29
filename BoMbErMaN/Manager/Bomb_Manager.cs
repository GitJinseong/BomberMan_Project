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

        public Bomb_Manager(PlayerClass player_, Map_Manager map_, UI_Manager ui_)
        {
            Player = player_;
            Map = map_;
            UI = ui_;
            Monster = Player.Monster;
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
            Player.BombCount -= 1;
            Map.Tile.Board[y, x] = "δ";
            Map.Get_PrintMap();

            Set_Explosion(x, y);   
        }

        public async Task Set_Explosion(int x, int y)
        {
            await Task.Delay(ExplosionTime);
            bool up = false; bool down = false; bool left = false; bool right = false;
            Map.Tile.Board[y, x] = "※";
            for (int i = 1; i < Player.BombPower; i++)
            {
                if (!(y - i < 0) && "δ" != Map.Tile.Board[y - i, x] && "■" != Map.Tile.Board[y - i, x])
                {
                    if (!up) { Map.Tile.Board[y - i, x] = "※"; }
                }
                else { up = true; }
                if (!(y + i > Map.MapSize_Y - 1) && Map.Tile.Board[y + i, x] != "δ" && "■" != Map.Tile.Board[y + i, x])
                {
                    if (!down) { Map.Tile.Board[y + i, x] = "※"; }
                }
                else { down = true; }
                if (!(x - i < 0)&& Map.Tile.Board[y, x - i] != "δ" && "■" != Map.Tile.Board[y, x - i])
                {
                    if (!left) { Map.Tile.Board[y, x - i] = "※"; }
                    
                }
                else { left = true; }
                if (!(x + i > Map.MapSize_X - 1) && Map.Tile.Board[y, x + i] != "δ" && "■" != Map.Tile.Board[y, x + i])
                {
                    if (!right) { Map.Tile.Board[y, x + i] = "※"; }
                }
                else { right = true; }
            }
            if (Map.Tile.Board[Player.Dir_Y, Player.Dir_X] == "※")
            {
                Player.Set_Damage(50);
                Player.IsHit = 1;
            }

            for (int i = 0; i < Monster.List.Count; i++)
            {
                if (Map.Tile.Board[Monster.List[i].Dir_Y, Monster.List[i].Dir_X] == "※")
                {
                    Monster.List[i].Set_Damage(Player.Atk);
                }
            }
            Monster.Get_IsDead();
            Map.Get_PrintMap();
            Player.BombCount += 1;
            Set_RemoveExplosion(x, y, up, down, left, right);
        }

        public async Task Set_RemoveExplosion(int x, int y, bool up, bool down, bool left, bool right)
        {
            await Task.Delay(ExplosionTime / 4);
            Map.Tile.Board[y, x] = "　";
            for (int i = 1; i < Player.BombPower; i++)
            {
                if (!(y - i < 0) && Map.Tile.Board[y - i, x] == "※")
                {
                    Map.Tile.Board[y - i, x] = "　";
                }
                if (!(y + i > Map.MapSize_Y - 1) && Map.Tile.Board[y + i, x] == "※")
                {
                    Map.Tile.Board[y + i, x] = "　";
                }
                if (!(x - i < 0) && Map.Tile.Board[y, x - i] == "※")
                {
                    Map.Tile.Board[y, x - i] = "　";
                }
                if (!(x + i > Map.MapSize_X - 1) && Map.Tile.Board[y, x + i] == "※")
                {
                    Map.Tile.Board[y, x + i] = "　";
                }
            }
            Map.Get_PrintMap();
        }
    }
}
