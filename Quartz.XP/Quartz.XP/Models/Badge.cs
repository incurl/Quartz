using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiteDB;
using Newtonsoft.Json;

namespace Quartz.XP.Models
{
    public class Badge
    {
        public int e { get; set; }
        public int p { get; set; }
        [BsonIgnore]
        [JsonIgnore]
        public Puzzle Puzzle { get; set; }
        [BsonIgnore]
        [JsonIgnore]
        public string eye { get; set; }

    }
}
