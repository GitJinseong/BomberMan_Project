using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoMbErMaN.Manager
{
    public class Character_Manager
    {
        // 객체 생성
        Input_Manager Input = new Input_Manager();

        // 여백 크기
        const int PADDING_SIZE = 90;
        const int MAIN_SIZE = 17;
        bool choiceMenu = false;
        int choiceCharacter = default;
        int[,] charIntArray = new int[2,3] { {100, 20, 10}, {150, 10, 10} };
        string[,] charStrArray = new string[2, 2] { {"Bomber_One", "♬"}, { "Bomber_Two", "ⓐ" } };

        public PlayerClass Get_PrintList()
        {
            while (true)
            {
                if (choiceMenu)
                {
                    int index = choiceCharacter;
                    PlayerClass player = new PlayerClass(charStrArray[index, 0], charStrArray[index, 1], charIntArray[index, 0], charIntArray[index, 1], charIntArray[index, 2]);
                    return player;
                }

                // 화면 지우기
                Console.Clear();

                // 커서 위치 설정
                Console.SetCursorPosition(0, 0);

                string str = "";

                Console.WriteLine();

                for (int i = 0; i < MAIN_SIZE - 1; i++)
                {
                    if (i == 3)
                    {
                        str = "──────────────────────────[Choice─Characters!]─────────────────────────";
                        str = str.Replace("─", " ");
                    }
                    else if (i == 8)
                    {
                        switch (choiceCharacter)
                        {
                            case 0:
                                str = "───────────────────────▼───────────────────────────────────────────────";
                                break;
                            case 1:
                                str = "───────────────────────────────────────────────▼───────────────────────";
                                break;
                        }
                        str = str.Replace("─", " ");
                    }
                    else if (i == 10)
                    {
                        str = "───────────────────────♬──────────────────────ⓐ────────────────────────";
                        str = str.Replace("─", " ");
                    }
                    else
                    {
                        str = "───────────────────────────────────────────────────────────────────────";
                        str = str.Replace("─", " ");
                    }
                    Console.WriteLine(str.PadLeft(PADDING_SIZE));
                }

                str = "───────────────────────────────────────────────────────────────────────";
                Console.WriteLine(str.PadLeft(PADDING_SIZE));

                str = "Press Any Key. ";
                Console.WriteLine(str.PadLeft(PADDING_SIZE));
                Console.WriteLine();
                Console.WriteLine();
                switch (Input.Get_Input())
                {
                    case "Up":
                        choiceCharacter = choiceCharacter == 0 ? 1 : 0;
                        continue;
                    case "Down":
                        choiceCharacter = choiceCharacter == 0 ? 1 : 0;
                        continue;
                    case "Left":
                        choiceCharacter = choiceCharacter == 0 ? 1 : 0;
                        continue;
                    case "Right":
                        choiceCharacter = choiceCharacter == 0 ? 1 : 0;
                        continue;
                    case "Space":
                        Get_PrintInfo();
                        continue;
                    case "Enter":
                        Get_PrintInfo();
                        continue;
                    default:
                        continue;
                }
            }
        }

        public void Get_PrintInfo()
        {
            // 화면 지우기
            Console.Clear();

            string str = "";

            while (true)
            {
                Console.WriteLine();

                // 커서 위치 설정
                Console.SetCursorPosition(0, 0);

                for (int i = 0; i < MAIN_SIZE; i++)
                {
                    if (i == 3)
                    {
                        str = "────────────────────────────[Character─Info]───────────────────────────";
                        str = str.Replace("─", " ");
                    }
                    else if (i == 6)
                    {
                        str = "─────────────────────────────────────────────────<"+charStrArray[choiceCharacter, 0]+">──────────────────────────────────";
                        str = str.Replace("─", " ");
                    }
                    else if (i == 8)
                    {
                        str = "────────────────────────────────────────────────────Hp:─"+charIntArray[choiceCharacter,0]+"─────────────────────────────────";
                        str = str.Replace("─", " ");
                    }
                    else if (i == 9)
                    {
                        str = "───────────────────────────────────────────────────Atk:─"+charIntArray[choiceCharacter, 1]+"─────────────────────────────────";
                        str = str.Replace("─", " ");
                    }
                    else if (i == 10)
                    {
                        str = "───────────────────────────────────────────────────Def:─"+charIntArray[choiceCharacter, 2]+"─────────────────────────────────";
                        str = str.Replace("─", " ");
                    }
                    else if (i == 12)
                    {
                        str = "───────────────────────────────▼───────────────────────────────────";
                        str = str.Replace("─", " ");
                    }
                    else if (i == 13)
                    {
                        str = "───────────────────────────────"+charStrArray[choiceCharacter,1]+"───────────────────────────────────";
                        str = str.Replace("─", " ");
                    }
                    else
                    {
                        str = "───────────────────────────────────────────────────────────────────────";
                        str = str.Replace("─", " ");
                    }
                    Console.WriteLine(str.PadLeft(PADDING_SIZE));
                }

                str = "───────────────────────────────────────────────────────────────────────";
                Console.WriteLine(str.PadLeft(PADDING_SIZE));

                str = "Press Any Key. ";
                Console.WriteLine(str.PadLeft(PADDING_SIZE));
                Console.WriteLine();
                Console.WriteLine();

                Get_PrintOptions();
                switch (Input.Get_Input())
                {
                    case "Up":
                        choiceMenu = !choiceMenu;
                        continue;
                    case "Down":
                        choiceMenu = !choiceMenu;
                        continue;
                    case "Left":
                        choiceMenu = !choiceMenu;
                        continue;
                    case "Right":
                        choiceMenu = !choiceMenu;
                        continue;
                    case "Space":
                        break;
                    case "Enter":
                        break;
                    default:
                        continue;
                }
                break;
            }
        }

        public void Get_PrintOptions()
        {
            string str = "";
            if (choiceMenu)
            {
                str = "───────────────────▶─ACCEPT───────────────────BACK─────────────────────";

            }
            else
            {
                str = "─────────────────────ACCEPT─────────────────▶─BACK──────────────────────";
            }
            str = str.Replace("─", " ");
            Console.WriteLine(str.PadLeft(PADDING_SIZE));
        }
    }
}
