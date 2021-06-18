using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiteDB;
using Newtonsoft.Json;

namespace Quartz.XP.Models
{
    public class Cell
    {
        public String s { get; set; }
        public int c { get; set; }
        public int r { get; set; }

        [BsonIgnore]
        [JsonIgnore]
        public string guess { get; set; }
    }
}
