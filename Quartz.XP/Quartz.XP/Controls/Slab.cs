﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Quartz.XP.Models;

namespace Quartz.XP.Controls
{
    public partial class Slab : UserControl
    {
        public Slab()
        {
            InitializeComponent();
        }

        public void DisplayPoem(Poem poem)
        {
            this.tbTitle.Text=poem.Title;
            this.tbText.Text=poem.Text;
            this.tbPoet.Text=poem.Author;
        }

        public void qrid_ColumnBingo(object sender, EventArgs e)
        {
        }

        public void qrid_RowBingo(object sender, EventArgs e)
        {
        }

        public void qrid_ColumnMiss(object sender, EventArgs e)
        {
            this.tbPoet.Text = "";
            this.tbText.Text = "";
            this.tbTitle.Text = "";
        }

        public void qrid_RowMiss(object sender, EventArgs e)
        {
            this.tbPoet.Text = "";
            this.tbText.Text = "";
            this.tbTitle.Text = "";
        }

    }
}
