using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BoMbErMaN.Manager
{
    public class Title_Manager
    {
        // 객체 생성
        Input_Manager Input = new Input_Manager();

        // 여백 크기
        const int PADDING_SIZE = 90;
        const int MAIN_SIZE = 17;
        bool choiceStart = true;

        public bool Get_Print()
        {
            while (true)
            {
                // 커서 위치 설정
                Console.SetCursorPosition(0, 0);

                string str = "┌─────────────────────────────────────────────────────────────────────┐";
                Console.WriteLine(str.PadLeft(PADDING_SIZE));

                str = "│─────────────────────────────────────────────────────────────────────│";
                str = str.Replace("─", " ");
                for (int i = 0; i < (MAIN_SIZE / 2) - 1; i++)
                {
                    Console.WriteLine(str.PadLeft(PADDING_SIZE));
                }
                str = "│─────────────────────────────BoMbEr─MaN──────────────────────────────│";
                str = str.Replace("─", " ");
                Console.WriteLine(str.PadLeft(PADDING_SIZE));

                str = "│─────────────────────────────────────────────────────────────────────│";
                str = str.Replace("─", " ");
                for (int i = 0; i < MAIN_SIZE / 2; i++)
                {
                    Console.WriteLine(str.PadLeft(PADDING_SIZE));
                }

                str = "└─────────────────────────────────────────────────────────────────────┘";
                Console.WriteLine(str.PadLeft(PADDING_SIZE));

                str = "Press Any Key.";
                Console.WriteLine(str.PadLeft(PADDING_SIZE));
                Console.WriteLine();
                Console.WriteLine();
                Get_PrintOptions();
                switch (Input.Get_Input())
                {
                    case "Up":
                        choiceStart = !choiceStart;
                        continue;
                    case "Down":
                        choiceStart = !choiceStart;
                        continue;
                    case "Left":
                        choiceStart = !choiceStart;
                        continue;
                    case "Right":
                        choiceStart = !choiceStart;
                        continue;
                    case "Space":
                        break;
                    case "Enter":
                        break;
                    default:
                        continue;
                }
                if (choiceStart)
                {
                    return true;
                }
                return false;
            }
        }

        public void Get_PrintOptions()
        {
            string str = "";
            if (choiceStart)
            {
                str = "────────────────────▶─START───────────────────EXIT─────────────────────";

            }
            else
            {
                str = "──────────────────────START─────────────────▶─EXIT──────────────────────";
            }
            str = str.Replace("─", " ");
            Console.WriteLine(str.PadLeft(PADDING_SIZE));
        }
    }
}
