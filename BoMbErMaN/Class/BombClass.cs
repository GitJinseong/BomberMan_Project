using BoMbErMaN.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BoMbErMaN
{
    public class BombClass
    {
        // 비동기 메서드 취소 토큰 생성
        public CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        public CancellationToken cancellationToken = default;

        public int Dir_X { get; private set; } = default;
        public int Dir_Y { get; private set; } = default;
        public int index = default;
        public int ExplosionTime = 2000;
        public Map_Manager Map = default;
        public PlayerClass Player = default;
        public Monster_Manager Monster = default;
        public Bomb_Manager Bomb = default;

        public BombClass(int x, int y, Map_Manager map_, PlayerClass player_, Monster_Manager monster_, Bomb_Manager bomb_)
        {
            Dir_X = x;
            Dir_Y = y;
            Map = map_;
            Player = player_;
            Monster = monster_;
            Bomb = bomb_;
            Player.BombCount -= 1;
            Map.Tile.Board[y, x] = "δ";
            Map.Get_PrintMap();
            cancellationToken = cancellationTokenSource.Token;
            Set_Explosion(x, y, ExplosionTime, cancellationToken);
        }

        // 비동기 메서드 실행 취소
        public void Set_RemoveTask()
        {
            cancellationTokenSource.Cancel();
        }

        public async Task Set_Explosion(int x, int y, int time, CancellationToken cancellationToken)
        {

            // 딜레이에 시간과 , 취소 토큰을 넣음
            await Task.Delay(time, cancellationToken);
            bool up = false; bool down = false; bool left = false; bool right = false;
            Map.Tile.Board[y, x] = "※";
            for (int i = 1; i < Player.BombPower; i++)
            {
                if (!(y - i < 0) && "δ" != Map.Tile.Board[y - i, x] && "■" != Map.Tile.Board[y - i, x])
                {
                    if (!up) { Map.Tile.Board[y - i, x] = "※"; }
                }
                else {
                    Bomb.Get_FindBomb(x, y - i);
                    up = true;
                }
                if (!(y + i > Map.MapSize_Y - 1) && Map.Tile.Board[y + i, x] != "δ" && "■" != Map.Tile.Board[y + i, x])
                {
                    if (!down) { Map.Tile.Board[y + i, x] = "※"; }
                }
                else {
                    Bomb.Get_FindBomb(x, y + i);
                    down = true; 
                }
                if (!(x - i < 0)&& Map.Tile.Board[y, x - i] != "δ" && "■" != Map.Tile.Board[y, x - i])
                {
                    if (!left) { Map.Tile.Board[y, x - i] = "※"; }

                }
                else {
                    Bomb.Get_FindBomb(x - i, y);
                    left = true;
                }
                if (!(x + i > Map.MapSize_X - 1) && Map.Tile.Board[y, x + i] != "δ" && "■" != Map.Tile.Board[y, x + i])
                {
                    if (!right) { Map.Tile.Board[y, x + i] = "※"; }
                }
                else
                {
                    Bomb.Get_FindBomb(x + i, y);
                    right = true;
                }
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
            if (time > 0) { Map.Get_PrintMap(); }
            Player.BombCount += 1;
            Set_RemoveExplosion(x, y);
        }

        public async Task Set_RemoveExplosion(int x, int y)
        {
            await Task.Delay(ExplosionTime / 4);
            //bool up = false; bool down = false; bool left = false; bool right = false;
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
            //Map.Get_PrintMap();
        }
    }
}
