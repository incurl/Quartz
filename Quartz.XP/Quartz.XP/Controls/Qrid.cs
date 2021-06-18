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
using Accord.Controls;

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

        public void SetBoard(Puzzle p)
        {
            this.grid.DataSource = new ArrayDataView(p.Quartz);
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
                e.CellElement.BackColor = Color.Red;
                e.CellElement.AllowDrop = true;
                e.CellElement.AllowDrag = true;
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
            e.CellElement = new QuartzCellElement(e.Column, e.Row);
        }
    }
}
