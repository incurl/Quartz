using System;
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
using Telerik.WinControls.UI;
using Quartz.XP.Controls;

namespace Quartz.XP
{
    public partial class Form1 : Form
    {
        static Form1()
        {
            Telerik.WinControls.RadTypeResolver.Instance.ResolveTypesInCurrentAssembly = true;
        }
        
        public Form1()
        {
            InitializeComponent();
            openFileDialog1 = new OpenFileDialog();
            WireUp();
            InitializeDb();
        }

        public event EventHandler<GridViewCellEventArgs> UpdateQrid;
        public event EventHandler<GridViewCellEventArgs> UpdateRack;

        private void WireUp()
        {
            this.qrid.ColumnBingo += this.slabColumn.qrid_ColumnBingo;
            this.qrid.ColumnMiss += this.slabColumn.qrid_ColumnMiss;
            this.qrid.RowBingo += this.slabRow.qrid_RowBingo;
            this.qrid.RowMiss += this.slabRow.qrid_RowMiss;
            this.qrid.TileMeUp += this.qrid_TileMeUp;
            this.qrid.TileMeDown += this.qrid_TileMeDown;
            this.UpdateQrid += this.qrid.Update_Qrid;
            this.UpdateRack += this.rack.Update_Rack;
            this.audition.BundleSwitch += this.audition_bundleSwitch;
            this.judge.RevealQrid += this.qrid.Reveal_Puzzle;
            this.judge.ResetQrid += this.qrid.Reset_Puzzle;
            this.audition.SelectPuzzle += this.Select_Puzzle;
            this.audition.SelectPuzzle += this.judge.Select_Puzzle;
            this.judge.BundlePropertyChanged += this.audition.BundleProperyChanged;
            this.judge.PuzzlePropertyChanged += this.audition.PuzzlePropertyChanged;
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
            Load_Data();
        }

        private void Load_Data()
        {
            using (var db = new LiteDatabase(@".\Data\Quartz.db"))
            {
                var col = db.GetCollection<Bundle>("bundle");
                bundles = col.FindAll().ToList<Bundle>();
            }
            this.audition.BindingSourceBundle.DataSource = bundles;
            if (bundles.Count != 0)
            {
                this.audition.SetUpCombo();
            }
        }

        private OpenFileDialog openFileDialog1;
        private Bundle bundle;
        private List<Bundle> bundles;
        private List<Puzzle> puzzles;

        private void importBundleJson()
        {
            using (var db = new LiteDatabase(@".\Data\Quartz.db"))
            {
                var col = db.GetCollection<Bundle>("bundle");
                col.Insert(bundle);
            }
        }

        private void importPuzzleJson()
        {
            using (var db = new LiteDatabase(@".\Data\Quartz.db"))
            {
                var col = db.GetCollection<Puzzle>("puzzle");
                foreach (Puzzle p in puzzles)
                {
                    col.Insert(p);
                }
                col.EnsureIndex<int>(x => x.id);
                col.EnsureIndex<bool>(x => x.Solved);
                col.EnsureIndex<bool>(x => x.Starred);
                col.EnsureIndex<bool>(x => x.Binned);
            }
        }

        public void Select_Puzzle(object sender, SelectPuzzleEventArgs e)
        {
            Puzzle puzzle = e.Puzzle;
            this.rack.roulette_tiles(puzzle);
            this.qrid.SetBoard(puzzle);
            this.slabColumn.SetPoems(puzzle.Poems.Take<Poem>(3));
            this.slabRow.SetPoems(puzzle.Poems.Skip<Poem>(3).Take<Poem>(3));
        }

        public void qrid_TileMeUp(object sender, GridViewCellEventArgs e)
        {
            string g = ((Cell)e.Value).guess;
            string candidate = this.rack.Candidate;
            if (g != null && g != candidate && candidate != null)
            {
                this.rack.Restore_Tile(g);
            }
            if (candidate != null)
            {
                ((Cell)e.Value).guess = candidate;
                OnUpdateQrid(e);
                OnUpdateRack(e);
            }

        }

        public void qrid_TileMeDown(object sender, GridViewCellEventArgs e)
        {
            string g = ((Cell)e.Value).guess;
            if (g != null)
            {
                this.rack.Restore_Tile(g);
                ((Cell)e.Value).guess=null;
                this.OnUpdateQrid(e);
            }
        }

        protected virtual void OnUpdateQrid(GridViewCellEventArgs e)
        {
            EventHandler<GridViewCellEventArgs> handler = UpdateQrid;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnUpdateRack(GridViewCellEventArgs e)
        {
            EventHandler<GridViewCellEventArgs> handler = UpdateRack;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void radMenuItem6_Click(object sender, EventArgs e)
        {
            if (bundle != null)
            {
                importBundleJson();
            }
            if (puzzles != null)
            {
                importPuzzleJson();
            }
            Load_Data();
        }

        private void radMenuItem7_Click(object sender, EventArgs e)
        {
            using (var db = new LiteDatabase(@".\Data\Quartz.db"))
            {
                var col = db.GetCollection<Bundle>("bundle");
                col.Delete(Query.All());
            }
        }

        private void radMenuItemWeb_Click(object sender, EventArgs e)
        {
            FormWeb frm = new FormWeb();
            frm.ShowDialog();
        }

        private void audition_bundleSwitch(object sender, BundleSwitchEventArgs e)
        {
            int id = e.BundleId;
            using (var db = new LiteDatabase(@".\Data\Quartz.db"))
            {
                var col = db.GetCollection<Bundle>("bundle");
                Bundle bundle = col.FindById(id);
                Badge[] badges = bundle.badges;
                int[] pids = badges.Select(x => x.p).ToArray();
                var col_pzl = db.GetCollection<Puzzle>("puzzle");
                List<Puzzle> puzzles=new List<Puzzle>();
                foreach(int pid in pids)
                {
                    puzzles.Add(col_pzl.FindById(pid));
                }
                bundle.Initilaize(puzzles);
                this.judge.Idol = bundle;
                this.audition.Idol = bundle;
            }
        }

        private void radMenuItemFileBundle_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sr = new StreamReader(openFileDialog1.FileName);
                    var json = sr.ReadToEnd();
                    bundle = JsonConvert.DeserializeObject<List<Bundle>>(json).First<Bundle>();
                }
                catch (SecurityException ex)
                {
                    //MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +$"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void radMenuItemFilePuzzles_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sr = new StreamReader(openFileDialog1.FileName);
                    var json = sr.ReadToEnd();
                    puzzles = JsonConvert.DeserializeObject<List<Puzzle>>(json);

                }
                catch (SecurityException ex)
                {
                    //MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +$"Details:\n\n{ex.StackTrace}");
                }
            }

        }

        private void radMenuItemxVerse_Click(object sender, EventArgs e)
        {
            FormxVerse frm = new FormxVerse();
            frm.ShowDialog();
        }

    }

}
