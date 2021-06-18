namespace Quartz.XP.Controls
{
    partial class Qrid
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.grid = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AllowDrop = true;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.grid.MasterTemplate.AllowAddNewRow = false;
            this.grid.MasterTemplate.AllowColumnChooser = false;
            this.grid.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.grid.MasterTemplate.AllowColumnReorder = false;
            this.grid.MasterTemplate.AllowColumnResize = false;
            this.grid.MasterTemplate.AllowDeleteRow = false;
            this.grid.MasterTemplate.AllowDragToGroup = false;
            this.grid.MasterTemplate.EnableGrouping = false;
            this.grid.MasterTemplate.EnableSorting = false;
            this.grid.MasterTemplate.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
            this.grid.MasterTemplate.ShowColumnHeaders = false;
            this.grid.MasterTemplate.ShowFilteringRow = false;
            this.grid.MasterTemplate.ShowRowHeaderColumn = false;
            this.grid.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grid.Name = "grid";
            // 
            // 
            // 
            this.grid.RootElement.AutoSize = true;
            this.grid.ShowGroupPanel = false;
            this.grid.ShowGroupPanelScrollbars = false;
            this.grid.Size = new System.Drawing.Size(528, 359);
            this.grid.TabIndex = 1;
            this.grid.Text = "radGridView1";
            this.grid.CreateCell += new Telerik.WinControls.UI.GridViewCreateCellEventHandler(this.grid_CreateCell);
            this.grid.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.grid_RowFormatting);
            this.grid.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.grid_CellFormatting);
            this.grid.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grid_CellClick);
            // 
            // Qrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grid);
            this.Name = "Qrid";
            this.Size = new System.Drawing.Size(528, 359);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grid;
    }
}
