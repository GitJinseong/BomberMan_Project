using BoMbErMaN.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BoMbErMaN
{
    public class PlayerClass
    {
        public string Name { get; private set; } = default;
        public string Pattern { get; set; } = default;
        public int Hp { get; private set; } = default;
        public int MaxHP { get; private set; } = default;
        public int Atk { get; private set; } = default;
        public int Def { get; private set; } = default;
        public int Dir_X { get; private set; } = 5;
        public int Dir_Y { get; private set; } = 5;

        public int BombCount = 3;   // 보유한 폭탄 갯수
        public int BombPower = 2;   // 폭발 범위

        public Bomb_Manager Bomb = default;
        public Input_Manager Input = new Input_Manager();
        public Map_Manager Map = default;
        public UI_Manager UI = default;
        public Monster_Manager Monster = default;

        public PlayerClass(string name_, string pattern_, int hp_, int atk_, int def_)
        {
            Name = name_;
            Pattern = pattern_;
            Hp = hp_;
            MaxHP = hp_;
            Atk = atk_;
            Def = def_;
        }

        public void Set_LinkUI(UI_Manager ui_)
        {
            UI = ui_;
        }

        public void Set_LinkMonster(Monster_Manager monster_)
        {
            Monster = monster_;
        }

        public void Set_LinkMap(Map_Manager map_)
        {
            Map = map_;
        }

        public void Set_LinkBomb()
        {
            Bomb = new Bomb_Manager(this, Map, UI);
        }

        public void Set_Damage(int damage)
        {
            damage = damage < Def ? 1 : damage - Def;
            Hp = (Hp - damage) < 0 ? 0 : Hp - damage;
        }

        public void Set_Heal(int heal)
        {
            Hp = (Hp + heal) > MaxHP ? MaxHP : Hp + heal;
        }

        public void Set_Teleport(int x, int y)
        {
            Dir_X = x;
            Dir_Y = y;
        }

        public void Set_Actions()
        {
            int x = Dir_X;
            int y = Dir_Y;
            int size_x = Map.MapSize_X;
            int size_y = Map.MapSize_Y;
            switch (Input.Get_Input())
            {
                case "Up":
                    if (!Map.Tile.Get_CheckWalls(x, y - 1))
                    {
                        Dir_Y = (y == 0) ? y : y - 1;
                    }
                    break;
                case "Down":
                    if (!Map.Tile.Get_CheckWalls(x, y + 1))
                    {
                        Dir_Y = (y == size_y - 1) ? y : y + 1;
                    }
                    break;
                case "Left":
                    if (!Map.Tile.Get_CheckWalls(x - 1, y))
                    {
                        Dir_X = (x == 0) ? x : x - 1;
                    }
                    break;
                case "Right":
                    if (!Map.Tile.Get_CheckWalls(x + 1, y))
                    {
                        Dir_X = (x == size_x - 1) ? x : x + 1;
                    }
                    break;
                case "Space":
                    Bomb.Set_CreateBomb();
                    break;
                case "R":
                    Console.Clear();
                    break;
                default:
                    break;
            }
        }

        public void Get_IsDead()
        {
            if (Hp <= 0)
            {
                Console.Clear();
                while(true)
                {
                    Console.Write("GAMEOVER ");
                }
            }
        }
    }
}
