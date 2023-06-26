using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoMbErMaN
{
    public class PlayerClass
    {
        public string Name { get; set; } = default;
        public string Pattern { get; set; } = default;
        public int Hp { get; set; } = default;
        public int MaxHP { get; set; } = default;
        public int Atk { get; set; } = default;
        public int Def { get; set; } = default;

        public PlayerClass(string name_, string pattern_, int hp_, int atk_, int def_)
        {
            Name = name_;
            Pattern = pattern_;
            Hp = hp_;
            MaxHP = hp_;
            Atk = atk_;
            Def = def_;
        }
    }
}
