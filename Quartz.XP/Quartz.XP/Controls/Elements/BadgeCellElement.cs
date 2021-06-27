using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.WinControls.UI;
using Quartz.XP.Models;

namespace Quartz.XP.Controls.Elements
{
    class BadgeCellElement: GridDataCellElement
    {
        public BadgeCellElement(GridViewColumn column, GridRowElement row)
            : base(column, row)
        {

        }

        private LightVisualElement lightVisualElement;

        protected override void CreateChildElements()
        {
            base.CreateChildElements();

            lightVisualElement = new LightVisualElement();
            this.Children.Add(lightVisualElement);
        }

        protected override void SetContentCore(object value)
        {
            if (this.Value != null && this.Value != DBNull.Value)
            {
                this.lightVisualElement.Text = ((Badge)value).eye;
            }
        }

        protected override Type ThemeEffectiveType
        {
            get
            {
                return typeof(GridDataCellElement);
            }
        }

        public override bool IsCompatible(GridViewColumn data, object context)
        {
            return context is GridDataRowElement;
        }

    }
}
