using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.WinControls.UI;

namespace Quartz.XP.Controls
{
    class QuartzCellElement : GridDataCellElement
    {
        public QuartzCellElement(GridViewColumn column, GridRowElement row) : base(column, row)
        {

        }

        protected override void CreateChildElements()
        {
            base.CreateChildElements();

            //radProgressBarElement = new RadProgressBarElement();
            //this.Children.Add(radProgressBarElement);
        }
    }
}
