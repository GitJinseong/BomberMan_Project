﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoMbErMaN.Manager
{
    public class Monster_Manager
    {
        public List<MonsterClass> List = default;
        public Random random = new Random();

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

        public void Get_IsDead()
        {
            for (int i = List.Count - 1; i > -1; i--)
            {
                if (List[i].Hp <= 0)
                {
                    List.RemoveAt(i);
                }
            }
        }
    }
}
