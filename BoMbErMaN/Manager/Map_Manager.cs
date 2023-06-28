using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BoMbErMaN.Manager
{
    public class Map_Manager
    {
        public int MapSize_X = 41;
        public int MapSize_Y = 16;
        public string MapName = default;
        public Tile_Manager Tile = default;
        public PlayerClass Player = default;
        public Monster_Manager Monster = default;
        public Map_Manager(PlayerClass player_, Monster_Manager monster_)
        {
            Player = player_;
            Monster = monster_;
        }

        public void Get_PrintMap()
        {
            Player.UI.Get_PrintPlayBox(MapName);
            Tile.Set_CreateTiles();
            Tile.Get_PrintTiles();
        }

        public void Set_CreateMap001()
        {
            Tile = new Tile_Manager(MapSize_X, MapSize_Y, 28, Player, Monster);
            Monster.Set_CreateStage_001(MapSize_X, MapSize_Y, 10);
            Tile.Wall.Set_Dir_X(0, 8, 16, 24, 32, 40, 4, 12, 20, 28, 36, 0, 8, 16, 24, 32, 40, 4, 12, 20, 28, 36, 0, 8, 16, 24, 32, 40);
            Tile.Wall.Set_Dir_Y(0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 8, 8, 8, 8, 8, 8, 12, 12, 12, 12, 12, 15, 15, 15, 15, 15, 15);
            Tile.Wall.Set_Patterns("◈", "◈", "◈", "◈", "◈", "◈", "▣", "▣", "▣", "▣", "▣", "◈", "◈", "◈", "◈", "◈", "◈", "▣", "▣", "▣", "▣", "▣", "◈", "◈", "◈", "◈", "◈", "◈");
            MapName = "Stage <1>";
        }

        public void Set_CreateMap002()
        {
            Tile = new Tile_Manager(MapSize_X, MapSize_Y, 37, Player, Monster);
            Monster.Set_CreateStage_002(MapSize_X, MapSize_Y, 10);
            Tile.Wall.Set_Dir_X(4, 12, 20, 28, 36, 0, 4, 8, 12, 16, 20, 24, 28, 32, 36, 40, 4, 12, 20, 28, 36, 0, 4, 8, 12, 16, 20, 24, 28, 32, 36, 40, 4, 12, 20, 28, 36);
            Tile.Wall.Set_Dir_Y(0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 8, 8, 8, 8, 8, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 15, 15, 15, 15, 15);
            Tile.Wall.Set_Patterns("▣", "▣", "▣", "▣", "▣", "▣", "◈", "▣", "◈", "▣", "◈", "▣", "◈", "▣", "◈", "▣", "▣", "▣", "▣", "▣", "▣", "▣", "◈", "▣", "◈", "▣", "◈", "▣", "◈", "▣", "◈", "▣", "▣", "▣", "▣", "▣", "▣");
            MapName = "Stage <2>";
        }

        public void Set_CreateMap003()
        {
            Tile = new Tile_Manager(MapSize_X, MapSize_Y, 90, Player, Monster);
            Monster.Set_CreateStage_003(MapSize_X, MapSize_Y, 10);
            Tile.Wall.Set_Dir_X(0, 1, 2, 17, 18, 19, 20, 21, 22, 38, 39, 40, 0, 19, 20, 40, 0, 19, 20, 40, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 0, 19, 20, 40, 0, 19, 20, 40, 0, 1, 2, 17, 18, 19, 20, 21, 22, 38, 39, 40);
            Tile.Wall.Set_Dir_Y(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 13, 13, 13, 13, 14, 14, 14, 14, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15);
            MapName = "Stage <3>";
        }
    }
}
