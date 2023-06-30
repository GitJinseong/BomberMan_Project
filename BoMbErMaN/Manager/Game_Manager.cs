using BoMbErMaN.Manager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BoMbErMaN
{
    public class Game_Manager
    {
        // 매니저 생성
        Title_Manager Title = new Title_Manager();
        Character_Manager Character = new Character_Manager();
        Monster_Manager Monster = default;
        Map_Manager Map = default;
        PlayerClass Player = default;
        UI_Manager UI = default;

        // 델리게이트 선언
        delegate void myDelegate();
        myDelegate[] FuncArray = default;

        public void Get_Clear()
        {
            Console.Clear();
            while (true)
            {
                Console.Write("WIN ");
            }
        }

        public void Get_Start()
        {

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
                return;
            }

            // 플레이어 생성
            Player = Character.Get_PrintList();

            // UI 생성
            UI = new UI_Manager(Player);

            // 몬스터 생성
            Monster = new Monster_Manager(Player);

            // 링크
            Player.Set_LinkUI(UI);

            // 마을 생성
            Console.Clear();
            Map = new Map_Manager(Player, Monster);
            Player.Set_LinkMonster(Monster);
            Player.Set_LinkMap(Map);
            Player.Set_CreateBomb();
            Map.Set_CreateMap001();
            Monster.Set_Moves(Map);

            // 델리 게이트 초기화
            FuncArray = new myDelegate[3];
            FuncArray[0] = Map.Set_CreateMap001;
            FuncArray[1] = Map.Set_CreateMap002;
            FuncArray[2] = Map.Set_CreateMap003;

            int stage = 0;
            // 게임 실행
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Map.Get_PrintMap();
                Player.Set_Actions();
                Player.Get_IsDead();
                if (10 <= Player.KillCount)
                {
                    stage++;
                    // 게임 클리어
                    if (stage == 3)
                    {
                        Get_Clear();
                    }
                    FuncArray[stage]();
                    Player.Set_Move(Map.MapSize_X / 2, Map.MapSize_Y / 2);
                    Player.Set_ResetCount();
                }
                Thread.Sleep(100);
            }
        }
    }
}
