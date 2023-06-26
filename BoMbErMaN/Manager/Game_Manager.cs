using BoMbErMaN.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BoMbErMaN
{
    public class Game_Manager
    {
        public void Get_Start()
        {
            // 매니저 생성
            Title_Manager Title = new Title_Manager();
            Character_Manager Character = new Character_Manager();

            // 커서 숨기기
            Console.CursorVisible = false;

            // 콘솔 창 크기 설정
            Console.SetWindowSize(110, 30);

            // 버퍼 사이즈 설정
            Console.SetBufferSize(110, 30);

            // 커서 위치 설정
            Console.SetCursorPosition(0, 0);

            // 타이틀 실행
            if (!Title.Get_Print())     // 게임 종료시
            {
                Thread.Sleep(1000000000);
            }

            // 플레이어 생성
            PlayerClass player = Character.Get_PrintList();

            Console.WriteLine(player.Hp);

        }
    }
}
