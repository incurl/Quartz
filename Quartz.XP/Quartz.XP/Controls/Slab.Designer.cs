namespace Quartz.XP.Controls
{
    partial class Slab
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
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.tbPoet = new System.Windows.Forms.TextBox();
            this.tbText = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.tbTitle);
            this.flowLayoutPanel2.Controls.Add(this.tbPoet);
            this.flowLayoutPanel2.Controls.Add(this.tbText);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(528, 394);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(3, 3);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.ReadOnly = true;
            this.tbTitle.Size = new System.Drawing.Size(525, 20);
            this.tbTitle.TabIndex = 0;
            // 
            // tbPoet
            // 
            this.tbPoet.Location = new System.Drawing.Point(3, 29);
            this.tbPoet.Name = "tbPoet";
            this.tbPoet.ReadOnly = true;
            this.tbPoet.Size = new System.Drawing.Size(525, 20);
            this.tbPoet.TabIndex = 1;
            // 
            // tbText
            // 
            this.tbText.Location = new System.Drawing.Point(3, 55);
            this.tbText.Multiline = true;
            this.tbText.Name = "tbText";
            this.tbText.ReadOnly = true;
            this.tbText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbText.Size = new System.Drawing.Size(525, 333);
            this.tbText.TabIndex = 2;
            // 
            // Slab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel2);
            this.Name = "Slab";
            this.Size = new System.Drawing.Size(528, 394);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.TextBox tbPoet;
        private System.Windows.Forms.TextBox tbText;

    }
}
