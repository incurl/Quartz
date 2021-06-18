using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Quartz.XP.Controls
{
    public partial class Tile : Button
    {
        public Tile()
        {
            InitializeComponent();
        }

        private bool played = false;

        public bool Played
        {
            get
            {
                return played;
            }
            set
            {
                played = value;
                if (value) base.Enabled = false;
            }
        }

        public bool Pick()
        {
            if (!this.Played)
            {
                base.Enabled = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void UnPick()
        {
            if (!this.Played) base.Enabled = true;
        }
    }
}
