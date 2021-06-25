using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quartz.XP.Models
{
    class Bundle
    {
        public int id { get; set; }
        public string[] exclusive {get; set;}
        public Badge[] assembly {get; set;}
        public Puzzle[] Pool { get; set; }
    }
}
