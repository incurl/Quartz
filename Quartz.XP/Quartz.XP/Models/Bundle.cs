using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiteDB;
using Newtonsoft.Json;

namespace Quartz.XP.Models
{
    class Bundle
    {
        public int id { get; set; }
        public string[] exclusive {get; set;}
        public Badge[] assembly {get; set;}
        [BsonIgnore]
        [JsonIgnore]
        public Puzzle[] Pool { get; set; }
    }
}
