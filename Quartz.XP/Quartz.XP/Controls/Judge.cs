using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Quartz.XP.Models;
using LiteDB;
using Telerik.WinControls.UI;

namespace Quartz.XP.Controls
{
    public partial class Judge : UserControl
    {
        public Judge()
        {
            InitializeComponent();
            WireUp();
        }

        private void WireUp()
        {
            this.scale1.PuzzleDifficultyChanged += this.PuzzleDifficultyChanged;
            this.scale1.Enabled = false;
            this.radRating1.Enabled = false;
            this.buttonReset.Enabled = false;
            this.buttonReveal.Enabled = false;
        }

        private Bundle idol;
        public Bundle Idol
        {
            get
            {
                return idol;
            }
            set
            {
                idol=value;
                this.propertyGridBundle.SelectedObject = idol;
            }
        }

        private Puzzle puzzle;
        public Puzzle Puzzle
        {
            get
            {
                return puzzle;
            }
            set
            {
                puzzle = value;
                //this.scale1.Enabled = false;
                this.scale1.Level = puzzle.Difficulty;
                this.scale1.Enabled = true;
                //this.radRating1.Enabled = false;
                this.radRating1.Value = puzzle.Starred ? 100 : 0;
                this.radRating1.Enabled = true;
                this.buttonReveal.Enabled = true;
                this.buttonReset.Enabled = true;
            } 
        }

        public event EventHandler<EventArgs> RevealQrid;
        public event EventHandler<EventArgs> ResetQrid;
        public event EventHandler<BundleChangedEventArgs> BundlePropertyChanged;
        public event EventHandler<PuzzlePropertyChangedEventArgs> PuzzlePropertyChanged;

        protected virtual void OnRevealQrid(EventArgs e)
        {
            EventHandler<EventArgs> handler = RevealQrid;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnResetQrid(EventArgs e)
        {
            EventHandler<EventArgs> handler = ResetQrid;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnBundleProperyChanged(BundleChangedEventArgs e)
        {
            EventHandler<BundleChangedEventArgs> handler = BundlePropertyChanged;
            if (handler != null)
            {
                handler(this, e);
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

        private void buttonReset_Click(object sender, EventArgs e)
        {
            OnResetQrid(e);
        }

        private void buttonReveal_Click(object sender, EventArgs e)
        {
            OnRevealQrid(e);
        }

        private void propertyGridBundle_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            using (var db = new LiteDatabase(@".\Data\Quartz.db"))
            {
                string value = (string)(e.ChangedItem.Value);
                this.Idol.Moniker = value;
                var col = db.GetCollection<Bundle>("bundle");
                col.Update(this.Idol);
            }
            OnBundleProperyChanged(new BundleChangedEventArgs(this.Idol));
        }

        public void Select_Puzzle(object sender, SelectPuzzleEventArgs e)
        {
            this.Puzzle = e.Puzzle;
        }

        public void PuzzleDifficultyChanged(object sender, ScaleChangedEventArgs e)
        {
            if (this.Puzzle.Difficulty != e.Level)
            {
                this.Puzzle.Difficulty = e.Level;
                OnPuzzlePropertyChanged(new PuzzlePropertyChangedEventArgs(this.Puzzle));
            }
        }

        private void radRating1_ValueChanged(object sender, EventArgs e)
        {
            bool starred = ((RadRating)sender).Value > 50;
            if (this.puzzle.Starred != starred)
            {
                this.puzzle.Starred = starred;
                OnPuzzlePropertyChanged(new PuzzlePropertyChangedEventArgs(this.puzzle));
            }

        }

    }

    public class BundleChangedEventArgs : EventArgs
    {
        public BundleChangedEventArgs(Bundle b)
        {
            Bundle = b;
        }
        public Bundle Bundle { get; set; }
    }

    public class PuzzlePropertyChangedEventArgs : EventArgs
    {
        public PuzzlePropertyChangedEventArgs(Puzzle puzzle)
        {
            Puzzle = puzzle;
        }
        public Puzzle Puzzle { get; set; }
    }


}
