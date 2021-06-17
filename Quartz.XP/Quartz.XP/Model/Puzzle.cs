using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quartz.XP.Model
{
    class Puzzle
    {
        public int id { get; set; }
        public Cell[,] Quartz { get; set; }
        public Poem[] Poems { get; set; }
        public char a1 { get; set; }
        public char a2 { get; set; }
        public char a3 { get; set; }
        public char b1 { get; set; }
        public char b2 { get; set; }
        public char b3 { get; set; }
        public char c1 { get; set; }
        public char c2 { get; set; }
        public char c3 { get; set; }
    }
}
