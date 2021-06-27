namespace Quartz.XP.Controls
{
    partial class Audition
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
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.waitingGrid = new Telerik.WinControls.UI.RadGridView();
            this.binGrid = new Telerik.WinControls.UI.RadGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.bindingSourceBundle = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waitingGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binGrid)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBundle)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(3, 30);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.waitingGrid);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.binGrid);
            this.splitContainer1.Size = new System.Drawing.Size(500, 787);
            this.splitContainer1.SplitterDistance = 396;
            this.splitContainer1.TabIndex = 0;
            // 
            // waitingGrid
            // 
            this.waitingGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.waitingGrid.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.waitingGrid.MasterTemplate.AllowAddNewRow = false;
            this.waitingGrid.MasterTemplate.ShowColumnHeaders = false;
            this.waitingGrid.MasterTemplate.ShowRowHeaderColumn = false;
            this.waitingGrid.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.waitingGrid.Name = "waitingGrid";
            this.waitingGrid.ShowGroupPanel = false;
            this.waitingGrid.Size = new System.Drawing.Size(500, 396);
            this.waitingGrid.TabIndex = 0;
            this.waitingGrid.Text = "radGridView1";
            this.waitingGrid.CreateCell += new Telerik.WinControls.UI.GridViewCreateCellEventHandler(this.waitingGrid_CreateCell);
            this.waitingGrid.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.waitingGrid_CellFormatting);
            this.waitingGrid.CellBeginEdit += new Telerik.WinControls.UI.GridViewCellCancelEventHandler(this.waitingGrid_CellBeginEdit);
            this.waitingGrid.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grid_CellClick);
            this.waitingGrid.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grid_CellDoubleClick);
            // 
            // binGrid
            // 
            this.binGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.binGrid.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.binGrid.MasterTemplate.AllowAddNewRow = false;
            this.binGrid.MasterTemplate.ShowColumnHeaders = false;
            this.binGrid.MasterTemplate.ShowRowHeaderColumn = false;
            this.binGrid.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.binGrid.Name = "binGrid";
            this.binGrid.ShowGroupPanel = false;
            this.binGrid.Size = new System.Drawing.Size(500, 387);
            this.binGrid.TabIndex = 0;
            this.binGrid.Text = "radGridView2";
            this.binGrid.CreateCell += new Telerik.WinControls.UI.GridViewCreateCellEventHandler(this.binGrid_CreateCell);
            this.binGrid.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.binGrid_CellFormatting);
            this.binGrid.CellBeginEdit += new Telerik.WinControls.UI.GridViewCellCancelEventHandler(this.binGrid_CellBeginEdit);
            this.binGrid.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grid_CellClick);
            this.binGrid.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grid_CellDoubleClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.comboBox1);
            this.flowLayoutPanel1.Controls.Add(this.splitContainer1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(500, 787);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bundle";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.bindingSourceBundle;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(49, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(406, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // Audition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Audition";
            this.Size = new System.Drawing.Size(500, 787);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.waitingGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binGrid)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBundle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Telerik.WinControls.UI.RadGridView waitingGrid;
        private Telerik.WinControls.UI.RadGridView binGrid;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource bindingSourceBundle;

    }
}
