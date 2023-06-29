using BoMbErMaN.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoMbErMaN
{
    public class MonsterClass
    {
        public string Name { get; protected set; } = default;
        public string Pattern { get; protected set; } = default;
        public int Hp { get; protected set; } = default;
        public int MaxHP { get; protected set; } = default;
        public int Atk { get; protected set; } = default;
        public int Def { get; protected set; } = default;
        public int Dir_X { get; protected set; } = default;
        public int Dir_Y { get; protected set; } = default;

        public void Set_Damage(int damage)
        {
            damage = damage < Def ? 1 : damage - Def;
            Hp = (Hp - damage) < 0 ? 0 : Hp - damage;
        }

        public void Set_Dir_X(int x) { Dir_X = x; }

        public void Set_Dir_Y(int y) { Dir_Y = y; }
    }
}
