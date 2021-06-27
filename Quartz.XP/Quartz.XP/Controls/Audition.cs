﻿using System;
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

namespace Quartz.XP.Controls
{
    public partial class Audition : UserControl
    {
        public Audition()
        {
            InitializeComponent();
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
                this.waitingGrid.DataSource=null;
                this.waitingGrid.DataSource = new ArrayDataView(idol.Waiting());
                this.binGrid.DataSource = null;
                this.binGrid.DataSource = new ArrayDataView(idol.Binned());
            }
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
