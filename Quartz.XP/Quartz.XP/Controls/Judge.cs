﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Quartz.XP.Models;
using LiteDB;

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
        public event EventHandler<BundleChangedEventArgs> BundlePropertyChanged;

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

    }

    public class BundleChangedEventArgs : EventArgs
    {
        public BundleChangedEventArgs(Bundle b)
        {
            Bundle = b;
        }
        public Bundle Bundle { get; set; }
    }

}
