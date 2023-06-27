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
        public int MapSize_X = default;
        public int MapSize_Y = default;
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
            Player.UI.Get_PrintPlayBox();
            Tile.Set_CreateTiles();
            Tile.Get_PrintTiles();
        }

        public void Set_CreateMap001()
        {
            MapSize_X = 41;
            MapSize_Y = 16;
            Tile = new Tile_Manager(MapSize_X, MapSize_Y, 20, Player, Monster);
            Monster.Set_CreateStage_001(MapSize_X, MapSize_Y, 10);
            //Tile.Wall.Set_Dir_X(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            //Tile.Wall.Set_Dir_Y(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            //Tile.Wall.Set_Patterns("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
        }

        public void Set_CreateMap002()
        {
            MapSize_X = 40;
            MapSize_Y = 20;
            Tile = new Tile_Manager(MapSize_X, MapSize_Y, 20, Player, Monster);
            Tile.Wall.Set_Dir_X();
            Tile.Wall.Set_Dir_Y();
            Tile.Wall.Set_Patterns();
        }

        public void Set_CreateMap003()
        {
            MapSize_X = 40;
            MapSize_Y = 20;
            Tile = new Tile_Manager(MapSize_X, MapSize_Y, 20, Player, Monster);
            Tile.Wall.Set_Dir_X();
            Tile.Wall.Set_Dir_Y();
            Tile.Wall.Set_Patterns();
        }
    }
}
