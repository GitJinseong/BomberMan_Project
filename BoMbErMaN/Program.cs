using BoMbErMaN.Manager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoMbErMaN
{
    public class Program
    {
        static void Main(string[] args)
        {
            // 객체 생성
            Game_Manager game = new Game_Manager();

            // 게임 실행
            game.Get_Start();
        }
    }
}
