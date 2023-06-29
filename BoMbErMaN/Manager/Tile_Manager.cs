using BoMbErMaN.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoMbErMaN
{
    public class Tile_Manager
    {
        public int Size_X = default;
        public int Size_Y = default;
        public string[,] Board = default;
        public Wall_Manager Wall = default;
        public PlayerClass Player = default;
        public Monster_Manager Monster = default;
        public Tile_Manager(int x, int y, int wallSize, PlayerClass player_, Monster_Manager monster_)
        {
            Size_X = x;
            Size_Y = y;
            Board = new string[y, x];
            Wall = new Wall_Manager(wallSize);
            Player = player_;
            Monster = monster_;
        }

        public bool Get_CheckWall(int x, int y)
        {
            if ((0 > y || 0 > x || Size_X - 1 < x || Size_Y - 1 < y) || ("　" != Board[y, x] && Board[y, x] != "▼"))
            {
                return true;
            }

            return false;
        }

        public bool Get_CheckMonsterMove(int x, int y)
        {
            if ((0 > y || 0 > x || Size_X - 1 < x || Size_Y - 1 < y) || ("　" != Board[y, x] && Board[y, x] != "▼"))
            {
                return true;
            }

            return false;
        }
        public void Set_CreateTiles()
        {
            for (int y = 0; y < Size_Y; y++)
            {
                for (int x = 0; x < Size_X; x++)
                {
                    if (Board[y, x] == "δ" || "※" == Board[y, x])
                    {
                        continue;
                    }

                    Board[y, x] = "　";

                    for (int i = 0; i < Monster.List.Count; i++)
                    {
                        if (x == Monster.List[i].Dir_X && Monster.List[i].Dir_Y == y)
                        {
                            Board[y, x] = Monster.List[i].Pattern;
                        }
                    }

                    for (int i = 0; i < Wall.List.Count; i++)
                    {
                        if (x == Wall.List[i].Dir_X && Wall.List[i].Dir_Y == y)
                        {
                            Board[y, x] = Wall.List[i].Pattern;
                        }
                    }

                    if (x == Player.Dir_X && Player.Dir_Y == y)
                    {
                        Board[y, x] = Player.Pattern;
                    }
                }
            }
        }

        public void Get_PrintTiles()
        {
            Console.SetCursorPosition(0, 2);
            if (Player.Dir_Y != 0)
            {
                int x = Player.Dir_X;
                int y = Player.Dir_Y;
                string pattern = Board[y - 1, x];
                if (pattern == "　")
                {
                    Board[y - 1, x] = "▼";
                }
            }
            for (int y = 0; y < Size_Y; y++)
            {
                for (int x = 0; x < Size_X; x++)
                {
                    if (Player.IsHit > 0 && (x == Player.Dir_X && Player.Dir_Y == y))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(Board[y, x]);
                        Console.ResetColor();
                        Player.IsHit++;
                        if (Player.IsHit >= 5)
                        {
                            Player.IsHit = 0;
                        }
                        continue;
                    }
                    if (x == 0)
                    {
                        string str = "│ " + Board[y, x];
                        Console.Write(str.PadLeft(14));
                        continue;
                    }
                    Console.Write(Board[y, x]);
                }
                Console.WriteLine();
            }
        }
    }
}
