using System;
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
    public partial class Judge : UserControl
    {
        public Judge()
        {
            InitializeComponent();
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

        public event EventHandler<EventArgs> RevealQrid;
        public event EventHandler<EventArgs> ResetQrid;

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

        private void buttonReset_Click(object sender, EventArgs e)
        {
            OnResetQrid(e);
        }

        private void buttonReveal_Click(object sender, EventArgs e)
        {
            OnRevealQrid(e);
        }

    }
}
