using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiteDB;
using Newtonsoft.Json;
using System.Collections.Generic;

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
        public bool Solved { get; set; }

        [BsonIgnore]
        [JsonIgnore]
        public Dictionary<Tuple<int,int>, string> Solution
        {
            get
            {
                Dictionary<Tuple<int,int>, string> s= new Dictionary<Tuple<int,int>, string>();
                s.Add(new Tuple<int,int>(4, 4),a1);
                s.Add(new Tuple<int,int>(4, 5),a2);
                s.Add(new Tuple<int,int>(4, 6),a3);
                s.Add(new Tuple<int,int>(5, 4),b1);
                s.Add(new Tuple<int,int>(5, 5),b2);
                s.Add(new Tuple<int,int>(5, 6),b3);
                s.Add(new Tuple<int,int>(6, 4),c1);
                s.Add(new Tuple<int,int>(6, 5),c2);
                s.Add(new Tuple<int,int>(6, 6),c3);
                return s;
            }
        }
    }
}
