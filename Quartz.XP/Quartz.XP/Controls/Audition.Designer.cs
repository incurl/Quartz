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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition4 = new Telerik.WinControls.UI.TableViewDefinition();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.poolGrid = new Telerik.WinControls.UI.RadGridView();
            this.binGrid = new Telerik.WinControls.UI.RadGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.bindingSourceBundle = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.poolGrid)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.poolGrid);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.binGrid);
            this.splitContainer1.Size = new System.Drawing.Size(500, 787);
            this.splitContainer1.SplitterDistance = 396;
            this.splitContainer1.TabIndex = 0;
            // 
            // poolGrid
            // 
            this.poolGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.poolGrid.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.poolGrid.MasterTemplate.ShowColumnHeaders = false;
            this.poolGrid.MasterTemplate.ShowRowHeaderColumn = false;
            this.poolGrid.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.poolGrid.Name = "poolGrid";
            this.poolGrid.Size = new System.Drawing.Size(500, 396);
            this.poolGrid.TabIndex = 0;
            this.poolGrid.Text = "radGridView1";
            // 
            // binGrid
            // 
            this.binGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.binGrid.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.binGrid.MasterTemplate.ShowColumnHeaders = false;
            this.binGrid.MasterTemplate.ShowRowHeaderColumn = false;
            this.binGrid.MasterTemplate.ViewDefinition = tableViewDefinition4;
            this.binGrid.Name = "binGrid";
            this.binGrid.Size = new System.Drawing.Size(500, 387);
            this.binGrid.TabIndex = 0;
            this.binGrid.Text = "radGridView2";
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
            ((System.ComponentModel.ISupportInitialize)(this.poolGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binGrid)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBundle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Telerik.WinControls.UI.RadGridView poolGrid;
        private Telerik.WinControls.UI.RadGridView binGrid;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource bindingSourceBundle;

    }
}
