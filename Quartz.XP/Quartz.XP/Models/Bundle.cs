using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiteDB;
using Newtonsoft.Json;

namespace Quartz.XP.Models
{
    public class Bundle
    {
        public int id { get; set; }
        public string[] exclusive {get; set;}
        public string Moniker { get; set; }
        public Badge[] assembly {get; set;}
        [BsonIgnore]
        [JsonIgnore]
        public Puzzle[] Pool { get; set; }
        [BsonIgnore]
        [JsonIgnore]
        public string Title {
            get
            {
                return (Moniker != null) ? Moniker : id.ToString();
            }
        }

        public Badge[,] Transformed() 
        {
            int index = 0;
            int Rows=11;
            int Columns=11;
            Badge[,] twoDimensionalArray = new Badge[Rows, Columns];
            
            for (int x = 0; x < Rows; x++)
            {
                for (int y = 0; y < Columns; y++)
                {
                    Badge badge = assembly[index];
                    badge.eye = exclusive[index];
                    badge.Puzzle = Pool[index];
                    twoDimensionalArray[x, y] = badge;
                    index++;
                }
            }
            return twoDimensionalArray;
        }
    }
}
