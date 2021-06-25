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
            levels.Add(this.radioButton1,1);
            levels.Add(this.radioButton2,2);
            levels.Add(this.radioButton3,3);
            levels.Add(this.radioButton4,4);
            levels.Add(this.radioButton5,5);
        }

        public int Level {get; set;}
        private Hashtable levels;

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
            }
        }
    }
}
