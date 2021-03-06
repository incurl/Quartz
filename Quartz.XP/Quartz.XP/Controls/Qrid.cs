using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Quartz.XP.Models;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Accord.Controls;
using Quartz.XP.Controls.Elements;

namespace Quartz.XP.Controls
{
    public partial class Qrid : UserControl
    {
        public Qrid()
        {
            InitializeComponent();
            InitializeCrystal();
        }

        private void InitializeCrystal()
        {
            crystal.Add(4);
            crystal.Add(5);
            crystal.Add(6);
        }

        private HashSet<int> crystal = new HashSet<int>();
        private Puzzle puzzle;
        public event EventHandler<GridViewCellEventArgs> ColumnBingo;
        public event EventHandler<GridViewCellEventArgs> RowBingo;
        public event EventHandler<GridViewCellEventArgs> ColumnMiss;
        public event EventHandler<GridViewCellEventArgs> RowMiss;
        public event EventHandler<GridViewCellEventArgs> TileMeUp;
        public event EventHandler<GridViewCellEventArgs> TileMeDown;

        public void SetBoard(Puzzle p)
        {
            this.puzzle = p;
            this.grid.DataSource = new ArrayDataView(this.puzzle.Quartz);
            this.grid.TableElement.RowHeight = 31;
            foreach (GridViewDataColumn col in grid.Columns)
            {
                col.Width = 48;
            }
            
            for (int x = 0; x < p.Quartz.GetLength(0); x += 1)
            {
                for (int y = 0; y < p.Quartz.GetLength(1); y += 1)
                {
                    if (crystal.Contains(x) && crystal.Contains(y))
                    {

                    }
                    else
                    {
                        
                    }
                }
            }
        }

        private void grid_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (crystal.Contains(e.CellElement.ColumnIndex) && crystal.Contains(e.CellElement.RowIndex))
            {
                GridViewCellInfo cell=grid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.Style.CustomizeFill = true;
                cell.Style.DrawFill = true;
                cell.Style.BackColor = Color.AliceBlue;
                //e.CellElement.AllowDrop = true;
                //e.CellElement.AllowDrag = true;
            }
            else
            {
                e.CellElement.Enabled = false;
                e.CellElement.AllowDrop = false;
                e.CellElement.AllowDrag = false;
            }
        }

        private void grid_RowFormatting(object sender, RowFormattingEventArgs e)
        {
        }

        private void grid_CreateCell(object sender, GridViewCreateCellEventArgs e)
        {
            if (crystal.Contains(e.Column.Index) && crystal.Contains(e.Row.RowInfo.Index))
            {
                e.CellElement = new CrystalCellElement(e.Column, e.Row);
            }
            else
            {
                e.CellElement = new QuartzCellElement(e.Column, e.Row);
            }
        }

        private void grid_CellClick(object sender, GridViewCellEventArgs e)
        {
            int r=e.RowIndex;
            int c=e.ColumnIndex;
            bool columnBingo=true;
            bool rowBingo = true;
            for(int i=4;i<7;i++)
            {
                if(((Cell)grid.Rows[r].Cells[i].Value).guess!=((Cell)grid.Rows[r].Cells[i].Value).s)
                {
                    rowBingo=false;
                }
                if(((Cell)grid.Rows[i].Cells[c].Value).guess!=((Cell)grid.Rows[i].Cells[c].Value).s)
                {
                    columnBingo = false;
                }
            }
            if (columnBingo)
            {
                OnColumnBingo(e);
            }
            else
            {
                OnColumnMiss(e);
            }
            if (rowBingo)
            {
                OnRowBingo(e);
            }
            else
            {
                OnRowMiss(e);
            }

            if (crystal.Contains(c) && crystal.Contains(r))
            {
                OnTileMeUp(e);
            }
        }

        protected virtual void OnColumnBingo(GridViewCellEventArgs e)
        {
            EventHandler<GridViewCellEventArgs> handler = ColumnBingo;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnRowBingo(GridViewCellEventArgs e)
        {
            EventHandler<GridViewCellEventArgs> handler = RowBingo;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnColumnMiss(GridViewCellEventArgs e)
        {
            EventHandler<GridViewCellEventArgs> handler = ColumnMiss;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnRowMiss(GridViewCellEventArgs e)
        {
            EventHandler<GridViewCellEventArgs> handler = RowMiss;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnTileMeUp(GridViewCellEventArgs e)
        {
            EventHandler<GridViewCellEventArgs> handler = TileMeUp;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnTileMeDown(GridViewCellEventArgs e)
        {
            EventHandler<GridViewCellEventArgs> handler = TileMeDown;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void Update_Qrid(object sender, GridViewCellEventArgs e)
        {
            this.grid.TableElement.Update(GridUINotifyAction.StateChanged);
            e.Row.InvalidateRow();
        }

        private void grid_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void grid_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            int c = e.ColumnIndex;
            if (crystal.Contains(c) && crystal.Contains(r))
            {
                OnTileMeDown(e);
            }
        }

        public void Reset_Puzzle(object sender, EventArgs e)
        {
            for (int r = 4; r <7; r++){
                for (int i = 4; i < 7; i++)
                {
                    GridViewRowInfo rowInfo = grid.Rows[r];
                    GridViewColumn column = grid.Columns[i];
                    if(((Cell)grid.Rows[r].Cells[i].Value).guess != null) {
                        GridViewCellEventArgs ex = new GridViewCellEventArgs(rowInfo, column, null);
                        OnTileMeDown(ex);
                    }
                }
            }
        }

        public void Reveal_Puzzle(object sender, EventArgs e)
        {

        }

    }
}
