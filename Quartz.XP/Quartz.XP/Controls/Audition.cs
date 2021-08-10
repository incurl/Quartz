using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Quartz.XP.Models;
using Accord.Controls;
using Telerik.WinControls.UI;
using Quartz.XP.Controls.Elements;
using LiteDB;
using System.Drawing;

namespace Quartz.XP.Controls
{
    public partial class Audition : UserControl
    {
        public Audition()
        {
            InitializeComponent();
            WireUp();
        }

        private Color[] colors = new Color[6];
        private void WireUp()
        {
            this.PuzzleBinnedChanged += this.PuzzlePropertyChanged;
            colors[0] = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            colors[1] = Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(228)))), ((int)(((byte)(139)))));
            colors[2] = Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(231)))), ((int)(((byte)(141)))));
            colors[3] = Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(201)))), ((int)(((byte)(111)))));
            colors[4] = Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(148)))), ((int)(((byte)(99)))));
            colors[5] = Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(97)))), ((int)(((byte)(39)))));
        }

        public BindingSource BindingSourceBundle
        {
            get { return this.bindingSourceBundle; }
        }

        public void SetUpCombo()
        {
            this.comboBox1.DisplayMember = "Title";
            this.comboBox1.ValueMember = "id";
            this.comboBox1.SelectedIndex = 0;
        }

        public event EventHandler<BundleSwitchEventArgs> BundleSwitch;
        public event EventHandler<SelectPuzzleEventArgs> SelectPuzzle;
        public event EventHandler<PuzzlePropertyChangedEventArgs> PuzzleBinnedChanged;

        private Bundle idol;
        public Bundle Idol
        {
            get
            {
                return idol;
            }
            set
            {
                idol = value;
                if (idol != null)
                {
                    this.waitingGrid.DataSource = new ArrayDataView(idol.Waiting());
                    foreach (GridViewDataColumn col in this.waitingGrid.Columns)
                    {
                        col.Width = 45;
                    }
                    this.binGrid.DataSource = new ArrayDataView(idol.Binned());
                    foreach (GridViewDataColumn col in this.binGrid.Columns)
                    {
                        col.Width = 45;
                    }
                    apply_difficulty_colors();
                }
            }
        }

        protected virtual void OnBundleSwitch(BundleSwitchEventArgs e)
        {
            EventHandler<BundleSwitchEventArgs> handler = BundleSwitch;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnSelectPuzzle(SelectPuzzleEventArgs e)
        {
            EventHandler<SelectPuzzleEventArgs> handler = SelectPuzzle;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnPuzzleBinnedChanged(PuzzlePropertyChangedEventArgs e)
        {
            EventHandler<PuzzlePropertyChangedEventArgs> handler = PuzzleBinnedChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox combo=(ComboBox)sender;
            if (combo.SelectedIndex != -1)
            {
                if (combo.SelectedValue.GetType().ToString() != "Quartz.XP.Models.Bundle")
                {
                    BundleSwitchEventArgs bse = new BundleSwitchEventArgs((int)combo.SelectedValue);
                    OnBundleSwitch(bse);
                }
            }
        }

        protected virtual void OnPuzzlePropertyChanged(PuzzlePropertyChangedEventArgs e)
        {
            EventHandler<PuzzlePropertyChangedEventArgs> handler = PuzzlePropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void binGrid_CellFormatting(object sender, CellFormattingEventArgs e)
        {

        }

        private void binGrid_CreateCell(object sender, GridViewCreateCellEventArgs e)
        {
            e.CellElement = new BadgeCellElement(e.Column, e.Row);
        }

        private void binGrid_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void waitingGrid_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void waitingGrid_CellFormatting(object sender, CellFormattingEventArgs e)
        {

        }

        private void grid_CellClick(object sender, GridViewCellEventArgs e)
        {
            var v = e.Value;
            if (v != null)
            {
                Puzzle puzzle = (Puzzle)v;
                OnSelectPuzzle(new SelectPuzzleEventArgs(puzzle));
            }
        }

        private void waitingGrid_CreateCell(object sender, GridViewCreateCellEventArgs e)
        {
            e.CellElement = new BadgeCellElement(e.Column, e.Row);
        }

        private void grid_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            var v = e.Value;
            if (v != null)
            {
                Puzzle puzzle = (Puzzle)v;
                puzzle.Binned = !puzzle.Binned;
                this.OnPuzzleBinnedChanged(new PuzzlePropertyChangedEventArgs(puzzle));
            }
        }

        private void update_grids()
        {
            this.waitingGrid.DataSource = null;
            this.waitingGrid.DataSource = new ArrayDataView(idol.Waiting());
            foreach (GridViewDataColumn col in this.waitingGrid.Columns)
            {
                col.Width = 45;
            }
            this.binGrid.DataSource = null;
            this.binGrid.DataSource = new ArrayDataView(idol.Binned());
            foreach (GridViewDataColumn col in this.binGrid.Columns)
            {
                col.Width = 45;
            }
            apply_difficulty_colors();
        }

        private void apply_difficulty_colors()
        {
            RadGridView grid = this.waitingGrid;
            for (int y = 0; y < grid.RowCount; y++)
            {
                for (int x = 0; x < grid.ColumnCount; x++)
                {
                    GridViewCellInfo cell=grid.Rows[y].Cells[x];
                    if (cell.Value != null)
                    {
                        cell.Style.CustomizeFill = true;
                        cell.Style.DrawFill = true;
                        cell.Style.BackColor = colors[((Puzzle)cell.Value).Difficulty];
                    }
                }
            }

            grid = this.binGrid;
            for (int y = 0; y < grid.RowCount; y++)
            {
                for (int x = 0; x < grid.ColumnCount; x++)
                {
                    GridViewCellInfo cell=grid.Rows[y].Cells[x];
                    if (cell.Value != null)
                    {
                        cell.Style.CustomizeFill = true;
                        cell.Style.DrawFill = true;
                        cell.Style.BackColor = colors[((Puzzle)cell.Value).Difficulty];
                    }
                }
            }
        }

        public void BundleProperyChanged(object sender, BundleChangedEventArgs e)
        {
            Bundle b= e.Bundle;
            List<Bundle> bundles = (List<Bundle>)(this.BindingSourceBundle.DataSource);
            Bundle bundle=bundles.First(x => x.id == b.id);
            var index = bundles.IndexOf(bundle);
            if (index != -1)
            {
                bundles[index] = b;
            }
            this.BindingSourceBundle.ResetBindings(false);
        }

        public void PuzzlePropertyChanged(object sender, PuzzlePropertyChangedEventArgs e)
        {
            Puzzle p = e.Puzzle;
            using (var db = new LiteDatabase(@".\Data\Quartz.db"))
            {
                var col = db.GetCollection<Puzzle>("puzzle");
                var puzzle = col.FindById(p.id);
                puzzle.Difficulty = p.Difficulty;
                puzzle.Starred = p.Starred;
                puzzle.Binned = p.Binned;
                col.Update(puzzle);
            }
            update_grids();
        }

    }

    public class BundleSwitchEventArgs : EventArgs
    {
        public BundleSwitchEventArgs(int id)
        {
            BundleId = id;
        }

        public int BundleId { get; set; }
    }

    public class SelectPuzzleEventArgs : EventArgs
    {
        public SelectPuzzleEventArgs(Puzzle p)
        {
            Puzzle=p;
        }
        public Puzzle Puzzle {get; set;}
    }

}
