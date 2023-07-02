using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BoMbErMaN.Manager
{
    public class Monster_Manager
    {
        public List<MonsterClass> List = default;
        public PlayerClass Player = default;
        public Random random = new Random();
        public Monster_Manager(PlayerClass player_)
        {
            Player = player_;
        }

        public void Set_CreateStage_001(int map_X, int map_Y, int count)
        {
            List = new List<MonsterClass>();
            for (int i = 0; i < count; i++)
            {
                SlimeChild slime = new SlimeChild(random.Next(0, map_X - 1), random.Next(0, map_Y - 1));
                List.Add(slime);
            }
        }

        public void Set_CreateStage_002(int map_X, int map_Y, int count)
        {
            List = new List<MonsterClass>();
            for (int i = 0; i < count; i++)
            {
                GoblinChild goblin = new GoblinChild(random.Next(0, map_X - 1), random.Next(0, map_Y - 1));
                List.Add(goblin);
            }
        }

        public void Set_CreateStage_003(int map_X, int map_Y, int count)
        {
            List = new List<MonsterClass>();
            for (int i = 0; i < count; i++)
            {
                OrcChild orc = new OrcChild(random.Next(0, map_X - 1), random.Next(0, map_Y - 1));
                List.Add(orc);
            }
        }

        public async Task Set_Moves(Map_Manager map)
        {
            while (true)
            {
                await Task.Delay(500);
                int size_x = map.MapSize_X;
                int size_y = map.MapSize_Y;
                for (int i = 0; i < List.Count; i++)
                {
                    int x = List[i].Dir_X;
                    int y = List[i].Dir_Y;
                    if (x == 0)
                    {
                        x = size_x - 1;
                    }
                    int moveCount = 0;
                    while (moveCount == 0)
                    {
                        int num = random.Next(0, 3);
                        switch (num)
                        {
                            case 0:
                                if (!map.Tile.Get_CheckMonsterMove(x, y - 1))
                                {
                                    List[i].Set_Dir_Y((y == 0) ? y : y - 1);
                                    moveCount++;
                                    Set_Attack(x, y - 1);
                                }
                                else { Set_Attack(x, y - 1); }
                                break;
                            case 1:
                                if (!map.Tile.Get_CheckMonsterMove(x - 1, y))
                                {
                                    List[i].Set_Dir_X((x == 0) ? x : x - 1);
                                    moveCount++;
                                    Set_Attack(x - 1, y);
                                }
                                else { Set_Attack(x - 1, y); }
                                break;
                            case 2:
                                if (!map.Tile.Get_CheckMonsterMove(x, y + 1))
                                {
                                    List[i].Set_Dir_Y((y == size_y - 1) ? y : y + 1);
                                    moveCount++;
                                    Set_Attack(x, y + 1);
                                }
                                else { Set_Attack(x, y + 1); }
                                break;    
                            case 3:
                                if (!map.Tile.Get_CheckMonsterMove(x + 1, y))
                                {
                                    List[i].Set_Dir_X((x == size_x - 1) ? x : x + 1);
                                    moveCount++;
                                    Set_Attack(x + 1, y);
                                }
                                else { Set_Attack(x + 1, y); }
                                break;
                        }
                    }
                }
            }    
        }

        public void Set_Attack(int x, int y)
        {
            if (x == Player.Dir_X && Player.Dir_Y == y)
            {
                Player.Set_Damage(List[0].Atk);
                Player.IsHit = 1;
            }
        }

        public void Get_IsDead()
        {
            for (int i = List.Count - 1; i >= 0; i--)
            {
                if (List[i].Hp == 0)
                {
                    List.RemoveAt(i);
                    Player.Set_AddCount();
                }
            }
        }
    }
}
