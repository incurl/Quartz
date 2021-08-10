using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Quartz.XP.Controls
{
    public partial class Scale : UserControl
    {
        public Scale()
        {
            InitializeComponent();
            levels = new Hashtable();
            levels.Add(this.radioButton1, 1);
            levels.Add(this.radioButton2, 2);
            levels.Add(this.radioButton3, 3);
            levels.Add(this.radioButton4, 4);
            levels.Add(this.radioButton5, 5);
        }

        private int level;
        public int Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
                if (level == 0)
                {
                    foreach (DictionaryEntry s in levels)
                    {
                        ((RadioButton)s.Key).Checked = false;
                    }
                }
                else
                {
                    foreach (DictionaryEntry s in levels)
                    {
                        if ((int)s.Value == value)
                        {
                            ((RadioButton)s.Key).Checked = true;
                        }
                    }
                }
            }
        }
        
        private Hashtable levels;
        public event EventHandler<ScaleChangedEventArgs> PuzzleDifficultyChanged;

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb == null)
            {
                return;
            }

            // Ensure that the RadioButton.Checked property
            // changed to true.
            if (rb.Checked)
            {
                this.Level = (int)levels[rb];
                OnPuzzleDifficultyChanged(new ScaleChangedEventArgs(this.Level));
            }
        }

        protected virtual void OnPuzzleDifficultyChanged(ScaleChangedEventArgs e)
        {
            EventHandler<ScaleChangedEventArgs> handler = PuzzleDifficultyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

    }

    public class ScaleChangedEventArgs : EventArgs
    {
        public ScaleChangedEventArgs(int level)
        {
            Level = level;
        }
        public int Level { get; set; }

    }

}
