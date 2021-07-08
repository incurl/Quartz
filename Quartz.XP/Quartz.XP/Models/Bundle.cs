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
        public string Moniker { get; set; }
        public Badge[] badges {get; set;}
        [BsonIgnore]
        [JsonIgnore]
        public List<Puzzle> Pool { get; set; }
        [BsonIgnore]
        [JsonIgnore]
        public string Title {
            get
            {
                return (Moniker != null) ? Moniker : id.ToString();
            }
        }

        public void Initilaize(List<Puzzle> puzzles)
        {
            int index = 0;
            foreach (Puzzle puzzle in puzzles)
            {
                Badge badge = badges[index];
                puzzle.Badge=badge;
                index++;
            }
            this.Pool=puzzles;
        }

        private Dictionary<Func<int, bool>, Tuple<int, int>> squareSwitch = new Dictionary<Func<int, bool>, Tuple<int, int>>
            { 
             { x => x <=49,    Tuple.Create(7,7)},  
             { x => x <=64,    Tuple.Create(8,8)},
             { x => x <=81,    Tuple.Create(9,9)},
             { x => x <=100,   Tuple.Create(10,10)},
             { x => x <=121 ,  Tuple.Create(11,11)}
            };

        public Puzzle[,] Waiting()
        {
            int index = 0;
            Puzzle[] waiting= Pool.Where<Puzzle>(x=>(!x.Binned)).ToArray();
            int count = waiting.Count<Puzzle>();
            Tuple<int, int> t = squareSwitch.First(sw => sw.Key(waiting.Count<Puzzle>())).Value;
            int Rows = t.Item1;
            int Columns = t.Item2;
            Puzzle[,] twoDimensionalArray = new Puzzle[Rows, Columns];

            for (int x = 0; x < Rows; x++)
            {
                for (int y = 0; y < Columns; y++)
                {
                    if (index < count)
                    {
                        Puzzle puzzle = waiting[index];
                        twoDimensionalArray[x, y] = puzzle;
                    }
                    index++;
                }
            }
            return twoDimensionalArray;
        }

        public Puzzle[,] Binned()
        {
            int index = 0;
            Puzzle[] binned = Pool.Where<Puzzle>(x => (x.Binned)).ToArray();
            int count = binned.Count<Puzzle>();
            Tuple<int, int> t = squareSwitch.First(sw => sw.Key(count)).Value;
            int Rows = t.Item1;
            int Columns = t.Item2;
            Puzzle[,] twoDimensionalArray = new Puzzle[Rows, Columns];

            for (int x = 0; x < Rows; x++)
            {
                for (int y = 0; y < Columns; y++)
                {
                    if (index < count)
                    {
                        Puzzle puzzle = binned[index];
                        twoDimensionalArray[x, y] = puzzle;
                    }
                    index++;
                }
            }
            return twoDimensionalArray;
        }

    }
}
