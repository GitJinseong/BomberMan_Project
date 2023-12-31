﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoMbErMaN.Manager
{
    public class UI_Manager
    {
        public PlayerClass Player = default;

        public UI_Manager(PlayerClass player_)
        {
            Player = player_;
        }

        public void Get_PrintPlayBox(string mapName)
        {
            string str = "";
            int mainSize = 17;
            int padding = 96;
            // 커서 위치 설정
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(mapName.PadLeft((padding / 2) + mapName.Length));

            str = "┌───────────────────────────────────────────────────────────────────────────────────┐";
            Console.WriteLine(str.PadLeft(padding));

            str = "│───────────────────────────────────────────────────────────────────────────────────│";
            str = str.Replace("─", " ");
            for (int i = 0; i < (mainSize / 2) - 1; i++)
            {
                Console.WriteLine(str.PadLeft(padding));
            }
            str = "│───────────────────────────────────────────────────────────────────────────────────│";
            str = str.Replace("─", " ");
            Console.WriteLine(str.PadLeft(padding));

            str = "│───────────────────────────────────────────────────────────────────────────────────│";
            str = str.Replace("─", " ");
            for (int i = 0; i < mainSize / 2; i++)
            {
                Console.WriteLine(str.PadLeft(padding));
            }

            str = "└───────────────────────────────────────────────────────────────────────────────────┘";
            Console.WriteLine(str.PadLeft(padding));

            str = "Name: Bomber_one";
            Console.Write(str.PadLeft(28));
            str = "Press the Arrow Keys and the Space.";
            Console.WriteLine(str.PadLeft(padding - 28));

            str = "Hp: ";
            for (int i = 0; i < (Player.Hp / 50); i++)
            {
                str = str + "♥";

            }
            Console.Write(str.PadLeft(16 + (Player.Hp / 50)));
            int different = (Player.MaxHP / 50) - (Player.Hp / 50);
            for (int i = 0; i < different; i++)
            {
                Console.Write("♡");
            }
            Console.WriteLine();

            str = "Atk: ";
            for (int i = 0; i < (Player.Atk / 10); i++)
            {
                str = str + "★";
            }
            Console.WriteLine(str.PadLeft(17 + (Player.Atk / 10)));

            str = "Def: ";
            for (int i = 0; i < (Player.Def / 10); i++)
            {
                str = str + "★";
            }
            Console.WriteLine(str.PadLeft(17 + (Player.Def / 10)));
        }
    }
}
