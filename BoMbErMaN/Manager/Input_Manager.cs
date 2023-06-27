using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BoMbErMaN.Manager
{
    public class Input_Manager
    {
        public string Get_Input()
        {
            ConsoleKeyInfo input = Console.ReadKey(true);
            switch(input.Key)
            {
                case ConsoleKey.UpArrow:
                    return "Up";

                case ConsoleKey.DownArrow:
                    return "Down";

                case ConsoleKey.LeftArrow:
                    return "Left";

                case ConsoleKey.RightArrow:
                    return "Right";

                case ConsoleKey.Spacebar:
                    return "Space";

                case ConsoleKey.Enter:
                    return "Enter";

                case ConsoleKey.R:
                    return "R";
                default:
                    return " ";
            }

        }

    }

}
