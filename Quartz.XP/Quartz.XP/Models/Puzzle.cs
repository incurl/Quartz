using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiteDB;
using Newtonsoft.Json;

namespace Quartz.XP.Models
{
    public class Puzzle
    {
        public int id { get; set; }
        public Cell[,] Quartz { get; set; }
        public Poem[] Poems { get; set; }
        public String a1 { get; set; }
        public String a2 { get; set; }
        public String a3 { get; set; }
        public String b1 { get; set; }
        public String b2 { get; set; }
        public String b3 { get; set; }
        public String c1 { get; set; }
        public String c2 { get; set; }
        public String c3 { get; set; }
        public int Difficulty { get; set; }
        public bool Binned { get; set; }
        [JsonIgnore]
        public bool Solved { get; set; }

    }
}
