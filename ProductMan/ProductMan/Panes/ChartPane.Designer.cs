namespace ProductMan.Panes
{
    partial class ChartPane
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
            this.captionPane1 = new ProductMan.Panes.CaptionPane();
            this.chart1 = new ProductMan.Panes.Chart();
            this.SuspendLayout();
            // 
            // captionPane1
            // 
            this.captionPane1.AllowActive = false;
            this.captionPane1.AntiAlias = false;
            this.captionPane1.Caption = "Products Status";
            this.captionPane1.Dock = System.Windows.Forms.DockStyle.Top;
            this.captionPane1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.captionPane1.InactiveGradientHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(200)))), ((int)(((byte)(245)))));
            this.captionPane1.InactiveGradientLowColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(250)))));
            this.captionPane1.InactiveTextColor = System.Drawing.Color.Black;
            this.captionPane1.Location = new System.Drawing.Point(0, 0);
            this.captionPane1.Name = "captionPane1";
            this.captionPane1.Size = new System.Drawing.Size(272, 22);
            this.captionPane1.TabIndex = 0;
            // 
            // chart1
            // 
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Font = new System.Drawing.Font("Arial", 7F);
            this.chart1.Location = new System.Drawing.Point(0, 22);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(272, 212);
            this.chart1.TabIndex = 1;
            // 
            // ChartPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.captionPane1);
            this.Name = "ChartPane";
            this.Size = new System.Drawing.Size(272, 234);
            this.ResumeLayout(false);

        }

        #endregion

        private CaptionPane captionPane1;
        private Chart chart1;
    }
}
