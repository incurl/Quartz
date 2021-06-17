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
    }
}