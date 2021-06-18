﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security;
using LiteDB;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Quartz.XP.Models;
using System.Linq.Expressions;

namespace Quartz.XP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            openFileDialog1 = new OpenFileDialog();
            InitializeDb();
            WireUp();
        }

        private void WireUp()
        {
            this.qrid.ColumnBingo += this.slabColumn.qrid_ColumnBingo;
            this.qrid.ColumnMiss += this.slabColumn.qrid_ColumnMiss;
            this.qrid.RowBingo += this.slabColumn.qrid_RowBingo;
            this.qrid.RowMiss += this.slabColumn.qrid_RowMiss;
        }

        private void InitializeDb()
        {
            BsonMapper.Global.RegisterType<Cell[,]>
            (
                serialize: (Func<Cell[,], BsonValue>)(array =>
                {
                    var bsonArray = new BsonArray();
                    int I_LEN = array.GetLength(0);
                    int J_LEN = array.GetLength(1);

                    bsonArray.Add(I_LEN);
                    bsonArray.Add(J_LEN);

                    for (int i = 0; i < I_LEN; i++)
                    {
                        var arr = new BsonArray();
                        for (int j = 0; j < J_LEN; j++)
                        {
                            Cell cell = array[i, j];
                            BsonDocument d = new BsonDocument();
                            d["s"] = cell.s;
                            d["c"] = cell.c;
                            d["r"] = cell.r;
                            arr.Add(d);
                        }
                        bsonArray.Add(arr);
                    }
                    return bsonArray;
                }),
                deserialize: (Func<BsonValue, Cell[,]>)(bson =>
                {
                    var bsonArray = bson.AsArray;
                    int I_LEN = bsonArray[0];
                    int J_LEN = bsonArray[1];

                    Cell[,] array = new Cell[I_LEN, J_LEN];

                    for (int x = 2, i = 0; x < bsonArray.Count; x++)
                    {
                        var arr = bsonArray[x].AsArray;
                        int j = 0;
                        foreach (BsonValue v in arr)
                        {
                            BsonDocument d = v.AsDocument;
                            Cell c = new Cell { c = d["c"].AsInt32, r = d["r"].AsInt32, s = d["s"] };
                            array[i, j] = c;
                            j++;
                        }
                        i++;
                    }

                    return array;
                })
            );

            using (var db = new LiteDatabase(@".\Data\Quartz.db"))
            {
                var col = db.GetCollection<Puzzle>("puzzle");
                col.EnsureIndex<int>(x => x.id);
                col.EnsureIndex<bool>(x => x.Solved);
                puzzles = col.Find(x => x.Solved == false).ToList<Puzzle>();
            }
            bindingSource.DataSource = puzzles;
        }

        private OpenFileDialog openFileDialog1;
        private List<Puzzle> puzzles;

        private void radMenuItem2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sr = new StreamReader(openFileDialog1.FileName);
                    var json = sr.ReadToEnd();
                    puzzles = JsonConvert.DeserializeObject<List<Puzzle>>(json);

                    importJson();
                }
                catch (SecurityException ex)
                {
                    //MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +$"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void importJson()
        {
            using (var db = new LiteDatabase(@"E:\Projects\Visual Studio\Quartz\Quartz.XP\Quartz.XP\Data\Quartz.db"))
            {
                var col = db.GetCollection<Puzzle>("puzzle");
                foreach (Puzzle p in puzzles)
                {
                    col.Insert(p);
                }
                col.EnsureIndex<int>(x => x.id);
                col.EnsureIndex<bool>(x => x.Solved);
            }
        }

        private void bindingSource_CurrentChanged(object sender, EventArgs e)
        {
            Puzzle puzzle=(Puzzle)this.bindingSource.Current;
            this.rack.roulette_tiles(puzzle);
            this.qrid.SetBoard(puzzle);
        }
    }
}
