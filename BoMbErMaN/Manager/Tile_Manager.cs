﻿using BoMbErMaN.Manager;
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
        public Tile_Manager(int x, int y ,int wallSize, PlayerClass player_)
        {
            Size_X = x;
            Size_Y = y;
            Board = new string[y, x];
            Wall = new Wall_Manager(wallSize);
            Player = player_;
        }

        public bool Get_CheckWalls(int x, int y)
        {
            for (int i = 0; i < Wall.List.Count; i++)
            {
                if (x == Wall.List[i].Dir_X & Wall.List[i].Dir_X == y)
                {
                    return true;
                }   
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
                Board[Player.Dir_Y - 1, Player.Dir_X] = "▼";
            }
            for (int y = 0; y < Size_Y; y++)
            {
                for (int x = 0; x < Size_X; x++)
                {
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

        public void Get_PrintHouse001()
        {
            string str = "　　────────────";
            Console.WriteLine(str.PadLeft(50));
            str = "　　────────────";
            Console.WriteLine(str.PadLeft(50));
            str = "　／           ／＼";
            Console.WriteLine(str.PadLeft(50));
            str = " ／__Stage!___／　 ＼";
            Console.WriteLine(str.PadLeft(50));
            str = " ┃ # ______ # ┃ 　 ┃";
            Console.WriteLine(str.PadLeft(50));
            str = " ┃___┃ #┃_____┃____┃";
            Console.WriteLine(str.PadLeft(50));
        }
    }
}