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

namespace Quartz.XP.Controls
{
    public partial class Qrid : UserControl
    {
        public Qrid()
        {
            InitializeComponent();
        }

        public void SetBoard(Puzzle p)
        {
            this.grid.DataSource = new ArrayDataView(p.Quartz);
            foreach (GridViewDataColumn col in grid.Columns)
            {
                col.Width = 48;
            }
            //for (int x = 0; x < p.Quartz.GetLength(0); x += 1)
            //{
            //    for (int y = 0; y < p.Quartz.GetLength(1); y += 1)
            //    {
            //        Console.Write(p.Quartz[x, y]);
            //    }
            //} 
        }
    }
}
