using BoMbErMaN.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            Title_Manager title = new Title_Manager();
            Character_Manager character = new Character_Manager();
            Monster_Manager monster = new Monster_Manager();
            Map_Manager map = default;


            // 커서 숨기기
            Console.CursorVisible = false;

            // 콘솔 창 크기 설정
            Console.SetWindowSize(110, 30);

            // 버퍼 사이즈 설정
            Console.SetBufferSize(110, 30);

            // 커서 위치 설정
            Console.SetCursorPosition(0, 0);

            // 타이틀 실행
            if (!title.Get_Print())     // 게임 종료시
            {
                return;
            }

            // 플레이어 생성
            PlayerClass player = character.Get_PrintList();

            // UI 생성
            UI_Manager ui = new UI_Manager(player);

            // UI 링크
            player.Set_LinkUI(ui);

            // 마을 생성
            Console.Clear();
            map = new Map_Manager(player);
            player.Set_LinkMonster(monster);
            player.Set_LinkMap(map);
            map.Set_CreateMap001();

            // 폭탄 피격 체크 (Map 객체가 바뀌면 종료된다.)
            player.Bomb.Get_CheckBomb();

            while (true)
            {
                Console.SetCursorPosition(0, 0);
                ui.Get_PrintPlayBox();
                map.Get_PrintMap();
                player.Set_Actions();
                Thread.Sleep(32);
                Console.Clear();
            }


        }
    }
}
