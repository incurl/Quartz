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
    public partial class Slab : UserControl
    {
        private IEnumerable<Poem> poems;
        public Slab()
        {
            InitializeComponent();
        }

        public void SetPoems(IEnumerable<Poem> ps)
        {
            this.poems = ps;
            this.qrid_ColumnMiss(null, null);
            this.qrid_RowMiss(null, null);
        }

        protected void DisplayPoem(Poem poem)
        {
            this.tbTitle.Text=poem.Title;
            this.tbText.Text=poem.Text;
            this.tbPoet.Text=poem.Author;
        }

        public void qrid_ColumnBingo(object sender, GridViewCellEventArgs e)
        {
            int c = ((Cell)e.Value).c;
            foreach (Poem p in this.poems)
            {
                if (p.id == c)
                {
                    this.DisplayPoem(p);
                }
            }
        }

        public void qrid_RowBingo(object sender, GridViewCellEventArgs e)
        {
            int r = ((Cell)e.Value).r;
            foreach (Poem p in this.poems)
            {
                if (p.id == r)
                {
                    this.DisplayPoem(p);
                }
            }
        }

        public void qrid_ColumnMiss(object sender, GridViewCellEventArgs e)
        {
            this.tbPoet.Text = "";
            this.tbText.Text = "";
            this.tbTitle.Text = "";
        }

        public void qrid_RowMiss(object sender, GridViewCellEventArgs e)
        {
            this.tbPoet.Text = "";
            this.tbText.Text = "";
            this.tbTitle.Text = "";
        }

    }
}
